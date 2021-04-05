using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace PaperEnigma.Logic.Tests.Rotors.RotorOne
{
    public class WhenGetOneWayIndex : TestForRotorOne
    {
        private int _newIndex;
        protected override Task WhenAsync()
        {
            Subject.SetInitialValue("M");
            _newIndex = Subject.GetOneWayIndex(6);
            return Task.CompletedTask;
        }

        [Test]
        public void ThenNewIndexShouldBe()
        {
            _newIndex.Should().Be(6);
        }
    }
}