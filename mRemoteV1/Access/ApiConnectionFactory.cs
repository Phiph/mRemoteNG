using mRemoteNG.App;
using mRemoteNG.Security.SymmetricEncryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mRemoteNG.Access
{
    public class ApiConnectionFactory
    {
         public static ApiConnector ApiConnectorFromSettings()
         {
             var apiHost = mRemoteNG.Settings.Default.APIUrl;
             var apiTenant = mRemoteNG.Settings.Default.APITennant;
             var apiUsername = mRemoteNG.Settings.Default.APIUserName;
             var cryptographyProvider = new LegacyRijndaelCryptographyProvider();
             var apiPassword = cryptographyProvider.Decrypt(mRemoteNG.Settings.Default.APIPassword, Runtime.EncryptionKey);
             return new ApiConnector(apiHost, apiTenant, apiUsername, apiPassword);
         }
    }
}
