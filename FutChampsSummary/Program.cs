using FutChampsSummary;
using System.Runtime.CompilerServices;


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
            break;
            
        case "3":
            exit = true;
            break;

        default:
            Console.WriteLine("Invalid operation\n");
            break;
    }
}

void RatingAbove9(object sender, EventArgs args)
{
    Console.WriteLine("Wow that was excellent game!");
}

static void AddRatingToMemory()
{
        Console.WriteLine("Please, insert player name or nickname: ");
        string name = Console.ReadLine();
        Console.WriteLine("Please, insert player rarity: ");
        string rarity = Console.ReadLine();
        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(rarity))
        {
            var playerInMemory = new PlayerInMemory(name, rarity);
            
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
        var playerInMemory = new PlayerInMemory(name, rarity);
    }
    else
    {
        Console.WriteLine("Player name or rarity can't be empty.");
    }
}

static void AddRating(IPlayer player)
{
    while(true)
    {
        Console.WriteLine($"Enter rating after match for {player.Name} in version {player.Rarity}\n" +
            $"if you want to stop adding ratings type Q/q");
        var enter = Console.ReadLine();

        if( enter == "q" || enter == "Q" )
        {
            break;
        }
        try
        {

        }
        catch (FormatException exception)
        {
            throw new Exception(exception.Message);
        }
        catch(ArgumentOutOfRangeException exception)
        {
            throw new Exception(exception.Message);
        }
        catch(NullReferenceException exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            throw '';
        }
    }
}