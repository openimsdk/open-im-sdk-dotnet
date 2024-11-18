namespace OpenIM.IMSDK
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
        //////////////////////////////////////////
        NotificationBegin = 1000,

        FriendNotificationBegin = 1200,


        FriendApplicationApprovedNotification = 1201, //add_friend_response

        FriendApplicationRejectedNotification = 1202,//add_friend_response

        FriendApplicationNotification = 1203, //add_friend

        FriendAddedNotification = 1204,

        FriendDeletedNotification = 1205, //delete_friend

        FriendRemarkSetNotification = 1206, //set_friend_remark?

        BlackAddedNotification = 1207, //add_black

        BlackDeletedNotification = 1208, //remove_black

        FriendInfoUpdatedNotification = 1209,

        FriendsInfoUpdateNotification = 1210,

        FriendNotificationEnd = 1299,

        ConversationChangeNotification = 1300,


        UserNotificationBegin = 1301,

        UserInfoUpdatedNotification = 1303,
        //SetSelfInfoTip             = 204

        UserStatusChangeNotification = 1304,

        UserCommandAddNotification = 1305,

        UserCommandDeleteNotification = 1306,

        UserCommandUpdateNotification = 1307,


        UserNotificationEnd = 1399,

        OANotification = 1400,


        GroupNotificationBegin = 1500,


        GroupCreatedNotification = 1501,

        GroupInfoSetNotification = 1502,

        JoinGroupApplicationNotification = 1503,

        MemberQuitNotification = 1504,

        GroupApplicationAcceptedNotification = 1505,

        GroupApplicationRejectedNotification = 1506,

        GroupOwnerTransferredNotification = 1507,

        MemberKickedNotification = 1508,

        MemberInvitedNotification = 1509,

        MemberEnterNotification = 1510,

        GroupDismissedNotification = 1511,

        GroupMemberMutedNotification = 1512,

        GroupMemberCancelMutedNotification = 1513,

        GroupMutedNotification = 1514,

        GroupCancelMutedNotification = 1515,

        GroupMemberInfoSetNotification = 1516,

        GroupMemberSetToAdminNotification = 1517,

        GroupMemberSetToOrdinaryUserNotification = 1518,

        GroupInfoSetAnnouncementNotification = 1519,

        GroupInfoSetNameNotification = 1520,

        GroupNotificationEnd = 1599,


        SignalingNotificationBegin = 1600,

        SignalingNotification = 1601,

        SignalingNotificationEnd = 1649,


        SuperGroupNotificationBegin = 1650,

        SuperGroupUpdateNotification = 1651,

        MsgDeleteNotification = 1652,

        ReactionMessageModifierNotification = 1653,

        ReactionMessageDeleteNotification = 1654,

        SuperGroupNotificationEnd = 1699,


        ConversationPrivateChatNotification = 1701,

        ConversationUnreadNotification = 1702,


        WorkMomentNotificationBegin = 1900,

        WorkMomentNotification = 1901,


        BusinessNotificationBegin = 2000,

        BusinessNotification = 2001,

        BusinessNotificationEnd = 2099,


        RevokeNotification = 2101,


        HasReadReceiptNotification = 2150,

        GroupHasReadReceiptNotification = 2155,

        ClearConversationNotification = 2101,

        DeleteMsgsNotification = 2102,
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
        Reject = -1,
        Unprocessed = 0,
        Agree = 1,
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