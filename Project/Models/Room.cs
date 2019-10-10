using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IItem> Items { get; set; }
    public Dictionary<string, IImage> Images { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public void AddExit(IRoom room)
    {
      Exits.Add(room.Name, room);
    }
    public IRoom Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      return this;
    }
    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<IItem>();
      Images = new Dictionary<string, IImage>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}