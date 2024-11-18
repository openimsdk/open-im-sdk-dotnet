using Newtonsoft.Json;

namespace OpenIM.IMSDK
{
    public class MessageReceipt
    {
        [JsonProperty("groupID")]
        public string GroupID;
        [JsonProperty("userID")]
        public string UserID;
        [JsonProperty("msgIDList")]
        public string[] MsgIDList;
        [JsonProperty("readTime")]
        public long ReadTime;
        [JsonProperty("msgFrom")]
        public int MsgFrom;
        [JsonProperty("contentType")]
        public ContentType ContentType;
        [JsonProperty("sessionType")]
        public ConversationType SessionType;
    }
    public class MessageRevoked
    {
        [JsonProperty("revokerID")]
        public string RevokerID;
        [JsonProperty("revokerRole")]
        public int RevokerRole;
        [JsonProperty("clientMsgID")]
        public string ClientMsgID;
        [JsonProperty("revokerNickname")]
        public string RevokerNickname;
        [JsonProperty("revokeTime")]
        public long RevokeTime;
        [JsonProperty("sourceMessageSendTime")]
        public long SourceMessageSendTime;
        [JsonProperty("sourceMessageSendID")]
        public string SourceMessageSendID;
        [JsonProperty("sourceMessageSenderNickname")]
        public string SourceMessageSenderNickname;
        [JsonProperty("sessionType")]
        public ConversationType SessionType;
        [JsonProperty("seq")]
        public long Seq;
        [JsonProperty("ex")]
        public string Ex;
        [JsonProperty("isAdminRevoke")]
        public bool IsAdminRevoke;
    }
    public class PictureBaseInfo
    {
        [JsonProperty("uuid")]
        public string UUID;
        [JsonProperty("type")]
        public string Type;
        [JsonProperty("size")]
        public long Size;
        [JsonProperty("width")]
        public int Width;
        [JsonProperty("height")]
        public int Height;
        [JsonProperty("url")]
        public string Url;
    }

    public class TextElem
    {
        [JsonProperty("content")]
        public string Content;
    }

    public class CardElem
    {
        [JsonProperty("userID")]
        public string UserID;
        [JsonProperty("nickname")]
        public string Nickname;
        [JsonProperty("faceURL")]
        public string FaceURL;
        [JsonProperty("ex")]
        public string Ex;
    }

    public class PictureElem
    {
        [JsonProperty("sourcePath")]
        public string SourcePath;
        [JsonProperty("sourcePicture")]
        public PictureBaseInfo SourcePicture;
        [JsonProperty("bigPicture")]
        public PictureBaseInfo BigPicture;
        [JsonProperty("snapshotPicture")]
        public PictureBaseInfo SnapshotPicture;
    }

    public class SoundElem
    {
        [JsonProperty("uuid")]
        public string UUID;
        [JsonProperty("soundPath")]
        public string SoundPath;
        [JsonProperty("sourceUrl")]
        public string SourceURL;
        [JsonProperty("dataSize")]
        public long DataSize;
        [JsonProperty("duration")]
        public long Duration;
        [JsonProperty("soundType")]
        public string SoundType;
    }

    public class VideoElem
    {
        [JsonProperty("videoPath")]
        public string VideoPath;
        [JsonProperty("videoUUID")]
        public string VideoUUID;
        [JsonProperty("videoUrl")]
        public string VideoURL;
        [JsonProperty("videoType")]
        public string VideoType;
        [JsonProperty("videoSize")]
        public long VideoSize;
        [JsonProperty("duration")]
        public long Duration;
        [JsonProperty("snapshotPath")]
        public string SnapshotPath;
        [JsonProperty("snapshotUUID")]
        public string SnapshotUUID;
        [JsonProperty("snapshotSize")]
        public long SnapshotSize;
        [JsonProperty("snapshotUrl")]
        public string SnapshotURL;
        [JsonProperty("snapshotWidth")]
        public int SnapshotWidth;
        [JsonProperty("snapshotHeight")]
        public int SnapshotHeight;
        [JsonProperty("snapshotType")]
        public string SnapshotType;
    }

    public class FileElem
    {
        [JsonProperty("filePath")]
        public string FilePath;
        [JsonProperty("uuid")]
        public string UUID;
        [JsonProperty("sourceUrl")]
        public string SourceURL;
        [JsonProperty("fileName")]
        public string FileName;
        [JsonProperty("fileSize")]
        public long FileSize;
        [JsonProperty("fileType")]
        public string FileType;
    }

