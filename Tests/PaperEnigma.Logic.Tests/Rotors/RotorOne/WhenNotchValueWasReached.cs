using System.Threading.Tasks;
using NUnit.Framework;

namespace PaperEnigma.Logic.Tests.Rotors.RotorOne
{
    public class WhenNotchValueWasReached : TestForRotorOne
    {
        protected override Task WhenAsync()
        {
            Subject.SetInitialValue("R");
            Subject.NextRotorShift(MoqNextRotor.Object);
            return Task.CompletedTask;
        }

        [Test]
        public void ThenNextRotorShouldBeShiftedUp()
        {
            MoqNextRotor.VerifySet(r => r.MustShift = true);
        }
    }
}