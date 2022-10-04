using EasyCaching.Core;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repository
{
    public class RouletteRepository : IRouletteRepository
    {
        private IEasyCachingProviderFactory cachingProviderFactory;

        private IEasyCachingProvider cachingProvider;

        private const string KEYREDIS = "TABLEROULETE";

        public RouletteRepository(IEasyCachingProviderFactory cachingProviderFactory)
        {
            this.cachingProviderFactory = cachingProviderFactory;
            this.cachingProvider = this.cachingProviderFactory.GetCachingProvider("roulette");

        }

        public RouletteModel GetRouletteById(string Id)
        {
            var item = this.cachingProvider.Get<RouletteModel>(KEYREDIS + Id);
            if (!item.HasValue)
            {
                return null;
            }
            return item.Value;
        }

        public List<RouletteModel> GetRoulettes()
        {
            var rouletes = this.cachingProvider.GetByPrefix<RouletteModel>(KEYREDIS);
            if (rouletes.Values.Count == 0)
            {
                return new List<RouletteModel>();
            }
            return new List<RouletteModel>(rouletes.Select(x => x.Value.Value));
        }

        public RouletteModel UpdateRoulettes(string Id, RouletteModel roulette)
        {
            roulette.Id = Id;
            return SaveRoulette(roulette);
        }

        public RouletteModel SaveRoulette(RouletteModel roulette)
        {
            cachingProvider.Set(KEYREDIS + roulette.Id, roulette, TimeSpan.FromDays(365));
            return roulette;
        }
    }
}
