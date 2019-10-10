using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      Console.Clear();
      Console.WriteLine("You awake lying under a giant fallen log, in the middle of a sweltering junglescape...What's the plan?");
      while (true)
      {
        GetUserInput();
        Update();
      }
    }
    private void Update()
    {
      Console.Clear();
      foreach (string message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine(@"
What would you like to do?
(type 'h' for help)
");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      switch (command)
      {
        case "h":
          _gameService.Help();
          break;
        case "look":
          _gameService.Look();
          break;
        case "go":
          _gameService.Go(option);
          break;
        case "q":
        case "quit":
        case "exit":
        case "close":
          Environment.Exit(0);
          break;
      }
      //NOTE IE: take silver key => command = "take" option = "silver key"

    }

    //NOTE this should print your messages for the game.
    private void Print()
    {

    }
  }
}