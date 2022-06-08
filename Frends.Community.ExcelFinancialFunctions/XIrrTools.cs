using System.ComponentModel;
using System.Threading;
using Microsoft.CSharp; // You can remove this if you don't need dynamic type in .NET Standard frends Tasks
using Newtonsoft.Json.Linq;

#pragma warning disable 1591

namespace Frends.Community.ExcelFinancialFunctions
{
    public static class XIrrTools
    {
        /// <summary>
        /// A Frends-task for calculating XIrr value. More info in 
        /// Documentation: https://github.com/CommunityHiQ/Frends.Community.ExcelFinancialFunctions
        /// </summary>
        /// <param name="input">Values and dates for calculations</param>
        /// <param name="options">Define tollerance and max iterations.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Object {string Value} </returns>
        public static Result CalculateXIrr([PropertyTab] Parameters input, [PropertyTab] Options options, CancellationToken cancellationToken)
        {
            JArray jarray = JArray.Parse(input.Input);

            int maxIter = options.MaxIterations;
            double tol = options.Tolerance;

            double[] payments = Methods.getPaymentsFromJArray(jarray); // payments
            double[] days = Methods.getDaysFromJArray(jarray); // days of payment (as day of year)
            double xirr = Methods.Newtons_method(0.1, 
                Methods.total_f_xirr(payments, days), 
                Methods.total_df_xirr(payments, days), 
                tol, 
                maxIter, 
                cancellationToken);


            var output = new Result
            {
                Value = xirr.ToString()
            };

            return output;
        }
    }
}
