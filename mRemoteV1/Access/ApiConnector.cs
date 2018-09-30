using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mRemoteNG.Access
{
    public class ApiConnector : IApiConnector
    {
        public APIService ApiConnection { get; private set; } = default(APIService);
        private readonly string _apiHost;
        private readonly string _apiTenant;
        private readonly string _apiUsername;
        private readonly string _apiPassword;

        public bool IsConnected => throw new NotImplementedException();

        public ApiConnector(string apiHost, string tenant, string username, string password)
        {
            _apiHost = apiHost;
            _apiTenant = tenant;
            _apiUsername = username;
            _apiPassword = password;
            Initialize();
        }

        private void Initialize()
        {
            ApiConnection = new APIService(_apiHost);
        }


        public void Connect()
        {
            ApiConnection.Authenticate(_apiTenant, _apiUsername,_apiPassword);
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
