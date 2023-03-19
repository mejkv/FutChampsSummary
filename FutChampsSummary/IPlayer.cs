using static FutChampsSummary.PlayerBase;

namespace FutChampsSummary
{
    public interface IPlayer
    {
        string Name { get; }

        string Rarity { get; }

        void AddScore(float score);

        void AddScore(double score);

        void AddScore(int score);

        void AddScore(char score);

        void AddScore(string score);

        event RatingAddedDelegate RatingAdded;

        Statistics GetStatistics();

    }
}
