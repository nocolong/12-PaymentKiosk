﻿using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentKiosk.Core.Service
{
    public class MoneyService
    {
        private const string StripeApiKey = "sk_test_2BeAGHH8kh6ip8Eyqo2kfDex";

        public static bool Charge(Customer customer, CreditCard creditCard, decimal amount)
        {
            var chargeDetails = new StripeChargeCreateOptions();

            chargeDetails.Amount = (int)amount * 100;
            chargeDetails.Currency = "usd";

            chargeDetails.Source = new StripeSourceOptions
            {
                Object = "card",
                Number = creditCard.CardNumber,
                ExpirationMonth = creditCard.ExpiryDate.Month.ToString(),
                ExpirationYear = creditCard.ExpiryDate.Year.ToString(),
                Cvc = creditCard.Cvc
            };

            var chargeService = new StripeChargeService(StripeApiKey);
            var response = chargeService.Create(chargeDetails);

            if(response.Paid == false)
            {
                throw new Exception(response.FailureMessage);
            }

            return response.Paid;


        }
    }
}
