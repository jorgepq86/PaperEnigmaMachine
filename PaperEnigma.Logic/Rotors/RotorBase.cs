using System.Collections.Generic;
using System.Linq;
using PaperEnigma.Logic.Abstractions;
using PaperEnigma.Utils;

namespace PaperEnigma.Logic.Rotors
{
    public abstract class RotorBase : IRotor
    {
        public abstract List<(string, string)> RotorValues { get; set; }
        public abstract (string, string) NotchKeyPair { get; }
        public abstract bool MustShift { get; set; }
        
        public void SetInitialValue(string initialValue)
        {
            int initialKeyPairIndex = RotorValues.FindIndex(v => v.Item1 == initialValue);
            RotorValues = RotorValues.Rotate(initialKeyPairIndex);
        }

        public int GetOneWayIndex(int index)
        {
            if (MustShift)
                RotorValues = RotorValues.Rotate(1);
            var letterKeyPair = RotorValues[index];
            int newIndex = RotorValues.FindIndex(t => t.Item1 == letterKeyPair.Item2);
            return newIndex;
        }

        public int GetReturnIndex(int index)
        {
            var letterKeyPair = RotorValues[index];
            int newIndex = RotorValues.FindIndex(t => t.Item2 == letterKeyPair.Item1);
            return newIndex;
        }

        public void NextRotorShift(IRotor nextRotor)
        {
            var letterKeyPair = RotorValues.Last();
            nextRotor.MustShift = letterKeyPair == NotchKeyPair;
        }
    }
}