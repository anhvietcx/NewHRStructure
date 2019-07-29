using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QTNNL.Core.Entities;
using QTNNL.Core.ViewModels.UserViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QTNNL.Infrastructure.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        public UserService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<User> Authenticate(UserDto userDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
            "https://api.github.com/repos/aspnet/AspNetCore.Docs/branches");
            StringContent content = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
            request.Content = content;
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            User user = new User();
            if (response.IsSuccessStatusCode)
            {
                string userStringJson = await response.Content.ReadAsStringAsync();
                user = JObject.Parse(userStringJson).ToObject<User>();
            }
            return user;
        }
    }
}
