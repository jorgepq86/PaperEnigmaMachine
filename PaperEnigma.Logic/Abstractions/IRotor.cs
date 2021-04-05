using System.Collections.Generic;

namespace PaperEnigma.Logic.Abstractions
{
    public interface IRotor
    {
        List<(string, string)> RotorValues { get; set; }
        (string, string) NotchKeyPair { get; }
        bool MustShift { get; set; }
        void SetInitialValue(string initialValue);
        int GetOneWayIndex(int index);
        int GetReturnIndex(int index);
        void NextRotorShift(IRotor nextRotor);
    }
}