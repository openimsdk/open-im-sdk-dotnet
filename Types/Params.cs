using System;
using Newtonsoft.Json;

namespace open_im_sdk
{
    public class GetHistoryMessageListParams
    {
        [JsonProperty("userID")]
        public string UserID;
        [JsonProperty("groupID")]
        public string GroupID;
        [JsonProperty("conversationID")]
        public string ConversationID;
        [JsonProperty("startClientMsgID")]
        public string StartClientMsgID;
        [JsonProperty("count")]
        public int Count;
    }
    public class SetConversationStatusParams
    {
        [JsonProperty("userID")]
        public string UserId;
        [JsonProperty("status")]
        public int Status;
    }
    public class SearchLocalMessagesParams
    {
        [JsonProperty("conversationID")]
        public string ConversationID;
        [JsonProperty("keywordList")]
        public string[] KeywordList;
        [JsonProperty("keywordListMatchType")]
        public int KeywordListMatchType;
        [JsonProperty("senderUserIDList")]
        public string[] SenderUserIDList;
        [JsonProperty("messageTypeList")]
        public int[] MessageTypeList;
        [JsonProperty("searchTimePosition")]
        public long SearchTimePosition;
        [JsonProperty("searchTimePeriod")]
        public long SearchTimePeriod;
        [JsonProperty("pageIndex")]
        public int PageIndex;
        [JsonProperty("count")]
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