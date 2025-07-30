using System;
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
	
	//checks in the guess length is 5 letters only
	static bool validGuess(string guess) {
		int guessLen = guess.Length;
		if (guessLen != 5) {
			return false;
		} else
			return true;
	}
	
	//checks if the guess is correct
	static void checkCorrect(char[] guessSplit, char[] randWordSplit) {
		for (int i = 0; i < 5; i++) {
			if (guessSplit[i] == randWordSplit[i]) {
				Console.WriteLine($"The letter {guessSplit[i]} is in the correct position!");
			} else if (Array.Exists(randWordSplit, c => c == guessSplit[i])) {
				Console.WriteLine($"The letter {guessSplit[i]} is somewhere in the word!");
			} else {
				Console.WriteLine($"The letter {guessSplit[i]} is not in the word. Try a different one!");
			}
		}
	}
    
    
    static void Main(string[] args) {
		
		//all words
        string[] wordList = {
        
        "apple", "crane", "ghost", "lemon", "storm", "chair", "bread", "tiger", "ocean", "plant",
        "magic", "globe", "house", "drive", "beach", "smile", "clock", "sound", "flame", "cloud", 
        "space", "dance", "water", "quick", "blank", "earth", "light", "music", "power", "dream", 
        "stone", "river", "grape", "round", "block", "shine", "brown", "green", "wheel", "peace", 
        "heart", "voice", "knife", "sword", "seven", "night", "truck", "glass", "paper", "phone", 
        "black", "white", "horse", "snake", "world", "flute", "piano", "radio", "coral", "field", 
        "table", "shelf", "grass", "roses", "sugar", "honey", "money", "solar", "super", "royal", 
        "trade", "fresh", "birth", "metal", "cabin"
            
        };
        
        //index testing array
        //char[] wordleGrid = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'q', 'w', 'e', 
        //'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x'};
		
		//30 chars
		char[] wordleGrid = { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 
					'*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'};
        
        
        Random rand = new Random();
        int randPick = rand.Next(0, 74);
        string randWord = wordList[randPick]; //picks random word to be guessed
		char[] randWordSplit = randWord.ToCharArray();
        int guessAttempts = 0;
		int offset = 0;
        
        Console.WriteLine("Welcome to Mini Wordle! You get 6 tries to guess the word!");
        
		//attempts begin
        while (guessAttempts < 6) {
          printGrid(wordleGrid);
          Console.Write("Input guess here: ");
          string guess = Console.ReadLine();

		  bool checkGuess = validGuess(guess);
		  if (checkGuess) {
			  char[] guessSplit = guess.ToCharArray();
			  
			  for (int i = 0; i < 5; i++) {
				  wordleGrid[i+offset] = guessSplit[i];
			  }
			  
			  checkCorrect(guessSplit, randWordSplit);
			  
			  offset += 5;
          	  guessAttempts++;
		  } 
		  else {
			  Console.WriteLine("Invalid guess, must be 5 characters long. Try again!");
			  continue;
		  }
		}
		
		printGrid(wordleGrid);
		
		Console.WriteLine($"The correct word was: {randWord}!");
		
	}
}
