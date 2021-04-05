using System.Collections.Generic;

namespace PaperEnigma.Logic.Rotors
{
    public class RotorTwo : RotorBase
    {
        public override (string, string) NotchKeyPair => ("E", "S");
        public override bool MustShift { get; set; } = false;
        public sealed override List<(string, string)> RotorValues { get; set; }

        public RotorTwo()
        {
            RotorValues = new List<(string, string)>
            {
                ("E","S"),("F","I"),("G","R"),("H","U"),("I","X"),("J","B"),("K","L"),("L","H"),("M","W"),
                ("N","T"),("O","M"),("P","C"),("Q","Q"),("R","G"),("S","Z"),("T","N"),("U","P"),("V","Y"),
                ("W","F"),("X","V"),("Y","O"),("Z","E"), ("A","A"),("B","J"),("C","D"),("D","K")
            };
        }
    }
}