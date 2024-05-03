using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace OOP2_Assignment_actual_ {
  static class Statistics {

    public static int[] statsSevens = new int[2];
    public static int[] statsThree = new int[2];
  
    /// <summary>
    /// allows the player to view the leaderboards
    /// </summary>
    public static void ViewStatistics () {
      int _intInput = 0;

      while (_intInput != 3) {
        string _input = "0";

        while (!int.TryParse(_input, out _intInput) || _intInput < 1 || _intInput > 3) {

          Console.WriteLine("\nWhich game do you want to view statistics for?" +
                             "\n[1]Sevens Out" +
                             "\n[2]Three or more" +
                             "\n[3]Leave");
          _input = Console.ReadLine()!;

          
        }

        switch (_intInput) {
          case 1:
            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine($"sevens out stats" +
                              $"\nhigh score: {statsSevens[0]}" +
                              $"\nmost rolls: {statsSevens[1]}");
            break;
          case 2:
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"three or more stats" +
                              $"\nLeast rolls: {statsThree[0]}" +
                              $"\nHighest score: {statsThree[1]}");
            break;
        }
      }
      Console.WriteLine("Leaving");
    }

    /// <summary>
    /// checks if the value is a high score
    /// </summary>
    /// <param name="Score">the score to check</param>
    public static void SevensHighScore(int Score) {
      if(Score > statsSevens[0]) {
        statsSevens[0] = Score;
      }
    }

    /// <summary>
    /// checks if the value is the most rolls
    /// </summary>
    /// <param name="rolls">the rolls to check</param>
    public static void SevensMostRolls(int rolls) {
      if (rolls > statsSevens[1]) {
        statsSevens[1] = rolls;
      }
    }

    /// <summary>
    /// checks if the value is the least ammount of rolls
    /// </summary>
    /// <param name="rolls">the rolls to check</param>
    public static void ThreeLeastRolls(int rolls) {
      if(rolls < statsThree[0]) {
        statsThree[0] = rolls;
      }
    }

    /// <summary>
    /// checks if the score is the highest
    /// </summary>
    /// <param name="score">the score to check</param>
    public static void ThreeHighestScore(int score) {
      if (score > statsThree[0]) {
        statsThree[1] = score;
      }
    }
    /// <summary>
    /// code to run on start
    /// </summary>
    public static void OnStart() {
      statsThree[0] = 100000;
    }
  }
}
