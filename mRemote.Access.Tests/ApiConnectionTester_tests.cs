using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mRemote.Access.API;

namespace mRemote.Access.Tests
{
    [TestClass]
    public class ApiConnectionTester_tests
    {
        private ApiConnectionTester _apiConnectionTester;

        private string apiUrl = "http://localhost:21021/";

        public ApiConnectionTester_tests()
        {
            _apiConnectionTester = new ApiConnectionTester();
        }


        [TestMethod]
        public async Task TestCanILogInethod1()
        {
            //Arrange
            var tenantid = 2;
            var username = "phill.morton@theaccessgroup.com";
            var password = "123qwe";

            //Act
            _apiConnectionTester.Init(apiUrl, tenantid);
            var connectionTestResult = await _apiConnectionTester.TestConnectivity(username, password);

            //Assert
            Assert.IsNotNull(connectionTestResult);
            Assert.AreEqual(3, connectionTestResult.UserId);
        }

        [TestMethod]
        public async Task TestDoesTenantExist()
        {
            //Arrange
            var tennant = "Access";
            _apiConnectionTester.Init(apiUrl, null);
            var connectionTestResult = await _apiConnectionTester.ValidateTennant(tennant);
            //Act
        
            //Assert
            Assert.AreEqual(2, connectionTestResult.TenantId);
            Assert.IsNotNull(connectionTestResult);
        }
    }
}
