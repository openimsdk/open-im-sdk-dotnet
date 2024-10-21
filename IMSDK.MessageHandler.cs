using OpenIM.IMSDK.Native;
using Newtonsoft.Json;
using OpenIM.IMSDK.Util;
using System.Collections.Generic;
using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;

namespace OpenIM.IMSDK
{
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
    internal class ActiveCallResult
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

        static ConcurrentQueue<IdMsg> msgCache = new ConcurrentQueue<IdMsg>();

        private static void MessageHandler(int id, IntPtr data)
        {
            var idmsg = new IdMsg
            {
                Id = id,
                Data = Marshal.PtrToStringUTF8(data)
            };
            msgCache.Enqueue(idmsg);
        }
        public static void DispatorMsg(MessageDef id, string msg)
        {
            switch (id)
            {
                case MessageDef.Msg_Connecting:
                    connListener?.OnConnecting();
                    break;
                case MessageDef.Msg_ConnectSuccess:
                    connListener?.OnConnectSuccess();
                    break;
                case MessageDef.Msg_ConnectFailed:
                    {
                        Error err = Utils.FromJson<Error>(msg);
                        connListener?.OnConnectFailed(err.ErrCode, err.ErrMsg);
                        break;
                    }
                case MessageDef.Msg_KickedOffline:
                    connListener?.OnKickedOffline();
                    break;
                case MessageDef.Msg_UserTokenExpired:
                    connListener?.OnUserTokenExpired();
                    break;
                case MessageDef.Msg_UserTokenInvalid:
                    {
                        Error err = Utils.FromJson<Error>(msg);
                        connListener?.OnUserTokenInvalid(err.ErrMsg);
                        break;
                    }
                case MessageDef.Msg_SyncServerStart:
                    conversationListener?.OnSyncServerStart();
                    break;
                case MessageDef.Msg_SyncServerFinish:
                    conversationListener?.OnSyncServerFinish();
                    break;
                case MessageDef.Msg_SyncServerProgress:
                    {
                        var progress = Utils.FromJson<Progress>(msg);
                        conversationListener?.OnSyncServerProgress(progress._Progress);
                        break;
                    }
                case MessageDef.Msg_SyncServerFailed:
                    conversationListener?.OnSyncServerFailed();
                    break;
                case MessageDef.Msg_NewConversation:
                    {
                        var data = Utils.FromJson<List<Conversation>>(msg);
                        conversationListener?.OnNewConversation(data);
                        break;
                    }
                case MessageDef.Msg_ConversationChanged:
                    {
                        var data = Utils.FromJson<List<Conversation>>(msg);
                        conversationListener?.OnConversationChanged(data);
                        break;
                    }
                case MessageDef.Msg_TotalUnreadMessageCountChanged:
                    if (int.TryParse(msg, out int count))
                    {
                        conversationListener?.OnTotalUnreadMessageCountChanged(count);
                    }
                    break;
                case MessageDef.Msg_ConversationUserInputStatusChanged:
                    {
                        var data = Utils.FromJson<InputStatesChangedData>(msg);
                        conversationListener?.OnConversationUserInputStatusChanged(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvNewMessage:
                    {
                        var data = Utils.FromJson<Message>(msg);
                        advancedMsgListener?.OnRecvNewMessage(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvC2CReadReceipt:
                    {
                        var data = Utils.FromJson<List<MessageReceipt>>(msg);
                        advancedMsgListener?.OnRecvC2CReadReceipt(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvGroupReadReceipt:
                    {
                        var data = Utils.FromJson<List<MessageReceipt>>(msg);
                        advancedMsgListener?.OnRecvGroupReadReceipt(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_NewRecvMessageRevoked:
                    {
                        var data = Utils.FromJson<MessageRevoked>(msg);
                        advancedMsgListener?.OnNewRecvMessageRevoked(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvMessageExtensionsChanged:
                    {
                        var data = Utils.FromJson<MsgIDAndList>(msg);
                        advancedMsgListener?.OnRecvMessageExtensionsChanged(data.Id, data.List);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvMessageExtensionsDeleted:
                    {
                        var data = Utils.FromJson<MsgIDAndList>(msg);
                        advancedMsgListener?.OnRecvMessageExtensionsDeleted(data.Id, data.List);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvMessageExtensionsAdded:
                    {
                        var data = Utils.FromJson<MsgIDAndList>(msg);
                        advancedMsgListener?.OnRecvMessageExtensionsAdded(data.Id, data.List);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvOfflineNewMessage:
                    {
                        var data = Utils.FromJson<Message>(msg);
                        advancedMsgListener?.OnRecvOfflineNewMessage(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_MsgDeleted:
                    {
                        var data = Utils.FromJson<Message>(msg);
                        advancedMsgListener?.OnMsgDeleted(data);
                    }
                    break;
                case MessageDef.Msg_Advanced_RecvOnlineOnlyMessage:
                    {
                        var data = Utils.FromJson<Message>(msg);
                        advancedMsgListener?.OnRecvOnlineOnlyMessage(data);
                    }
                    break;
                case MessageDef.Msg_Batch_RecvNewMessages:
                    {
                        var data = Utils.FromJson<List<Message>>(msg);
                        batchMsgListener?.OnRecvNewMessages(data);
                    }
                    break;
                case MessageDef.Msg_Batch_RecvOfflineNewMessages:
                    {
                        var data = Utils.FromJson<List<Message>>(msg);
                        batchMsgListener?.OnRecvOfflineNewMessages(data);
                    }
                    break;
                case MessageDef.Msg_FriendApplicationAdded:
                    {
                        var data = Utils.FromJson<FriendApplicationInfo>(msg);
                        friendShipListener?.OnFriendApplicationAdded(data);
                    }
                    break;
                case MessageDef.Msg_FriendApplicationDeleted:
                    {
                        var data = Utils.FromJson<FriendApplicationInfo>(msg);
                        friendShipListener?.OnFriendApplicationDeleted(data);
                    }
                    break;
                case MessageDef.Msg_FriendApplicationAccepted:
                    {
                        var data = Utils.FromJson<FriendApplicationInfo>(msg);
                        friendShipListener?.OnFriendApplicationAccepted(data);
                    }
                    break;
                case MessageDef.Msg_FriendApplicationRejected:
                    {
                        var data = Utils.FromJson<FriendApplicationInfo>(msg);
                        friendShipListener?.OnFriendApplicationRejected(data);
                    }
                    break;
                case MessageDef.Msg_FriendAdded:
                    {
                        var data = Utils.FromJson<FriendInfo>(msg);
                        friendShipListener?.OnFriendAdded(data);
                    }
                    break;
                case MessageDef.Msg_FriendDeleted:
                    {
                        var data = Utils.FromJson<FriendInfo>(msg);
                        friendShipListener?.OnFriendDeleted(data);
                    }
                    break;
                case MessageDef.Msg_FriendInfoChanged:
                    {
                        var data = Utils.FromJson<FriendInfo>(msg);
                        friendShipListener?.OnFriendInfoChanged(data);
                    }
                    break;
                case MessageDef.Msg_BlackAdded:
                    {
                        var data = Utils.FromJson<BlackInfo>(msg);
                        friendShipListener?.OnBlackAdded(data);
                    }
                    break;
                case MessageDef.Msg_BlackDeleted:
                    {
                        var data = Utils.FromJson<BlackInfo>(msg);
                        friendShipListener?.OnBlackDeleted(data);
                    }
                    break;
                case MessageDef.Msg_JoinedGroupAdded:
                    {
                        var data = Utils.FromJson<GroupInfo>(msg);
                        groupListener?.OnJoinedGroupAdded(data);
                    }
                    break;
                case MessageDef.Msg_JoinedGroupDeleted:
                    {
                        var data = Utils.FromJson<GroupInfo>(msg);
                        groupListener?.OnJoinedGroupDeleted(data);
                    }
                    break;
                case MessageDef.Msg_GroupMemberAdded:
                    {
                        var data = Utils.FromJson<GroupMember>(msg);
                        groupListener?.OnGroupMemberAdded(data);
                    }
                    break;
                case MessageDef.Msg_GroupMemberDeleted:
                    {
                        var data = Utils.FromJson<GroupMember>(msg);
                        groupListener?.OnGroupMemberDeleted(data);
                    }
                    break;
                case MessageDef.Msg_GroupApplicationAdded:
                    {
                        var data = Utils.FromJson<GroupApplicationInfo>(msg);
                        groupListener?.OnGroupApplicationAdded(data);
                    }
                    break;
                case MessageDef.Msg_GroupApplicationDeleted:
                    {
                        var data = Utils.FromJson<GroupApplicationInfo>(msg);
                        groupListener?.OnGroupApplicationDeleted(data);
                    }
                    break;
                case MessageDef.Msg_GroupInfoChanged:
                    {
                        var data = Utils.FromJson<GroupInfo>(msg);
                        groupListener?.OnGroupInfoChanged(data);
                    }
                    break;
                case MessageDef.Msg_GroupDismissed:
                    {
                        var data = Utils.FromJson<GroupInfo>(msg);
                        groupListener?.OnGroupDismissed(data);
                    }
                    break;
                case MessageDef.Msg_GroupMemberInfoChanged:
                    {
                        var data = Utils.FromJson<GroupMember>(msg);
                        groupListener?.OnGroupMemberInfoChanged(data);
                    }
                    break;
                case MessageDef.Msg_GroupApplicationAccepted:
                    {
                        var data = Utils.FromJson<GroupApplicationInfo>(msg);
                        groupListener?.OnGroupApplicationAccepted(data);
                    }
                    break;
                case MessageDef.Msg_GroupApplicationRejected:
                    {
                        var data = Utils.FromJson<GroupApplicationInfo>(msg);
                        groupListener?.OnGroupApplicationRejected(data);
                    }
                    break;
                case MessageDef.Msg_RecvCustomBusinessMessage:
                    {
                    }
                    break;
                case MessageDef.Msg_SelfInfoUpdated:
                    {
                        var data = Utils.FromJson<UserInfo>(msg);
                        userListener?.OnSelfInfoUpdated(data);
                    }
                    break;
                case MessageDef.Msg_UserStatusChanged:
                    {
                        var data = Utils.FromJson<OnlineStatus>(msg);
                        userListener?.OnUserStatusChanged(data);
                    }
                    break;
                case MessageDef.Msg_UserCommandAdd:
                    {
                        userListener?.OnUserCommandAdd(msg);
                        break;
                    }
                case MessageDef.Msg_UserCommandDelete:
                    {
                        userListener?.OnUserCommandDelete(msg);
                        break;
                    }
                case MessageDef.Msg_UserCommandUpdate:
                    {
                        userListener?.OnUserCommandUpdate(msg);
                        break;
                    }
                case MessageDef.Msg_SendMessage_Error:
                    {
                        var data = Utils.FromJson<Error>(msg);
                        if (msgSendCallBackDic.TryGetValue(data.OperationId, out var callBack))
                        {
                            callBack.OnError(data.ErrCode, data.ErrMsg);
                            msgSendCallBackDic.Remove(data.OperationId);
                        }
                    }
                    break;
                case MessageDef.Msg_SendMessage_Success:
                    {
                        var data = Utils.FromJson<Success>(msg);
                        Message message = ConvertDataType(data.DataType, data.Data) as Message;
                        if (msgSendCallBackDic.TryGetValue(data.OperationId, out var callBack))
                        {
                            callBack.OnSuccess(message);
                            msgSendCallBackDic.Remove(data.OperationId);
                        }
                    }
                    break;
                case MessageDef.Msg_SendMessage_Progress:
                    {
                        var data = Utils.FromJson<Progress>(msg);
                        if (msgSendCallBackDic.TryGetValue(data.OperationId, out var callBack))
                        {
                            callBack.OnProgress(data._Progress);
                            msgSendCallBackDic.Remove(data.OperationId);
                        }
                    }
                    break;
                case MessageDef.Msg_ActiveCall:
                    DispatorActiveCallMsg(Utils.FromJson<ActiveCallResult>(msg));
                    break;
            }
        }
        private static void DispatorActiveCallMsg(ActiveCallResult msg)
        {
            if (callBackDic.TryGetValue(msg.OperationId, out Delegate func))
            {
                if (msg.ErrCode >= 0)
                {
                    func.DynamicInvoke(null, msg.ErrCode, msg.ErrMsg);
                }
                else
                {
                    func.DynamicInvoke(ConvertDataType(msg.DataType, msg.Data), 0, "");
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
                case DataTypeDef.DataType_StringArray:
                    return Utils.FromJson<string[]>(msg);
                case DataTypeDef.DataType_Conversation:
                    return Utils.FromJson<Conversation>(msg);
                case DataTypeDef.DataType_Conversation_List:
                    return Utils.FromJson<List<Conversation>>(msg);
                case DataTypeDef.DataType_FindMessageResult:
                    return Utils.FromJson<FindMessageResult>(msg);
                case DataTypeDef.DataType_AdvancedHistoryMessageResult:
                    return Utils.FromJson<AdvancedMessageResult>(msg);
                case DataTypeDef.DataType_Message:
                    return Utils.FromJson<Message>(msg);
                case DataTypeDef.DataType_SearchMessagesResult:
                    return Utils.FromJson<SearchMessageResult>(msg);
                case DataTypeDef.DataType_UserInfo:
                    return Utils.FromJson<UserInfo>(msg);
                case DataTypeDef.DataType_UserInfo_List:
                    return Utils.FromJson<List<UserInfo>>(msg);
                case DataTypeDef.DataType_PublicUserInfo:
                    return Utils.FromJson<PublicUserInfo>(msg);
                case DataTypeDef.DataType_PublicUserInfo_List:
                    return Utils.FromJson<List<PublicUserInfo>>(msg);
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
                case DataTypeDef.DataType_FriendInfo:
                    return Utils.FromJson<FriendInfo>(msg);
                case DataTypeDef.DataType_FriendInfo_List:
                    return Utils.FromJson<List<FriendInfo>>(msg);
                case DataTypeDef.DataType_FriendApplicationInfo:
                    return Utils.FromJson<FriendApplicationInfo>(msg);
                case DataTypeDef.DataType_FriendApplicationInfo_List:
                    return Utils.FromJson<List<FriendApplicationInfo>>(msg);
                case DataTypeDef.DataType_BlackInfo:
                    return Utils.FromJson<BlackInfo>(msg);
                case DataTypeDef.DataType_BlackInfo_List:
                    return Utils.FromJson<List<BlackInfo>>(msg);
                case DataTypeDef.DataType_GroupInfo:
                    return Utils.FromJson<GroupInfo>(msg);
                case DataTypeDef.DataType_GroupInfo_List:
                    return Utils.FromJson<List<GroupInfo>>(msg);
                case DataTypeDef.DataType_GroupMember:
                    return Utils.FromJson<GroupMember>(msg);
                case DataTypeDef.DataType_GroupMember_List:
                    return Utils.FromJson<List<GroupMember>>(msg);
                case DataTypeDef.DataType_GroupApplicationInfo:
                    return Utils.FromJson<GroupApplicationInfo>(msg);
                case DataTypeDef.DataType_GroupApplicationInfo_List:
                    return Utils.FromJson<List<GroupApplicationInfo>>(msg);
            }
            return null;
        }
    }
}