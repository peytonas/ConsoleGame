using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Item : IItem
  {
    public IRoom Location { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Item(string name, string description, IRoom location)
    {
      Name = name;
      Description = description;
      Location = location;
    }
  }
}