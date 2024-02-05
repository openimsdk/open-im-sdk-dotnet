namespace open_im_sdk.native
{
    public enum MessageDef
    {
        Msg_Error,

        Msg_Connecting,
        Msg_ConnectSuccess,
        Msg_ConnectFailed,
        Msg_KickedOffline,
        Msg_UserTokenExpired,

        Msg_SyncServerStart,
        Msg_SyncServerFinish,
        Msg_SyncServerFailed,
        Msg_NewConversation,
        Msg_ConversationChanged,
        Msg_TotalUnreadMessageCountChanged,
        Msg_ConversationUserInputStatusChanged,

        Msg_Advanced_RecvNewMessage,
        Msg_Advanced_RecvC2CReadReceipt,
        Msg_Advanced_RecvGroupReadReceipt,
        Msg_Advanced_NewRecvMessageRevoked,
        Msg_Advanced_RecvMessageExtensionsChanged,
        Msg_Advanced_RecvMessageExtensionsDeleted,
        Msg_Advanced_RecvMessageExtensionsAdded,
        Msg_Advanced_RecvOfflineNewMessage,
        Msg_Advanced_MsgDeleted,
        Msg_Advanced_RecvOnlineOnlyMessage,

        Msg_Batch_RecvNewMessages,
        Msg_Batch_RecvOfflineNewMessages,

        Msg_FriendApplicationAdded,
        Msg_FriendApplicationDeleted,
        Msg_FriendApplicationAccepted,
        Msg_FriendApplicationRejected,
        Msg_FriendAdded,
        Msg_FriendDeleted,
        Msg_FriendInfoChanged,

        Msg_BlackAdded,
        Msg_BlackDeleted,

        Msg_JoinedGroupAdded,

        Msg_JoinedGroupDeleted,
        Msg_GroupMemberAdded,
        Msg_GroupMemberDeleted,
        Msg_GroupApplicationAdded,
        Msg_GroupApplicationDeleted,
        Msg_GroupInfoChanged,
        Msg_GroupDismissed,

        Msg_GroupMemberInfoChanged,
        Msg_GroupApplicationAccepted,
        Msg_GroupApplicationRejected,

        Msg_RecvCustomBusinessMessage,

        Msg_SelfInfoUpdated,
        Msg_UserStatusChanged,

        Msg_SendMessage_Error,
        Msg_SendMessage_Success,
        Msg_SendMessage_Progress,

        Msg_ErrorOrSuc,
    }
}