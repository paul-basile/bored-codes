using System;
using System.Collections.Generic;

namespace Game {
	class RPS
	{
		//scores and rule dictionary
		static Dictionary<char, char> whatBeatsWhat = new Dictionary<char, char> {
			{'R', 'S'},
			{'S', 'P'},
			{'P', 'R'}
		};
			
		//if the score is 3 for one player, they win
		static bool CheckWin(int playerScore, int aiScore) {
			if (playerScore == 3 || aiScore == 3) return true; else return false;
		}
		
		static void Main()
		{
			int playerScore = 0, aiScore = 0;
			Random rnd = new Random();
			string chars = "RPS";
			Console.WriteLine("Welcome to Rock Paper Scissors! Play a Best of 5 with the computer!");
			
			while (!CheckWin(playerScore, aiScore)) {
				Console.WriteLine("Input R for Rock, P for Paper, S for Scissors.");
				char choice = Convert.ToChar(Console.ReadLine().ToUpper());	//your pick
    			int num = rnd.Next(0, chars.Length);
    			char aiChoice = chars[num]; //ai pick
				Console.WriteLine("AI Choice: " + aiChoice);
				
				//who won the round?
				if (whatBeatsWhat[choice] == aiChoice) {
					Console.WriteLine("Player gets a point!");
					playerScore += 1;
				} 
				else if (whatBeatsWhat[aiChoice] == choice) {
					Console.WriteLine("Computer gets a point!");
					aiScore += 1;
				} else {
					Console.WriteLine("Tie, no points!");
				}
				
				
				Console.WriteLine("Current Scores\nPlayer: " + playerScore);
				Console.WriteLine("Computer Score: " + aiScore);
				CheckWin(playerScore, aiScore);
			}
		}
	}
}
