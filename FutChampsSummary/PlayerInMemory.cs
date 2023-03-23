using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FutChampsSummary
{
    public class PlayerInMemory : PlayerBase
    {
        public override event RatingAddedDelegate RatingAdded;

        private List<float> score = new List<float>();

        public PlayerInMemory(string name, string rarity)
            :base(name, rarity)
        { 
        }

        public override void AddScore(float score)
        {
            if (score >= 0 && score <= 10)
            {
                this.score.Add(score);

                if (RatingAdded != null)
                {
                    RatingAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException("Invalid score value, only scores from 0 to 10 or from F to A are allowed");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var score in this.score)
            {
                statistics.AddScore(score);
            }

            return statistics;
        }

        public override void ShowRatings()
        {
            int i = 0;
            StringBuilder sb = new StringBuilder($"{this.Name} {this.Rarity} ratings are: ");
            do
            {
                if (i == score.Count - 1)
                {
                    sb.Append("{0}" + score[i]);
                }
                else
                {
                    sb.Append("{0} / " + score[i]);
                }
                i++;
            }
            while (i < score.Count);
        }
    }
}
