using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudABISSampleWebApp.Models.MatchingServer.Enums
{

    public enum EnumOperationalResponseStatus
    {
        None = -1,
        Failed = 0,
        Success = 1,

        DuplicateFound,
        MatchFound,
        NoMatchFound,

        IDExist,
        IDNotExist,

        ChangeSuccess,
        ChangeFailed,

        DeleteSuccess,
        DeleteFailed,

        InsertSuccess,
        InsertFailed,

        UpdateSuccess,
        UpdateFailed,

        Registered,
        NotRegistered,
        RegistrationSuccess,
        RegistrationFailed,

        ExtractionSuccess,
        ExtractionFailed,

        VerifySuccess,
        VerifyFailed
    }
}
