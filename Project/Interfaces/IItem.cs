using System.Collections.Generic;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IItem
  {
    IRoom Location { get; set; }
    string Name { get; set; }
    string Description { get; set; }
  }
}