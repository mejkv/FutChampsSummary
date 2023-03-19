namespace FutChampsSummary
{
    public abstract class PlayerBase : IPlayer
    {
        public delegate void RatingAddedDelegate(object sender, EventArgs args);

        public abstract event RatingAddedDelegate RatingAdded;

        public PlayerBase(string name, string rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
        }
        public string Name { get; private set; }
        public string Rarity { get; private set; }

        public int overall => throw new NotImplementedException();

        public abstract void AddScore(float score);

        public abstract void AddScore(double score);


        public abstract void AddScore(int score);

        public abstract void AddScore(char score);

        public abstract void AddScore(string score);

        public abstract void ShowRatings();

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var stats = GetStatistics();
            if (stats.Count != 0)
            {
                ShowRatings();
                Console.WriteLine("====================================");
                Console.WriteLine($"{Name} {Rarity} rantings after FC: ");
                Console.WriteLine($"Best rating: {stats.Max}");
                Console.WriteLine($"Worst rating: {stats.Min}");
                Console.WriteLine($"Average rating: {stats.Average}");
                Console.WriteLine($"Average letter rating: {stats.AverageLetter}");
                Console.WriteLine($"Count of ratings: {stats.Count}");
                Console.WriteLine("====================================");
            }
            else
            {
                Console.WriteLine($"{Name} {Rarity} don't have any ratings");
            }
        }
    }
}
