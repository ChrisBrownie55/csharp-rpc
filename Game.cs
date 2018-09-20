using System;
using System.Collections.Generic;
using System.Threading;

namespace rock_paper_scissors {
  class Game {

    static Dictionary<string, string> Options = new Dictionary<string, string>() {
      { "rock", "scissors" },
      { "paper", "rock" },
      { "scissors", "paper" }
    };
    static List<string> Keys = new List<string>(Options.Keys);

    static Random rand = new Random();
    string RandomChoice() {
      return Keys[rand.Next(0, 3)];
    }

    string GetUserChoice() {
      Console.Write("Pick your poison (rock, paper, or scissors)? ");
      string option = Console.ReadLine().ToLower();
      if (!Options.ContainsKey(option)) {
        Console.WriteLine("Invalid option...");
        Thread.Sleep(500);
        Console.Clear();
        return GetUserChoice();
      }

      return option;
    }

    public Game() {
      bool playing = true;
      Console.WriteLine("Welcome to the JUNGLE (rock paper scissors)!");

      while (playing == true) {
        Console.Clear();
        string userChoice = GetUserChoice();
        string enemyChoice = RandomChoice();
        Console.WriteLine($"The enemy chose {enemyChoice}.");

        if (Options[userChoice] == enemyChoice) {
          Console.WriteLine("You win!");
        } else if (userChoice == enemyChoice) {
          Console.WriteLine("It's a tie...");
        } else {
          Console.WriteLine("You lose :(");
        }
        Console.Write("Would you like to keep playing (Y/n)");
        if (Console.ReadLine().ToLower() == "n") {
          playing = false;
        }
      }
    }
  }
}