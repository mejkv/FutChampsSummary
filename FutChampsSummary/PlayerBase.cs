using System.Numerics;

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

        public abstract void AddScore(float score);

        public void AddScore(double score)
        {
            var result = (float)score;
            this.AddScore(result);
        }

        public void AddScore(int score)
        {
            float result = score;
            this.AddScore(result);
        }

        public void AddScore(char score)
        {
            switch (score)
            {
                case 'A':
                case 'a':
                    this.AddScore(10);
                    break;
                case 'B':
                case 'b':
                    this.AddScore(8);
                    break;
                case 'C':
                case 'c':
                    this.AddScore(6);
                    break;
                case 'D':
                case 'd':
                    this.AddScore(4);
                    break;
                case 'E':
                case 'e':
                    this.AddScore(2);
                    break;
                default:
                    throw new Exception("Invalid score value");
            }
        }

        public void AddScore(string score)
        {
            if (float.TryParse(score, out float result))
            {
                this.AddScore(result);
            }
            else if (char.TryParse(score, out char resultChar))
            {
                AddScore(resultChar);
            }
            else
            {
                throw new Exception("Invalid score value");
            }
        }

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
