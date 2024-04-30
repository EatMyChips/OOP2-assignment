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
            Console.WriteLine("sevens out test");
            for (int i = 0; i <= 1000; i++) {
              sevensOut.Game(false, true);
              Debug.Assert(sevensOut._die1.Value + sevensOut._die2.Value == 7 , "The values dont add up to equal 7");
            }
            break;
          case 2:
            Console.WriteLine("three or more test");
            for(int i = 0; i <= 1000; i++) {
              Debug.Assert(threeOrMore.Play(true) ,);
            }
            break;
        }
      }
      Console.WriteLine("Leaving");
    }
  }
}
