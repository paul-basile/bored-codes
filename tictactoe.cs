using System;

namespace Game {
  class TicTacToe {
    
    static void PrintBoard(string[] board) {
      for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) {
          if (j==2) Console.Write(board[i*3+j]); else Console.Write(board[i*3+j] + " | ");
        }
        Console.WriteLine("");
      }
    }
    
    static bool CheckVictory(string[] board) {
      bool row1 = board[0] == board[1] && board[1] == board[2];
      bool row2 = board[3] == board[4] && board[4] == board[5];
      bool row3 = board[6] == board[7] && board[7] == board[8];
      bool col1 = board[0] == board[3] && board[3] == board[6];
      bool col2 = board[1] == board[4] && board[4] == board[7];
      bool col3 = board[2] == board[5] && board[5] == board[8];
      bool diag1 = board[0] == board[4] && board[4] == board[8];
      bool diag2 = board[2] == board[4] && board[4] == board[6];
      
      return row1 || row2 || row3 || col1 || col2 || col3 || diag1 || diag2;
    }
    
    static void Main(string[] args) {
      string[] board = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
	  Console.WriteLine("Welcome to Tic Tac Toe! Choose numbers between 1 - 9 to place an X/O.");
	  Console.WriteLine("Player 1 is X's, Player 2 is O's!");
      
      bool isPlayer1Turn = true;
      int numTurns = 0;
      
      while (!CheckVictory(board) && numTurns != 9) {
        
        PrintBoard(board);
        if (isPlayer1Turn == true) Console.WriteLine("Player 1 Turn"); else Console.WriteLine("Player 2 Turn");
        string choice = Console.ReadLine();
        
        for (int i = 0; i < 3; i++) {
          for (int j = 0; j < 3; j++) {
            if (board[i*3+j] == choice && choice != "X" && choice != "O") {
              int boardIndex = Convert.ToInt32(choice) - 1;
              if (isPlayer1Turn == true) board[boardIndex] = "X"; else board[boardIndex] = "O";
			  numTurns++;
			  isPlayer1Turn = !isPlayer1Turn;
            }
          }
        }
      }
      
      if (CheckVictory(board) && isPlayer1Turn == false) {
        Console.WriteLine("Player 1 Wins!");
      } else if (CheckVictory(board) && isPlayer1Turn == true) {
        Console.WriteLine("Player 2 Wins!");
      } else {
        Console.WriteLine("It's a tie!");
      }
    }
  }
}
