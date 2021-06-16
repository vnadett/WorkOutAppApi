using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WorkOutAppApi.Client.Contracts;
using WorkOutAppApi.Shared.Models;

namespace WorkOutAppApi.Client.Services
{
    public class RegistrationRepository : BaseRepository<RegisterModel>, IRegistrationRepository
    {
        HttpClient _client;
        public RegistrationRepository(HttpClient client) : base(client)
        {
            client = _client;
        }
    }
}
