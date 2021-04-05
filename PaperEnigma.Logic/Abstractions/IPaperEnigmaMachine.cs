using System.Collections.Generic;

namespace PaperEnigma.Logic.Abstractions
{
    public interface IPaperEnigmaMachine
    {
        List<string> InputOutputData { get; }
        List<string> ReflectorData { get; }
        void SetInitialSettings(string initialSettings);
        string DecodeMessage(string message);
    }
}