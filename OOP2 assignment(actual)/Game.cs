using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_actual_ {
  abstract class Game {
   
    protected abstract void _play(bool multiplayer, bool testing);

    public void Play(bool testing) {
      //pick ai or multiplayer
      bool multiplayer = true;
      string _input = "0";
      int _intInput;

      while (!int.TryParse(_input, out _intInput) || _intInput < 1 || _intInput > 2) {
        Console.WriteLine("Do you want to play the game" +
                          "\n[1] Multiplayer" +
                          "\n[2] Against AI");
        _input = Console.ReadLine()!;
      }

      if (_intInput  == 1) {
        multiplayer = true;
      }
      else {
        multiplayer = false;
      }
        _play(multiplayer, testing);
    }
  }
}
