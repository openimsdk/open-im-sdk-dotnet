using System.Collections.Generic;
using System;
using System.Reflection;
using OpenIM.IMSDK.Native;
using OpenIM.IMSDK.Util;
using OpenIM.IMSDK.Listener;

namespace OpenIM.IMSDK
{
    public interface IMsgSendCallBack
    {
        public void OnError(int code, string errMsg);
        public void OnSuccess(Message msg);
        public void OnProgress(long progress);
    }

    public partial class IMSDK
    {
        public delegate void OnBase<T>(T data, int errCode, string errMsg);

        private static Dictionary<string, Delegate> callBackDic = new Dictionary<string, Delegate>();
        private static Dictionary<string, IMsgSendCallBack> msgSendCallBackDic = new Dictionary<string, IMsgSendCallBack>();
        private static IConnListener connListener;
        private static IConversationListener conversationListener;
        private static IGroupListener groupListener;
        private static IFriendShipListener friendShipListener;
        private static IAdvancedMsgListener advancedMsgListener;
        private static IUserListener userListener;
        private static IBatchMsgListener batchMsgListener;
        private static string GetOperationId(string prefix)
        {
            return prefix + "_" + Utils.GetOperationIndex();
        }
        public static void Polling()
        {
            if (msgCache.Count > 0)
            {
                IdMsg msg;
                while (msgCache.TryDequeue(out msg))
                {
                    Utils.Log(string.Format("[{0}]:{1}", (MessageDef)msg.Id, msg.Data));
                    try
                    {
                        DispatorMsg((MessageDef)msg.Id, msg.Data);
                    }
                    catch (Exception e)
                    {
                        Utils.Log(e.ToString());
                    }
                }
            }
        }

        #region convert value 
        class Empty
        {
        }
        class BoolValue
        {
            public bool value;
        }
        class StringValue
        {
            public string value;
        }
        class IntValue
        {
            public int value;
        }
        #endregion

        #region  set listener
        public static void SetConversationListener(IConversationListener l)
        {
            conversationListener = l;
        }
        public static void SetGroupListener(IGroupListener l)
        {
            groupListener = l;
        }
        public static void SetFriendShipListener(IFriendShipListener l)
        {
            friendShipListener = l;
        }
        public static void SetAdvancedMsgListener(IAdvancedMsgListener l)
        {
            advancedMsgListener = l;
        }
        public static void SetUserListener(IUserListener l)
        {
            userListener = l;
        }
        public static void SetBatchMsgListener(IBatchMsgListener l)
        {
            batchMsgListener = l;
        }
        #endregion

