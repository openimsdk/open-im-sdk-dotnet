namespace open_im_sdk
{
    public enum LoginStatus
    {
        Empty = 0,
        Logout = 1,
        Logging = 2,
        Logged = 3,
    }
    public enum MsgStatus
    {
        Default,
        Sending,
        SendSuccess,
        SendFailed,
        Deleted,
        Filtered,
    }
    public enum ContentType
    {
        Text = 101,

        Picture = 102,

        Sound = 103,

        Video = 104,

        File = 105,

        AtText = 106,

        Merger = 107,

        Card = 108,

        Location = 109,

        Custom = 110,

        Typing = 113,

        Quote = 114,

        Face = 115,

        AdvancedText = 117,

        CustomMsgNotTriggerConversation = 119,

        CustomMsgOnlineOnly = 120,

        ReactionMessageModifier = 121,

        ReactionMessageDeleter = 122,
    }

    public enum AllowType
    {
        Allowed, NotAllowed
    }
    public enum ConversationType
    {
        Single = 1,
        Group = 3,
        Notification = 4,
    }

    public enum GroupAtType
    {
        AtNormal = 0,
        AtMe = 1,
        AtAll = 2,
        AtAllAtMe = 3,
        AtGroupNotice = 4,
    }
    public enum GroupMemberFilter
    {
        All,
        Owner,
        Admin,
        Nomal,
        AdminAndNomal,
        AdminAndOwner,
    }
    public enum GroupStatus
    {
        Nomal,
        Baned,
        Dismissed,
        Muted,
    }
    public enum GroupType
    {
        Group = 2,
    }
    public enum GroupVerification
    {
        ApplyNeedInviteNot,
        AllNeed,
        AllNot,
    }

    public enum HandleResult
    {
        Unprocessed = -1,
        Agree = 0,
        Reject = 1,
    }

    public enum JoinSource
    {
        Invitation = 2,
        Search = 3,
        QrCode = 4,
    }

    public enum MessageContentType
    {
        TextMessage = 101,
        PictureMessage = 102,
        VoiceMessage = 103,
        VideoMessage = 104,
        FileMessage = 105,
        AtTextMessage = 106,
        MergeMessage = 107,
        CardMessage = 108,
        LocationMessage = 109,
        CustomMessage = 110,
        TypingMessage = 113,
        QuoteMessage = 114,
        FaceMessage = 115,
        FriendAdded = 1201,
        OANotification = 1400,
        GroupCreated = 1501,
        MemberQuit = 1504,
        GroupOwnerTransferred = 1507,
        MemberKicked = 1508,
        MemberInvited = 1509,
        MemberEnter = 1510,
        GroupDismissed = 1511,
        GroupMemberMuted = 1512,
        GroupMemberCancelMuted = 1513,
        GroupMuted = 1514,
        GroupCancelMuted = 1515,
        GroupAnnouncementUpdated = 1519,
        GroupNameUpdated = 1518,
        BurnMessageChange = 1701,
        RevokeMessage = 2101,
    }
    public enum MessageStatus
    {
        Sending = 1,
        Succeed = 2,
        Failed = 3,
    }

    public enum RecvMsgOpt
    {
        Nomal = 0,
        NotReceive = 1,
        NotNotify = 2,
    }

    public enum RoleLevel
    {
        Owner = 100,
        Admin = 60,
        Nomal = 20,
    }
    public enum LogLevel
    {
        Panic = 0,
        Fatal = 1,
        Error = 2,
        Warn = 3,
        Info = 4,
        Debug = 5,
    }
}