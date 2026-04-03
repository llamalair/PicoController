// first unit test using Xunit 
// Xunit is a free open source unit testing tool for C#
using Xunit;
using connectToHardware.MVVM;

namespace connectToHardware.Tests
{
    public class RelayCommandTests
    {
        [Fact] // tells Xunit this method is a test
        public void Execute_CallsProvidedAction()
        {
            bool wasCalled = false;
            var command = new RelayCommand(_ => wasCalled = true);

            command.Execute(null);

            Assert.True(wasCalled);
        }

        [Fact]
        public void CanExecute_AlwaysReturnsTrue()
        {
            var command = new RelayCommand(_ => { });

            bool result = command.CanExecute(null);

            Assert.True(result);
        }
    }
}
