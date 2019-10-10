using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public List<Item> Inventory { get; set; }

    public void Setup()
    {
      //NOTE initializes players
      // Player ps = new Player("P-SON");
      // Player cs = new Player("C-SON");
      // Player dm = new Player("D$");
      Inventory.AddRange(new Item[] { });
    }
    public Player(string name, List<Item> inventory)
    {
      Name = name;
      Inventory = new List<Item>();
      Setup();
    }
  }
}