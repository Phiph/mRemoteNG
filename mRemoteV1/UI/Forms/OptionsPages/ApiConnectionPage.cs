using System;
using mRemote.Access.API;
using mRemoteNG.App;
using mRemoteNG.Config.Connections;
using mRemoteNG.Config.Connections.Multiuser;
using mRemoteNG.Config.DatabaseConnectors;
using mRemoteNG.Security.SymmetricEncryption;

namespace mRemoteNG.UI.Forms.OptionsPages
{
	public sealed partial class ApiConnectionPage
    {
        private readonly ApiConnectionTester _apiConnectionTester;
 
        public ApiConnectionPage()
        {
            InitializeComponent();
            ApplyTheme();
            _apiConnectionTester = new ApiConnectionTester();
        }

        public override string PageName
        {
            get => Language.strSQLServer.TrimEnd(':');
            set { }
        }

        public override void ApplyLanguage()
        {
            base.ApplyLanguage();

            lblExperimental.Text = Language.strExperimental.ToUpper();
            lblSQLInfo.Text = Language.strSQLInfo;

            chkUseAPISync.Text = Language.strUseSQLServer;
            lblAPIEndpoint.Text = Language.strLabelHostname;
            lblTennantName.Text = Language.strLabelSQLServerDatabaseName;
            lblSQLUsername.Text = Language.strLabelUsername;
            lblSQLPassword.Text = Language.strLabelPassword;
            
            btnTestConnection.Text = Language.TestConnection;
        }

        public override void LoadSettings()
        {
            base.SaveSettings();

            chkUseAPISync.Checked = Settings.Default.UseAPI;
            txtAPIEndpoint.Text = Settings.Default.APIUrl;
            txtAPITennant.Text = Settings.Default.APITennant;
            txtAPIUsername.Text = Settings.Default.APIUserName;
            var cryptographyProvider = new LegacyRijndaelCryptographyProvider();
            txtAPIPassword.Text = cryptographyProvider.Decrypt(Settings.Default.APIPassword, Runtime.EncryptionKey);
         
	        lblTestConnectionResults.Text = "";
        }

        public override void SaveSettings()
        {
            base.SaveSettings();
            var sqlServerWasPreviouslyEnabled = Settings.Default.UseAPI;

            Settings.Default.UseAPI = chkUseAPISync.Checked;
            Settings.Default.APIUrl = txtAPIEndpoint.Text;
            Settings.Default.APITennant = txtAPITennant.Text;
            Settings.Default.APIUserName = txtAPIUsername.Text;
            var cryptographyProvider = new LegacyRijndaelCryptographyProvider();
            Settings.Default.APIPassword = cryptographyProvider.Encrypt(txtAPIPassword.Text, Runtime.EncryptionKey);

            if (Settings.Default.UseAPI)
                ReinitializeSqlUpdater();
            else if (!Settings.Default.UseAPI && sqlServerWasPreviouslyEnabled)
                DisableSql();

            Settings.Default.Save();
        }

        private static void ReinitializeSqlUpdater()
        {
           // Runtime.ConnectionsService.RemoteConnectionsSyncronizer?.Dispose();
           // Runtime.ConnectionsService.RemoteConnectionsSyncronizer = new RemoteConnectionsSyncronizer(new SqlConnectionsUpdateChecker());
           // Runtime.ConnectionsService.RemoteConnectionsSyncronizer.Enable();
        }

        private void DisableSql()
        {
           // Runtime.ConnectionsService.RemoteConnectionsSyncronizer?.Dispose();
           // Runtime.ConnectionsService.RemoteConnectionsSyncronizer = null;
           // Runtime.LoadConnections(true);
        }

        private void chkUseSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            toggleSQLPageControls(chkUseAPISync.Checked);
        }

        private void toggleSQLPageControls(bool useSQLServer)
        {
            lblAPIEndpoint.Enabled = useSQLServer;
            lblTennantName.Enabled = useSQLServer;
            lblSQLUsername.Enabled = useSQLServer;
            lblSQLPassword.Enabled = useSQLServer;
            txtAPIEndpoint.Enabled = useSQLServer;
            txtAPITennant.Enabled = useSQLServer;
            txtAPIUsername.Enabled = useSQLServer;
            txtAPIPassword.Enabled = useSQLServer;
            btnTestConnection.Enabled = useSQLServer;
        }

        private async void btnTestConnection_Click(object sender, EventArgs e)
        {
            var apiUrl = txtAPIEndpoint.Text;
            var tenant = txtAPITennant.Text;
            var username = txtAPIUsername.Text;
            var password = txtAPIPassword.Text;

          

            lblTestConnectionResults.Text = Language.TestingConnection;
            imgConnectionStatus.Image = Resources.loading_spinner;
            btnTestConnection.Enabled = false;

            _apiConnectionTester.Init(apiUrl, null);
            ///ValidateTennant
            var tennantcheck = await _apiConnectionTester.ValidateTennant(tenant);

            //If valid tenant, continue
            if (tennantcheck.TenantId.HasValue)
            {
                _apiConnectionTester.AddTenantHeader(tennantcheck.TenantId);

                btnTestConnection.Enabled = true;

                try
                {
                    var connectionTestResult = await _apiConnectionTester.TestConnectivity(username, password);

                    if(connectionTestResult.Data.UserId != null)
                    {
                        UpdateConnectionImage(true);
                        lblTestConnectionResults.Text = Language.ConnectionSuccessful;
                    }
                    else
                    {
                        UpdateConnectionImage(false);
                        lblTestConnectionResults.Text = BuildTestFailedMessage(Language.strRdpErrorUnknown);
                    }
                }
                catch
                {

                }

               
            }
            else
            {
                
            }

 
        }

        private void UpdateConnectionImage(bool connectionSuccess)
        {
            imgConnectionStatus.Image = connectionSuccess
                ? Resources.tick
                : Resources.exclamation;
        }

        private string BuildTestFailedMessage(string specificMessage)
        {
            return Language.strConnectionOpenFailed +
                   Environment.NewLine +
                   specificMessage;
        }
    }
}