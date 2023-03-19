using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FutChampsSummary.PlayerBase;
using static System.Formats.Asn1.AsnWriter;

namespace FutChampsSummary
{
    public class PlayerInFile: PlayerBase
    {
        public override event RatingAddedDelegate RatingAdded;

        private const string fileName = "scores.txt";

        public PlayerInFile(string name, string rarity)
            : base(name, rarity)
        {
        }

        public override void AddScore(float score)
        {
            if (score >= 0 && score <= 100)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(score);
                }

                if (RatingAdded != null)
                {
                    RatingAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid score value");
            }
        }

        public override void AddScore(double score)
        {
            var result = (float)score;
            this.AddScore(result);
        }

        public override void AddScore(int score)
        {
            float result = score;
            this.AddScore(result);
        }

        public override void AddScore(char score)
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

        public override void AddScore(string score)
        {
            if (float.TryParse(score, out float result))
            {
                this.AddScore(result);
            }
            else
            {
                switch (score)
                {
                    case "A":
                    case "a":
                        this.AddScore(10);
                        break;
                    case "B":
                    case "b":
                        this.AddScore(8);
                        break;
                    case "C":
                    case "c":
                        this.AddScore(6);
                        break;
                    case "D":
                    case "d":
                        this.AddScore(4);
                        break;
                    case "E":
                    case "e":
                        this.AddScore(20);
                        break;
                    default:
                        throw new Exception("Invalid score value");
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = this.StatisticsFromFile();
            var finalResult = this.GetStatisticsFromFile(result);
            return finalResult;
        }

        private List<float> StatisticsFromFile()
        {
            var scores = new List<float>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
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
            int i = 0;
            StringBuilder sb = new StringBuilder($"{this.Name} {this.Rarity} ratings are: ");

            using (var reader = File.OpenText(fileName))
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
