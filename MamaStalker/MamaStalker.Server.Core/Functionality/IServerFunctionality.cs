using System;
using System.Collections.Generic;
using System.Text;

namespace MamaStalker.Server.Core.Functionality
{
    public delegate void OnFunctionalitySend(byte[] buffer);
    public interface IServerFunctionality
    {
        void Register(OnFunctionalitySend callback);
        void Start();
    }
}
