using mRemoteNG.Tree;
using mRemoteNG.Tree.Root;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mRemoteNG.Access
{
    public class ApiConnectionsLoader
    {
        public ConnectionTreeModel Load()
        {
            var connector = ApiConnectionFactory.ApiConnectorFromSettings();
            //var dataProvider = new SqlDataProvider(connector);
            //var databaseVersionVerifier = new SqlDatabaseVersionVerifier(connector);
            //databaseVersionVerifier.VerifyDatabaseVersion();
            //var dataTable = dataProvider.Load();
            //var deserializer = new DataTableDeserializer();
            //return deserializer.Deserialize(dataTable);

            var Model = new ConnectionTreeModel();
            var t = new RootNodeInfo(RootNodeType.Connection);
            t.Name = "Test";
            Model.AddRootNode(t);

            return Model;
        }
    }
}
