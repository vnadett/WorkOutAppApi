using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WorkOutAppApi.Shared.Models;
using WorkOutAppApi.Client.Helpers;
using Newtonsoft.Json;

namespace WorkOutAppApi.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LoginUser> LoginAsync(LoginUser user)
        {
            try
            {
                user.Password = Utility.Encrypt(user.Password);
                string serializedUser = JsonConvert.SerializeObject(user, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "api/Login/Login");
                requestMessage.Content = new StringContent(serializedUser);

                requestMessage.Content.Headers.ContentType
                    = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.SendAsync(requestMessage);

                var responseStatusCode = response.StatusCode;
                var responseBody = await response.Content.ReadAsStringAsync();

                var returnedUser = JsonConvert.DeserializeObject<LoginUser>(responseBody);

                return await Task.FromResult(returnedUser);
            }
            catch (Exception ex)
            {
                LoginUser u = new LoginUser();
                u.UserName = user.UserName;
                u.Error = ex.ToString();

                return await Task.FromResult(u);
            }
        }

        public async Task<RegisterModel> RegisterUserAsync(RegisterModel user)
        {
            try
            {
                user.Password = Utility.Encrypt(user.Password);
                string serializedUser = JsonConvert.SerializeObject(user, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "api/Felhasznalo/Regisztracio"); // api/Applications/RegisterUser
                requestMessage.Content = new StringContent(serializedUser);

                requestMessage.Content.Headers.ContentType
                    = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.SendAsync(requestMessage);

                var responseStatusCode = response.StatusCode;
                var responseBody = await response.Content.ReadAsStringAsync();

                var returnedUser = JsonConvert.DeserializeObject<RegisterModel>(responseBody);

                return await Task.FromResult(returnedUser);
            }
            catch (Exception ex)
            {
                RegisterModel u = new RegisterModel();
                u.UserName = user.UserName;
                u.Error = ex.ToString();

                return await Task.FromResult(u);
            }
        }

        public async Task<LoginUser> GetUserByAccessTokenAsync(string accessToken)
        {
            try
            {
                string serializedRefreshRequest = JsonConvert.SerializeObject(accessToken, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "api/Felhasznalo/FelhasznaloHozzaferesiTokennel");
                requestMessage.Content = new StringContent(serializedRefreshRequest);

                requestMessage.Content.Headers.ContentType
                    = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.SendAsync(requestMessage);

                var responseStatusCode = response.StatusCode;
                var responseBody = await response.Content.ReadAsStringAsync();

                var returnedUser = JsonConvert.DeserializeObject<LoginUser>(responseBody);

                return await Task.FromResult(returnedUser);
            }
            catch (Exception ex)
            {
                LoginUser u = new LoginUser();
                u.Error = ex.ToString();

                return await Task.FromResult(u);
            }
        }


    }
}
