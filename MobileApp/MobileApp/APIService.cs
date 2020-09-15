using Flurl.Http;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static int UserId { get; set; }

        private readonly string _route;
#if DEBUG
        private string _apiUrl = "http://localhost:55208/api";
#endif
        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greska", "Niste authentificirani", "OK");
                }
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";
            var data = await url.WithBasicAuth(Username,Password).PostJsonAsync(request).ReceiveJson<T>();
            return data;
            //try
            //{
            //   
            //}
            ////catch (FlurlHttpException ex)
            ////{
            //var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

            //var stringBuilder = new StringBuilder();
            //    foreach (var error in errors)
            //    {
            //        stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
            //    }

            //    MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return default(T);
            //}

        }

        public async Task<T> Update<T>(int id, object request)
        {

            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();

            //catch (FlurlHttpException ex)
            //{
            //    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

            //    var stringBuilder = new StringBuilder();
            //    foreach (var error in errors)
            //    {
            //        stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
            //    }

            //    MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return default(T);
            //}

        }
        //public HttpStatusCode Delete<T>(int id)
        //{
        //    //var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
        //    //return await url.WithBasicAuth(Username, Password).DeleteAsync(id).ReceiveJson();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(Properties.Settings.Default.APIUrl);
        //        var response = client.DeleteAsync($"api/{_route}/{id}").Result;
        //        return response.StatusCode;
        //    }
        //}
    }
}
