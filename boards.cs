using System.Collections.Generic;
using System;

namespace kryds {
    public enum GameState {
        Draw, Player1Won, Player2Won, Progress
    };

    public class Board {
        private char[] piece = { 'X', ' ', 'O' };
        private int[] board = new int[9];
        private int[,] winCondition = new int[8,3]
            { {0,1,2}, {3,4,5}, {6,7,8},
              {0,3,6}, {1,4,7}, {2,5,8},
              {0,4,8}, {2,4,6} };

        public List<int> getMoves(int player) {
            List<int> result = new List<int>();

            for (int n=0; n<9; n++) {
                if (board[n] == 0) result.Add(n);
            }

            return result;
        }

        public void move(int player, int field) {
            board[field] = player == 2 ? -1 : 1;
        }

        public void clear() {
            for (int n=0; n<9; n++) {
                board[n] = 0;
            }
        }

        public GameState GetState() {
            for (int n=0; n<8; n++) {
                int sum = 0;
                for (int k=0; k<3; k++) {
                    sum += board[winCondition[n,k]];
                }
//                Console.WriteLine(n.ToString() + " " + sum.ToString());
                if (sum == -3) return GameState.Player2Won;
                if (sum == 3) return GameState.Player1Won;
            }
            
            for (int n=0; n<board.Length; n++) {
                if (board[n] == 0) return GameState.Progress;
            }
            
            return GameState.Draw;
        }

        public override string ToString() {
            string s = "";
            
            for (int n=0; n<board.Length; n++) {
                s += piece[board[n]+1];
                if ((n+1)%3==0 && n>0) s+= "\n";
            }
            return s;
        }
    }
};