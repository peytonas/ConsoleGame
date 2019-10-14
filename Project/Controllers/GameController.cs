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
    //FIXME data belongs in the service
    private bool playing = true;
    public void Run()
    {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine(@"
 ▄▄▄██▀▀▀█    ██  ██▀███   ▄▄▄        ██████   ██████  ██▓ ▄████▄      ▄▄▄██▀▀▀▒█████   █    ██  ██▀███   ███▄    █ ▓█████▓██   ██▓
   ▒██   ██  ▓██▒▓██ ▒ ██▒▒████▄    ▒██    ▒ ▒██    ▒ ▓██▒▒██▀ ▀█        ▒██  ▒██▒  ██▒ ██  ▓██▒▓██ ▒ ██▒ ██ ▀█   █ ▓█   ▀ ▒██  ██▒
   ░██  ▓██  ▒██░▓██ ░▄█ ▒▒██  ▀█▄  ░ ▓██▄   ░ ▓██▄   ▒██▒▒▓█    ▄       ░██  ▒██░  ██▒▓██  ▒██░▓██ ░▄█ ▒▓██  ▀█ ██▒▒███    ▒██ ██░
▓██▄██▓ ▓▓█  ░██░▒██▀▀█▄  ░██▄▄▄▄██   ▒   ██▒  ▒   ██▒░██░▒▓▓▄ ▄██▒   ▓██▄██▓ ▒██   ██░▓▓█  ░██░▒██▀▀█▄  ▓██▒  ▐▌██▒▒▓█  ▄  ░ ▐██▓░
 ▓███▒  ▒▒█████▓ ░██▓ ▒██▒ ▓█   ▓██▒▒██████▒▒▒██████▒▒░██░▒ ▓███▀ ░    ▓███▒  ░ ████▓▒░▒▒█████▓ ░██▓ ▒██▒▒██░   ▓██░░▒████▒ ░ ██▒▓░
 ▒▓▒▒░  ░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░░▓  ░ ░▒ ▒  ░    ▒▓▒▒░  ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░░ ▒░   ▒ ▒ ░░ ▒░ ░  ██▒▒▒ 
 ▒ ░▒░  ░░▒░ ░ ░   ░▒ ░ ▒░  ▒   ▒▒ ░░ ░▒  ░ ░░ ░▒  ░ ░ ▒ ░  ░  ▒       ▒ ░▒░    ░ ▒ ▒░ ░░▒░ ░ ░   ░▒ ░ ▒░░ ░░   ░ ▒░ ░ ░  ░▓██ ░▒░ 
 ░ ░ ░   ░░░ ░ ░   ░░   ░   ░   ▒   ░  ░  ░  ░  ░  ░   ▒ ░░            ░ ░ ░  ░ ░ ░ ▒   ░░░ ░ ░   ░░   ░    ░   ░ ░    ░   ▒ ▒ ░░  
 ░   ░     ░        ░           ░  ░      ░        ░   ░  ░ ░          ░   ░      ░ ░     ░        ░              ░    ░  ░░ ░     
                                                          ░                                                                ░ ░     
      ");
      Console.ForegroundColor = ConsoleColor.Red;
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
What do you do?
(type 'h' for help)
");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //FIXME you have to end the game at some point
      switch (command)
      {
        // case "y":
        //   _gameService.Reset();
        //   break;
        case "use":
          _gameService.UseItem(option);
          break;
        // FIXME remove this handle the yes no elsewhere
        // case "n":
        //   Environment.Exit(0);
        //   break;
        case "take":
          _gameService.TakeItem(option);
          Print();
          break;
        case "s":
          _gameService.Search();
          break;
        case "i":
          _gameService.Inventory();
          break;
        case "h":
          _gameService.Help();
          break;
        case "l":
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
      foreach (string message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      //REVIEW the controller shouldnt clear the message log
    }
  }
}