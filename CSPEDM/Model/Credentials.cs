using System;

namespace CSPEDM
{
    class Credentials
    {
        public string AccessToken { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public Credentials(string accessToken, long epochTime)
        {
            AccessToken = accessToken;
            ExpirationDate = EpochToTime(epochTime);
        }

        public DateTime EpochToTime(long epochTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(epochTime).AddHours(1); // UTC +1
        }
    }
}