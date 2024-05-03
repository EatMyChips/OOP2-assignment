using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_actual_ {
  abstract class Game {

    /// <summary>
    /// plays either game
    /// </summary>
    /// <param name="multiplayer">is the game being played multiplayer</param>
    /// <param name="testing">is the game being played in testing mode</param>
    /// <returns>the scores for the testing class</returns>
    protected abstract (List<int> _scores1, List<int> _scores2) _play(bool multiplayer, bool testing);

    /// <summary>
    /// plays either game and asks the user if they want to play in multiplayer
    /// </summary>
    /// <param name="testing">is the game being run in testing mode</param>
    /// <returns>the scores for the testing class</returns>
    public (List<int> Scores1, List<int> Scores2) Play(bool testing) {
      //pick ai or multiplayer
      bool multiplayer = true;
      string _input = "0";
      int _intInput;
      

      if (testing) {
        _input = "2";
      }

      while (!int.TryParse(_input, out _intInput) || _intInput < 1 || _intInput > 2) {
        Console.WriteLine("Do you want to play the game" +
                          "\n[1] Multiplayer" +
                          "\n[2] Against AI");
        _input = Console.ReadLine()!;
      }

      if (_intInput == 1) {
        multiplayer = true;
      }
      else {
        multiplayer = false;
      }

      List<int> _scores1 = [];
      List<int> _scores2 = [];

      (_scores1, _scores2) = _play(multiplayer, testing);

      return (_scores1, _scores2);
    }
    
  }
}
