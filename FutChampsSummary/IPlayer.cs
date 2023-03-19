using static FutChampsSummary.PlayerBase;

namespace FutChampsSummary
{
    internal interface IPlayer
    {
        string Name { get; }

        string Rarity { get; }

        void AddScore(float score);

        void AddScore(double score);

        void AddScore(int score);

        void AddScore(char score);

        void AddScore(string score);

        event RatingAbove9Delegate RatingAbove9;

        Statistics GetStatistics();

    }
}
