using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OOP2_Assignment_actual_ {
  class ThreeOrMore : Game {

    int Score1 = 0;
    int Player1Turns = 0;
    int Score2 = 0;
    int Player2Turns = 0;
    List<Die> _dice = [];

    protected override void _play(bool multiplayer, bool testing) {
      while (Score1 < 20 || Score2 < 20) {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Player 1 go");
        Score1 += Game(true, false);
        Player1Turns++;

        Console.WriteLine("\n----------------------------------------------");
        if (multiplayer) {
          Console.WriteLine("Player 2 go");
        }
        else {
          Console.WriteLine("Ai go");
        }
        Score2 += Game(multiplayer, false);
        Player2Turns++;

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Current Scores:");
        Console.WriteLine($"Player 1 score {Score1}");
        if (multiplayer) {

          Console.WriteLine($"Player 2 score {Score2}");
        }
        else {
          Console.WriteLine($"AI score {Score2}");
        }
      }
    }

    public int Game(bool player , bool testing) {
      _dice = [];

      for (int i = 0; i < 5; i++) {
        _dice.Add( new Die());
      }
      List<Die> _indexOfReroll = new List<Die>(_dice);

      int _longestStreak = 0;
      
      while (_longestStreak < 3) {
        foreach (Die die in _indexOfReroll) {
          die.roll();
        }

        if (!testing) {
          if (player) {
            Console.Write("Press ENTER to roll");
            Console.ReadLine();
            Console.WriteLine("Rolling...");
          }
          else {
            Console.WriteLine("Ai rolling...");
          }
          Thread.Sleep(1000);

          showRolls();
        }

        int _longestValue = 0;
        foreach (Die die in _dice) {
          int _currentStreak = 0;
          var diceOfSameType = (from die2 in _dice
                                where die2.Value == die.Value
                                select die2).ToList();

          _currentStreak = diceOfSameType.Count();
          if (_currentStreak > _longestStreak) {
            _longestStreak = _currentStreak;
            _longestValue = die.Value;
          }
        }

        if (_longestStreak < 3 && player) {
          string _input = "0";
          int _intInput;
          if (testing) {
            _input = "2";
          }

          while (!int.TryParse(_input, out _intInput) || _intInput < 1 || _intInput > 2) {
            Console.WriteLine("\nDo you want to" +
                              "\n[1] roll all dice again" +
                              "\n[2] roll none duplicate dice again");
            _input = Console.ReadLine()!;
          }
          if (_intInput == 1) {
            _indexOfReroll = new List<Die>(_dice);
          }
          else {
            _indexOfReroll = (from die in _dice
                              where die.Value != _longestValue
                              select die).ToList();
          }
        }
        else if (!player) {
          _indexOfReroll = (from die in _dice
                            where die.Value != _longestValue
                            select die).ToList();
        }
      }

      int _score = 0;
      switch (_longestStreak) {
        case 3:
          _score = 3;
          break;
        case 4:
          _score = 6;
          break;
        case 5:
          _score = 12;
          break;
      }
      
      return _score;
    }

    private void showRolls() {
      var diceRolls = from die in _dice
                      select die.Value;
      Console.WriteLine($"the rolls were: {string.Join(", ", diceRolls)}");
    }
  }
}
