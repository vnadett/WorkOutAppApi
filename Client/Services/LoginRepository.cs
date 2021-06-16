using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkOutAppApi.Client.Contracts;
using WorkOutAppApi.Shared.Models;

namespace WorkOutAppApi.Client.Services
{
    public class LoginRepository : BaseRepository<LoginUser>, ILoginRepository
    {
        HttpClient _client;
        public LoginRepository(HttpClient client) : base(client)
        {
            client = _client;
        }


    }
}
