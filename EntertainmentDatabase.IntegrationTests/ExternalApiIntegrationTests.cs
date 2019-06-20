using EntertainmentDatabase.Services;
using Xunit;

namespace EntertainmentDatabase.IntegrationTests
{
    public class ExternalApiIntegrationTests
    {
        [Fact]
        public async void TestUpcItemConnection()
        {
            // todo If keeping this test it will need to be updated. Will essentially always pass
            var upcDataManager = new UpcDataManager();
            var result = await upcDataManager.GetItemDetailsFromExternalApi("786936816365");
            
            Assert.NotNull(result);
        }
    }
}