using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Joke
{
    public class CallApi
    {
        public string GetDataFromApi(string url)
        {
            try
            {
                string result = "";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                result = client.GetStringAsync(client.BaseAddress).Result;

                return result;
            } catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public JokeChuckNorris? GetAJoke(string jsonString)
        {
            var json = GetDataFromApi(jsonString);
            JokeChuckNorris? result = JsonSerializer.Deserialize<JokeChuckNorris>(json);
            return result;
        }
    }
}