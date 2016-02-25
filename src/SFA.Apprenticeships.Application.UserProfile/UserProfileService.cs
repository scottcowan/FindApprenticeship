﻿namespace SFA.Apprenticeships.Application.UserProfile
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Entities.Raa.Users;
    using Domain.Raa.Interfaces.Repositories;
    using Interfaces.Users;

    public class UserProfileService : IUserProfileService
    {
        private readonly IProviderUserReadRepository _providerUserReadRepository;
        private readonly IProviderUserWriteRepository _providerUserWriteRepository;
        private readonly IAgencyUserReadRepository _agencyUserReadRepository;
        private readonly IAgencyUserWriteRepository _agencyUserWriteRepository;

        public UserProfileService(IProviderUserReadRepository providerUserReadRepository, IProviderUserWriteRepository providerUserWriteRepository, IAgencyUserReadRepository agencyUserReadRepository, IAgencyUserWriteRepository agencyUserWriteRepository)
        {
            _providerUserReadRepository = providerUserReadRepository;
            _providerUserWriteRepository = providerUserWriteRepository;
            _agencyUserReadRepository = agencyUserReadRepository;
            _agencyUserWriteRepository = agencyUserWriteRepository;
        }

        public ProviderUser GetProviderUser(int providerUserId)
        {
            return _providerUserReadRepository.Get(providerUserId);
        }

        public ProviderUser GetProviderUser(string username)
        {
            return _providerUserReadRepository.Get(username);
        }

        public IEnumerable<ProviderUser> GetProviderUsers(string ukprn)
        {
            return _providerUserReadRepository.GetForProvider(ukprn);
        }

        public ProviderUser CreateUser(ProviderUser providerUser)
        {
            //Check if email is being updated and set pending, verification code, send email etc
            return _providerUserWriteRepository.Create(providerUser);
        }

        public ProviderUser UpdateUser(ProviderUser providerUser)
        {
            //Check if email is being updated and set pending, verification code, send email etc
            return _providerUserWriteRepository.Update(providerUser);
        }

        public AgencyUser GetAgencyUser(string username)
        {
            return _agencyUserReadRepository.Get(username);
        }

        public AgencyUser SaveUser(AgencyUser agencyUser)
        {
            return _agencyUserWriteRepository.Save(agencyUser);
        }

        public IEnumerable<Team> GetTeams()
        {
            //TODO: Get these from config or a repo once the design and full list has been agreed
            return new List<Team>
            {
                GetTeam("All", "All", true)
            };
        }

        private static Team GetTeam(string id, string name, bool isDefault = false)
        {
            return new Team
            {
                Id = id,
                Name = name,
                IsDefault = isDefault
            };
        }

        public IEnumerable<Role> GetRoles(string roleList)
        {
            //TODO: Get these from config or a repo once the design and full list has been agreed
            const string technicalAdvisor = "Technical_advisor";

            var roles = new List<Role>
            {
                GetRole("Helpdesk_advisor", "Helpdesk adviser"),
                GetRole("QA_advisor", "Vacancy reviewer", true)
                //GetRole(technicalAdvisor, "Technical adviser")
            };

            return roleList == "Serco" ? roles.Where(r => r.Id != technicalAdvisor) : roles;
        }

        private static Role GetRole(string id, string name, bool isDefault = false)
        {
            return new Role
            {
                Id = id,
                Name = name,
                IsDefault = isDefault
            };
        }
    }
}
