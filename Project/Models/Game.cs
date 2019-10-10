using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      // NOTE initializes rooms
      Room n1 = new Room("north", "Back where you started, better keep exploring...");
      Room c2 = new Room("center", "You're still not sure how you got here, but heading east or west seem to be your best options...");
      Room w3 = new Room("west", "A large bush blocks your view of anything beyond it...");
      Room e4 = new Room("east", "A nice boulder is all you can see at first glance...");
      Room s5 = new Room("south", "Nothing notable besides some thick underbrush in the near distance...");
      Room b6 = new Room("final", "A tyrannosaurus looms above you. Holding still won't help, no matter what the movies taught you...");
      //NOTE initializes relationships between rooms
      n1.Exits.Add("s", c2);

      c2.Exits.Add("n", n1);
      c2.Exits.Add("e", e4);
      c2.Exits.Add("s", s5);
      c2.Exits.Add("w", w3);

      w3.Exits.Add("e", e4);

      e4.Exits.Add("w", c2);

      s5.Exits.Add("n", c2);
      s5.Exits.Add("s", b6);

      b6.Exits.Add("n", s5);
      //NOTE add items to inventory


      //NOTE starting point
      CurrentRoom = n1;
    }
    public Game()
    {
      CurrentPlayer = new Player();
      Setup();
    }
  }
}