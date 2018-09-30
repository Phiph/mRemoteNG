using mRemoteNG.Config.Connections.Multiuser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using mRemoteNG.App;
using mRemoteNG.Messages;

namespace mRemoteNG.Access.Events
{
    class ApiConnectionsUpdateChecker : IConnectionsUpdateChecker
    {
        private readonly ApiConnector _ApiConnector;
        private DateTime _lastUpdateTime;
        private DateTime _lastDatabaseUpdateTime;


        public ApiConnectionsUpdateChecker()
        {
            _ApiConnector = ApiConnectionFactory.ApiConnectorFromSettings();
            _lastUpdateTime = default(DateTime);
            _lastDatabaseUpdateTime = default(DateTime);
        }

        public bool IsUpdateAvailable()
        {
            RaiseUpdateCheckStartedEvent();
            ConnectToApi();
            var updateIsAvailable = DatabaseIsMoreUpToDateThanUs();
            if (updateIsAvailable)
                RaiseConnectionsUpdateAvailableEvent();
            RaiseUpdateCheckFinishedEvent(updateIsAvailable);
            return updateIsAvailable;
        }

        public void IsUpdateAvailableAsync()
        {
            var thread = new Thread(() => IsUpdateAvailable());
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void ConnectToApi()
        {
            try
            {
                _ApiConnector.Connect();
            }
            catch (Exception e)
            {
                Runtime.MessageCollector.AddMessage(MessageClass.WarningMsg, "Unable to connect to Authenticate To API to check for updates." + Environment.NewLine + e.Message, true);
            }
        }

        private bool DatabaseIsMoreUpToDateThanUs()
        {
            var lastUpdateInDb = GetLastUpdateTimeFromDbResponse();
            var IAmTheLastoneUpdated = CheckIfIAmTheLastOneUpdated(lastUpdateInDb);
            //  return (lastUpdateInDb > _lastUpdateTime && !IAmTheLastoneUpdated);

            return false;
        }

        private bool CheckIfIAmTheLastOneUpdated(DateTime lastUpdateInDb)
        {
            DateTime LastSqlUpdateWithoutMilliseconds = new DateTime(Runtime.ConnectionsService.LastSqlUpdate.Ticks - (Runtime.ConnectionsService.LastSqlUpdate.Ticks % TimeSpan.TicksPerSecond), Runtime.ConnectionsService.LastSqlUpdate.Kind);
            return lastUpdateInDb == LastSqlUpdateWithoutMilliseconds;
        }

        private DateTime GetLastUpdateTimeFromDbResponse()
        {
           var lastUpdateInDb = default(DateTime);
            try
            {
                lastUpdateInDb = DateTime.Now.Subtract(TimeSpan.FromMinutes(60));
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddMessage(MessageClass.WarningMsg, "Error executing Sql query to get updates from the DB." + Environment.NewLine + ex.Message, true);
            }
            _lastDatabaseUpdateTime = lastUpdateInDb;
             return lastUpdateInDb;
        }


        public event EventHandler UpdateCheckStarted;
        private void RaiseUpdateCheckStartedEvent()
        {
            UpdateCheckStarted?.Invoke(this, EventArgs.Empty);
        }

        public event UpdateCheckFinishedEventHandler UpdateCheckFinished;
        private void RaiseUpdateCheckFinishedEvent(bool updateAvailable)
        {
            var args = new ConnectionsUpdateCheckFinishedEventArgs { UpdateAvailable = updateAvailable };
            UpdateCheckFinished?.Invoke(this, args);
        }

        public event ConnectionsUpdateAvailableEventHandler ConnectionsUpdateAvailable;
        private void RaiseConnectionsUpdateAvailableEvent()
        {
           var args = new ConnectionsUpdateAvailableEventArgs(_ApiConnector, _lastDatabaseUpdateTime);
           ConnectionsUpdateAvailable?.Invoke(this, args);
           if (args.Handled)
               _lastUpdateTime = _lastDatabaseUpdateTime;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool itIsSafeToDisposeManagedObjects)
        {
         //  if (!itIsSafeToDisposeManagedObjects) return;
         //  _sqlConnector.Disconnect();
         //  _sqlConnector.Dispose();
         //  _sqlQuery.Dispose();
        }
    }
}
