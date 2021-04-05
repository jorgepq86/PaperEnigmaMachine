using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace PaperEnigma.Logic.Tests.Rotors.RotorOne
{
    public class WhenGetReturnIndex : TestForRotorOne
    {
        private int _newIndex;
        protected override Task WhenAsync()
        {
            Subject.SetInitialValue("M");
            _newIndex = Subject.GetReturnIndex(10);
            return Task.CompletedTask;
        }
        
        [Test]
        public void ThenNewIndexShouldBe()
        {
            _newIndex.Should().Be(1);
        }
    }
}