        #region init_login
        public static bool InitSDK(IMConfig _config, IConnListener conn)
        {
            connListener = conn;
            NativeSDK.SetMessageHandler(MessageHandler);
            string config = Utils.ToJson(_config);
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                config
            };
            var res = NativeSDK.CallAPI<BoolValue>(APIKey.InitSDK, Utils.ToJson(args));
            return res.value;
        }
        public static void UnInitSDK()
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            NativeSDK.CallAPI<Empty>(APIKey.UnInitSDK, Utils.ToJson(args));
        }
        public static void Login(string uid, string token, OnBase<bool> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                uid,
                token
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.Login, Utils.ToJson(args));
        }
        public static void Logout(OnBase<bool> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.Logout, Utils.ToJson(args));
        }
        public static void SetAppBackGroundStatus(OnBase<bool> cb, bool isBackground)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                isBackground,
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SetAppBackgroundStatus, Utils.ToJson(args));
        }
        public static void NetworkStatusChanged(OnBase<bool> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.NetworkStatusChanged, Utils.ToJson(args));
        }
        public static LoginStatus GetLoginStatus()
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            var res = NativeSDK.CallAPI<IntValue>(APIKey.GetLoginStatus, Utils.ToJson(args));
            return (LoginStatus)res.value;
        }
        public static string GetLoginUserId()
        {
            var res = NativeSDK.CallAPI<StringValue>(APIKey.GetLoginUserID, "");
            return res.value;
        }
        #endregion

        #region conversation_msg
        public static Message CreateTextMessage(string text)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                text,
            };
            var res = NativeSDK.CallAPI<Message>(APIKey.CreateTextMessage, Utils.ToJson(args));
            return res;
        }
        public static Message CreateAdvancedTextMessage(string text, MessageEntity[] messageEntityList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                text,
                messageEntityList = Utils.ToJson(messageEntityList)
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateAdvancedTextMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateTextAtMessage(string text, string[] atUserList, AtInfo[] atUsersInfo, Message message)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                text,
                atUserList = Utils.ToJson(atUserList),
                atUsersInfo = Utils.ToJson(atUsersInfo),
                message = Utils.ToJson(message)
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateTextAtMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateLocationMessage(string description, double longitude, double latitude)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                description,
                longitude,
                latitude
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateLocationMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateCustomMessage(string data, string extension, string description)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                data,
                extension,
                description
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateCustomMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateQuoteMessage(string text, Message message)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                text,
                message = Utils.ToJson(message)
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateQuoteMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateAdvancedQuoteMessage(string text, Message message, MessageEntity[] messageEntityList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                text,
                message = Utils.ToJson(message),
                messageEntityList = Utils.ToJson(messageEntityList)
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateAdvancedQuoteMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateCardMessage(CardElem cardInfo)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                cardInfo = Utils.ToJson(cardInfo),
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateCardMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateVideoMessageFromFullPath(string videoFullPath, string videoType, long duration, string snapshotFullPath)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                videoFullPath,
                videoType,
                duration,
                snapshotFullPath
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateVideoMessageFromFullPath, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateImageMessageFromFullPath(string imageFullPath)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                imageFullPath
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateImageMessageFromFullPath, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateSoundMessageFromFullPath(string soundPath, long duration)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                soundPath,
                duration
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateSoundMessageFromFullPath, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateFileMessageFromFullPath(string fileFullPath, string fileName)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                fileFullPath,
                fileName
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateFileMessageFromFullPath, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateImageMessage(string imagePath)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                imagePath
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateImageMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateImageMessageByURL(string sourcePath, PictureBaseInfo sourcePicture, PictureBaseInfo bigPicture, PictureBaseInfo snapshotPicture)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                sourcePath,
                sourcePicture = Utils.ToJson(sourcePicture),
                bigPicture = Utils.ToJson(bigPicture),
                snapshotPicture = Utils.ToJson(snapshotPicture)
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateImageMessageByURL, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateSoundMessageByURL(SoundElem soundBaseInfo)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                soundBaseInfo = Utils.ToJson(soundBaseInfo)
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateSoundMessageByURL, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateSoundMessage(string soundPath, long duration)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                soundPath,
                duration
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateSoundMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateVideoMessageByURL(VideoElem videoBaseInfo)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                videoBaseInfo = Utils.ToJson(videoBaseInfo)
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateVideoMessageByURL, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateVideoMessage(string videoPath, string videoType, long duration, string snapshotPath)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                videoPath,
                videoType,
                duration,
                snapshotPath,
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateVideoMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateFileMessageByURL(FileElem fileBaseInfo)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                fileBaseInfo = Utils.ToJson(fileBaseInfo)
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateFileMessageByURL, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateFileMessage(string filePath, string fileName)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                filePath,
                fileName
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateFileMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateMergerMessage(Message[] messageList, string title, string[] summaryList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                messageList = Utils.ToJson(messageList),
                title,
                summaryList = Utils.ToJson(summaryList)
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateMergerMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateFaceMessage(int index, string data)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                index,
                data
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateFaceMessage, Utils.ToJson(args));
            return msg;
        }
        public static Message CreateForwardMessage(Message message)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                message = Utils.ToJson(message)
            };
            var msg = NativeSDK.CallAPI<Message>(APIKey.CreateForwardMessage, Utils.ToJson(args));
            return msg;
        }
        public static void GetAllConversationList(OnBase<List<Conversation>> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetAllConversationList, Utils.ToJson(args));
        }
        public static void GetConversationListSplit(OnBase<List<Conversation>> cb, int offset, int count)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                offset,
                count
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetConversationListSplit, Utils.ToJson(args));
        }
        public static void GetOneConversation(OnBase<Conversation> cb, ConversationType sessionType, string sourceId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                sessionType,
                sourceId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetOneConversation, Utils.ToJson(args));
        }
        public static void GetMultipleConversation(OnBase<List<Conversation>> cb, string[] conversationIdList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationIdList = Utils.ToJson(conversationIdList)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetMultipleConversation, Utils.ToJson(args));
        }
        public static void HideConversation(OnBase<bool> cb, string conversationId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.HideConversation, Utils.ToJson(args));
        }
        public static void SetConversation(OnBase<bool> cb, string conversationId, ConversationReq req)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationId,
                req = Utils.ToJson(req)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SetConversation, Utils.ToJson(args));
        }
        public static void SetConversationDraft(OnBase<bool> cb, string conversationId, string draftText)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationId,
                draftText
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SetConversationDraft, Utils.ToJson(args));
        }
        public static void GetTotalUnreadMsgCount(OnBase<int> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetTotalUnreadMsgCount, Utils.ToJson(args));
        }
        public static string GetAtAllTag()
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            var res = NativeSDK.CallAPI<StringValue>(APIKey.GetAtAllTag, Utils.ToJson(args));
            return res.value;
        }
        public static string GetConversationIdBySessionType(string sourceId, int sessionType)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                sourceId,
                sessionType
            };
            var res = NativeSDK.CallAPI<StringValue>(APIKey.GetConversationIDBySessionType, Utils.ToJson(args));
            return res.value;
        }
        public static void SendMessage(IMsgSendCallBack cb, Message message, string recvId, string groupId, OfflinePushInfo offlinePushInfo, bool isOnlineOnly)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                message = Utils.ToJson(message),
                recvId,
                groupId,
                offlinePushInfo = Utils.ToJson(offlinePushInfo),
                isOnlineOnly
            };
            msgSendCallBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SendMessage, Utils.ToJson(args));
        }
        public static void SendMessageNotOSS(IMsgSendCallBack cb, Message message, string recvId, string groupId, OfflinePushInfo offlinePushInfo, bool isOnlineOnly)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                message = Utils.ToJson(message),
                recvId,
                groupId,
                offlinePushInfo = Utils.ToJson(offlinePushInfo),
                isOnlineOnly
            };
            msgSendCallBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SendMessageNotOss, Utils.ToJson(args));
        }
        public static void FindMessageList(OnBase<FindMessageResult> cb, ConversationArgs[] findMessageOptions)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                findMessageOptions = Utils.ToJson(findMessageOptions)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.FindMessageList, Utils.ToJson(args));
        }
        public static void GetAdvancedHistoryMessageList(OnBase<AdvancedMessageResult> cb, GetAdvancedHistoryMessageListParams getMessageOptions)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                getMessageOptions = Utils.ToJson(getMessageOptions)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetAdvancedHistoryMessageList, Utils.ToJson(args));
        }
        public static void GetAdvancedHistoryMessageListReverse(OnBase<AdvancedMessageResult> cb, GetAdvancedHistoryMessageListParams getMessageOptions)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                getMessageOptions = Utils.ToJson(getMessageOptions)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetAdvancedHistoryMessageListReverse, Utils.ToJson(args));
        }
        public static void RevokeMessage(OnBase<bool> cb, string conversationId, string clientMsgId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationId,
                clientMsgId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.RevokeMessage, Utils.ToJson(args));
        }
        public static void TypingStatusUpdate(OnBase<bool> cb, string recvId, string msgTip)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                recvId,
                msgTip
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.TypingStatusUpdate, Utils.ToJson(args));
        }
        public static void MarkConversationMessageAsRead(OnBase<bool> cb, string conversationId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.MarkConversationMessageAsRead, Utils.ToJson(args));
        }
        public static void DeleteMessageFromLocalStorage(OnBase<bool> cb, string conversationId, string clientMsgId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationId,
                clientMsgId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.DeleteMessageFromLocalStorage, Utils.ToJson(args));
        }
        public static void DeleteMessage(OnBase<bool> cb, string conversationId, string clientMsgId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationId,
                clientMsgId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.DeleteMessage, Utils.ToJson(args));
        }
        public static void HideAllConversations(OnBase<bool> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.HideAllConversations, Utils.ToJson(args));
        }
        public static void DeleteAllMsgFromLocalAndSVR(OnBase<bool> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.DeleteAllMsgFromLocalAndSvr, Utils.ToJson(args));
        }
        public static void DeleteAllMsgFromLocal(OnBase<bool> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.DeleteAllMsgFromLocal, Utils.ToJson(args));
        }
        public static void ClearConversationAndDeleteAllMsg(OnBase<bool> cb, string conversationId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.ClearConversationAndDeleteAllMsg, Utils.ToJson(args));
        }
        public static void DeleteConversationAndDeleteAllMsg(OnBase<bool> cb, string conversationId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.DeleteConversationAndDeleteAllMsg, Utils.ToJson(args));
        }
        public static void InsertSingleMessageToLocalStorage(OnBase<Message> cb, Message message, string recvId, string sendId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                message = Utils.ToJson(message),
                recvId,
                sendId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.InsertSingleMessageToLocalStorage, Utils.ToJson(args));
        }
        public static void InsertGroupMessageToLocalStorage(OnBase<Message> cb, Message message, string groupId, string sendId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                message = Utils.ToJson(message),
                groupId,
                sendId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.InsertGroupMessageToLocalStorage, Utils.ToJson(args));
        }
        public static void SearchLocalMessages(OnBase<SearchMessageResult> cb, SearchMessagesParams searchParam)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                searchParam = Utils.ToJson(searchParam)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SearchLocalMessages, Utils.ToJson(args));
        }
        public static void SetMessageLocalEx(OnBase<bool> cb, string conversationId, string clientMsgId, string localEx)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                conversationId,
                clientMsgId,
                localEx
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SetMessageLocalEx, Utils.ToJson(args));
        }
        #endregion

        #region user
        public static void GetUsersInfo(OnBase<List<PublicUserInfo>> cb, string[] userIds)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                userIds = Utils.ToJson(userIds)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetUsersInfo, Utils.ToJson(args));
        }
        public static void SetSelfInfo(OnBase<bool> cb, UserInfo userInfo)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                userInfo = Utils.ToJson(userInfo)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SetSelfInfo, Utils.ToJson(args));
        }
        public static void GetSelfUserInfo(OnBase<UserInfo> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetSelfUserInfo, Utils.ToJson(args));
        }
        public static void SubscribeUsersStatus(OnBase<List<OnlineStatus>> cb, string[] userIds)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                userIds = Utils.ToJson(userIds)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SubscribeUsersStatus, Utils.ToJson(args));
        }
        public static void UnsubscribeUsersStatus(OnBase<bool> cb, string[] userIds)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                userIds = Utils.ToJson(userIds)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.UnsubscribeUsersStatus, Utils.ToJson(args));
        }
        public static void GetSubscribeUsersStatus(OnBase<List<OnlineStatus>> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetSubscribeUsersStatus, Utils.ToJson(args));
        }
        public static void GetUserStatus(OnBase<List<OnlineStatus>> cb, string[] userIds)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                userIds = Utils.ToJson(userIds)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetUserStatus, Utils.ToJson(args));
        }
        #endregion

        #region friend
        public static void GetSpecifiedFriendsInfo(OnBase<List<FriendInfo>> cb, string[] userIdList, bool filterBlack)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                userIdList = Utils.ToJson(userIdList),
                filterBlack
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetSpecifiedFriendsInfo, Utils.ToJson(args));
        }
        public static void GetFriendList(OnBase<List<FriendInfo>> cb, bool filterBlack)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                filterBlack
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetFriendList, Utils.ToJson(args));
        }
        public static void GetFriendListPage(OnBase<List<FriendInfo>> cb, int offset, int count, bool filterBlack)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                offset,
                count,
                filterBlack
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetFriendListPage, Utils.ToJson(args));
        }

        public static void SearchFriends(OnBase<List<SearchFriendItem>> cb, SearchFriendsParam searchParam)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                searchParam = Utils.ToJson(searchParam)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SearchFriends, Utils.ToJson(args));
        }
        public static void UpdateFriends(OnBase<bool> cb, UpdateFriendsReq req)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                req = Utils.ToJson(req)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.UpdateFriends, Utils.ToJson(args));
        }
        public static void CheckFriend(OnBase<List<UserIDResult>> cb, string[] userIdList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                userIdList = Utils.ToJson(userIdList)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.CheckFriend, Utils.ToJson(args));
        }
        public static void AddFriend(OnBase<bool> cb, ApplyToAddFriendReq userIdReqMsg)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                userIdReqMsg = Utils.ToJson(userIdReqMsg)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.AddFriend, Utils.ToJson(args));
        }
        public static void DeleteFriend(OnBase<bool> cb, string friendUserId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                friendUserId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.DeleteFriend, Utils.ToJson(args));
        }
        public static void GetFriendApplicationListAsRecipient(OnBase<List<FriendApplicationInfo>> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetFriendApplicationListAsRecipient, Utils.ToJson(args));
        }
        public static void GetFriendApplicationListAsApplicant(OnBase<List<FriendApplicationInfo>> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetFriendApplicationListAsApplicant, Utils.ToJson(args));
        }
        public static void AcceptFriendApplication(OnBase<bool> cb, ProcessFriendApplicationParams userIDHandleMsg)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                userIdHandleMsg = Utils.ToJson(userIDHandleMsg)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.AcceptFriendApplication, Utils.ToJson(args));
        }
        public static void RefuseFriendApplication(OnBase<bool> cb, ProcessFriendApplicationParams userIdHandleMsg)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                userIdHandleMsg = Utils.ToJson(userIdHandleMsg)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.RefuseFriendApplication, Utils.ToJson(args));
        }
        public static void AddBlack(OnBase<bool> cb, string blackUserId, string ex)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                blackUserId,
                ex
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.AddBlack, Utils.ToJson(args));
        }
        public static void GetBlackList(OnBase<List<BlackInfo>> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetBlackList, Utils.ToJson(args));
        }
        public static void RemoveBlack(OnBase<bool> cb, string removeUserId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                removeUserId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.RemoveBlack, Utils.ToJson(args));
        }
        #endregion

        #region group
        public static void CreateGroup(OnBase<GroupInfo> cb, CreateGroupReq groupReqInfo)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupReqInfo = Utils.ToJson(groupReqInfo)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.CreateGroup, Utils.ToJson(args));
        }
        public static void JoinGroup(OnBase<bool> cb, string groupId, string reqMsg, JoinSource joinSource, string ex)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                reqMsg,
                joinSource = (int)joinSource,
                ex,
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.JoinGroup, Utils.ToJson(args));
        }
        public static void QuitGroup(OnBase<bool> cb, string groupId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.QuitGroup, Utils.ToJson(args));
        }

        public static void DismissGroup(OnBase<bool> cb, string groupId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.DismissGroup, Utils.ToJson(args));
        }
        public static void ChangeGroupMute(OnBase<bool> cb, string groupId, bool isMute)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                isMute,
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.ChangeGroupMute, Utils.ToJson(args));
        }
        public static void ChangeGroupMemberMute(OnBase<bool> cb, string groupId, string userId, int mutedSeconds)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                userId,
                mutedSeconds
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.ChangeGroupMemberMute, Utils.ToJson(args));
        }
        public static void SetGroupMemberInfo(OnBase<bool> cb, SetGroupMemberInfo groupMemberInfo)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupMemberInfo = Utils.ToJson(groupMemberInfo)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SetGroupMemberInfo, Utils.ToJson(args));
        }
        public static void GetJoinedGroupList(OnBase<List<GroupInfo>> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetJoinedGroupList, Utils.ToJson(args));
        }
        public static void GetJoinedGroupListPage(OnBase<List<GroupInfo>> cb, int offset, int count)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                offset,
                count
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetJoinedGroupListPage, Utils.ToJson(args));
        }
        public static void GetSpecifiedGroupsInfo(OnBase<List<GroupInfo>> cb, string[] groupIdList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupIdList = Utils.ToJson(groupIdList)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetSpecifiedGroupsInfo, Utils.ToJson(args));
        }
        public static void SearchGroups(OnBase<List<GroupInfo>> cb, SearchGroupsParam searchParam)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                searchParam = Utils.ToJson(searchParam)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SearchGroups, Utils.ToJson(args));
        }
        public static void SetGroupInfo(OnBase<bool> cb, GroupInfoForSet groupInfo)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupInfo = Utils.ToJson(groupInfo)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SetGroupInfo, Utils.ToJson(args));
        }
        public static void GetGroupMemberList(OnBase<List<GroupMember>> cb, string groupId, GroupMemberFilter filter, int offset, int count)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                filter,
                offset,
                count,
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetGroupMemberList, Utils.ToJson(args));
        }
        public static void GetGroupMemberOwnerAndAdmin(OnBase<List<GroupMember>> cb, string groupId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetGroupMemberOwnerAndAdmin, Utils.ToJson(args));
        }
        public static void GetGroupMemberListByJoinTimeFilter(OnBase<List<GroupMember>> cb, string groupId, int offset, int count, long joinTimeBegin, long joinTimeEnd, string[] filterUserIDList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                offset,
                count,
                joinTimeBegin,
                joinTimeEnd,
                filterUserIdList = Utils.ToJson(filterUserIDList)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetGroupMemberListByJoinTimeFilter, Utils.ToJson(args));
        }
        public static void GetSpecifiedGroupMembersInfo(OnBase<List<GroupMember>> cb, string groupId, string[] userIdList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                userIdList = Utils.ToJson(userIdList)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetSpecifiedGroupMembersInfo, Utils.ToJson(args));
        }
        public static void KickGroupMember(OnBase<bool> cb, string groupId, string reason, string[] userIdList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                reason,
                userIdList = Utils.ToJson(userIdList)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.KickGroupMember, Utils.ToJson(args));
        }
        public static void TransferGroupOwner(OnBase<bool> cb, string groupId, string newOwnerUserId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                newOwnerUserId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.TransferGroupOwner, Utils.ToJson(args));
        }
        public static void InviteUserToGroup(OnBase<bool> cb, string groupId, string reason, string[] userIdList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                reason,
                userIdList = Utils.ToJson(userIdList)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.InviteUserToGroup, Utils.ToJson(args));
        }
        public static void GetGroupApplicationListAsRecipient(OnBase<List<GroupApplicationInfo>> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetGroupApplicationListAsRecipient, Utils.ToJson(args));
        }
        public static void GetGroupApplicationListAsApplicant(OnBase<List<GroupApplicationInfo>> cb)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetGroupApplicationListAsApplicant, Utils.ToJson(args));
        }
        public static void AcceptGroupApplication(OnBase<bool> cb, string groupId, string fromUserId, string handleMsg)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                fromUserId,
                handleMsg,
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.AcceptGroupApplication, Utils.ToJson(args));
        }
        public static void RefuseGroupApplication(OnBase<bool> cb, string groupId, string fromUserId, string handleMsg)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                fromUserId,
                handleMsg
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.RefuseFriendApplication, Utils.ToJson(args));
        }
        public static void SearchGroupMembers(OnBase<List<GroupMember>> cb, SearchGroupMembersParam searchParam)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                searchParam = Utils.ToJson(searchParam)
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.SearchGroupMembers, Utils.ToJson(args));
        }
        public static void IsJoinGroup(OnBase<bool> cb, string groupId)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.IsJoinGroup, Utils.ToJson(args));
        }
        public static void GetUsersInGroup(OnBase<string[]> cb, string groupId, string[] userIdList)
        {
            var args = new
            {
                operationId = GetOperationId(MethodBase.GetCurrentMethod().Name),
                groupId,
                userIdList
            };
            callBackDic[args.operationId] = cb;
            NativeSDK.CallAPI<Empty>(APIKey.GetUsersInGroup, Utils.ToJson(args));
        }
        #endregion
    }
}