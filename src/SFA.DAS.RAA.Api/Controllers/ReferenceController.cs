namespace SFA.DAS.RAA.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Apprenticeships.Application.ReferenceData;
    using Apprenticeships.Domain.Entities.Raa.Reference;
    using Constants;
    using Strategies;

    [RoutePrefix("reference")]
    public class ReferenceController : ApiController
    {
        private readonly IReferenceDataProvider _referenceDataProvider;
        private readonly IGetCountiesStrategy _getCountiesStrategy;

        public ReferenceController(IReferenceDataProvider referenceDataProvider, IGetCountiesStrategy getCountiesStrategy)
        {
            _referenceDataProvider = referenceDataProvider;
            _getCountiesStrategy = getCountiesStrategy;
        }

        /// <summary>
        /// Retrieves all county information for all counties
        /// </summary>
        /// <returns>The full list of counties</returns>
        [Route("counties")]
        [ResponseType(typeof(IEnumerable<County>))]
        [HttpGet]
        public IHttpActionResult GetCounties()
        {
            return Ok(_getCountiesStrategy.GetCounties());
        }

        /// <summary>
        /// Returns the information for the county identified by the primary identifier in the URL
        /// </summary>
        /// <param name="id">The county's primary identifier</param>
        /// <returns>The county object</returns>
        [Route("county/{id}")]
        [ResponseType(typeof(County))]
        [HttpGet]
        public IHttpActionResult GetCounty(int id)
        {
            return Ok(_getCountiesStrategy.GetCounty(id));
        }

        /// <summary>
        /// Returns the information for the county identified by the county's code in the URL
        /// </summary>
        /// <param name="code">The county's code</param>
        /// <returns>The county object</returns>
        [Route("county/code/{code}")]
        [ResponseType(typeof(County))]
        [HttpGet]
        public IHttpActionResult GetCounty(string code)
        {
            return Ok(_getCountiesStrategy.GetCounty(countyCode: code));
        }

        [Route("localauthorities")]
        [ResponseType(typeof(IEnumerable<LocalAuthority>))]
        [HttpGet]
        public IHttpActionResult GetLocalAuthorities()
        {
            return Ok(_referenceDataProvider.GetLocalAuthorities());
        }

        [Route("localauthority")]
        [ResponseType(typeof(LocalAuthority))]
        [HttpGet]
        public IHttpActionResult GetLocalAuthority(int? localAuthorityId = null, string localAuthorityCode = null)
        {
            if (!localAuthorityId.HasValue && string.IsNullOrEmpty(localAuthorityCode))
            {
                throw new ArgumentException(ReferenceMessages.MissingLocalAuthorityIdentifier);
            }

            var localAuthority = localAuthorityId.HasValue ? _referenceDataProvider.GetLocalAuthorityById(localAuthorityId.Value) : _referenceDataProvider.GetLocalAuthorityByCode(localAuthorityCode);

            if (localAuthority == null)
            {
                throw new KeyNotFoundException(ReferenceMessages.LocalAuthorityNotFound);
            }

            return Ok(localAuthority);
        }

        [Route("regions")]
        [ResponseType(typeof(IEnumerable<Region>))]
        [HttpGet]
        public IHttpActionResult GetRegions()
        {
            return Ok(_referenceDataProvider.GetRegions());
        }

        [Route("region")]
        [ResponseType(typeof(Region))]
        [HttpGet]
        public IHttpActionResult GetRegion(int? regionId = null, string regionCode = null)
        {
            if (!regionId.HasValue && string.IsNullOrEmpty(regionCode))
            {
                throw new ArgumentException(ReferenceMessages.MissingRegionIdentifier);
            }

            var region = regionId.HasValue ? _referenceDataProvider.GetRegionById(regionId.Value) : _referenceDataProvider.GetRegionByCode(regionCode);

            if (region == null)
            {
                throw new KeyNotFoundException(ReferenceMessages.RegionNotFound);
            }

            return Ok(region);
        }
    }
}