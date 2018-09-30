using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mRemoteNG.Access
{
    public interface IApiConnector : IDisposable
    {
        bool IsConnected { get; }
        void Connect();
        void Disconnect();
    }
}
