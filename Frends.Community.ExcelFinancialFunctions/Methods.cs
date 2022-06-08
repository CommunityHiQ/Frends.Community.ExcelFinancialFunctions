using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Frends.Community.ExcelFinancialFunctions
{
    internal class Methods
    {
        public delegate double fx(double x);

        public static fx composeFunctions(fx f1, fx f2)
        {
            return (double x) => f1(x) + f2(x);
        }

        public static fx f_xirr(double p, double dt, double dt0)
        {
            return (double x) => p * Math.Pow((1.0 + x), ((dt0 - dt) / 365.0));
        }

        public static fx df_xirr(double p, double dt, double dt0)
        {
            return (double x) => (1.0 / 365.0) * (dt0 - dt) * p * Math.Pow((x + 1.0), (((dt0 - dt) / 365.0) - 1.0));
        }

        public static fx total_f_xirr(double[] payments, double[] days)
        {
            fx resf = (double x) => 0.0;

            for (int i = 0; i < payments.Length; i++)
            {
                resf = composeFunctions(resf, f_xirr(payments[i], days[i], days[0]));
            }

            return resf;
        }

        public static fx total_df_xirr(double[] payments, double[] days)
        {
            fx resf = (double x) => 0.0;

            for (int i = 0; i < payments.Length; i++)
            {
                resf = composeFunctions(resf, df_xirr(payments[i], days[i], days[0]));
            }

            return resf;
        }


        /// <summary>
        /// Calculates XIrr using Newton's method
        /// </summary>
        /// <param name="cancellationToken"></param>
        public static double Newtons_method(double guess, fx f, fx df, double tol, int maxIterations, CancellationToken cancellationToken)
        {
            int i = 0;
            double x0 = guess;
            double x1 = 0.0;
            double err = 1e+100;

            while (err > tol && ++i < maxIterations)
            {
                cancellationToken.ThrowIfCancellationRequested();
                x1 = x0 - f(x0) / df(x0);
                err = Math.Abs(x1 - x0);
                x0 = x1;
            }
            if (i == maxIterations)
            {
                throw new InvalidOperationException("Could not calculate: No solution found. Max iterations reached.");
            }

            return x0;
        }

        public static double[] getPaymentsFromJArray(JArray jarray)
        {
            return jarray.Select(x => double.Parse(x["value"].ToString())).ToList().ToArray();
        }

        public static double[] getDaysFromJArray(JArray jarray)
        {
            return jarray.Select(x => (double)DateTime.Parse(x["date"].ToString()).DayOfYear).ToList().ToArray();
        }
    }
}