    public class MergeElem
    {
        [JsonProperty("title")]
        public string Title;
        [JsonProperty("abstractList")]
        public string[] AbstractList;
        [JsonProperty("multiMessage")]
        public Message[] MultiMessage;
        [JsonProperty("messageEntityList")]
        public MessageEntity[] MessageEntityList;
    }

    public class AtTextElem
    {
        [JsonProperty("text")]
        public string Text;
        [JsonProperty("atUserList")]
        public string[] AtUserList;
        [JsonProperty("atUsersInfo")]
        public AtInfo[] AtUsersInfo;
        [JsonProperty("quoteMessage")]
        public Message QuoteMessage;
        [JsonProperty("isAtSelf")]
        public bool IsAtSelf;
    }

    public class FaceElem
    {
        [JsonProperty("index")]
        public int Index;
        [JsonProperty("data")]
        public string Data;
    }

    public class LocationElem
    {
        [JsonProperty("description")]
        public string Description;
        [JsonProperty("longitude")]
        public double Longitude;
        [JsonProperty("latitude")]
        public double Latitude;
    }

    public class CustomElem
    {
        [JsonProperty("data")]
        public string Data;
        [JsonProperty("description")]
        public string Description;
        [JsonProperty("extension")]
        public string Extension;
    }

    public class QuoteElem
    {
        [JsonProperty("text")]
        public string Text;
        [JsonProperty("quoteMessage")]
        public Message QuoteMessage;
        [JsonProperty("messageEntityList")]
        public MessageEntity[] MessageEntityList;
    }

    public class NotificationElem
    {
        [JsonProperty("detail")]
        public string Detail;
    }

    public class AdvancedTextElem
    {
        [JsonProperty("text")]
        public string Text;
        [JsonProperty("messageEntityList")]
        public MessageEntity[] MessageEntityList;
    }

    public class TypingElem
    {
        [JsonProperty("msgTips")]
        public string MsgTips;
    }

    public class Message
    {
        [JsonProperty("clientMsgID")]
        public string ClientMsgID;
        [JsonProperty("serverMsgID")]
        public string ServerMsgID;
        [JsonProperty("createTime")]
        public long CreateTime;
        [JsonProperty("sendTime")]
        public long SendTime;
        [JsonProperty("sessionType")]
        public ConversationType SessionType;
        [JsonProperty("sendID")]
        public string SendID;
        [JsonProperty("recvID")]
        public string RecvID;
        [JsonProperty("msgFrom")]
        public int MsgFrom;
        [JsonProperty("contentType")]
        public ContentType ContentType;
        [JsonProperty("senderPlatformID")]
        public int SenderPlatformID;
        [JsonProperty("senderNickname")]
        public string SenderNickname;
        [JsonProperty("senderFaceUrl")]
        public string SenderFaceURL;
        [JsonProperty("groupID")]
        public string GroupID;
        [JsonProperty("content")]
        public string Content;
        [JsonProperty("seq")]
        public long Seq;
        [JsonProperty("isRead")]
        public bool IsRead;
        [JsonProperty("status")]
        public int Status;
        [JsonProperty("isReact")]
        public bool IsReact;
        [JsonProperty("isExternalExtensions")]
        public bool IsExternalExtensions;
        public OfflinePushInfo OfflinePush;
        [JsonProperty("attachedInfo")]
        public string AttachedInfo;
        [JsonProperty("ex")]
        public string Ex;
        [JsonProperty("localEx")]
        public string LocalEx;
        [JsonProperty("textElem")]
        public TextElem TextElem;
        [JsonProperty("cardElem")]
        public CardElem CardElem;
        [JsonProperty("pictureElem")]
        public PictureElem PictureElem;
        [JsonProperty("sourdElem")]
        public SoundElem SoundElem;
        [JsonProperty("videoElem")]
        public VideoElem VideoElem;
        [JsonProperty("fileElem")]
        public FileElem FileElem;
        [JsonProperty("mergeElem")]
        public MergeElem MergeElem;
        [JsonProperty("atTextElem")]
        public AtTextElem AtTextElem;
        [JsonProperty("faceElem")]
        public FaceElem FaceElem;
        [JsonProperty("locationElem")]
        public LocationElem LocationElem;
        [JsonProperty("customElem")]
        public CustomElem CustomElem;
        [JsonProperty("quoteElem")]
        public QuoteElem QuoteElem;
        [JsonProperty("notificationElem")]
        public NotificationElem NotificationElem;
        [JsonProperty("advancedTextElem")]
        public AdvancedTextElem AdvancedTextElem;
        [JsonProperty("typingElem")]
        public TypingElem TypingElem;
        [JsonProperty("attachedInfoElem")]
        public AttachedInfoElem AttachedInfoElem;
    }

