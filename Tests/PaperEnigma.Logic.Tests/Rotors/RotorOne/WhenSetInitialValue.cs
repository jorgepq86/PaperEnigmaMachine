using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace PaperEnigma.Logic.Tests.Rotors.RotorOne
{
    public class WhenSetInitialValue : TestForRotorOne
    {
        protected override Task WhenAsync()
        {
            Subject.SetInitialValue("M");
            return Task.CompletedTask;
        }

        [Test]
        public void TheInitialKeyPairShouldBe()
        {
            Subject.RotorValues.First().Should().BeEquivalentTo(("M","O"));
        }
    }
}