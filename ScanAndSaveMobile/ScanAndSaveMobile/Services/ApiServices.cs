using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScanAndSaveMobile.Helpers;
using ScanAndSaveMobile.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ScanAndSaveMobile.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterAsync(string userName, string email, string password, string confirmPassword)
        {

            //Debug.WriteLine("Username: " + userName);

            //var httpClientHandler = new HttpClientHandler(); 

            var client = new HttpClient();
            //HttpClientHandler.ServiceCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            var model = new RegisterBindingModel
            {
                Username = userName,
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            bool success = false;

            try
            {
                var response = await client.PostAsync("https://10.0.2.2:3000/api/Account/Register", content);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            if (success)
            {
                return true;
            }
            return false;
            //return response.IsSuccessStatusCode;
        }







        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")


            };
            var request = new HttpRequestMessage(HttpMethod.Post, "http://10.0.2.2:3000/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var jwt = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);

            var accessToken = jwtDynamic.Value<string>("access_token");
            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
            Settings.AccessTokenExpiration = accessTokenExpiration;

            Debug.WriteLine(jwt);

            return accessToken;



        }

        public async Task<List<Carts>> GetCartAsync(string accessToken)
        {
            var client = new HttpClient();
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            var json = await client.GetStringAsync("http://10.0.2.2:3000/api/Carts/ForCurrentUser");

            var cart = JsonConvert.DeserializeObject<List<Carts>>(json);

            return cart;


        }


        public async Task PostCartAsync(Carts cart, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(cart);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://10.0.2.2:3000/api/Carts", content);

        }

        public async Task EditCartAsync(Carts cart, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(cart);

            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync("http://10.0.2.2:3000/api/Carts/" + cart.Id, content);




        }

        public async Task DeleteCartAsync(int id, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.DeleteAsync("http://10.0.2.2:3000/api/Carts/" + id);
        }



    }
}
    

