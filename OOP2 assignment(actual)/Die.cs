using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment_actual_ {
  class Die {

    public int Value { get; private set; }
    private static Random _rand = new Random();

    //Method

    /// <summary>
    /// rolls a 6 sided dice
    /// </summary>
    /// <returns>
    /// the rolled value
    /// </returns>
    public int roll() {
      Value = _rand.Next(1, 7);

      return Value;
    }
  }
}
