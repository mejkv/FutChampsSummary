namespace FutChampsSummary
{
    public abstract class PlayerBase : IPlayer
    {
        public delegate void RatingAbove9Delegate(object sender, EventArgs args);

        public abstract event RatingAbove9Delegate RatingAbove9;

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

        public abstract Statistics GetStatistics();
    }
}
