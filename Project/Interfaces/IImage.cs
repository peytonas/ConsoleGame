using System.Collections.Generic;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IImage
  {
    IRoom Location { get; set; }
    string Name { get; set; }
    string Description { get; set; }
  }
}