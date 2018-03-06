using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSPEDM
{
    class Login
    {
        private static readonly HttpClient _loginClient = new HttpClient();
        public string AccessToken { private get; set; }
        public async Task<Credentials> GetCredentials(string login, string password)
        {
            var _userCredentials = new Dictionary<string, string>
            {
                { "email", login },
                { "password", password }
            };
            var json = JsonConvert.SerializeObject(_userCredentials);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _loginClient.PostAsync(@"http://localhost:5000/login", content);

            var result = response.Content.ReadAsStringAsync().Result;
            var resultJson = (JObject)JsonConvert.DeserializeObject(result);
            var token = resultJson["token"].Value<string>();
            var expire = resultJson["expiry"].Value<string>();
            return new Credentials(token, long.Parse(expire));
        }
    }
}
