using System.Collections.Generic;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IGameService
  {
    List<string> Messages { get; }
    void Setup(string playerName);

    void Reset();

    #region Console Commands

    //NOTE Stops the application
    void Quit();

    //NOTE Should display a list of commands to the console
    void Help();

    //NOTE Validate CurrentRoom.Exits contains the desired direction
    //NOTE if it does change the CurrentRoom
    void Go(string direction);
    void TakeItem(string itemName);
    void UseItem(string itemName);
    //NOTE Print the list of items in the players inventory to the console
    void Inventory();
    //NOTE Display the CurrentRoom Description, Exits, and Items
    void Look();

    #endregion
  }
}
