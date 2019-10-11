using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Image : IImage
  {
    public IRoom Location { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Image(string name, string description, IRoom location)
    {
      Name = name;
      Description = description;
      Location = location;
    }
  }
}