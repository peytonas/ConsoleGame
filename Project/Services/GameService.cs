using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void Go(string direction)
    {
      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;
      string desc = _game.CurrentRoom.Description;
      if (from == to)
      {
        Messages.Add("do you like the idea of being eaten...? MOVE.");
        return;
      }
      Messages.Add($@"Traveled from {from} to {to}. {desc}
      
      ");
    }
    public void Help()
    {
      Messages.Add("Type: \ngo + (n)orth, (s)outh, (e)ast, (w)est: travel in specified direction.\n(l)ook: repeats location and room description. \n(q)uit: quits application.");
    }

    public void Inventory()
    {
      // throw new System.NotImplementedException();
    }

    public void Look()
    {
      string current = _game.CurrentRoom.Name;
      string desc = _game.CurrentRoom.Description;
      Messages.Add($"You're still {current}. {desc}");
    }
    public void Search()
    {
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Add("Nothing else to be found here...");
        return;
      }
      foreach (Item i in _game.CurrentRoom.Items)
      {
        Messages.Add($"After some exploring you find {i.Name}. \n{i.Description}\n");
      }
    }

    public void Quit()
    {
      // throw new System.NotImplementedException();
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      // throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
      // throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {



      // throw new System.NotImplementedException();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      // throw new System.NotImplementedException();
    }
  }
}