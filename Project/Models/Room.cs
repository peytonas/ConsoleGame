using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public void Setup()
    {
      // NOTE initializes rooms
      // Room n = new Room("North", "you awake lying under a giant fallen log, in the middle of a sweltering junglescape...");
      // Room c = new Room("Center", "You're still not sure how you got here, but heading east or west seem to be your best options...");
      // Room w = new Room("West", "A large bush blocks your view of anything beyond it...");
      // Room e = new Room("East", "A nice boulder is all you can see at first glance...");
      // Room s = new Room("South", "Nothing notable besides some thick underbrush in the near distance...");
    }
  }
}