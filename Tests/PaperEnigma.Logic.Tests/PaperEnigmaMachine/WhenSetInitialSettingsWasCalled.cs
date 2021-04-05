using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PaperEnigma.Logic.Enums;

namespace PaperEnigma.Logic.Tests.PaperEnigmaMachine
{
    public class WhenSetInitialSettingsWasCalled : TestForPaperEnigmaMachine
    {
        protected override Task SetupAsync()
        {
            MoqRotorFactory.Setup(x => x[It.Is<RotorNumber>(r => r == RotorNumber.RotorOne)]).Returns(MoqRotorOne.Object);
            MoqRotorFactory.Setup(x => x[It.Is<RotorNumber>(r => r == RotorNumber.RotorTwo)]).Returns(MoqRotorTwo.Object);
            MoqRotorFactory.Setup(x => x[It.Is<RotorNumber>(r => r == RotorNumber.RotorThree)]).Returns(MoqRotorThree.Object);
            return base.SetupAsync();
        }

        protected override Task WhenAsync()
        {
            Subject.SetInitialSettings("MCK");
            return Task.CompletedTask;
        }

        [Test]
        public void RotorOneShouldBeInitialized()
        {
            MoqRotorOne.Verify(x => x.SetInitialValue(It.Is<string>(value => value == "M")), Times.Once);
        }
        
        [Test]
        public void RotorTwoShouldBeInitialized()
        {
            MoqRotorTwo.Verify(x => x.SetInitialValue(It.Is<string>(value => value == "C")), Times.Once);
        }
        
        [Test]
        public void RotorThreeShouldBeInitialized()
        {
            MoqRotorThree.Verify(x => x.SetInitialValue(It.Is<string>(value => value == "K")), Times.Once);
        }
    }
}