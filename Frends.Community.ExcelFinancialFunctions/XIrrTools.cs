using System.ComponentModel;
using System.Threading;
using Newtonsoft.Json.Linq;
using Excel.FinancialFunctions;
using System.Collections.Generic;
using System;

#pragma warning disable 1591

namespace Frends.Community.ExcelFinancialFunctions
{
    public static class XIrrTools
    {
        /// <summary>
        /// A Frends-task for calculating XIrr value. See documentation for more information. 
        /// Documentation: https://github.com/CommunityHiQ/Frends.Community.ExcelFinancialFunctions
        /// </summary>
        /// <param name="input">Values and dates for calculations</param>
        /// <param name="options">Define guess and error value.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Object {string Value} </returns>
        public static Result CalculateXIrr([PropertyTab] Parameters input, [PropertyTab] Options options, CancellationToken cancellationToken)
        {
            JArray jarray = JArray.Parse(input.Input);

            double guess = options.Guess;

            List<double> payments = Methods.getPaymentsFromJArray(jarray, cancellationToken); // payments
            List<DateTime> dates = Methods.getDatesFromJArray(jarray, cancellationToken); // dates of payment

            string xirr;

            if (options.ReturnValueOnError)
            {
                try
                {
                    xirr = Financial.XIrr(payments, dates, guess).ToString();
                }
                catch (Exception)
                {
                    xirr = options.ReturnValue.ToString();
                }
            }
            else
            {
                xirr = Financial.XIrr(payments, dates, guess).ToString();
            }
            
            var output = new Result
            {
                Value = xirr.ToString()
            };

            return output;
        }
    }
}
