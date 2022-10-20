using static System.Console;
namespace MyGame;

internal class Program
{
    // Make a random number generator that is easily "shared" throughout my Program class.
    private static Random Rnd = new Random();

    static void Main(string[] args)
    {
        WriteLine("Welcome to my game!");
        string[] players = new string[2];
        for (int index = 0; index < players.Length; index++)
            players[index] = GetPlayerName();

        PlayGame(players);
    }

    private static void PlayGame(string[] players)
    {
        // Have each player roll 5 die and compare their totals to each other
        // I will track the grand total for each player,
        int[] playerTotals = new int[players.Length];

        // and the one with the largest total at the end wins.
        // There will a random number of turns.
        int maxTurns = Rnd.Next(3, 8); // 3 to 7 inclusive
        do
        {
            for(int index = 0; index < players.Length; index++)
            {
                playerTotals[index] += TakeTurn(players[index]);
            }
            maxTurns--;
        }while (maxTurns > 0);
    }

    private static int TakeTurn(string playerName)
    {
        int[] dice = RollDie(5);
        Write($"Player: {playerName,-10}");
        foreach (int faceValue in dice)
            Write($" {faceValue} ");
        WriteLine();
        int total = TotalDie(dice);
        return total;
    }

    private static int TotalDie(int[] dice)
    {
        int sum = 0;
        foreach (var value in dice)
            sum += value;
        return sum;
    }

    private static int[] RollDie(int count)
    {
        int[] dice = new int[count];
        for (int index = 0; index < count; index++)
            dice[index] = Rnd.Next(1, 7); // six-sided die
        return dice;
    }

    private static string GetPlayerName()
    {
        ForegroundColor = ConsoleColor.DarkYellow;
        Write("Enter a player name: ");
        ForegroundColor = ConsoleColor.DarkGreen;
        string name = ReadLine();
        // TODO: Maybe put a loop here to make sure the string is not empty
        ResetColor();
        Beep(); // Let them know it was accepted
        return name;
    }
}