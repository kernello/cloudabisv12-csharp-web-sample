using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.ModelsInterfaces
{
    public interface IRequest
    {
        IBiometricRequest ToBiometricRequest();
    }
}
