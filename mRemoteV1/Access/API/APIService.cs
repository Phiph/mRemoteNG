using mRemote.Access.Client.Api;
using mRemote.Access.Client.Client;
using mRemote.Access.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mRemoteNG.Access
{
    public class APIService
    {
        private Configuration _apiConfig { get; set; }

        private ApiClient _apiClient { get; set; }

        private AuthenticateResultModel _authResult { get; set; }

        public APIService(string apiUrl)
        {
            _apiConfig = new Configuration
            {
                BasePath = apiUrl 
            };
        }

        public void Authenticate(string tenantname, string username, string password)
        {
            int tenantId;
            int.TryParse(tenantname, out tenantId);
            if (tenantId == 0)
            {
                tenantId = getTenantId(tenantname);
            }
            
            _authResult = GetAccessToken(tenantId.ToString(), username, password);
            _apiConfig.AddDefaultHeader("Authorization", $"Bearer {_authResult.AccessToken}");
            
        }

         public int getTenantId(string tenantName)
        {
              var accountClient = new AccountApi(_apiConfig);
              var model = new IsTenantAvailableInput(tenantName);
              var result = accountClient.ApiServicesAppAccountIsTenantAvailablePost(model);
              return (int) result.TenantId;
        }

        private AuthenticateResultModel GetAccessToken(string tenantId, string username, string password)
        {
            var tokenApi = new TokenAuthApi(_apiConfig);
            tokenApi.AddDefaultHeader("Abp.TenantId", tenantId);
            var model = new AuthenticateModel(username, password, false);
            var result = tokenApi.ApiTokenAuthAuthenticatePost(model);
            _apiConfig.DefaultHeader.Remove("Abp.TenantId");
            return result;
        }

        public PagedResultDtoUserDto GetUsers()
        {
            var userApi = new UserApi(_apiConfig);

            return   userApi.ApiServicesAppUserGetAllGet();
        }

       

    }
}
