using System.Collections.Generic;

namespace PaperEnigma.Logic.Rotors
{
    public class RotorOne : RotorBase
    {
        public override (string, string) NotchKeyPair => ("Q", "X");
        public override bool MustShift { get; set; } = false;
        public sealed override List<(string, string)> RotorValues { get; set; }

        public RotorOne()
        {
            RotorValues = new List<(string, string)>
            {
                ("Q","X"),("R","U"),("S","S"),("T","P"),("U","A"),("V","I"),("W","B"),("X","R"),("Y","C"),
                ("Z","J"),("A","E"),("B","K"),("C","M"),("D","F"),("E","L"),("F","G"),("G","D"),("H","Q"),
                ("I","V"),("J","Z"),("K","N"),("L","T"), ("M","O"),("N","W"),("O","Y"),("P","H")
            };
        }
    }
}