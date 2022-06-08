using NUnit.Framework;
using System;

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

            Assert.That(ret.Value, Is.EqualTo("77.4425237947709"));
        }
    }
}
