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
        /// Guess is a number that you guess is close to the result of XIRR.
        /// </summary>
        [DefaultValue(0.1)]
        public double Guess { get; set; }

        /// <summary>
        /// If set, allows you to ignore errors and return specified value.
        /// If not set, error will be thrown normally.
        /// </summary>
        [DefaultValue(false)]
        public bool ReturnValueOnError { get; set; }

        /// <summary>
        /// What task should return on failure (string)
        /// </summary>
        [UIHint(nameof(ReturnValueOnError), "", true)]
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("NM")]
        public string ReturnValue { get; set; }
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