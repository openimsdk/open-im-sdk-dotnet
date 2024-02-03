using open_im_sdk.native;
using Newtonsoft.Json;
using open_im_sdk.util;
using System.Collections.Generic;
using System;



#if UNITY_EDITOR || UNITY_EDITOR_OSX || UNITY_IPHONE || UNITY_ANDROID || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_WEBGL
using AOT;
#endif
namespace open_im_sdk
{
#if UNITY_EDITOR || UNITY_EDITOR_OSX || UNITY_IPHONE || UNITY_ANDROID || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_WEBGL
#else
    internal class MonoPInvokeCallbackAttribute : Attribute
    {
        Type funcType;
        public MonoPInvokeCallbackAttribute(Type funcType)
        {
            this.funcType = funcType;
        }
    }
#endif
    internal class Error
    {
        [JsonProperty("errCode")]
        public int ErrCode;
        [JsonProperty("errMsg")]
        public string ErrMsg;
        [JsonProperty("operationId")]
        public string OperationId;
    }
    internal class Success
    {
        [JsonProperty("operationId")]
        public string OperationId;
        [JsonProperty("dataType")]
        public int DataType;
        [JsonProperty("data")]
        public string Data;
    }
    internal class ErrorOrSuccess
    {
        [JsonProperty("operationId")]
        public string OperationId;
        [JsonProperty("errCode")]
        public int ErrCode;
        [JsonProperty("errMsg")]
        public string ErrMsg;
        [JsonProperty("dataType")]
        public int DataType;
        [JsonProperty("data")]
        public string Data;
    }

    internal class Progress
    {
        [JsonProperty("operationId")]
        public string OperationId;
        [JsonProperty("progress")]
        public int _Progress;
    }

    internal class MsgIDAndList
    {
        [JsonProperty("msgId")]
        public string Id;
        [JsonProperty("list")]
        public string List;
    }
    internal struct IdMsg
    {
        public int Id;
        public string Data;
    }


    public partial class IMSDK
    {

