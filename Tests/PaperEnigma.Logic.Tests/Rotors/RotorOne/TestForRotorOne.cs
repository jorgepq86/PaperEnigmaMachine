using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PaperEnigma.Logic.Abstractions;

namespace PaperEnigma.Logic.Tests.Rotors.RotorOne
{
    [TestFixture]
    public abstract class TestForRotorOne : TestForRotor
    {
        protected override Task<IRotor> GivenAsync()
        {
            var rotorOne = new Logic.Rotors.RotorOne();
            return Task.FromResult<IRotor>(rotorOne);
        }
    }
}