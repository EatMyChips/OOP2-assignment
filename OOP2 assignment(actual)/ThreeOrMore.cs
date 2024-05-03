using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OOP2_Assignment_actual_ {
  class ThreeOrMore : Game {

    public int Score1 { get; private set; } = 0;
    int Player1Turns = 0;
    public List<int> Scores1 { get; private set; } = new List<int>();
    public int Score2 { get; private set; } = 0;
    int Player2Turns = 0;
    public List<int> Scores2 { get; private set; } = new List<int>();
    List<Die> _dice = [];

    protected override (List<int> _scores1, List<int> _scores2) _play(bool multiplayer, bool testing) {
      Score1 = 0;
      Score2 = 0;
      Player1Turns = 0;
      Player2Turns = 0;

      while (Score1 < 20 || Score2 < 20) {
        if (!testing) {
          Console.WriteLine("----------------------------------------------");
          Console.WriteLine("Player 1 go");
          int _score1 = 0;
          _score1 = Game(true, false);
          Score1 += _score1;
          Scores1.Add(_score1);
          Player1Turns++;

          if (Score1 >= 20) {
            break;
          }

          Console.WriteLine("\n----------------------------------------------");
          if (multiplayer) {
            Console.WriteLine("Player 2 go");
          }
          else {
            Console.WriteLine("Ai go");
          }
          int _score2 = 0;
          _score2 = Game(multiplayer, false);
          Score2 += _score2;
          Scores2.Add(_score2);
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
        else {
          int _score1 = 0;
          _score1 = Game(false, true);
          Score1 += _score1;
          Scores1.Add(_score1);
          Player1Turns++;

          if (Score1 >= 20) {
            break;
          }

          int _score2 = 0;
          _score2 = Game(false, true);
          Score2 += _score2;
          Scores2.Add(_score2);
          Player2Turns++;
        }
      }

      Statistics.ThreeLeastRolls(Player1Turns);
      Statistics.ThreeLeastRolls(Player2Turns);
      Statistics.ThreeHighestScore(Score2);
      Statistics.ThreeHighestScore(Score1);
      return (Scores1, Scores2);
    }

    /// <summary>
    /// plays the main game functionality for one of the players
    /// </summary>
    /// <param name="player">is it a player or ai</param>
    /// <param name="testing">is it being run in testing mode</param>
    /// <returns>the score for that game</returns>
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
