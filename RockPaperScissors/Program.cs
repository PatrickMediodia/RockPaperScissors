namespace RockPaperScissors
{
    class Program
    {
        //Keep track of scores
        static int playerScore = 0;
        static int computerScore = 0;

        //list of acceptable input
        static List<string> choices = new List<string> { "rock", "paper", "scissors" };

        //Random object
        static Random random = new Random();

        static void Main(string[] args)
        {
            while (true)
            {
                string userInput = getUserInput();
                if (userInput == "x") break;

                string computerChoice = getComputerChoice();
                getResults(userInput, computerChoice);
            }
        }

        static string getUserInput()
        {
            string userInput = "";

            //check if user is in choices or is X
            while (choices.Where(x => x.Equals(userInput)).FirstOrDefault() == null && userInput != "x")
            {
                Console.Write("Enter your choice (Rock, Paper, Scissors, or X to exit): ");
                userInput = Console.ReadLine()!.ToLower();
            }

            return userInput.ToLower();
        }

        static string getComputerChoice()
        {
            int randomChoice = random.Next(0, 3);

            //get from list of choices and return the string
            return choices[randomChoice];
        }

        static void getResults(string userInput, string computerChoice)
        {
            //scenario if tie
            if (userInput == computerChoice)
            {
                Console.WriteLine($"\nYou both chose {userInput}, its a tie.");
            }

            //scenario if user wins
            else if (
                userInput == "scissors" && computerChoice == "paper" 
                || userInput == "paper" && computerChoice == "rock" 
                || userInput == "rock" && computerChoice == "scissors")
            {
                Console.WriteLine($"\nThe computer chose {computerChoice} and lost.");
                playerScore++;
            }
            
            //scenario if computer wins
            else
            {
                Console.WriteLine($"\nThe computer chose {computerChoice} and won");
                computerScore++;
            }

            //display score
            Console.WriteLine($"\nScore:\nPlayer: {playerScore}\nComputer: {computerScore}\n\n");
        }
    }
}