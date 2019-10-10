using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public void Setup()
    {
      //NOTE initializes items 
      Item r = new Item("Rock", "Your friends always made fun of you for hoarding, but they just don't understand. Better keep it.");
      Item p = new Item("Paper", "A mysterious, single sheet of paper. You found it lying next to you when you woke up.");
      Item s = new Item("Scissors", "You probably shouldn't run around with these, but they seem important.");
    }
    public Item(string name, string description)
    {
      Name = name;
      Description = description;
      Setup();
    }
  }
}