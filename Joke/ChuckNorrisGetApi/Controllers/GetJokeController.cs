using Joke;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChuckNorrisGetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetJokeController : ControllerBase
    {
        CallApi callApi { get; set; }
        string url = "https://api.chucknorris.io/jokes/random";

        public GetJokeController()
        {
            callApi = new CallApi();
        }
        // GET: api/<GetJokeController>
        [HttpGet]
        public JokeChuckNorris Get()
        {
            return callApi.GetAJoke(url);
        }

        // GET api/<GetJokeController>/categorie
        [HttpGet("{categorie}")]
        public JokeChuckNorris GetJokeByCategorie(string categorie)
        {
            var newUrl = url + "?category=" + categorie;
            try
            {
                return callApi.GetAJoke(newUrl);
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // POST api/<GetJokeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GetJokeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetJokeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
