using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BotApplicationBoiler.JsonModels;
using Newtonsoft.Json;

namespace BotApplicationBoiler.Extensions
{
    public static class WebRequestExtension
    {

        /// <summary>
        /// Extends support of HTTP - GET Reqest
        /// </summary>
        /// <param name="url"> Endpoint for HTTP (GET) Request</param>
        /// <returns>Response String</returns>
        public static async Task<string> ParseJson(string url)
        {
            var jsonString = String.Empty;
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                jsonString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return jsonString;
        }

        public static async Task<List<ConversationModel>> GetConversationModelModelAsync(string conversationEndpoint)
        {

            var conversationResultJson = await WebRequestExtension.ParseJson(conversationEndpoint);
            var conversationList = JsonConvert.DeserializeObject<List<ConversationModel>>(conversationResultJson);
            return conversationList;
        }

    }
}