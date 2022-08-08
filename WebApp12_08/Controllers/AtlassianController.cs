using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp12_08.Models;
using Newtonsoft.Json;

namespace WebApp12_08.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtlassianController : ControllerBase {

        //Functionality to check your existing boards and their Id's

        /*[HttpGet]
        public async Task<string> GetBoardsAsync(string apiKey, string apiToken)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.trello.com/1/members/me/boards?fields=name,url&key={apiKey}&token={apiToken}")
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }*/

        //functionality to check your existing lists for the board
        [HttpGet]
        public async Task<string> GetListsOfBoardAsync(string apiKey, string apiToken, string boardId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.trello.com/1/boards/{boardId}/lists?key={apiKey}&token={apiToken}")
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }

        [HttpPost]
        public async Task<Card> MakeBoardAsync(string cardName, string cardDescription, string columnId, string apiKey, string apiToken)
        {
            var client = new HttpClient();
            var card = new Card
            {
                IdList = columnId,
                Name = cardName,
                Description = cardDescription
            };
            var stringRequest = JsonConvert.SerializeObject(card);
            var requestContent = new StringContent(stringRequest, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"https://api.trello.com/1/cards?idList={columnId}&key={apiKey}&token={apiToken}", requestContent);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Card>(body);
        }
    }
}