namespace PruebaTecnica.Models
{

    [Serializable]
    public class RouletteModel
    {
        public string Id { get; set; }
        public bool IsOpen { get; set; } = false;
        public DateTime? OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public IDictionary<string, double>[] board { get; set; } = new IDictionary<string, double>[39];

        public RouletteModel()
        {
            this.Init();
        }

        private void Init()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new Dictionary<string, double>();
            }
        }


    }
}
