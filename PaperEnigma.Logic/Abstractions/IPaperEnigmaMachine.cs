using System.Collections.Generic;

namespace PaperEnigma.Logic.Abstractions
{
    public interface IPaperEnigmaMachine
    {
        void SetInitialSettings(string initialSettings);
        string DecodeMessage(string message);
    }
}