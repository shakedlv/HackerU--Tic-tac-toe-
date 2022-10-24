namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string value = "";
            while(value.ToLower() != "q")
            {
                GameLoop();

                Console.WriteLine("write q to quit, otherwise play again");
                value = Console.ReadLine();
            }
        }

        static void GameLoop()
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("======================Tic Tac Toe======================");
            Console.WriteLine("=======================================================");
            string[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Console.WriteLine("Enter Player 1 nickname :");
            string player1 = Console.ReadLine();
            string player1_symbol = "X";
            Console.WriteLine("Enter Player 2 nickname :");
            string player2 = Console.ReadLine();
            string player2_symbol = "O";
            Console.WriteLine($"{player1} what do you want to be ?\n1) X\n2) O");
            int.TryParse(Console.ReadLine(), out int pick);
            while (pick != 1 && pick != 2)
            {
                Console.Clear();
                Console.WriteLine("?\n1 =  X\n2 = O");
                int.TryParse(Console.ReadLine(), out pick);
            }
            player1_symbol = pick == 1 ? "X" : "O";
            player2_symbol = pick == 1 ? "O" : "X";
            Console.WriteLine($"{player1} is {player1_symbol}\n{player2} is {player2_symbol}");
            PrintBoard(board);

            Console.WriteLine("Game board is 3 by 3 , enter number to indicate cell number (see board above)");
            bool isPlayer1Win = isWin(player1_symbol, board);
            bool isPlayer2Win = isWin(player2_symbol, board);
            int currentPlayer = 1;
            while (!isPlayer1Win && !isPlayer2Win)
            {
                Console.WriteLine((currentPlayer == 1 ? player1 : player2) + " turn, pick a cell");
                int.TryParse(Console.ReadLine(), out int pos);
                GetInput(currentPlayer == 1 ? player1_symbol : player2_symbol, pos, ref board);
                isPlayer1Win = isWin(player1_symbol, board);
                isPlayer2Win = isWin(player2_symbol, board);
                if (currentPlayer == 1)
                    currentPlayer = 2;
                else
                    currentPlayer = 1;
            }
            Console.Clear();

            Console.WriteLine((isPlayer1Win ? player1 : player2) + " Won!");
        }

        static bool isWin(string symbol, string[] board)
        {
            if (board[0] == board[1] && board[0] == board[2] && board[0].Equals(symbol))
                return true;
            if (board[3] == board[4] && board[3] == board[5] && board[3].Equals(symbol))
                return true;
            if (board[6] == board[7] && board[6] == board[8] && board[6].Equals(symbol))
                return true;

            if (board[0] == board[3] && board[0] == board[6] && board[0].Equals(symbol))
                return true;
            if (board[1] == board[4] && board[1] == board[7] && board[1].Equals(symbol))
                return true;
            if (board[2] == board[5] && board[2] == board[8] && board[2].Equals(symbol))
                return true;

            if (board[0] == board[4] && board[0] == board[8] && board[0].Equals(symbol))
                return true;

            if (board[2] == board[4] && board[2] == board[6] && board[0].Equals(symbol))
                return true;

            return false;
        }

        static bool GetInput(string player,int pos, ref string[] board)
        {
            while(pos < 1 || pos > 9)
            {
                PrintBoard(board);
                Console.WriteLine("Cell is out side of game board, must be between 1 - 9");
                int.TryParse(Console.ReadLine(), out pos);
            }
            bool isFree = int.TryParse(board[pos - 1], out int num);

            if (isFree)
                board[pos - 1] = player;
            else
            {
                Console.WriteLine("Cell is occupied, try again");
                int.TryParse(Console.ReadLine(), out int cell);
                PrintBoard(board);
                GetInput(player,cell,ref board);
            }

            PrintBoard(board);
            return true;

            
        }

        static void PrintBoard(string[] board)
        {
            Console.Clear();
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0] , board[1], board[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
            Console.WriteLine("     |     |      ");
        }


    }
}