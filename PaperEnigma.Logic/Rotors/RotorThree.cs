using System.Collections.Generic;

namespace PaperEnigma.Logic.Rotors
{
    public class RotorThree : RotorBase
    {
        public override (string, string) NotchKeyPair => ("V", "M");
        public override bool MustShift { get; set; } = true;
        public sealed override List<(string, string)> RotorValues { get; set; }

        public RotorThree()
        {
            RotorValues = new List<(string, string)>
            {
                ("V","M"),("W","U"),("X","S"),("Y","Q"),("Z","O"),("A","B"),("B","D"),("C","F"),("D","H"),
                ("E","J"),("F","L"),("G","C"),("H","P"),("I","R"),("J","T"),("K","X"),("L","V"),("M","Z"),
                ("N","N"),("O","Y"),("P","E"),("Q","I"),("R","W"),("S","G"),("T","A"),("U","K")
            };
        }
    }
}