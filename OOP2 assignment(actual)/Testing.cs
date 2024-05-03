using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_actual_ {
  class Testing {
    SevensOut sevensOut = new SevensOut();
    ThreeOrMore threeOrMore = new ThreeOrMore();

    /// <summary>
    /// used to test the games
    /// </summary>
    public void TestGames() {
      int _intInput = 0;

      while (_intInput != 3) {
        string _input = "0";

        while (!int.TryParse(_input, out _intInput) || _intInput < 1 || _intInput > 3) {

          Console.WriteLine("Which game do you want to test?" +
                             "\n[1]Sevens Out" +
                             "\n[2]Three or more" +
                             "\n[3]Leave");
          _input = Console.ReadLine()!;
        }

        switch (_intInput) {
          case 1:
            for (int i = 0; i <= 1000; i++) {
              sevensOut.Game(false, true);
              Debug.Assert(sevensOut._die1.Value + sevensOut._die2.Value == 7 , "The values dont add up to equal 7");
            }
            Console.WriteLine("Testing done");
            break;
          case 2:
            for(int i = 0; i <= 1000; i++) {
              List<int> _scores1 = [];
              int total1 = 0;
              List<int> _scores2 = [];
              int total2 = 0;
              (_scores1, _scores2) = threeOrMore.Play(true);
              Debug.Assert(threeOrMore.Score1 <= 20 || threeOrMore.Score2 <= 20, "Both players went over 20");

              foreach(int j in _scores1) {
                total1 += j;
              }
              foreach(int j in _scores2) {
                total2 += j;
              }

              Debug.Assert(total1 == threeOrMore.Score1 || total2 == threeOrMore.Score2, "a score does not equal the right ammount");
            }
            Console.WriteLine("Testing done");
            break;
        }
      }
      Console.WriteLine("Leaving");
    }
  }
}
