using Newtonsoft.Json;

namespace OpenIM.IMSDK
{
    public class GroupHasReadInfo
    {
        [JsonProperty("hasReadUserIDList")]
        public string[] HasReadUserIDList;
        [JsonProperty("hasReadCount")]
        public int HasReadCount;
        [JsonProperty("groupMemberCount")]
        public int GroupMemberCount;
    }
    public class GroupInfo
    {
        [JsonProperty("groupID")]
        public string GroupID;

        [JsonProperty("groupName")]
        public string GroupName;

        [JsonProperty("notification")]
        public string Notification;

        [JsonProperty("introduction")]
        public string Introduction;

        [JsonProperty("faceURL")]
        public string FaceURL;

        [JsonProperty("createTime")]
        public long CreateTime;

        [JsonProperty("status")]
        public int Status;

        [JsonProperty("creatorUserID")]
        public string CreatorUserID;

        [JsonProperty("groupType")]
        public int GroupType;

        [JsonProperty("ownerUserID")]
        public string OwnerUserID;

        [JsonProperty("memberCount")]
        public int MemberCount;

        [JsonProperty("ex")]
        public string Ex;

        [JsonProperty("attachedInfo")]
        public string AttachedInfo;

        [JsonProperty("needVerification")]
        public int NeedVerification;

        [JsonProperty("lookMemberInfo")]
        public int LookMemberInfo;

        [JsonProperty("applyMemberFriend")]
        public int ApplyMemberFriend;

        [JsonProperty("notificationUpdateTime")]
        public long NotificationUpdateTime;

        [JsonProperty("notificationUserID")]
        public string NotificationUserID;
    }

    public class GroupMember
    {
        [JsonProperty("groupID")]
        public string GroupID;

        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("nickname")]
        public string Nickname;

        [JsonProperty("faceURL")]
        public string FaceURL;

        [JsonProperty("roleLevel")]
        public int RoleLevel;

        [JsonProperty("joinTime")]
        public long JoinTime;

        [JsonProperty("joinSource")]
        public int JoinSource;

        [JsonProperty("inviterUserID")]
        public string InviterUserID;

        [JsonProperty("muteEndTime")]
        public long MuteEndTime;

        [JsonProperty("operatorUserID")]
        public string OperatorUserID;

        [JsonProperty("ex")]
        public string Ex;

        [JsonProperty("attachedInfo")]
        public string AttachedInfo;
    }
    public class GroupApplicationInfo
    {
        [JsonProperty("groupID")]
        public string GroupID;
        [JsonProperty("groupName")]
        public string GroupName;
        [JsonProperty("notification")]
        public string Notification;
        [JsonProperty("introduction")]
        public string Introduction;
        [JsonProperty("groupFaceURL")]
        public string GroupFaceURL;
        [JsonProperty("createTime")]
        public long CreateTime;
        [JsonProperty("status")]
        public GroupStatus Status;
        [JsonProperty("creatorUserID")]
        public string CreatorUserID;
        [JsonProperty("groupType")]
        public GroupType GroupType;
        [JsonProperty("ownerUserID")]
        public string OwnerUserID;
        [JsonProperty("memberCount")]
        public int MemberCount;
        [JsonProperty("userID")]
        public string UserID;
        [JsonProperty("nickname")]
        public string Nickname;
        [JsonProperty("userFaceURL")]
        public string UserFaceURL;
        [JsonProperty("handleResult")]
        public HandleResult HandleResult;
        [JsonProperty("reqMsg")]
        public string ReqMsg;
        [JsonProperty("handledMsg")]
        public string HandledMsg;
        [JsonProperty("reqTime")]
        public long ReqTime;
        [JsonProperty("handleUserID")]
        public string HandleUserID;
        [JsonProperty("handledTime")]
        public long HandledTime;
        [JsonProperty("ex")]
        public string Ex;
        [JsonProperty("attachedInfo")]
        public string AttachedInfo;
        [JsonProperty("joinSource")]
        public JoinSource JoinSource;
        [JsonProperty("inviterUserID")]
        public string InviterUserID;
    }
    public class SearchGroupsParam
    {
        [JsonProperty("keywordList")]
        public string[] KeywordList;

        [JsonProperty("isSearchGroupID")]
        public bool IsSearchGroupID;

        [JsonProperty("isSearchGroupName")]
        public bool IsSearchGroupName;
    }
    public class SearchGroupMembersParam
    {
        [JsonProperty("groupID")]
        public string GroupID;

        [JsonProperty("keywordList")]
        public string[] KeywordList;

        [JsonProperty("isSearchUserID")]
        public bool IsSearchUserID;

        [JsonProperty("isSearchMemberNickname")]
        public bool IsSearchMemberNickname;

        [JsonProperty("offset")]
        public int Offset;

        [JsonProperty("count")]
        public int Count;
    }

    public class SetGroupMemberInfo
    {
        [JsonProperty("groupID")]
        public string GroupID;

        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("nickname")]
        public StringValue Nickname;

        [JsonProperty("faceURL")]
        public StringValue FaceURL;

        [JsonProperty("roleLevel")]
        public Int32Value RoleLevel;

        [JsonProperty("ex")]
        public StringValue Ex;
    }

    public class GroupInfoForSet
    {
        [JsonProperty("groupID")]
        public string GroupID;

        [JsonProperty("groupName")]
        public string GroupName;

        [JsonProperty("notification")]
        public string Notification;

        [JsonProperty("introduction")]
        public string Introduction;

        [JsonProperty("faceURL")]
        public string FaceURL;

        [JsonProperty("ex")]
        public StringValue Ex;

        [JsonProperty("needVerification")]
        public Int32Value NeedVerification;

        [JsonProperty("lookMemberInfo")]
        public Int32Value LookMemberInfo;

        [JsonProperty("applyMemberFriend")]
        public Int32Value ApplyMemberFriend;
    }

}