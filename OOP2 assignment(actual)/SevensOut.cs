using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_actual_ {
  class SevensOut : Game {


    public Die _die1{ private set; get;}
    public Die _die2{ private set; get;}
    protected override void _play(bool multiplayer, bool testing) {
      int _game1 = 0;
      int _game2 = 0;
      Console.WriteLine("Player 1 turn");
      _game1 = Game(true, false);
      if(multiplayer) {
        Console.WriteLine("Player 2 turn");
      }
      else {
        Console.WriteLine("AI turn");
      }
      _game2 = Game(multiplayer, false);

      if(_game1 > _game2) {
        Console.WriteLine("Player 1 wins");
      }
      else {
        if (multiplayer) {
          Console.WriteLine("Player 2 wins");
        }
        else {
          Console.WriteLine("Ai wins");
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int Game(bool player, bool testing) {
      
      int _total = 0;
      _die1 = new Die();
      _die2 = new Die();

      if (!testing) {
        Console.WriteLine("----------------------------------------------");
      } 
      while ((_die1.Value + _die2.Value) != 7) {
        if (!testing) {
          Console.WriteLine($"\nThe current total is: {_total}");
          if (player) {
            Console.Write("\nPress ENTER to roll");
            Console.ReadLine();
            Console.WriteLine("\nRolling...");
          }
          else {
            Console.WriteLine("\nBot rolling...");
          }

          Thread.Sleep(1000);
          Console.WriteLine($"\nThe first roll was: {_die1.roll()}");
          Console.WriteLine($"The second roll was: {_die2.roll()}");
        }
        else {
          _die1.roll();
          _die2.roll();
        }
        if(_die1.Value == _die2.Value) {
          _total += (_die1.Value + _die2.Value) * 2;
        }
        else {
          _total += _die1.Value + _die2.Value;
        }
      }
      if (!testing) {
        Console.WriteLine("\nGame Over!");
        Console.WriteLine($"The final total is: {_total}");
        Console.WriteLine("----------------------------------------------");
      }

      return _total;
    }

  }
}
