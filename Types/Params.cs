using System;
using Newtonsoft.Json;

namespace open_im_sdk
{
    public class GetHistoryMessageListParams
    {
        public string UserID;
        public string GroupID;
        public string ConversationID;
        public string StartClientMsgID;
        public int Count;
    }
    public class SetConversationStatusParams
    {
        public string UserId;
        public int Status;
    }
    public class SearchLocalMessagesParams
    {
        public string ConversationID;
        public string[] KeywordList;
        public int KeywordListMatchType;
        public string[] SenderUserIDList;
        public int[] MessageTypeList;
        public long SearchTimePosition;
        public long SearchTimePeriod;
        public int PageIndex;
        public int Count;
    }
    public class GetAdvancedHistoryMessageListParams
    {
        [JsonProperty("userID")]
        public string UserID;
        [JsonProperty("lastMinSeq")]
        public Int64 LastMinSeq;
        [JsonProperty("groupID")]
        public string GroupID;
        [JsonProperty("conversationID")]
        public string ConversationID;
        [JsonProperty("startClientMsgID")]
        public string StartClientMsgID;
        [JsonProperty("count")]
        public int Count;
    }
}