        static List<IdMsg> msgCache = new List<IdMsg>();
        [MonoPInvokeCallback(typeof(MessageHandler))]
        private static void MessageHandler(int msgId, string msg)
        {
            var idmsg = new IdMsg
            {
                Id = msgId,
                Data = msg
            };
            msgCache.Add(idmsg);
        }
        public static void DispatorMsg(MessageDef id, string msg)
        {
            Utils.Log("Recv", id, msg);
            switch (id)
            {
                case MessageDef.Msg_Connecting:
                    connCallBack.OnConnecting();
                    break;
                case MessageDef.Msg_ConnectSuccess:
                    connCallBack.OnConnectSuccess();
                    break;
                case MessageDef.Msg_ConnectFailed:
                    {
                        Error err = Utils.FromJson<Error>(msg);
                        connCallBack.OnConnectFailed(err.ErrCode, err.ErrMsg);
                        break;
                    }
                case MessageDef.Msg_KickedOffline:
                    connCallBack.OnKickedOffline();
                    break;
                case MessageDef.Msg_UserTokenExpired:
                    connCallBack.OnUserTokenExpired();
                    break;
                case MessageDef.Msg_SyncServerStart:
                    ConversationListener.OnSyncServerStart();
                    break;
                case MessageDef.Msg_SyncServerFinish:
                    ConversationListener.OnSyncServerFinish();
                    break;
                case MessageDef.Msg_SyncServerFailed:
                    ConversationListener.OnSyncServerFailed();
                    break;
                case MessageDef.Msg_NewConversation:
                    {
                        var data = Utils.FromJson<List<LocalConversation>>(msg);
                        ConversationListener.OnNewConversation(data);
                        break;
                    }
                case MessageDef.Msg_ConversationChanged:
                    {
                        var data = Utils.FromJson<List<LocalConversation>>(msg);
                        ConversationListener.OnConversationChanged(data);
                        break;
                    }
                case MessageDef.Msg_TotalUnreadMessageCountChanged:
                    if (int.TryParse(msg, out int count))
                    {
                        ConversationListener.OnTotalUnreadMessageCountChanged(count);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvNewMessage:
                    {
                        var data = Utils.FromJson<MsgStruct>(msg);
                        AdvancedMsgListener.OnRecvNewMessage(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvC2CReadReceipt:
                    {
                        var data = Utils.FromJson<List<MessageReceipt>>(msg);
                        AdvancedMsgListener.OnRecvC2CReadReceipt(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvGroupReadReceipt:
                    {
                        var data = Utils.FromJson<List<MessageReceipt>>(msg);
                        AdvancedMsgListener.OnRecvGroupReadReceipt(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_NewRecvMessageRevoked:
                    {
                        var data = Utils.FromJson<MessageRevoked>(msg);
                        AdvancedMsgListener.OnNewRecvMessageRevoked(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvMessageExtensionsChanged:
                    {
                        var data = Utils.FromJson<MsgIDAndList>(msg);
                        AdvancedMsgListener.OnRecvMessageExtensionsChanged(data.Id, data.List);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvMessageExtensionsDeleted:
                    {
                        var data = Utils.FromJson<MsgIDAndList>(msg);
                        AdvancedMsgListener.OnRecvMessageExtensionsDeleted(data.Id, data.List);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvMessageExtensionsAdded:
                    {
                        var data = Utils.FromJson<MsgIDAndList>(msg);
                        AdvancedMsgListener.OnRecvMessageExtensionsAdded(data.Id, data.List);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvOfflineNewMessage:
                    {
                        var data = Utils.FromJson<MsgStruct>(msg);
                        AdvancedMsgListener.OnRecvOfflineNewMessage(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_MsgDeleted:
                    {
                        var data = Utils.FromJson<MsgStruct>(msg);
                        AdvancedMsgListener.OnMsgDeleted(data);
                    }
                    break;

                case MessageDef.Msg_Batch_RecvNewMessages:
                    {
                        var data = Utils.FromJson<List<MsgStruct>>(msg);
                        BatchMsgListener.OnRecvNewMessages(data);
                    }
                    break;
                case MessageDef.Msg_Batch_RecvOfflineNewMessages:
                    {
                        var data = Utils.FromJson<List<MsgStruct>>(msg);
                        BatchMsgListener.OnRecvOfflineNewMessages(data);
                    }
                    break;
                case MessageDef.Msg_FriendApplicationAdded:
                    {
                        var data = Utils.FromJson<LocalFriendRequest>(msg);
                        FriendShipListener.OnFriendApplicationAdded(data);
                    }
                    break;
                case MessageDef.Msg_FriendApplicationDeleted:
                    {
                        var data = Utils.FromJson<LocalFriendRequest>(msg);
                        FriendShipListener.OnFriendApplicationDeleted(data);
                    }
                    break;
                case MessageDef.Msg_FriendApplicationAccepted:
                    {
                        var data = Utils.FromJson<LocalFriendRequest>(msg);
                        FriendShipListener.OnFriendApplicationAccepted(data);
                    }
                    break;
                case MessageDef.Msg_FriendApplicationRejected:
                    {
                        var data = Utils.FromJson<LocalFriendRequest>(msg);
                        FriendShipListener.OnFriendApplicationRejected(data);
                    }
                    break;
                case MessageDef.Msg_FriendAdded:
                    {
                        var data = Utils.FromJson<LocalFriend>(msg);
                        FriendShipListener.OnFriendAdded(data);
                    }
                    break;
                case MessageDef.Msg_FriendDeleted:
                    {
                        var data = Utils.FromJson<LocalFriend>(msg);
                        FriendShipListener.OnFriendDeleted(data);
                    }
                    break;
                case MessageDef.Msg_FriendInfoChanged:
                    {
                        var data = Utils.FromJson<LocalFriend>(msg);
                        FriendShipListener.OnFriendInfoChanged(data);
                    }
                    break;
                case MessageDef.Msg_BlackAdded:
                    {
                        var data = Utils.FromJson<LocalBlack>(msg);
                        FriendShipListener.OnBlackAdded(data);
                    }
                    break;
                case MessageDef.Msg_BlackDeleted:
                    {
                        var data = Utils.FromJson<LocalBlack>(msg);
                        FriendShipListener.OnBlackDeleted(data);
                    }
                    break;
                case MessageDef.Msg_JoinedGroupAdded:
                    {
                        var data = Utils.FromJson<LocalGroup>(msg);
                        GroupListener.OnJoinedGroupAdded(data);
                    }
                    break;
                case MessageDef.Msg_JoinedGroupDeleted:
                    {
                        var data = Utils.FromJson<LocalGroup>(msg);
                        GroupListener.OnJoinedGroupDeleted(data);
                    }
                    break;
                case MessageDef.Msg_GroupMemberAdded:
                    {
                        var data = Utils.FromJson<LocalGroupMember>(msg);
                        GroupListener.OnGroupMemberAdded(data);
                    }
                    break;
                case MessageDef.Msg_GroupMemberDeleted:
                    {
                        var data = Utils.FromJson<LocalGroupMember>(msg);
                        GroupListener.OnGroupMemberDeleted(data);
                    }
                    break;
                case MessageDef.Msg_GroupApplicationAdded:
                    {
                        var data = Utils.FromJson<LocalGroupRequest>(msg);
                        GroupListener.OnGroupApplicationAdded(data);
                    }
                    break;
                case MessageDef.Msg_GroupApplicationDeleted:
                    {
                        var data = Utils.FromJson<LocalGroupRequest>(msg);
                        GroupListener.OnGroupApplicationDeleted(data);
                    }
                    break;
                case MessageDef.Msg_GroupInfoChanged:
                    {
                        var data = Utils.FromJson<LocalGroup>(msg);
                        GroupListener.OnGroupInfoChanged(data);
                    }
                    break;
                case MessageDef.Msg_GroupDismissed:
                    {
                        var data = Utils.FromJson<LocalGroup>(msg);
                        GroupListener.OnGroupDismissed(data);
                    }
                    break;
                case MessageDef.Msg_GroupMemberInfoChanged:
                    {
                        var data = Utils.FromJson<LocalGroupMember>(msg);
                        GroupListener.OnGroupMemberInfoChanged(data);
                    }
                    break;
                case MessageDef.Msg_GroupApplicationAccepted:
                    {
                        var data = Utils.FromJson<LocalGroupRequest>(msg);
                        GroupListener.OnGroupApplicationAccepted(data);
                    }
                    break;
                case MessageDef.Msg_GroupApplicationRejected:
                    {
                        var data = Utils.FromJson<LocalGroupRequest>(msg);
                        GroupListener.OnGroupApplicationRejected(data);
                    }
                    break;
                case MessageDef.Msg_RecvCustomBusinessMessage:
                    {
                        CustomBusinessListener.OnRecvCustomBusinessMessage(msg);
                    }
                    break;
                case MessageDef.Msg_SelfInfoUpdated:
                    {
                        var data = Utils.FromJson<LocalUser>(msg);
                        UserListener.OnSelfInfoUpdated(data);
                    }
                    break;
                case MessageDef.Msg_UserStatusChanged:
                    {
                        var data = Utils.FromJson<OnlineStatus>(msg);
                        UserListener.OnUserStatusChanged(data);
                    }
                    break;
                case MessageDef.Msg_SendMessage_Error:
                    {
                        var data = Utils.FromJson<Error>(msg);
                        if (callBackDic.TryGetValue(data.OperationId, out Delegate func))
                        {
                            if (func is OnSendMessage)
                            {
                                func.DynamicInvoke(null, data.ErrCode, data.ErrMsg);
                            }
                            callBackDic.Remove(data.OperationId);
                        }
                    }
                    break;
                case MessageDef.Msg_SendMessage_Success:
                    {
                        var data = Utils.FromJson<Success>(msg);
                        MsgStruct msgStruct = ConvertDataType(data.DataType, data.Data) as MsgStruct;
                        if (callBackDic.TryGetValue(data.OperationId, out Delegate func))
                        {
                            if (func is OnSendMessage)
                            {
                                func.DynamicInvoke(msgStruct, 0, "");
                            }
                            callBackDic.Remove(data.OperationId);
                        }
                    }
                    break;
                case MessageDef.Msg_SendMessage_Progress:
                    {
                        // var data = Utils.FromJson<Progress>(msg);
                    }
                    break;
                case MessageDef.Msg_ErrorOrSuc:
                    DispatorErrorOrSucMsg(Utils.FromJson<ErrorOrSuccess>(msg));
                    break;
            }
        }
        private static void DispatorErrorOrSucMsg(ErrorOrSuccess msg)
        {
            if (callBackDic.TryGetValue(msg.OperationId, out Delegate func))
            {
                if (func is OnSucOrError)
                {
                    if (msg.ErrCode >= 0)
                    {
                        func.DynamicInvoke(false, msg.ErrCode, msg.ErrMsg);
                    }
                    else
                    {
                        func.DynamicInvoke(true, 0, "");
                    }
                }
                else if (func is OnInt || func is OnBool)
                {
                    func.DynamicInvoke(ConvertDataType(msg.DataType, msg.Data));
                }
                else
                {
                    if (msg.ErrCode >= 0)
                    {
                        func.DynamicInvoke(null, msg.ErrCode, msg.ErrMsg);
                    }
                    else
                    {
                        func.DynamicInvoke(ConvertDataType(msg.DataType, msg.Data), 0, "");
                    }
                }
                callBackDic.Remove(msg.OperationId);
            }
        }
        private static object ConvertDataType(int type, string msg)
        {
            switch ((DataTypeDef)type)
            {
                case DataTypeDef.DataType_Empty:
                    return null;
                case DataTypeDef.DataType_Int:
                    return Utils.FromJson<int>(msg);
                case DataTypeDef.DataType_Bool:
                    return Utils.FromJson<bool>(msg);
                case DataTypeDef.DataType_LocalConversation:
                    return Utils.FromJson<LocalConversation>(msg);
                case DataTypeDef.DataType_LocalConversation_List:
                    return Utils.FromJson<List<LocalConversation>>(msg);
                case DataTypeDef.DataType_GetConversationRecvMessageOptResp_List:
                    return Utils.FromJson<List<GetConversationRecvMessageOptResp>>(msg);
                case DataTypeDef.DataType_FindMessageList:
                    return Utils.FromJson<FindMessageList>(msg);
                case DataTypeDef.DataType_GetAdvancedHistoryMessageList:
                    return Utils.FromJson<GetAdvancedHistoryMessageList>(msg);
                case DataTypeDef.DataType_MsgStruct:
                    return Utils.FromJson<MsgStruct>(msg);
                case DataTypeDef.DataType_SearchLocalMessagesCallback:
                    return Utils.FromJson<int>(msg);
                case DataTypeDef.DataType_FullUserInfo:
                    return Utils.FromJson<int>(msg);
                case DataTypeDef.DataType_FullUserInfo_List:
                    return Utils.FromJson<List<FullUserInfo>>(msg);
                case DataTypeDef.DataType_FullUserInfoWithCache:
                    return Utils.FromJson<FullUserInfoWithCache>(msg);
                case DataTypeDef.DataType_FullUserInfoWithCache_List:
                    return Utils.FromJson<List<FullUserInfoWithCache>>(msg);
                case DataTypeDef.DataType_LocalUser:
                    return Utils.FromJson<LocalUser>(msg);
                case DataTypeDef.DataType_LocalUser_List:
                    return Utils.FromJson<List<LocalUser>>(msg);
                case DataTypeDef.DataType_OnlineStatus:
                    return Utils.FromJson<OnlineStatus>(msg);
                case DataTypeDef.DataType_OnlineStatus_List:
                    return Utils.FromJson<List<OnlineStatus>>(msg);
                case DataTypeDef.DataType_SearchFriendItem:
                    return Utils.FromJson<SearchFriendItem>(msg);
                case DataTypeDef.DataType_SearchFriendItem_List:
                    return Utils.FromJson<List<SearchFriendItem>>(msg);
                case DataTypeDef.DataType_UserIDResult:
                    return Utils.FromJson<UserIDResult>(msg);
                case DataTypeDef.DataType_UserIDResult_List:
                    return Utils.FromJson<List<UserIDResult>>(msg);
                case DataTypeDef.DataType_LocalFriendRequest:
                    return Utils.FromJson<LocalFriendRequest>(msg);
                case DataTypeDef.DataType_LocalFriendRequest_List:
                    return Utils.FromJson<List<LocalFriendRequest>>(msg);
                case DataTypeDef.DataType_LocalBlack:
                    return Utils.FromJson<LocalBlack>(msg);
                case DataTypeDef.DataType_LocalBlack_List:
                    return Utils.FromJson<List<LocalBlack>>(msg);
                case DataTypeDef.DataType_GroupInfo:
                    return Utils.FromJson<GroupInfo>(msg);
                case DataTypeDef.DataType_LocalGroup:
                    return Utils.FromJson<LocalGroup>(msg);
                case DataTypeDef.DataType_LocalGroup_List:
                    return Utils.FromJson<List<LocalGroup>>(msg);
                case DataTypeDef.DataType_LocalGroupMember:
                    return Utils.FromJson<LocalGroupMember>(msg);
                case DataTypeDef.DataType_LocalGroupMember_List:
                    return Utils.FromJson<List<LocalGroupMember>>(msg);
                case DataTypeDef.DataType_LocalAdminGroupRequest:
                    return Utils.FromJson<LocalAdminGroupRequest>(msg);
                case DataTypeDef.DataType_LocalAdminGroupRequest_List:
                    return Utils.FromJson<List<LocalAdminGroupRequest>>(msg);
                case DataTypeDef.DataType_LocalGroupRequest:
                    return Utils.FromJson<LocalGroupRequest>(msg);
                case DataTypeDef.DataType_LocalGroupRequest_List:
                    return Utils.FromJson<List<LocalGroupRequest>>(msg);
            }
            return null;
        }
    }
}