using System.Collections.Generic;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IImage
  {
    string Location { get; set; }
    Dictionary<string, IRoom> Images { get; set; }
  }
}
