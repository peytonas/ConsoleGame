using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Image
  {
    public string Location { get; set; }
    public Image(string location)
    {
      Location = location;
    }
  }
}