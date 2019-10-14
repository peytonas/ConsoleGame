using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    private bool playing = true;

    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void Go(string direction)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;
      string desc = _game.CurrentRoom.Description;
      int inv = _game.CurrentPlayer.Inventory.Count;
      if (from == to)
      {
        Messages.Add("do you like the idea of being eaten...? Better get moving.");
        return;
      }
      Messages.Add($@"Traveled from {from} to {to}. {desc}");
      // REVIEW No need to iterate more than once here... just use a find
      if (to == "west")
      {
        Item Item = _game.CurrentPlayer.Inventory.Find(x => x.Name == "scissors");
        if (_game.CurrentRoom.Blocked == true && Item.Name != "scissors")
        {
          Messages.Add(@"You startle a peaceful Stegosaurus feeding with her babies...In her fear, she rampages and you find yourself impaled by the massive spikes in her tail...
                                                       .*                                                    
                              ,((((,.   *#%##%%,%%(,  %%%##(                                                 
                              .#%%%%%&&%(((#%####%%%#(%#%%###.   .(                                          
                                .%%%%%%%%%%((#/##%%%%%(#((#(%(   ##//                                        
                                  #%%%&&%%%&%#/%##%%%%%%(&%#*(/ (%(//(#                                      
                          .%%%%%%, ,#%%%%&%##%(#%%#%&&&%#(%#((/ %##(//((                                     
                           %#(#%#%%%%#%%####%##%//&&%%&%##(%&%/%(/(((//                                    
                            #%%#%%%%%%%%%%%(((%%#(#%%%#%%%%####/###((#(                                    
                             %#%###(%%#%#&&&%#(((%#(###&(#&%%%%#%%/####(   #((/                              
                             %%#%%(((####%%%##//(#(#(%(#(%%&%#%%#(%((  %#(((/.                             
                      *(##%(((&&%(%&%#%#%#%#(*((/((((##(#((%%(#%&&%(%, %%##(/(#/                             
                       #/######%&%#((/(###/#***/#/(///((((%%%#%%%%%%#(,%%#%%#(/*                             
                        (##(*(#(((/((/(#((*/,*///(//#//*#*%//%#(&(%%%%%%%%(#(/*.                             
                   ,/,  #&#(/(***/(*(((/,.(///*,///#(//(###/%#(%%%%%##/%##(((                              
                  /(((((#%#(((/*/,,*//#((/*,**/(/*/***((/*,/#(##/#%&&%##%#%.                               
     .*           //%/*((%/*,,,,.,**//((//*,,*,/**///*,**((*/*#//(###(%%%(%%%#                               
      #/            #%#%/*,,,**//((#(#((/,,,/,*(***/**,***,(/*#(/(%/%#%#%#(##%%#(#                           
       #/, //       #(((,,*/***///(((#////,**,*//*.***,,,,***,*(((##/%###&%%#%%%#                            
       .##,/(#   .%/**,**/*((//((//.. ///*,,/*,*/,,/,,*,.***,,,///((#(#(#&&%#(%&..                           
         #(/,((////,**//(((*          .(****,,.***,,,,*,,,*,.***/(%(((/##((%#&%%#%#(*#,    ,####%%((/*.      
            (/*,,**///(/.              */****..//**,,**.*/**.,.**(#(//(/(/#(#%%&&%&%%####%##(**,***/,.     
             .((///(,                  ,**/,/.,*/,***,,*/,,,*,*,/*((/*//((((((#%%###///#(*(*/*(/***//(       
                                        */**,,./*#*****,.,*,.,,**/(/((*#/#*(((#///(///***/,*,,/(//*///.      
                                         *****,,//&,,*,,*,*,*,*,*(//#//**/*//(*/*,*,**////(.                 
                                         ,//**,**/#/(****,*.,.,,,*(///**,,***/(/,////(/                      
                                         *******/((%%%%#((((/(/(((,/(**,,*****///////                        
                                          (/**(//(#&&&&&( .(((((/.,*****(((//((//(,                          
                                          .((/((((&&&&&(        *,,,,,,,/(###.                               
                                           /(#/(((%%&&&%        **,,,,,*####(.                               
                                           %%#(#(%%%%%%&%*      /*(//,*((((#(                                
                       . .................*%##%%%%%&%#%#,....   /*/,**//(((/(                                
                                     ......%%%&%(%%,,,.........../*/*////((#%.                               
                                      ..../#((%(###%/,........,.,.*((/(//(/#%%.                              
                                         .(,*#(**(#/(...............*#((/(((#///.                            
                                                                ......(###(((#...                            
                                                                      .(#*(/(#(/.                            
                                                                       #(((((,*(,       
          !!!!GAME OVER!!!!");
          // GameOver();
        }
        else if (_game.CurrentRoom.Blocked == true)
        {
          UseItem("scissors");
          _game.CurrentRoom.Blocked = false;
        }

      }
      if (to == "final")
      {
        if (inv == 0)
        {
          Messages.Add("The mighty tyrannosaurus notices you immediately. With nothing to defend yourself, your final moments are fleeting. A deafening roar is all you hear before it ends...\n!!!!GAME OVER!!!!\n");
        }
        if (inv < 3 && inv > 0)
        {
          Messages.Add("The mighty tyrannosaurus notices you immediately. Without all the relics to defend yourself, your final moments are fleeting. A deafening roar is all you hear before it ends...\n!!!!GAME OVER!!!!\n");
        }
        else if (inv == 3)
        {
          Messages.Add("Thanks to the necessary relics you found, you successfully defeat the mighty tyrannosaurus and are able to continue your journey towards regaining your memory in peace...For now...\n****YOU WIN****\n");
        }
        // GameOver();
      }
    }
    public void Help()
    {
      Messages.Add("Type:\ngo + (n)orth, (s)outh, (e)ast, (w)est: travel in specified direction\n(l)ook: repeats location and room description\n(s)earch: searches the immediate area for hints\n(t)ake: takes item found in current room\n(i)nventory: checks player inventory\n(u)se: uses an item in your inventory\n(q)uit: quits application");
    }
    public void Inventory()
    {
      Messages.Add("Inventory:");
      for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      {
        Messages.Add($"{_game.CurrentPlayer.Inventory[i].Name}");
      }
    }

    public void Look()
    {
      string current = _game.CurrentRoom.Name;
      string desc = _game.CurrentRoom.Description;
      Messages.Add($"You're still {current}. {desc}");
    }
    public void Search()
    {
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Add("Nothing to be found here...");
        return;
      }
      foreach (Item i in _game.CurrentRoom.Items)
      {
        Messages.Add($"After some exploring you find {i.Name}. \n{i.Description}\n");
      }
    }
    public void Quit()
    {
      Environment.Exit(0);
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      // throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {
      // throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Item i = new Item(null, null, null, false);
      foreach (Item item in _game.CurrentRoom.Items)
      {
        if (item.Name == itemName)
        {
          i = item;
        }
      }
      if (i.Name != null)
      {
        _game.CurrentRoom.Items.Remove(i);
        _game.CurrentPlayer.Inventory.Add(i);
        Messages.Add($"You're not sure how this could help, but better safe than sorry! You grab the {i.Name} and take it with you...");
      }
      else
      {
        Messages.Add("There's no " + itemName + "here...");
      }
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      if (_game.CurrentRoom.Name == "west")
      {
        foreach (Item i in _game.CurrentPlayer.Inventory)
        {
          if (i.Name.ToLower() == "scissors")
          {
            _game.CurrentRoom.Blocked = false;
            Messages.Add("You stealthily chop down the brush in front of you and find a clearing. Gentle thuds fade in the distance...Good thing you didn't come bursting in here without those scissors!");
          }
          // else
          // {
          //   Messages.Add("You don't have any way to cut through here...Better look around elsewhere first.");
          // }
        }
      }
    }
    public void GameOver()
    {
      Console.Clear();
      Console.WriteLine("Play again? (y) / (n)");
    }
  }
}