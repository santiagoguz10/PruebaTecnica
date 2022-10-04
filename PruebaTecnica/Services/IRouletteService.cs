using PruebaTecnica.Models;

namespace PruebaTecnica.Services
{
    public interface IRouletteService
    {
        public RouletteModel CreateRoulette();

        public RouletteModel FindRoulette(string Id);

        public RouletteModel OpenRoulette(string Id);
        public RouletteModel CloseRoulette(string Id);

        public RouletteModel BetRoulette(string Id, string UserId, int position, double money);

        public List<RouletteModel> GetRoulettes();
    }
}
