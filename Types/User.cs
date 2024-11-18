using Newtonsoft.Json;

namespace OpenIM.IMSDK
{
    public class UserInfo
    {
        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("nickname")]
        public string Nickname;

        [JsonProperty("faceURL")]
        public string FaceURL;

        [JsonProperty("createTime")]
        public long CreateTime;

        [JsonProperty("appMangerLevel")]
        public int AppMangerLevel;

        [JsonProperty("ex")]
        public string Ex;

        [JsonProperty("attachedInfo")]
        public string AttachedInfo;

        [JsonProperty("globalRecvMsgOpt")]
        public int GlobalRecvMsgOpt;
    }
    public class PublicUserInfo
    {
        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("nickname")]
        public string Nickname;

        [JsonProperty("faceURL")]
        public string FaceURL;

        [JsonProperty("ex")]
        public string Ex;

        [JsonProperty("createTime")]
        public long CreateTime;
    }
    public class OnlineStatus
    {
        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("status")]
        public int Status;

        [JsonProperty("platformIDs")]
        public int[] PlatformIDs;
    }
    public class UserIDResult
    {
        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("result")]
        public int Result;
    }
}