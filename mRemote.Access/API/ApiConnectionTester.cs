using mRemote.Access.Client.Api;
using mRemote.Access.Client.Client;
using mRemote.Access.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mRemote.Access.API
{
    public class ApiConnectionTester
    {
        private bool _initialised { get; set; } = false;

        private Configuration APIConfig { get; set; }

        private ApiClient _apiClient { get; set; }

        public ApiConnectionTester(string apiUrl, int? tenantId)
        {
            APIConfig = new Configuration
            {
                BasePath = apiUrl
            };

            if (tenantId != null)
            {
                APIConfig.AddDefaultHeader("Abp.TenantId", tenantId.ToString());
            }
           
            _initialised = true;
        }

        public ApiConnectionTester()
        {

        }

        public void Init(string apiUrl, int? tenantId)
        {
            if (APIConfig == null) { 
                APIConfig = new Configuration
                {
                    BasePath = apiUrl
                };
            }

            AddTenantHeader(tenantId);

            _initialised = true;
        }

        public void AddTenantHeader(int? tenantId){
            if (tenantId != null && !APIConfig.DefaultHeader.ContainsKey("Abp.TenantId"))
            {
                APIConfig.AddDefaultHeader("Abp.TenantId", tenantId.ToString());
            }
        }


        public async Task<ApiResponse<AuthenticateResultModel>> TestConnectivity(string username, string password)
        {
            var tokenAuth = new TokenAuthApi(APIConfig);
            var model = new AuthenticateModel(username, password, false);
            var result =  await tokenAuth.ApiTokenAuthAuthenticatePostAsyncWithHttpInfo(model);
            return result;
        }

      public async Task<IsTenantAvailableOutput> ValidateTennant(string tenantName)
      {
            var accountClient = new AccountApi(APIConfig);
            var model = new IsTenantAvailableInput(tenantName);
            var result = await accountClient.ApiServicesAppAccountIsTenantAvailablePostAsync(model);
            return result;
      }
      

    }
}
