using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumOperationName
    {
        None = 0,
        IsRegistered = 1,
        Register = 2,
        Identify = 3,
        Verify = 4,
        Update = 5,
        ChangeID = 6,
        DeleteID = 7
    }
}
