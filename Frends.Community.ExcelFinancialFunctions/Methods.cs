using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Frends.Community.ExcelFinancialFunctions
{
    internal class Methods
    {
        /// <summary>
        /// Calculates XIrr using ExcelFinancialFunctions .NET Standard library
        /// </summary>
        /// <param name="cancellationToken"></param>
        public static List<double> getPaymentsFromJArray(JArray jarray, CancellationToken cancellationToken)
        {
            var values = new List<double>();

            foreach (var item in jarray)
            {
                cancellationToken.ThrowIfCancellationRequested();

                double value = double.Parse(item["value"].ToString());
                values.Add(value);
            }

            return values;
        }

        public static List<DateTime> getDatesFromJArray(JArray jarray, CancellationToken cancellationToken)
        {
            var dates = new List<DateTime>();

            foreach (var item in jarray)
            {
                cancellationToken.ThrowIfCancellationRequested();

                DateTime date = DateTime.Parse(item["date"].ToString());
                dates.Add(date);
            }

            return dates;
        }
    }
}
