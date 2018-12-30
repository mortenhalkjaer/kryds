using System;

namespace kryds
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player playerX = new Player(1);
            Player playerO = new Player(2);
            int turn = 0;


            while (board.GetState() == GameState.Progress) {
                if (turn == 0) playerO.move(board);
                else playerX.move(board);

                Console.WriteLine("player " + turn.ToString());
                Console.WriteLine(board.ToString());

                turn = 1-turn;                
            }

            Console.WriteLine(board.GetState());


            Console.WriteLine("Hello World!");
        }
    }
}
