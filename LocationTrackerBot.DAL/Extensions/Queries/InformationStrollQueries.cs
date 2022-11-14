using System;

namespace Skinhealth.DAL.Extensions.Queries
{
    public static class InformationStrollQueries
    {
        public static readonly String Get = "exec spSearchByEMEI @emei";
        public static readonly String GetTable = "exec spSearchByEMEI @emei";
        public static readonly String GetEmei =
            "select IMEI From [dbo].[TrackLocation] where IMEI = @emei";
    }
}