using PruebaTecnica.Models;

namespace PruebaTecnica.Repository
{
    public interface IRouletteRepository : IRepository
    {
        public RouletteModel GetRouletteById(string Id);
        public List<RouletteModel> GetRoulettes();
        public RouletteModel UpdateRoulettes(string Id, RouletteModel roulette);
        public RouletteModel SaveRoulette(RouletteModel roulette);

    }
}
