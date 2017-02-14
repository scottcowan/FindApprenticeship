namespace SFA.Apprenticeships.Domain.Entities.Vacancies
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Object containing all the wage information for a vacancy
    /// </summary>
    public class Wage
    {
        public Wage()
        {
            
        }

        [JsonConstructor]
        public Wage(WageType type, decimal? amount, decimal? amountLowerBound, decimal? amountUpperBound, string text, WageUnit unit, decimal? hoursPerWeek, string reasonForType)
        {
            Type = type;
            Amount = amount;
            AmountLowerBound = amountLowerBound;
            AmountUpperBound = amountUpperBound;
            ReasonForType = reasonForType;
            Text = text;
            HoursPerWeek = hoursPerWeek;
            Unit = CorrectWageUnit(type, unit);
        }

        /// <summary>
        /// The basic type of the wage. Defines which additional properties will be set
        /// </summary>
        public WageType Type { get; set; }

        public string ReasonForType { get; set; }

        public decimal? Amount { get; set; }

        public decimal? AmountLowerBound { get; set; }

        public decimal? AmountUpperBound { get; set; }

        public string Text { get; set; }

        public WageUnit Unit { get; set; }

        public decimal? HoursPerWeek { get; set; }

        private static WageUnit CorrectWageUnit(WageType type, WageUnit unit)
        {
            switch (type)
            {
                case WageType.CustomRange:
                    if (unit == WageUnit.NotApplicable)
                        return WageUnit.Weekly;
                    return unit;

                case WageType.LegacyText:
                case WageType.CompetitiveSalary:
                case WageType.ToBeAgreedUponAppointment:
                case WageType.Unwaged:
                    return WageUnit.NotApplicable;

                case WageType.Custom:
                    switch (unit)
                    {
                        case WageUnit.Weekly:
                        case WageUnit.Monthly:
                        case WageUnit.Annually:
                        case WageUnit.NotApplicable:
                            return unit;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(WageUnit), $"Invalid Wage Unit: {unit}");
                    }

                case WageType.LegacyWeekly:
                default:
                    return WageUnit.Weekly;
            }
        }

        protected bool Equals(Wage other)
        {
            return Type == other.Type && string.Equals(ReasonForType, other.ReasonForType) && Amount == other.Amount && AmountLowerBound == other.AmountLowerBound && AmountUpperBound == other.AmountUpperBound && string.Equals(Text, other.Text) && Unit == other.Unit && HoursPerWeek == other.HoursPerWeek;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Wage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Type;
                hashCode = (hashCode * 397) ^ (ReasonForType != null ? ReasonForType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Amount.GetHashCode();
                hashCode = (hashCode * 397) ^ AmountLowerBound.GetHashCode();
                hashCode = (hashCode * 397) ^ AmountUpperBound.GetHashCode();
                hashCode = (hashCode * 397) ^ (Text != null ? Text.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Unit;
                hashCode = (hashCode * 397) ^ HoursPerWeek.GetHashCode();
                return hashCode;
            }
        }
    }
}
