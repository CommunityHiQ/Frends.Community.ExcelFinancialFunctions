#pragma warning disable 1591

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Community.ExcelFinancialFunctions
{
    /// <summary>
    /// Contains execution parameters
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// JArray string with value and date
        /// </summary>
        /// <example>
        /// [{value: 1.234, date: "2021-05-25"}, {value: 2.345, date: "2022-05-25"}]
        /// </example>
        [DisplayFormat(DataFormatString = "Text")]
        public string Input { get; set; }
    }

    /// <summary>
    /// Options class provides additional optional parameters.
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Tolerance that will be used in calculations.
        /// </summary>
        [DefaultValue(0.00000001)]
        public double Tolerance { get; set; }

        /// <summary>
        /// Max number of iterations(to prevent infinite looping).
        /// </summary>
        [DefaultValue(100)]
        public int MaxIterations { get; set; }
    }

    public class Result
    {
        /// <summary>
        /// Calculated XIrr value.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Value;
    }
}