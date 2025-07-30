using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
	//prints the grid
	static void printGrid(char[] grid) {
		for (int i = 0; i < 6; i++) {
			for (int j = 0; j < 5; j++) {
				Console.Write(grid[(i*4+j)+i] + " ");
			}
			Console.WriteLine();
		}
	}
	//checks in the guess length is 5 letters only and that characters are A-Z
	static bool validGuess(string guess) {
		if (!(guess.All(char.IsLetter))) { return false; }
		int guessLen = guess.Length;
		if (guessLen != 5) { return false; } else { return true; }
	}
	
  	//checks if the guess is correct
	static void checkCorrect(char[] guessSplit, char[] randWordSplit, List<char> recordedCorrectGuesses) {
		for (int i = 0; i < 5; i++) {
			if (guessSplit[i] == randWordSplit[i]) {
				Console.WriteLine($"The letter {guessSplit[i]} is in the correct position!");
				recordedCorrectGuesses.Add(guessSplit[i]);
			} else if (Array.Exists(randWordSplit, c => c == guessSplit[i])) {
				Console.WriteLine($"The letter {guessSplit[i]} is somewhere in the word!");
			} else {
				Console.WriteLine($"The letter {guessSplit[i]} is not in the word. Try a different one!");
			}
		}
	}
	
	static void Main(string[] args) {
		//all words
		string[] wordList = { "apple", "crane", "ghost", "lemon", "storm", "chair", "bread", "tiger", "ocean", "plant",
			"magic", "globe", "house", "drive", "beach", "smile", "clock", "sound", "flame", "cloud", 
			"space", "dance", "water", "quick", "blank", "earth", "light", "music", "power", "dream", 
			"stone", "river", "grape", "round", "block", "shine", "brown", "green", "wheel", "peace", 
			"heart", "voice", "knife", "sword", "seven", "night", "truck", "glass", "paper", "phone", 
			"black", "white", "horse", "snake", "world", "flute", "piano", "radio", "coral", "field", 
			"table", "shelf", "grass", "roses", "sugar", "honey", "money", "solar", "super", "royal", 
			"trade", "fresh", "birth", "metal", "cabin" };
		
		//30 chars
		char[] wordleGrid = { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 
			'*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'};
		
		Random rand = new Random();
		int randPick = rand.Next(0, 74);
		string randWord = wordList[randPick]; //picks random word to be guessed
		char[] randWordSplit = randWord.ToCharArray();
		int guessAttempts = 0;
		int offset = 0;
		var rCG = new List<char>();
		
		Console.WriteLine("Welcome to Mini Wordle! You get 6 tries to guess the word!");
		
		//attempts begin
		while (guessAttempts < 6 && rCG.Distinct().Count() != 5) {
			printGrid(wordleGrid);
			Console.Write("Input guess here: ");
			string guess = Console.ReadLine();
			
			bool checkGuess = validGuess(guess);
			if (checkGuess) {
				char[] guessSplit = guess.ToCharArray();
				
				for (int i = 0; i < 5; i++) {
					wordleGrid[i+offset] = guessSplit[i];
				}

				//checks for any letters in the word or in the correct position
				checkCorrect(guessSplit, randWordSplit, rCG);
				
				offset += 5;
				guessAttempts++;
		        }
			else { //condition only met when the guess isn't 5 characters, attempts are not counted
				Console.WriteLine("Invalid guess. Word must only contain letters A-Z and be 5 characters long. Try again!");
				continue;
			}
		}
		
		if (rCG.Distinct().Count() == 5) {
			printGrid(wordleGrid);
			Console.WriteLine($"You guessed the correct word, {randWord}, in {guessAttempts} attempts! Nice job!");
		} else {
			printGrid(wordleGrid);
			Console.WriteLine($"The correct word was: {randWord}. Good try!");
		}
	}
}
