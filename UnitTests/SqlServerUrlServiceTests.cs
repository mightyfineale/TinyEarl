using System.Threading.Tasks;
using BlazorApp.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace BlazorApp.UnitTests {
    
    [TestFixture]
    [Ignore("Used For testing connection and stored procedure expected returns, Should not be run as part of production suite.")]
    public class SqlServerUrlServiceTests {
        
        private SqlServerUrlService service;
        private Mock<IConfiguration> mockIConfig;
        
        [SetUp]
        public void SetUp() {
            mockIConfig = new Mock<IConfiguration>(MockBehavior.Loose);
            mockIConfig.Setup(m => m[Constants.ConfigurationConnectionStringKey])
                .Returns("Server=;Database=;User Id=;Password=;");
            service = new SqlServerUrlService(mockIConfig.Object);
        }

        [Test]
        public async Task CallDb() {
            var dbReturn = await service.GetFullUrl("ae");
            Assert.True(!string.IsNullOrWhiteSpace(dbReturn));
        }
    }
}