    public class AtInfo
    {
        [JsonProperty("atUserID")]
        public string AtUserID;
        [JsonProperty("groupNickname")]
        public string GroupNickname;
    }

    public class AttachedInfoElem
    {
        [JsonProperty("groupHasReadInfo")]
        public GroupHasReadInfo GroupHasReadInfo;
        [JsonProperty("isPrivateChat")]
        public bool IsPrivateChat;
        [JsonProperty("burnDuration")]
        public int BurnDuration;
        [JsonProperty("hasReadTime")]
        public long HasReadTime;
        [JsonProperty("messageEntityList")]
        public MessageEntity[] MessageEntityList;
        [JsonProperty("isEncryption")]
        public bool IsEncryption;
        [JsonProperty("inEncryptStatus")]
        public bool InEncryptStatus;
        [JsonProperty("messageReactionElem")]
        public ReactionElem[] MessageReactionElem;
        [JsonProperty("uploadProgress")]
        public UploadProgress Progress;
    }

    public class UploadProgress
    {
        [JsonProperty("total")]
        public long Total;
        [JsonProperty("save")]
        public long Save;
        [JsonProperty("current")]
        public long Current;
        [JsonProperty("uploadID")]
        public string UploadID;
    }

    public class ReactionElem
    {
        [JsonProperty("counter")]
        public int Counter;
        [JsonProperty("type")]
        public int Type;
        [JsonProperty("userReactionList")]
        public UserReactionElem[] UserReactionList;
        [JsonProperty("canRepeat")]
        public bool CanRepeat;
        [JsonProperty("info")]
        public string Info;
    }

    public class UserReactionElem
    {
        [JsonProperty("userID")]
        public string UserID;
        [JsonProperty("counter")]
        public int Counter;
        [JsonProperty("info")]
        public string Info;
    }

    public class MessageEntity
    {
        [JsonProperty("type")]
        public string Type;
        [JsonProperty("offset")]
        public int Offset;
        [JsonProperty("length")]
        public int Length;
        [JsonProperty("url")]
        public string Url;
        [JsonProperty("ex")]
        public string Ex;
    }

    public class SearchMessageResult
    {
        [JsonProperty("totalCount")]
        public int TotalCount;

        [JsonProperty("searchResultItems")]
        public SearchResultItem[] SearchResultItems;
    }
    public class SearchResultItem
    {
        [JsonProperty("conversationID")]
        public string ConversationID;

        [JsonProperty("conversationType")]
        public ConversationType ConversationType;

        [JsonProperty("showName")]
        public string ShowName;

        [JsonProperty("faceURL")]
        public string FaceURL;

        [JsonProperty("messageCount")]
        public int MessageCount;

        [JsonProperty("messageList")]
        public Message[] MessageList;
    }
    public class GetAdvancedHistoryMessageListParams
    {
        [JsonProperty("lastMinSeq")]
        public Int64 LastMinSeq;
        [JsonProperty("conversationID")]
        public string ConversationID;
        [JsonProperty("startClientMsgID")]
        public string StartClientMsgID;
        [JsonProperty("count")]
        public int Count;
    }
    public class SearchMessagesParams
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
    public class AdvancedMessageResult
    {
        [JsonProperty("messageList")]
        public Message[] MessageList;

        [JsonProperty("lastMinSeq")]
        public long LastMinSeq;

        [JsonProperty("isEnd")]
        public bool IsEnd;

        [JsonProperty("errCode")]
        public int ErrCode;

        [JsonProperty("errMsg")]
        public string ErrMsg;
    }
    public class FindMessageResult
    {
        [JsonProperty("totalCount")]
        public int TotalCount;

        [JsonProperty("findResultItems")]
        public SearchResultItem[] FindResultItems;
    }
    public class OfflinePushInfo
    {
        [JsonProperty("title")]
        public string Title;
        [JsonProperty("desc")]
        public string Desc;
        [JsonProperty("ex")]
        public string Ex;
        [JsonProperty("iOSPushSound")]
        public string IOSPushSound;
        [JsonProperty("iOSBadgeCount")]
        public bool IOSBadgeCount;
        [JsonProperty("signalInfo")]
        public string SignalInfo;
    }


}