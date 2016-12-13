// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace SFA.DAS.RAA.Api.Client.V1.Models
{
    using System.Linq;

    public partial class Wage
    {
        /// <summary>
        /// Initializes a new instance of the Wage class.
        /// </summary>
        public Wage() { }

        /// <summary>
        /// Initializes a new instance of the Wage class.
        /// </summary>
        /// <param name="type">Possible values include: 'LegacyText',
        /// 'LegacyWeekly', 'ApprenticeshipMinimum', 'NationalMinimum',
        /// 'Custom', 'CustomRange', 'CompetitiveSalary',
        /// 'ToBeAgreedUponAppointment', 'Unwaged'</param>
        /// <param name="unit">Possible values include: 'NotApplicable',
        /// 'Weekly', 'Monthly', 'Annually'</param>
        public Wage(string type = default(string), string reasonForType = default(string), decimal? amount = default(decimal?), decimal? amountLowerBound = default(decimal?), decimal? amountUpperBound = default(decimal?), string text = default(string), string unit = default(string), decimal? hoursPerWeek = default(decimal?))
        {
            Type = type;
            ReasonForType = reasonForType;
            Amount = amount;
            AmountLowerBound = amountLowerBound;
            AmountUpperBound = amountUpperBound;
            Text = text;
            Unit = unit;
            HoursPerWeek = hoursPerWeek;
        }

        /// <summary>
        /// Gets possible values include: 'LegacyText', 'LegacyWeekly',
        /// 'ApprenticeshipMinimum', 'NationalMinimum', 'Custom',
        /// 'CustomRange', 'CompetitiveSalary', 'ToBeAgreedUponAppointment',
        /// 'Unwaged'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Type")]
        public string Type { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ReasonForType")]
        public string ReasonForType { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Amount")]
        public decimal? Amount { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "AmountLowerBound")]
        public decimal? AmountLowerBound { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "AmountUpperBound")]
        public decimal? AmountUpperBound { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Text")]
        public string Text { get; private set; }

        /// <summary>
        /// Gets possible values include: 'NotApplicable', 'Weekly',
        /// 'Monthly', 'Annually'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "Unit")]
        public string Unit { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "HoursPerWeek")]
        public decimal? HoursPerWeek { get; private set; }

    }
}
