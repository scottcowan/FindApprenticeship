﻿namespace SFA.Apprenticeship.Api.AvmsCompatability.DataContracts.Version51
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Common;

    [DataContract(Namespace=CommonNamespaces.ExternalInterfacesRel51)]
    public class VacancyUploadResultData
    {
        [DataMember(IsRequired = true, Order = 1 )]
        public Guid VacancyId { get; set; }

        [DataMember( IsRequired = true, Order = 2 )]
        public VacancyUploadResult Status { get; set; }

        [DataMember( IsRequired = true, Order = 3 )]
        public List<ElementErrorData> ErrorCodes { get; set; }

        /// <summary>
        /// Vacancy reference number, valid only when Status is ok
        /// </summary>
        [DataMember( IsRequired = false, Order = 4 )]
        public int ReferenceNumber { get; set; }
    }
}