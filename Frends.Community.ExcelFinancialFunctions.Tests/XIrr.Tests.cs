using NUnit.Framework;
using System;
using System.Globalization;

namespace Frends.Community.ExcelFinancialFunctions.Tests
{
    [TestFixture]
    class TestClass
    {
        /// <summary>
        /// You need to run Frends.Community.ExcelFinancialFunctions.SetPaswordsEnv.ps1 before running unit test, or some other way set environment variables e.g. with GitHub Secrets.
        /// </summary>
        [Test]
        public void ThreeXIrrToolss()
        {
            var input = new Parameters
            {
                Input = @"[
                            {
                                'value': -6800,
                                'date': '2022-01-01'
                            },
                            {
                                'value': 1000,
                                'date': '2022-01-02'
                            },
                            {
                                'value': 2000,
                                'date': '2022-01-03'
                            },
                            {
                                'value': 4000,
                                'date': '2022-01-04'
                            }
                        ]"
            };

            var options = new Options
            {
                Tolerance = 0.00000001,
                MaxIterations = 100
            };

            var ret = XIrrTools.CalculateXIrr(input, options, new System.Threading.CancellationToken());
            string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            double val =double.Parse($"77{decimalSeparator}44252379477088");
           
            Assert.That(Math.Round(val,13), Is.EqualTo(77.4425237947709));
        }
    }
}
