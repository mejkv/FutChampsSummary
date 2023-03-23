
using System.Text;
using static FutChampsSummary.PlayerBase;
using static System.Formats.Asn1.AsnWriter;

namespace FutChampsSummary
{
    public class PlayerInFile: PlayerBase
    {
        public override event RatingAddedDelegate RatingAdded;

        private const string fileName = "scores.txt";
        private string FileName; 

        public PlayerInFile(string name, string rarity)
            : base(name, rarity)
        {
            FileName = $"{name}_{rarity}_{fileName}";
        }

        public override void AddScore(float score)
        {
            if (score >= 0 && score <= 10)
            {
                using (var writer = File.AppendText(FileName))
                {
                    writer.WriteLine(score);

                    if (RatingAdded != null)
                    {
                        RatingAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid score value, only scores from 0 to 10 or from F to A are allowed");
            }
        }
       

        public override Statistics GetStatistics()
        {
            var result = this.GetScoresFromFile();
            var finalResult = this.GetStatisticsFromFile(result);
            return finalResult;
        }

        private List<float> GetScoresFromFile()
        {
            var scores = new List<float>();
            if (File.Exists(FileName))
            {
                using (var reader = File.OpenText(FileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        scores.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return scores;
        }

        public override void ShowRatings()
        {
            StringBuilder sb = new StringBuilder($"{this.Name} {this.Rarity} ratings are: ");

            using (var reader = File.OpenText(FileName))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    sb.Append("{0}" + line);
                    line = reader.ReadLine();
                }
            }
        }

        private Statistics GetStatisticsFromFile(List<float> scores)
        {
            var statistics = new Statistics();

            foreach (var score in scores)
            {
                statistics.AddScore(score);
            }

            return statistics;
        }
    }
}
