using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();
    private bool playing = true;

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    //FIXME data belongs in the service
    public void Run()
    {
      _gameService.Reset();
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
      _gameService.Print();
      while (playing)
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
      Console.Clear();
      //NOTE this will take the user input and parse it into a command and option.
      //FIXME you have to end the game at some point
      switch (command)
      {
        case "use":
          _gameService.UseItem(option);
          break;
        case "take":
          _gameService.TakeItem(option);
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
        case "reset":
        case "yes":
          Run();
          break;
        case "no":
        case "q":
        case "quit":
        case "exit":
        case "close":
          Environment.Exit(0);
          break;
      }
    }
  }
}