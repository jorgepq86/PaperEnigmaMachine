using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PaperEnigma.Logic.Abstractions;

namespace PaperEnigma.Logic.Tests.Rotors
{
    public abstract class TestForRotor
    {
        protected readonly Mock<IRotor> MoqNextRotor = new ();
        
        protected IRotor Subject;
        
        [SetUp]
        protected async Task TestForSetupAsync()
        {
            await SetupAsync().ConfigureAwait(false);
            Subject = await GivenAsync().ConfigureAwait(false);
            await WhenAsync().ConfigureAwait(false);
        }
        
        protected virtual Task SetupAsync() => Task.CompletedTask;

        protected abstract Task<IRotor> GivenAsync();

        protected abstract Task WhenAsync();

        [TearDown]
        protected virtual void TearDown()
        {
            MoqNextRotor.Invocations.Clear();
        }
    }
}