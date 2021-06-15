using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkOutAppApi.Shared.Models;

namespace WorkOutAppApi.Client.Services
{
    public class IAuthenticationStateProvider : AuthenticationStateProvider
    {
        public ILocalStorageService _localStorageService { get; }
        public IAuthenticationService _authenticationService { get; set; }

        private readonly HttpClient _httpClient;
        public IAuthenticationStateProvider(ILocalStorageService localStorageService,
          IAuthenticationService authenticationService,
          HttpClient httpClient)
        {
            //throw new Exception("IAuthenticationStateProviderException");
            this._localStorageService = localStorageService;
            _authenticationService = authenticationService;
            _httpClient = httpClient;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
