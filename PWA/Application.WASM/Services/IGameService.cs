using Application.WASM.Extentions;
using Application.WASM.Model;
using System.Net.Http.Json;
using static Application.WASM.Services.GameService;

namespace Application.WASM.Services
{
    public interface IGameService
    {
         Task<List<Game>> GetGames(Ordering ordering, string searchkey, long? catid, int pagesize, int page);
    }
    public class GameService : IGameService
    {
        private  HttpClient _httpClient;

        public GameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Game>> GetGames(Ordering ordering,string? searchkey,long? catid,int pagesize,int page)
        {
            var s = _httpClient.BaseAddress;
            var res = await _httpClient.GetAsync($"/Game/GetGames/{ordering}/{searchkey}/{0}/{pagesize}/{page}");
            if (res.IsSuccessStatusCode)
            {
                return await res.ReadContentAs<List<Game>>();

            }
            return new List<Game>();
        }
        public enum Ordering
        {
            NotOrder,
            Cheapset,
            Expensive,
            theNewest,
            theoldest,
            Saled

        }
    }
}
