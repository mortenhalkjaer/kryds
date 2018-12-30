using System.Collections.Generic;
using System;

namespace kryds {
    public class Player {
        int player;
        Random ran = new Random();

        public void move(Board board) {
            List<int> moves = board.getMoves(player);
            
            int f = ran.Next() % moves.Count;
            board.move(player, moves[f]);
        }

        public Player(int number) {
            player = number;
        }
    }
}