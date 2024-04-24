using Newtonsoft.Json;
namespace open_im_sdk
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
        public int ContentType;
        [JsonProperty("sessionType")]
        public int SessionType;
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
        public int SessionType;
        [JsonProperty("seq")]
        public long Seq;
        [JsonProperty("ex")]
        public string Ex;
        [JsonProperty("isAdminRevoke")]
        public bool IsAdminRevoke;
    }

    public class MessageReaction
    {
        [JsonProperty("clientMsgID")]
        public string ClientMsgID;
        [JsonProperty("reactionType")]
        public int ReactionType;
        [JsonProperty("counter")]
        public int Counter;
        [JsonProperty("userID")]
        public string UserID;
        [JsonProperty("groupID")]
        public string GroupID;
        [JsonProperty("sessionType")]
        public int SessionType;
        [JsonProperty("info")]
        public string Info;
    }

    public class ImageInfo
    {
        [JsonProperty("x")]
        public int Width;
        [JsonProperty("y")]
        public int Height;
        [JsonProperty("type")]
        public string Type;
        [JsonProperty("size")]
        public long Size;
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

    public class SoundBaseInfo
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

    public class VideoBaseInfo
    {
        [JsonProperty("videoPath")]
        public string VideoPath;
        [JsonProperty("VideoUUID")]
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
        public MsgStruct[] MultiMessage;
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
        public MsgStruct QuoteMessage;
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
        public MsgStruct QuoteMessage;
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

    public class MsgStruct
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
        public int SessionType;
        [JsonProperty("sendID")]
        public string SendID;
        [JsonProperty("recvID")]
        public string RecvID;
        [JsonProperty("msgFrom")]
        public int MsgFrom;
        [JsonProperty("contentType")]
        public int ContentType;
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

    public class GroupHasReadInfo
    {
        [JsonProperty("hasReadUserIDList")]
        public string[] HasReadUserIDList;
        [JsonProperty("hasReadCount")]
        public int HasReadCount;
        [JsonProperty("groupMemberCount")]
        public int GroupMemberCount;
    }

    public class CmdJoinedSuperGroup
    {
        [JsonProperty("operationID")]
        public string OperationID;
    }

    public class OANotificationElem
    {
        [JsonProperty("notificationName")]
        public string NotificationName;
        [JsonProperty("notificationFaceURL")]
        public string NotificationFaceURL;
        [JsonProperty("notificationType")]
        public int NotificationType;
        [JsonProperty("text")]
        public string Text;
        [JsonProperty("url")]
        public string Url;
        [JsonProperty("mixType")]
        public int MixType;
        [JsonProperty("image")]
        public string Image;
        [JsonProperty("video")]
        public string Video;
        [JsonProperty("file")]
        public string File;
        [JsonProperty("ex")]
        public string Ex;
    }

    public class MsgDeleteNotificationElem
    {
        [JsonProperty("groupID")]
        public string GroupID;
        [JsonProperty("isAllDelete")]
        public bool IsAllDelete;
        [JsonProperty("seqList")]
        public string[] SeqList;
    }
    public class LocalFriend
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
        public int AddSource;
        [JsonProperty("operatorUserID")]
        public string OperatorUserID;
        [JsonProperty("nickname")]
        public string Nickname;
        [JsonProperty("faceURL")]
        public string FaceURL;
        // [JsonProperty("gender")]
        // public int //Gender; 
        // [JsonProperty("phoneNumber")]
        // public string //PhoneNumber; 
        // [JsonProperty("birth")]
        // public uint //Birth; 
        // [JsonProperty("email")]
        // public string //Email; 
        [JsonProperty("ex")]
        public string Ex;
        [JsonProperty("attachedInfo")]
        public string AttachedInfo;
        [JsonProperty("isPinned")]
        public bool IsPinned;
    }
    public class LocalFriendRequest
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
        public int HandleResult;

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

    public class LocalGroup
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

    public class LocalGroupMember
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

    public class LocalGroupRequest
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
        public int Status;

        [JsonProperty("creatorUserID")]
        public string CreatorUserID;

        [JsonProperty("groupType")]
        public int GroupType;

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

        // public int //Gender; 

        [JsonProperty("handleResult")]
        public int HandleResult;

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
        public int JoinSource;

        [JsonProperty("inviterUserID")]
        public string InviterUserID;
    }

    public class LocalUser
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

    public class LocalBlack
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

    public class LocalSeqData
    {
        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("seq")]
        public uint Seq;
    }

    public class LocalSeq
    {
        [JsonProperty("id")]
        public string ID;

        [JsonProperty("minSeq")]
        public uint MinSeq;
    }

    public class LocalChatLog
    {
        [JsonProperty("clientMsgID")]
        public string ClientMsgID;

        [JsonProperty("serverMsgID")]
        public string ServerMsgID;

        [JsonProperty("sendID")]
        public string SendID;

        [JsonProperty("recvID")]
        public string RecvID;

        [JsonProperty("senderPlatformID")]
        public int SenderPlatformID;

        [JsonProperty("senderNickname")]
        public string SenderNickname;

        [JsonProperty("senderFaceURL")]
        public string SenderFaceURL;

        [JsonProperty("sessionType")]
        public int SessionType;

        [JsonProperty("msgFrom")]
        public int MsgFrom;

        [JsonProperty("contentType")]
        public int ContentType;

        [JsonProperty("content")]
        public string Content;

        [JsonProperty("isRead")]
        public bool IsRead;

        [JsonProperty("status")]
        public int Status;

        [JsonProperty("seq")]
        public long Seq;

        [JsonProperty("sendTime")]
        public long SendTime;

        [JsonProperty("createTime")]
        public long CreateTime;

        [JsonProperty("attachedInfo")]
        public string AttachedInfo;

        [JsonProperty("ex")]
        public string Ex;

        [JsonProperty("localEx")]
        public string LocalEx;

        [JsonProperty("isReact")]
        public bool IsReact;

        [JsonProperty("isExternalExtensions")]
        public bool IsExternalExtensions;

        [JsonProperty("msgFirstModifyTime")]
        public long MsgFirstModifyTime;
    }

    public class LocalErrChatLog
    {
        [JsonProperty("seq")]
        public long Seq;

        [JsonProperty("clientMsgID")]
        public string ClientMsgID;

        [JsonProperty("serverMsgID")]
        public string ServerMsgID;

        [JsonProperty("sendID")]
        public string SendID;

        [JsonProperty("recvID")]
        public string RecvID;

        [JsonProperty("senderPlatformID")]
        public int SenderPlatformID;

        [JsonProperty("senderNickname")]
        public string SenderNickname;

        [JsonProperty("senderFaceURL")]
        public string SenderFaceURL;

        [JsonProperty("sessionType")]
        public int SessionType;

        [JsonProperty("msgFrom")]
        public int MsgFrom;

        [JsonProperty("contentType")]
        public int ContentType;

        [JsonProperty("content")]
        public string Content;

        [JsonProperty("isRead")]
        public bool IsRead;

        [JsonProperty("status")]
        public int Status;

        [JsonProperty("sendTime")]
        public long SendTime;

        [JsonProperty("createTime")]
        public long CreateTime;

        [JsonProperty("attachedInfo")]
        public string AttachedInfo;

        [JsonProperty("ex")]
        public string Ex;
    }

    public class TempCacheLocalChatLog
    {
        [JsonProperty("clientMsgID")]
        public string ClientMsgID;

        [JsonProperty("serverMsgID")]
        public string ServerMsgID;

        [JsonProperty("sendID")]
        public string SendID;

        [JsonProperty("recvID")]
        public string RecvID;

        [JsonProperty("senderPlatformID")]
        public int SenderPlatformID;

        [JsonProperty("senderNickname")]
        public string SenderNickname;

        [JsonProperty("senderFaceURL")]
        public string SenderFaceURL;

        [JsonProperty("sessionType")]
        public int SessionType;

        [JsonProperty("msgFrom")]
        public int MsgFrom;

        [JsonProperty("contentType")]
        public int ContentType;

        [JsonProperty("content")]
        public string Content;

        [JsonProperty("isRead")]
        public bool IsRead;

        [JsonProperty("status")]
        public int Status;

        [JsonProperty("seq")]
        public long Seq;

        [JsonProperty("sendTime")]
        public long SendTime;

        [JsonProperty("createTime")]
        public long CreateTime;

        [JsonProperty("attachedInfo")]
        public string AttachedInfo;

        [JsonProperty("ex")]
        public string Ex;
    }

    public class LocalConversation
    {
        [JsonProperty("conversationID")]
        public string ConversationID;

        [JsonProperty("conversationType")]
        public int ConversationType;

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

        [JsonProperty("latestMsgStruct")]
        public MsgStruct LatestMsgStruct;
    }

    public class LocalConversationUnreadMessage
    {
        [JsonProperty("conversationID")]
        public string ConversationID;

        [JsonProperty("clientMsgID")]
        public string ClientMsgID;

        [JsonProperty("sendTime")]
        public long SendTime;

        [JsonProperty("ex")]
        public string Ex;
    }

    public class LocalAdminGroupRequest
    {
    }

    public class LocalChatLogReactionExtensions
    {
        [JsonProperty("clientMsgID")]
        public string ClientMsgID;

        [JsonProperty("localReactionExtensions")]
        public byte[] LocalReactionExtensions;
    }

    public class LocalWorkMomentsNotification
    {
        [JsonProperty("jsonDetail")]
        public string JsonDetail;

        [JsonProperty("createTime")]
        public long CreateTime;
    }

    public class WorkMomentNotificationMsg
    {
        [JsonProperty("notificationMsgType")]
        public int NotificationMsgType;

        [JsonProperty("replyUserName")]
        public string ReplyUserName;

        [JsonProperty("replyUserID")]
        public string ReplyUserID;

        [JsonProperty("content")]
        public string Content;

        [JsonProperty("contentID")]
        public string ContentID;

        [JsonProperty("workMomentID")]
        public string WorkMomentID;

        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("userName")]
        public string UserName;

        [JsonProperty("faceURL")]
        public string FaceURL;

        [JsonProperty("workMomentContent")]
        public string WorkMomentContent;

        [JsonProperty("createTime")]
        public int CreateTime;
    }

    public class LocalWorkMomentsNotificationUnreadCount
    {
        [JsonProperty("unreadCount")]
        public int UnreadCount;
    }

    public class NotificationSeqs
    {
        [JsonProperty("conversationID")]
        public string ConversationID;

        [JsonProperty("seq")]
        public long Seq;
    }

    public class LocalUpload
    {
        [JsonProperty("partHash")]
        public string PartHash;

        [JsonProperty("uploadID")]
        public string UploadID;

        [JsonProperty("uploadInfo")]
        public string UploadInfo;

        [JsonProperty("expireTime")]
        public long ExpireTime;

        [JsonProperty("createTime")]
        public long CreateTime;
    }

    public class ConversationArgs
    {
        [JsonProperty("conversationID")]
        public string ConversationID;

        [JsonProperty("clientMsgIDList")]
        public string[] ClientMsgIDList;
    }

    public class FindMessageListCallback
    {
        [JsonProperty("totalCount")]
        public int TotalCount;

        [JsonProperty("findResultItems")]
        public SearchByConversationResult[] FindResultItems;
    }

    public class AdvancedHistoryMessageData
    {
        [JsonProperty("messageList")]
        public MsgStruct[] MessageList;

        [JsonProperty("lastMinSeq")]
        public long LastMinSeq;

        [JsonProperty("isEnd")]
        public bool IsEnd;

        [JsonProperty("errCode")]
        public int ErrCode;

        [JsonProperty("errMsg")]
        public string ErrMsg;
    }

    public class SearchLocalMessagesCallback
    {
        [JsonProperty("totalCount")]
        public int TotalCount;

        [JsonProperty("searchResultItems")]
        public SearchByConversationResult[] SearchResultItems;
    }

    public class SearchByConversationResult
    {
        [JsonProperty("conversationID")]
        public string ConversationID;

        [JsonProperty("conversationType")]
        public int ConversationType;

        [JsonProperty("showName")]
        public string ShowName;

        [JsonProperty("faceURL")]
        public string FaceURL;

        [JsonProperty("messageCount")]
        public int MessageCount;

        [JsonProperty("messageList")]
        public MsgStruct[] MessageList;
    }

    public class SetMessageReactionExtensionsCallback
    {
        [JsonProperty("key")]
        public string Key;

        [JsonProperty("value")]
        public string Value;

        [JsonProperty("errCode")]
        public int ErrCode;

        [JsonProperty("errMsg")]
        public string ErrMsg;
    }

    public class AddMessageReactionExtensionsCallback
    {
        [JsonProperty("key")]
        public string Key;

        [JsonProperty("value")]
        public string Value;

        [JsonProperty("errCode")]
        public int ErrCode;

        [JsonProperty("errMsg")]
        public string ErrMsg;
    }

    public class GetTypekeyListResp
    {
        [JsonProperty("typeKeyInfoList")]
        public SingleTypeKeyInfoSum[] TypeKeyInfoList;
    }

    public class SingleTypeKeyInfoSum
    {
        [JsonProperty("typeKey")]
        public string TypeKey;

        [JsonProperty("counter")]
        public long Counter;

        [JsonProperty("infoList")]
        public Info[] InfoList;

        [JsonProperty("isContainSelf")]
        public bool IsContainSelf;
    }

    public class SingleTypeKeyInfo
    {
        [JsonProperty("typeKey")]
        public string TypeKey;

        [JsonProperty("counter")]
        public long Counter;

        [JsonProperty("isCanRepeat")]
        public bool IsCanRepeat;

        [JsonProperty("index")]
        public int Index;
        // public map[string] Info InfoList; 
    }

    public class Info
    {
        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("ex")]
        public string Ex;
    }

    public class AddFriendParams
    {
        [JsonProperty("toUserID")]
        public string ToUserID;

        [JsonProperty("reqMsg")]
        public string ReqMsg;
    }

    public class ProcessFriendApplicationParams
    {
        [JsonProperty("toUserID")]
        public string ToUserID;

        [JsonProperty("handleMsg")]
        public string HandleMsg;
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

    public class GetFriendListPage
    {
    }

    public class SearchFriendItem
    {
        [JsonProperty("relationship")]
        public int Relationship;
    }

    public class SetFriendRemarkParams
    {
        [JsonProperty("toUserID")]
        public string ToUserID;

        [JsonProperty("remark")]
        public string Remark;
    }

    public class CreateGroupBaseInfoParam
    {
        [JsonProperty("groupType")]
        public int GroupType;
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

    public class SetGroupInfoParam
    {
        [JsonProperty("groupName")]
        public string GroupName;

        [JsonProperty("notification")]
        public string Notification;

        [JsonProperty("introduction")]
        public string Introduction;

        [JsonProperty("faceURL")]
        public string FaceURL;

        [JsonProperty("ex")]
        public string Ex;

        [JsonProperty("needVerification")]
        public int NeedVerification;
    }
    public class SetGroupMemberInfoParam
    {
        [JsonProperty("groupID")]
        public string GroupID;

        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("ex")]
        public string Ex;
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

    public class PublicUser
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

    public class FullUserInfo
    {
        [JsonProperty("publicInfo")]
        public PublicUser PublicInfo;

        [JsonProperty("friendInfo")]
        public LocalFriend FriendInfo;

        [JsonProperty("blackInfo")]
        public LocalBlack BlackInfo;
    }

    public class GetAdvancedHistoryMessageList
    {
        [JsonProperty("messageList")]
        public MsgStruct[] MessageList;

        [JsonProperty("lastMinSeq")]
        public long LastMinSeq;

        [JsonProperty("isEnd")]
        public bool IsEnd;

        [JsonProperty("errCode")]
        public int ErrCode;

        [JsonProperty("errMsg")]
        public string ErrMsg;
    }
    public class GetConversationRecvMessageOptResp
    {
        [JsonProperty("conversationID")]
        public string ConversationID;

        [JsonProperty("result")]
        public int Result;
    }

    public class FindMessageList
    {
        [JsonProperty("totalCount")]
        public int TotalCount;

        [JsonProperty("findResultItems")]
        public SearchByConversationResult[] FindResultItems;
    }

    public class FullUserInfoWithCache
    {
        [JsonProperty("publicInfo")]
        public PublicUser PublicInfo;

        [JsonProperty("friendInfo")]
        public LocalFriend FriendInfo;

        [JsonProperty("blackInfo")]
        public LocalBlack BlackInfo;

        [JsonProperty("groupMemberInfo")]
        public LocalGroupMember GroupMemberInfo;
    }

    public class UserIDResult
    {
        [JsonProperty("userID")]
        public string UserID;

        [JsonProperty("result")]
        public int Result;
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

    public class UserInfo
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

        [JsonProperty("appMangerLevel")]
        public int AppManagerLevel;

        [JsonProperty("globalRecvMsgOpt")]
        public int GlobalRecvMsgOpt;
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

    public class CreateGroupReq
    {
        [JsonProperty("memberUserIDs")]
        public string[] MemberUserIDs;

        [JsonProperty("groupInfo")]
        public LocalGroup GroupInfo;

        [JsonProperty("adminUserIDs")]
        public string[] AdminUserIDs;

        [JsonProperty("ownerUserID")]
        public string OwnerUserID;
    }

    public class StringValue
    {
        [JsonProperty("value")]
        public string Value;
    }

    public class Int32Value
    {
        [JsonProperty("value")]
        public int Value;
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