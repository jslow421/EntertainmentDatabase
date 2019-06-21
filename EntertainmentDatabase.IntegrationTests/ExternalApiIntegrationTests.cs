using EntertainmentDatabase.Services;
using Xunit;

namespace EntertainmentDatabase.IntegrationTests
{
    public class ExternalApiIntegrationTests
    {
        [Fact]
        public async void TestUpcItemConnection()
        {
            var upcDataManager = new UpcDataManager();
            var result = await upcDataManager.GetItemDetailsFromExternalApi("786936816365");
            
            Assert.True(result.Code.Equals("OK"));
        }
    }
}