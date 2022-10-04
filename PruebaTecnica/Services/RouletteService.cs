using PruebaTecnica.Exception;
using PruebaTecnica.Models;
using PruebaTecnica.Repository;

namespace PruebaTecnica.Services
{
    public class RouletteService : IRouletteService
    {
        private IRouletteRepository rouletteRepository;

        public RouletteService(IRouletteRepository rouletteRepository)
        {
            this.rouletteRepository = rouletteRepository;
        }

        public RouletteModel CreateRoulette()
        {
            RouletteModel roulette = new RouletteModel()
            {
                Id = Guid.NewGuid().ToString(),
                IsOpen = false,
                OpenedAt = null,
                ClosedAt = null
            };
            rouletteRepository.SaveRoulette(roulette);
            return roulette;
        }

        public RouletteModel FindRoulette(string Id)
        {
            return rouletteRepository.GetRouletteById(Id);
        }

        public RouletteModel OpenRoulette(string Id)
        {
            RouletteModel roulette = rouletteRepository.GetRouletteById(Id);
            if (roulette == null)
            {
                throw new RouletteNotFound();
            }

            if (roulette.OpenedAt != null)
            {
                throw new NotAllowedOpenException();
            }
            roulette.OpenedAt = DateTime.Now;
            roulette.IsOpen = true;
            return rouletteRepository.UpdateRoulettes(Id, roulette);
        }

        public RouletteModel CloseRoulette(string Id)
        {
            RouletteModel roulette = rouletteRepository.GetRouletteById(Id);
            if (roulette == null)
            {
                throw new RouletteNotFound();
            }
            if (roulette.ClosedAt != null)
            {
                throw new NotAllowedClosedException();
            }
            roulette.ClosedAt = DateTime.Now;
            roulette.IsOpen = false;
            return rouletteRepository.UpdateRoulettes(Id, roulette);
        }

        public RouletteModel BetRoulette(string Id, string UserId, int position, double moneyBet)
        {
            if (moneyBet > 10000 || moneyBet < 1)
            {
                throw new CashOutRangeException();
            }
            RouletteModel roulette = rouletteRepository.GetRouletteById(Id);
            if (roulette == null)
            {
                throw new RouletteNotFound();
            }

            if (roulette.IsOpen == false)
            {
                throw new RouletteClosedException();
            }

            double value = 0d;
            roulette.board[position].TryGetValue(UserId, out value);
            roulette.board[position].Remove(UserId + "");
            roulette.board[position].TryAdd(UserId + "", value + moneyBet);

            return rouletteRepository.UpdateRoulettes(roulette.Id, roulette);
        }

        public List<RouletteModel> GetRoulettes()
        {
            return rouletteRepository.GetRoulettes();
        }
    }
}
