﻿namespace SFA.Apprenticeships.Web.Raa.Common.ViewModels.VacancyPosting
{
    using FluentValidation.Attributes;
    using Validators.VacancyPosting;
    using Web.Common.ViewModels.Locations;

    [Validator(typeof(VacancyLocationAddressViewModelClientValidator))]
    public class VacancyLocationAddressViewModel
    {
        public VacancyLocationAddressViewModel()
        {
            Address = new AddressViewModel();
        }

        public int VacancyLocationId { get; set; }

        public AddressViewModel Address { get; set; }

        public int? NumberOfPositions { get; set; }

        public string OfflineApplicationUrl { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as VacancyLocationAddressViewModel);
        }

        protected bool Equals(VacancyLocationAddressViewModel other)
        {
            if (other == null) return false;

            return Equals(Address, other.Address) && NumberOfPositions == other.NumberOfPositions;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Address != null ? Address.GetHashCode() : 0)*397) ^ NumberOfPositions.GetHashCode();
            }
        }
    }
}