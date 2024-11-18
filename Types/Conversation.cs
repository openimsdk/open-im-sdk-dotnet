using Newtonsoft.Json;

namespace OpenIM.IMSDK
{
    public class Conversation
    {
        [JsonProperty("conversationID")]
        public string ConversationID;

        [JsonProperty("conversationType")]
        public ConversationType ConversationType;

        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("groupID")]
        public string GroupID;

        [JsonProperty("showName")]
        public string ShowName;

        [JsonProperty("faceURL")]
        public string FaceURL;

        [JsonProperty("recvMsgOpt")]
        public int RecvMsgOpt;

        [JsonProperty("unreadCount")]
        public int UnreadCount;

        [JsonProperty("groupAtType")]
        public int GroupAtType;

        [JsonProperty("latestMsg")]
        public string LatestMsg;

        [JsonProperty("latestMsgSendTime")]
        public long LatestMsgSendTime;

        [JsonProperty("draftText")]
        public string DraftText;

        [JsonProperty("draftTextTime")]
        public long DraftTextTime;

        [JsonProperty("isPinned")]
        public bool IsPinned;

        [JsonProperty("isPrivateChat")]
        public bool IsPrivateChat;

        [JsonProperty("burnDuration")]
        public int BurnDuration;

        [JsonProperty("isNotInGroup")]
        public bool IsNotInGroup;

        [JsonProperty("updateUnreadCountTime")]
        public long UpdateUnreadCountTime;

        [JsonProperty("attachedInfo")]
        public string AttachedInfo;

        [JsonProperty("ex")]
        public string Ex;

        [JsonProperty("maxSeq")]
        public long MaxSeq;

        [JsonProperty("minSeq")]
        public long MinSeq;

        [JsonProperty("hasReadSeq")]
        public long HasReadSeq;

        [JsonProperty("msgDestructTime")]
        public long MsgDestructTime;

        [JsonProperty("isMsgDestruct")]
        public bool IsMsgDestruct;
    }
    public class ConversationArgs
    {
        [JsonProperty("conversationID")]
        public string ConversationID;

        [JsonProperty("clientMsgIDList")]
        public string[] ClientMsgIDList;
    }
    public class ConversationReq
    {
        [JsonProperty("recvMsgOpt")]
        public Int32Value RecvMsgOpt;
        [JsonProperty("isPinned")]
        public BoolValue IsPinned;
        [JsonProperty("isPrivateChat")]
        public BoolValue IsPrivateChat;
        [JsonProperty("ex")]
        public StringValue Ex;
        [JsonProperty("burnDuration")]
        public Int32Value BurnDuration;
        [JsonProperty("groupAtType")]
        public Int32Value GroupAtType;
    }
    public class CreateGroupReq
    {
        [JsonProperty("memberUserIDs")]
        public string[] MemberUserIDs;

        [JsonProperty("groupInfo")]
        public GroupInfo GroupInfo;

        [JsonProperty("adminUserIDs")]
        public string[] AdminUserIDs;

        [JsonProperty("ownerUserID")]
        public string OwnerUserID;
    }
    public class InputStatesChangedData
    {
        [JsonProperty("conversationID")]
        public string ConversationID;

        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("platformIDs")]
        public int[] PlatformIDs;
    }

}