﻿namespace SFA.Apprenticeships.Infrastructure.Postcode
{
    using System;
    using System.Linq;
    using Application.Location;
    using Configuration;
    using Domain.Entities.Raa.Locations;
    using Rest;
    using SFA.Infrastructure.Interfaces;

    public class GeoCodeLookupProvider : RestService, IGeoCodeLookupProvider
    {
        private readonly ILogService _logService;
        private GeoCodingServiceConfiguration Config { get; }

        public GeoCodeLookupProvider(IConfigurationService configurationService, ILogService logService)
        {
            _logService = logService;
            Config = configurationService.Get<GeoCodingServiceConfiguration>();
            BaseUrl = new Uri(Config.GeoCodingEndpoint);
        }

        public GeoPoint GetGeoCodingFor(PostalAddress address)
        {
            _logService.Debug("Calling GeoCodeLookupProvider to geocode address {0}", address.ToString());

            var geoPoint = GetGeoPointFor(address.Postcode);

            if (!geoPoint.IsValid())
            {
                geoPoint = GetGeoPointFor(GetServiceAddressFrom(address));
            }

            return geoPoint;
        }

        private string GetServiceAddressFrom(PostalAddress address)
        {
            // Clerkenwell Close, London -> returns values
            // 31 Clerkenwell Close, London -> doesn't return values
            // 31, Clerkenwell Close, London -> return values

            var addressLine1Splitted = address.AddressLine1.Split(' ');
            int number;
            var startsWithNumber = int.TryParse(addressLine1Splitted.First(), out number);

            var addressLine1 = startsWithNumber
                ? $"{number},{string.Join(" ", addressLine1Splitted.Skip(1))}"
                : address.AddressLine1;

            var addressLines = new[]
                {addressLine1, address.AddressLine2, address.AddressLine3, address.AddressLine4, address.AddressLine5};

            return string.Join(",", addressLines.Where(l => !string.IsNullOrWhiteSpace(l))); 
        }

        private GeoPoint GetGeoPointFor(string addressOrPostCode)
        {
            //Build the url
            var url = "http://services.postcodeanywhere.co.uk/Geocoding/UK/Geocode/v2.00/dataset.ws?";
            url += "&Key=" + System.Web.HttpUtility.UrlEncode(Config.Key);
            url += "&Location=" + System.Web.HttpUtility.UrlEncode(addressOrPostCode);

            //Create the dataset
            var dataSet = new System.Data.DataSet();
            dataSet.ReadXml(url);

            //Check for an error
            if (dataSet.Tables.Count == 1 && dataSet.Tables[0].Columns.Count == 4 &&
                dataSet.Tables[0].Columns[0].ColumnName == "Error")
            {
                _logService.Error("An error has occurred accessing GeoCode service for location {0}: {1}",
                    addressOrPostCode, dataSet.Tables[0].Rows[0].ItemArray[1].ToString());

                return GeoPoint.Invalid;
            }

            //Return the dataset
            // return dataSet;

            //FYI: The dataset contains the following columns:
            //Location
            //Easting
            //Northing
            //Latitude
            //Longitude
            //OsGrid
            //Accuracy

            return new GeoPoint
            {
                Easting = int.Parse(dataSet.Tables[0].Rows[0].ItemArray[1].ToString()),
                Northing = int.Parse(dataSet.Tables[0].Rows[0].ItemArray[2].ToString()),
                Latitude = double.Parse(dataSet.Tables[0].Rows[0].ItemArray[3].ToString()),
                Longitude = double.Parse(dataSet.Tables[0].Rows[0].ItemArray[4].ToString()),
            };
        }
    }
}