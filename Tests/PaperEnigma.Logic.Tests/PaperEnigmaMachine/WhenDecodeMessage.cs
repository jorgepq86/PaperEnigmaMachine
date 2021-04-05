using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PaperEnigma.Logic.Enums;

namespace PaperEnigma.Logic.Tests.PaperEnigmaMachine
{
    public class WhenDecodeMessage : TestForPaperEnigmaMachine
    {
        private string _decodedMessage;
        
        protected override Task SetupAsync()
        {
            MoqRotorThree.Setup(mth => mth.GetOneWayIndex(It.IsAny<int>())).Returns(1);
            MoqRotorTwo.Setup(mt => mt.GetOneWayIndex(It.IsAny<int>())).Returns(2);
            MoqRotorOne.Setup(mo => mo.GetOneWayIndex(It.IsAny<int>())).Returns(3);

            MoqRotorOne.Setup(mo => mo.GetReturnIndex(It.IsAny<int>())).Returns(4);
            MoqRotorTwo.Setup(mo => mo.GetReturnIndex(It.IsAny<int>())).Returns(5);
            MoqRotorThree.Setup(mo => mo.GetReturnIndex(It.IsAny<int>())).Returns(16);
            
            MoqRotorFactory.Setup(x => x[It.Is<RotorNumber>(r => r == RotorNumber.RotorOne)]).Returns(MoqRotorOne.Object);
            MoqRotorFactory.Setup(x => x[It.Is<RotorNumber>(r => r == RotorNumber.RotorTwo)]).Returns(MoqRotorTwo.Object);
            MoqRotorFactory.Setup(x => x[It.Is<RotorNumber>(r => r == RotorNumber.RotorThree)]).Returns(MoqRotorThree.Object);
            return base.SetupAsync();
        }
        
        protected override Task WhenAsync()
        {
            Subject.SetInitialSettings("MCK");
            _decodedMessage = Subject.DecodeMessage("E ");
            return Task.CompletedTask;
        }

        [Test]
        public void ThenDecodedMessageShouldBe()
        {
            _decodedMessage.Should().Be("Q ");
        }

        [Test]
        public void ThenOneWayIndexRotorsShouldBeCalled()
        {
            MoqRotorThree.Verify(mth => mth.GetOneWayIndex(It.IsAny<int>()), Times.Once);
            MoqRotorTwo.Verify(mth => mth.GetOneWayIndex(It.IsAny<int>()), Times.Once);
            MoqRotorOne.Verify(mth => mth.GetOneWayIndex(It.IsAny<int>()), Times.Once);
        }
        
        [Test]
        public void ThenReturnIndexRotorsShouldBeCalled()
        {
            MoqRotorThree.Verify(mth => mth.GetReturnIndex(It.IsAny<int>()), Times.Once);
            MoqRotorTwo.Verify(mth => mth.GetReturnIndex(It.IsAny<int>()), Times.Once);
            MoqRotorOne.Verify(mth => mth.GetReturnIndex(It.IsAny<int>()), Times.Once);
        }
    }
}