using FutChampsSummary;
using System.Runtime.CompilerServices;

void RatingAdded(object sender, EventArgs args)
{
    Console.Write(" (Rating Added)");
}

Console.WriteLine("Hello to the FUT Champions Player Rating console app.");

bool exit  = false;

while (!exit)
{
    Console.WriteLine();
    Console.WriteLine("1. Add player's rating to the program memory and show statistics\n" +
        "2. Add player's rating to the txt file and show statistics\n" +
        "3. Exit\n");

    Console.WriteLine("(Press key 1, 2 or 3");
    var input = Console.ReadLine();

    switch(input)
    {
        case "1":
            AddRatingToMemory();
            break;

        case "2":
            AddRatingToFile();
            break;
            
        case "3":
            exit = true;
            Console.WriteLine("\nSee you next time!\n");
            break;

        default:
            Console.WriteLine("Invalid operation\n");
            break;
    }
}

static void AddRatingToMemory()
{
     Console.WriteLine("Please, insert player name or nickname: ");
     string name = Console.ReadLine();
     Console.WriteLine("Please, insert player rarity: ");
     string rarity = Console.ReadLine();

     if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(rarity))
     {
         var player = new PlayerInMemory(name, rarity);
         AddRating(player);
         player.GetStatistics();
         player.ShowStatistics();
     }
     else
     {
         Console.WriteLine("Player name or rarity can't be empty.");
     }
}

static void AddRatingToFile()
{
    Console.WriteLine("Please, insert player name or nickname: ");
    string name = Console.ReadLine();
    Console.WriteLine("Please, insert player rarity: ");
    string rarity = Console.ReadLine();

    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(rarity))
    {
        var player = new PlayerInFile(name, rarity);
        AddRating(player);
        player.GetStatistics();
        player.ShowStatistics();
    }
    else
    {
        Console.WriteLine("Player name or rarity can't be empty.");
    }
}

static void AddRating(PlayerBase player)
{
    while(true)
    {
        Console.WriteLine($"Enter rating after match for {player.Name} in version {player.Rarity}\n");
        var enter = Console.ReadLine();

        if( enter == "q" || enter == "Q" )
        {
            break;
        }
        try
        {
            player.AddScore(enter);
        }
        catch (FormatException exception)
        {
            Console.WriteLine($"Exception catched: {exception.Message}");
        }
        catch(ArgumentOutOfRangeException exception)
        {
            Console.WriteLine($"Exception catched: {exception.Message}");
        }
        catch(NullReferenceException exception)
        {
            Console.WriteLine($"Exception catched: {exception.Message}");
        }
        finally
        {
            Console.WriteLine("if you want to stop adding ratings type Q/q");
        }
    }
}