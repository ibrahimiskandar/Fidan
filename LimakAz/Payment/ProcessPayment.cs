using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimakAz.Models.Payment;
using Stripe;

namespace LimakAz.Payment
{
    public class ProcessPayment
    {
        public static async Task<dynamic> PayAsync(PayModel payModel)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51LaXLzA33b1cDRQHiUNbX0osZTsOJjMqYYP7Kgruv4Qm6xQrAEuIyGW7kSDYwNIeijxGWYwU7aKpfH4rpzdlv42C001KcyBAOW";

                var options = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = payModel.CardNumder,
                        ExpMonth = payModel.Month.ToString(),
                        ExpYear = payModel.Year.ToString(),
                        Cvc = payModel.CVC
                    },
                };

                var serviceToken = new TokenService();
                Token stripeToken = await serviceToken.CreateAsync(options);

                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = payModel.Amount,
                    Currency = "usd",
                    Description = "Stripe Test Payment",
                    Source = stripeToken.Id
                };

                var chargeService = new ChargeService();
                Charge charge = await chargeService.CreateAsync(chargeOptions);

                if (charge.Paid)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}