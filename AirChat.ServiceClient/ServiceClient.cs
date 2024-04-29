namespace AirChat.ServiceClient
{
    using global::AirChat.Contract;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    namespace AirChat.API.Services
    {
        public class AirChatServiceClient
        {
            private readonly HttpClient _httpClient;

            public AirChatServiceClient(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<List<Message>> GetMessagesAsync()
            {
                return await _httpClient.GetFromJsonAsync<List<Message>>("/messages");
            }

            public async Task<Message> SendMessageAsync(string name, string text)
            {
                var message = new Message(name, text, DateTime.Now);
                var response = await _httpClient.PostAsJsonAsync("/messages", message);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Message>();
            }
        }
    }

}
