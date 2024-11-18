using Newtonsoft.Json;

namespace OpenIM.IMSDK
{
    public class FriendInfo
    {
        [JsonProperty("ownerUserID")]
        public string OwnerUserID;

        [JsonProperty("userID")]
        public string FriendUserID;
        [JsonProperty("remark")]
        public string Remark;
        [JsonProperty("createTime")]
        public long CreateTime;
        [JsonProperty("addSource")]
        public JoinSource AddSource;
        [JsonProperty("operatorUserID")]
        public string OperatorUserID;
        [JsonProperty("nickname")]
        public string Nickname;
        [JsonProperty("faceURL")]
        public string FaceURL;
        [JsonProperty("ex")]
        public string Ex;
        [JsonProperty("attachedInfo")]
        public string AttachedInfo;
        [JsonProperty("isPinned")]
        public bool IsPinned;
    }
    public class FriendApplicationInfo
    {
        [JsonProperty("fromUserID")]
        public string FromUserID;

        [JsonProperty("fromNickname")]
        public string FromNickname;

        [JsonProperty("fromFaceURL")]
        public string FromFaceURL;

        // public int //FromGender; 

        [JsonProperty("toUserID")]
        public string ToUserID;

        [JsonProperty("toNickname")]
        public string ToNickname;

        [JsonProperty("toFaceURL")]
        public string ToFaceURL;

        // public int //ToGender; 

        [JsonProperty("handleResult")]
        public HandleResult HandleResult;

        [JsonProperty("reqMsg")]
        public string ReqMsg;

        [JsonProperty("createTime")]
        public long CreateTime;

        [JsonProperty("handlerUserID")]
        public string HandlerUserID;

        [JsonProperty("handleMsg")]
        public string HandleMsg;

        [JsonProperty("handleTime")]
        public long HandleTime;

        [JsonProperty("ex")]
        public string Ex;

        [JsonProperty("attachedInfo")]
        public string AttachedInfo;
    }
    public class BlackInfo
    {
        [JsonProperty("ownerUserID")]
        public string OwnerUserID;

        [JsonProperty("blockUserID")]
        public string BlockUserID;

        [JsonProperty("nickname")]
        public string Nickname;

        [JsonProperty("faceURL")]
        public string FaceURL;

        // public int //Gender; 

        [JsonProperty("createTime")]
        public long CreateTime;

        [JsonProperty("addSource")]
        public int AddSource;

        [JsonProperty("operatorUserID")]
        public string OperatorUserID;

        [JsonProperty("ex")]
        public string Ex;

        [JsonProperty("attachedInfo")]
        public string AttachedInfo;
    }
    public class SearchFriendsParam
    {
        [JsonProperty("keywordList")]
        public string[] KeywordList;

        [JsonProperty("isSearchUserID")]
        public bool IsSearchUserID;

        [JsonProperty("isSearchNickname")]
        public bool IsSearchNickname;

        [JsonProperty("isSearchRemark")]
        public bool IsSearchRemark;
    }

    public class ProcessFriendApplicationParams
    {
        [JsonProperty("toUserID")]
        public string ToUserID;

        [JsonProperty("handleMsg")]
        public string HandleMsg;
    }
    public class UpdateFriendsReq
    {
        [JsonProperty("friendUserIDs")]
        public string[] FriendUserIDs;
        [JsonProperty("isPinned")]
        public BoolValue IsPinned;
        [JsonProperty("remark")]
        public StringValue Remark;
        [JsonProperty("ex")]
        public StringValue Ex;
    }
    public class SearchFriendItem : FriendInfo
    {
        [JsonProperty("relationship")]
        public int Relationship;
    }
    public class ApplyToAddFriendReq
    {
        [JsonProperty("fromUserID")]
        public string FromUserID;

        [JsonProperty("toUserID")]
        public string ToUserID;

        [JsonProperty("reqMsg")]
        public string ReqMsg;

        [JsonProperty("ex")]
        public string Ex;
    }

}