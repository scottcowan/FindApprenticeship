﻿namespace SFA.Apprenticeships.Web.Employer.Tests.Builders
{
    using ViewModels;

    public class AddressViewModelBuilder
    {
        private string _addressLine1;
        private string _addressLine2;
        private string _addressLine3;
        private string _city;
        private string _postcode;

        public AddressViewModelBuilder AddressLine2(string addressLine2)
        {
            _addressLine2 = addressLine2;
        }

        public AddressViewModelBuilder AddressLine3(string addressLine3)
        {
            _addressLine3 = addressLine3;
        }

        public AddressViewModelBuilder City(string city)
        {
            _city = city;
        }

        public AddressViewModelBuilder Postcode(string postcode)
        {
            _postcode = postcode;
        }

        public AddressViewModelBuilder AddressLine1(string addressLine1)
        {
            _addressLine1 = addressLine1;
        }

        public AddressViewModel Build()
        {
            var model = new AddressViewModel()
            {
                AddressLine1 = _addressLine1,
                AddressLine2 = _addressLine2,
                AddressLine3 = _addressLine3,
                City = _city,
                Postcode = _postcode
            };

            return model;
        } 
    }
}