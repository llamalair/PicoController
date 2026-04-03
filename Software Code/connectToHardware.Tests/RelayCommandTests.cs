// first unit test using Xunit 
// Xunit is a free open source unit testing tool for C#
using Xunit;
using connectToHardware.MVVM;

namespace connectToHardware.Tests
{
    public class RelayCommandTests
    {
        [Fact]
        public void Execute_CallsProvidedAction()
        {
            bool wasCalled = false;
            var command = new RelayCommand(() => wasCalled = true);

            command.Execute(null);

            Assert.True(wasCalled);
        }

        [Fact]
        public void CanExecute_AlwaysReturnsTrue()
        {
            var command = new RelayCommand(() => { });

            bool result = command.CanExecute(new object());

            Assert.True(result);
        }
    }
}