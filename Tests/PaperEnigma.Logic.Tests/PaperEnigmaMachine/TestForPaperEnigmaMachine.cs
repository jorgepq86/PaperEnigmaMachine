using System.Threading.Tasks;
using Autofac.Features.Indexed;
using Moq;
using NUnit.Framework;
using PaperEnigma.Logic.Abstractions;
using PaperEnigma.Logic.Enums;

namespace PaperEnigma.Logic.Tests.PaperEnigmaMachine
{
    public abstract class TestForPaperEnigmaMachine
    {
        protected readonly Mock<IIndex<RotorNumber, IRotor>> MoqRotorFactory = new();
        protected readonly Mock<IRotor> MoqRotorOne = new();
        protected readonly Mock<IRotor> MoqRotorTwo = new();
        protected readonly Mock<IRotor> MoqRotorThree = new();
        protected IPaperEnigmaMachine Subject;
        
        [SetUp]
        protected async Task TestForSetupAsync()
        {
            await SetupAsync().ConfigureAwait(false);
            Subject = await GivenAsync().ConfigureAwait(false);
            await WhenAsync().ConfigureAwait(false);
        }
        
        protected virtual Task SetupAsync() => Task.CompletedTask;

        private Task<IPaperEnigmaMachine> GivenAsync()
        {
            var newDachpcPaperEnigmaMachine = new DachpcPaperEnigmaMachine(MoqRotorFactory.Object);
            return Task.FromResult<IPaperEnigmaMachine>(newDachpcPaperEnigmaMachine);
        }

        protected abstract Task WhenAsync();

        [TearDown]
        protected virtual void TearDown()
        {
            MoqRotorFactory.Invocations.Clear();
            MoqRotorOne.Invocations.Clear();
            MoqRotorTwo.Invocations.Clear();
            MoqRotorThree.Invocations.Clear();
        }
    }
}