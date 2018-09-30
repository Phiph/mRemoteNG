using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mRemoteNG.Access;

namespace mRemote.Access.Tests
{
    [TestClass]
    public class ApiService_tests
    {
        private APIService _apiService { get; set; }


        private string url => "http://localhost:21021/";
        private string tenantId => "Access";

        private string username => "phill.morton@theaccessgroup.com";

        private string password => "123qwe";


        public ApiService_tests()
        {
            _apiService = new APIService(url);
            _apiService.Authenticate(tenantId, username, password);
        }

        [TestMethod]
        public void Can_I_CountMyUsers()
        {

            Assert.AreEqual(1,_apiService.GetUsers().TotalCount);
        }
    }
}
