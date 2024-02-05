using System.Runtime.InteropServices;
using open_im_sdk.native;
using open_im_sdk.util;
using open_im_sdk.listener;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace open_im_sdk
{
    public partial class IMSDK
    {
        public delegate void OnInt(int v);
        public delegate void OnBool(int v);
        public delegate void OnSucOrError(bool suc, int errCode, string errMsg);
        public delegate void OnConversationList(List<LocalConversation> list, int errCode, string errMsg);
        public delegate void OnLocalUser(LocalUser user, int errCode, string errMsg);
        public delegate void OnLocalUserList(List<LocalUser> list, int errCode, string errMsg);
        public delegate void OnFullUserInfoList(List<FullUserInfo> list, int errCode, string errMsg);
        public delegate void OnFullUserInfoWithCacheList(List<FullUserInfoWithCache> list, int errCode, string errMsg);
        public delegate void OnGetConversationRecvMessageOptRespList(List<GetConversationRecvMessageOptResp> list, int errCode, string errMsg);
        public delegate void OnFindMesageList(List<FindMessageList> list, int errCode, string errMsg);
        public delegate void OnGetAdvancedHistoryMessageList(List<GetAdvancedHistoryMessageList> list, int errCode, string errMsg);
        public delegate void OnMsgStruct(MsgStruct msg, int errCode, string errMsg);
        public delegate void OnSearchLocalMessagesCallback(SearchLocalMessagesCallback v, int errCode, string errMsg);
        public delegate void OnOnlineStatusList(List<OnlineStatus> list, int errCode, string errMsg);
        public delegate void OnSearchFriendItemList(List<SearchFriendItem> list, int errCode, string errMsg);
        public delegate void OnUserIDResultList(List<UserIDResult> list, int errCode, string errMsg);
        public delegate void OnLocalFriendRequestList(List<LocalFriendRequest> list, int errCode, string errMsg);
        public delegate void OnLocalBlackList(List<LocalBlack> list, int errCode, string errMsg);
        public delegate void OnGroupInfo(List<GroupInfo> list, int errCode, string errMsg);
        public delegate void OnLocalGroupList(List<LocalGroup> list, int errCode, string errMsg);
        public delegate void OnLocalGroupMemberList(List<LocalGroupMember> list, int errCode, string errMsg);
        public delegate void OnLocalAdminGroupRequestList(List<LocalAdminGroupRequest> list, int errCode, string errMsg);
        public delegate void OnLocalGroupRequestList(List<LocalGroupRequest> list, int errCode, string errMsg);
        public delegate void OnSendMessage(MsgStruct msg, int errCode, string errMsg);
        private static Dictionary<string, Delegate> callBackDic = new Dictionary<string, Delegate>();
        private static IConnCallBack connCallBack;
        private static IConversationListener ConversationListener;
        private static IGroupListener GroupListener;
        private static IFriendShipListener FriendShipListener;
        private static IAdvancedMsgListener AdvancedMsgListener;
        private static IUserListener UserListener;
        private static ICustomBusinessListener CustomBusinessListener;
        private static IBatchMsgListener BatchMsgListener;

        #region sdk help function
        private static string GetOperationID(string prefix)
        {
            return prefix + "_" + Utils.GetOperationIndex();
        }
        public static void Polling()
        {
            if (msgCache.Count > 0)
            {
                for (int i = 0; i < msgCache.Count; i++)
                {
                    try
                    {
                        DispatorMsg((MessageDef)msgCache[i].Id, msgCache[i].Data);
                    }
                    catch (Exception e)
                    {
                        Utils.Log("DispatorMsg Exception", e.ToString());
                    }
                }
                msgCache.Clear();
            }
        }
        #endregion

        #region set global listener
        public static void SetConversationListener(IConversationListener l)
        {
            ConversationListener = l;
        }
        public static void SetGroupListener(IGroupListener l)
        {
            GroupListener = l;
        }
        public static void SetFriendShipListener(IFriendShipListener l)
        {
            FriendShipListener = l;
        }
        public static void SetAdvancedMsgListener(IAdvancedMsgListener l)
        {
            AdvancedMsgListener = l;
        }
        public static void SetBatchMsgListener(IBatchMsgListener l)
        {
            BatchMsgListener = l;
        }
        public static void SetUserListener(IUserListener l)
        {
            UserListener = l;
        }
        public static void SetCustomBusinessListener(ICustomBusinessListener l)
        {
            CustomBusinessListener = l;
        }
        #endregion

        #region init_login
        public static bool InitSDK(IMConfig config, IConnCallBack cb)
        {
            connCallBack = cb;
            IMNativeSDK.SetMessageHandler(MessageHandler);
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var configJson = Utils.ToJson(config);
            return IMNativeSDK.init_sdk(operationID, configJson);
        }
        public static void UnInitSDK()
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IMNativeSDK.un_init_sdk(operationID);
        }
        public static void Login(string uid, string token, OnSucOrError cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.login(operationID, uid, token);
        }
        public static void Logout(OnSucOrError cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.logout(operationID);
        }
        public static void SetAppBackGroundStatus(bool isBackGround, OnSucOrError cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_app_background_status(operationID, isBackGround ? 1 : 0);
        }
        public static void NetworkStatusChanged(OnSucOrError cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.network_status_changed(operationID);
        }
        public static LoginStatus GetLoginStatus()
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            return (LoginStatus)IMNativeSDK.get_login_status(operationID);
        }
        public static string GetLoginUser()
        {
            var strPtr = IMNativeSDK.get_login_user();
            var loginUser = Marshal.PtrToStringUTF8(strPtr);
            Marshal.FreeHGlobal(strPtr);
            return loginUser;
        }
        #endregion

        #region conversation_msg
        public static MsgStruct CreateTextMessage(string text)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_text_message(operationID, text);
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return Utils.FromJson<MsgStruct>(json);
        }
        public static MsgStruct CreateAdvancedTextMessage(string text, MessageEntity[] messageEntityList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_advanced_text_message(operationID, text, Utils.ToJson(messageEntityList));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateTextAtMessage(string text, string[] atUserList, AtInfo atUsersInfo, MsgStruct message)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_text_at_message(operationID, text, Utils.ToJson(atUserList), Utils.ToJson(atUsersInfo), Utils.ToJson(message));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateLocationMessage(string description, double longitude, double latitude)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_location_message(operationID, description, longitude, latitude);
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateCustomMessage(string data, string extension, string description)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_custom_message(operationID, data, extension, description);
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateQuoteMessage(string text, MsgStruct message)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_quote_message(operationID, text, Utils.ToJson(message));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateAdvancedQuoteMessage(string text, MsgStruct message, MessageEntity[] messageEntityList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_advanced_quote_message(operationID, text, Utils.ToJson(message), Utils.ToJson(messageEntityList));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateCardMessage(CardElem cardInfo)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_card_message(operationID, Utils.ToJson(cardInfo));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateVideoMessageFromFullPath(string videoFullPath, string videoType, long duration, string snapshotFullPath)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_video_message_from_full_path(operationID, videoFullPath, videoType, duration, snapshotFullPath);
            Marshal.FreeHGlobal(res);
            var json = Marshal.PtrToStringUTF8(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateImageMessageFromFullPath(string imageFullPath)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_image_message_from_full_path(operationID, imageFullPath);
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateSoundMessageFromFullPath(string soundPath, long duration)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_sound_message_from_full_path(operationID, soundPath, duration);
            Marshal.FreeHGlobal(res);
            var json = Marshal.PtrToStringUTF8(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateFileMessageFromFullPath(string fileFullPath, string fileName)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_file_message_from_full_path(operationID, fileFullPath, fileName);
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateImageMessage(string imagePath)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_image_message(operationID, imagePath);
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateImageMessageByURL(string sourcePath, PictureBaseInfo sourcePicture, PictureBaseInfo bigPicture, PictureBaseInfo snapshotPicture)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_image_message_by_url(operationID, sourcePath, Utils.ToJson(sourcePicture), Utils.ToJson(bigPicture), Utils.ToJson(snapshotPicture));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateSoundMessageByURL(SoundBaseInfo soundBaseInfo)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_sound_message_by_url(operationID, Utils.ToJson(soundBaseInfo));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateSoundMessage(string soundPath, long duration)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_sound_message(operationID, soundPath, duration);
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateVideoMessageByURL(VideoBaseInfo videoBaseInfo)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_video_message_by_url(operationID, Utils.ToJson(videoBaseInfo));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateVideoMessage(string videoPath, string videoType, long duration, string snapshotPath)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_video_message(operationID, videoPath, videoType, duration, snapshotPath);
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateFileMessageByURL(FileBaseInfo fileBaseInfo)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_file_message_by_url(operationID, Utils.ToJson(fileBaseInfo));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateFileMessage(string filePath, string fileName)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_file_message(operationID, filePath, fileName);
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateMergerMessage(MsgStruct[] messageList, string title, string[] summaryList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_merger_message(operationID, Utils.ToJson(messageList), title, Utils.ToJson(summaryList));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateFaceMessage(int index, string data)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_face_message(operationID, index, data);
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static MsgStruct CreateForwardMessage(MsgStruct m)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.create_forward_message(operationID, Utils.ToJson(m));
            var json = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return JsonConvert.DeserializeObject<MsgStruct>(json);
        }
        public static void GetAllConversationList(OnConversationList cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_all_conversation_list(operationID);
        }
        public static void GetConversationListSplit(OnConversationList cb, int offset, int count)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_conversation_list_split(operationID, offset, count);
        }
        public static void GetOneConversation(OnConversationList cb, int sessionType, string sourceID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_one_conversation(operationID, sessionType, sourceID);
        }
        public static void GetMultipleConversation(OnConversationList cb, string[] conversationIdList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_multiple_conversation(operationID, Utils.ToJson(conversationIdList));
        }
        public static void SetConversationMsgDeStructTime(OnSucOrError cb, string conversationID, long msgDestructTime)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_conversation_msg_destruct_time(operationID, conversationID, msgDestructTime);
        }
        public static void SetConversationIsMsgDeStruct(OnSucOrError cb, string conversationID, bool isMsgDestruct)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_conversation_is_msg_destruct(operationID, conversationID, isMsgDestruct ? 1 : 0);
        }
        public static void HideConversation(OnSucOrError cb, string conversationID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.hide_conversation(operationID, conversationID);
        }
        public static void GetConversationRecvMessageOpt(OnGetConversationRecvMessageOptRespList cb, string[] conversationIDList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_conversation_recv_message_opt(operationID, Utils.ToJson(conversationIDList));
        }
        public static void SetConversationDraft(OnSucOrError cb, string conversationID, string draftText)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_conversation_draft(operationID, conversationID, draftText);
        }
        public static void ResetConversationGroupAtType(OnSucOrError cb, string conversationID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.reset_conversation_group_at_type(operationID, conversationID);
        }
        public static void PinConversation(OnSucOrError cb, string conversationID, bool isPinned)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.pin_conversation(operationID, conversationID, isPinned ? 1 : 0);
        }
        public static void SetConversationPrivateChat(OnSucOrError cb, string conversationID, bool isPrivate)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_conversation_private_chat(operationID, conversationID, isPrivate ? 1 : 0);
        }
        public static void SetConversationBurnDuration(OnSucOrError cb, string conversationID, int duration)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_conversation_burn_duration(operationID, conversationID, duration);
        }
        public static void SetConversationRecvMessageOpt(OnSucOrError cb, string conversationID, int opt)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_conversation_recv_message_opt(operationID, conversationID, opt);
        }
        public static void GetTotalUnreadMsgCount(OnInt cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_total_unread_msg_count(operationID);
        }
        public static string GetAtAllTag()
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.get_at_all_tag(operationID);
            var data = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return data;
        }
        public static string GetConversationIdBySessionType(string sourceID, int sessionType)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IntPtr res = IMNativeSDK.get_conversation_id_by_session_type(operationID, sourceID, sessionType);
            var data = Marshal.PtrToStringUTF8(res);
            Marshal.FreeHGlobal(res);
            return data;
        }
        public static void SendMessage(OnSendMessage cb, MsgStruct message, string recvID, string groupID, OfflinePushInfo offlinePushInfo)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.send_message(operationID, Utils.ToJson(message), recvID, groupID, Utils.ToJson(offlinePushInfo));
        }
        public static void SendMessageNotOSS(OnSendMessage cb, MsgStruct message, string recvID, string groupID, OfflinePushInfo offlinePushInfo)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.send_message_not_oss(operationID, Utils.ToJson(message), recvID, groupID, Utils.ToJson(offlinePushInfo));
        }
        public static void FindMessageList(OnFindMesageList cb, ConversationArgs[] findMessageOptions)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.find_message_list(operationID, Utils.ToJson(findMessageOptions));
        }
        public static void GetAdvancedHistoryMessageList(OnGetAdvancedHistoryMessageList cb, GetAdvancedHistoryMessageListParams getMessageOptions)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_advanced_history_message_list(operationID, Utils.ToJson(getMessageOptions));
        }
        public static void GetAdvancedHistoryMessageListReverse(OnGetAdvancedHistoryMessageList cb, GetAdvancedHistoryMessageListParams getMessageOptions)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_advanced_history_message_list_reverse(operationID, Utils.ToJson(getMessageOptions));
        }
        public static void RevokeMessage(OnGetAdvancedHistoryMessageList cb, string conversationID, string clientMsgID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.revoke_message(operationID, conversationID, clientMsgID);
        }
        public static void TypingStatusUpdate(OnSucOrError cb, string recvID, string msgTip)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.typing_status_update(operationID, recvID, msgTip);
        }
        public static void MarkConversationMessageAsRead(OnSucOrError cb, string conversationID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.mark_conversation_message_as_read(operationID, conversationID);
        }
        public static void DeleteMessageFromLocalStorage(OnSucOrError cb, string conversationID, string clientMsgID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.delete_message_from_local_storage(operationID, conversationID, clientMsgID);
        }
        public static void DeleteMessage(OnSucOrError cb, string conversationID, string clientMsgID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.delete_message(operationID, conversationID, clientMsgID);
        }
        public static void HideAllConversations(OnSucOrError cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.hide_all_conversations(operationID);
        }
        public static void DeleteAllMsgFromLocalAndSVR(OnSucOrError cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.delete_all_msg_from_local_and_svr(operationID);
        }
        public static void DeleteAllMsgFromLocal(OnSucOrError cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.delete_all_msg_from_local(operationID);
        }
        public static void ClearConversationAndDeleteAllMsg(OnSucOrError cb, string conversationID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.clear_conversation_and_delete_all_msg(operationID, conversationID);

        }
        public static void DeleteConversationAndDeleteAllMsg(OnSucOrError cb, string conversationID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.delete_conversation_and_delete_all_msg(operationID, conversationID);
        }
        public static void InsertSingleMessageToLocalStorage(OnMsgStruct cb, string message, string recvID, string sendID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.insert_single_message_to_local_storage(operationID, message, recvID, sendID);
        }
        public static void InsertGroupMessageToLocalStorage(OnMsgStruct cb, string message, string groupID, string sendID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.insert_group_message_to_local_storage(operationID, message, groupID, sendID);
        }
        public static void SearchLocalMessages(OnSearchLocalMessagesCallback cb, SearchLocalMessagesParams searchParam)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.search_local_messages(operationID, Utils.ToJson(searchParam));
        }
        public static void SetMessageLocalEx(OnSucOrError cb, string conversationID, string clientMsgID, string localEx)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_message_local_ex(operationID, conversationID, clientMsgID, localEx);
        }
        #endregion

        #region user
        public static void GetUsersInfo(OnFullUserInfoList cb, string[] userIDs)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_users_info(operationID, Utils.ToJson(userIDs));
        }
        public static void GetUsersInfoWithCache(OnFullUserInfoWithCacheList cb, string[] userIds, string groupId)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_users_info_with_cache(operationID, Utils.ToJson(userIds), groupId);
        }
        public static void GetUsersInfoFromSRV(OnLocalUserList cb, string[] userIDs)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_users_info_from_srv(operationID, Utils.ToJson(userIDs));
        }
        public static void SetSelfInfo(OnSucOrError cb, UserInfo userInfo)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_self_info(operationID, Utils.ToJson(userInfo));
        }
        public static void SetGlobalRecvMessageOpt(OnSucOrError cb, int opt)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_global_recv_message_opt(operationID, opt);
        }
        public static void GetSelfUserInfo(OnLocalUser cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_self_user_info(operationID);
        }
        public static void UpdateMsgSenderInfo(OnSucOrError cb, string nickname, string faceURL)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.update_msg_sender_info(operationID, nickname, faceURL);
        }
        public static void SubscribeUsersStatus(OnOnlineStatusList cb, string[] userIDs)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.subscribe_users_status(operationID, Utils.ToJson(userIDs));
        }
        public static void UnsubscribeUsersStatus(OnSucOrError cb, string[] userIDs)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.unsubscribe_users_status(operationID, Utils.ToJson(userIDs));
        }
        public static void GetSubscribeUsersStatus(OnOnlineStatusList cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_subscribe_users_status(operationID);
        }
        public static void GetUserStatus(OnOnlineStatusList cb, string[] userIDs)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_user_status(operationID, Utils.ToJson(userIDs));
        }
        #endregion

        #region friend
        public static void GetSpecifiedFriendsInfo(OnFullUserInfoList cb, string[] userIDList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_specified_friends_info(operationID, Utils.ToJson(userIDList));
        }
        public static void GetFriendList(OnFullUserInfoList cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_friend_list(operationID);
        }
        public static void GetFriendListPage(OnFullUserInfoList cb, int offset, int count)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_friend_list_page(operationID, offset, count);
        }
        public static void SearchFriends(OnSearchFriendItemList cb, SearchFriendsParam searchParam)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.search_friends(operationID, Utils.ToJson(searchParam));
        }
        public static void CheckFriend(OnUserIDResultList cb, string[] userIDList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.check_friend(operationID, Utils.ToJson(userIDList));
        }
        public static void AddFriend(OnSucOrError cb, ApplyToAddFriendReq userIDReqMsg)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.add_friend(operationID, Utils.ToJson(userIDReqMsg));
        }
        public static void SetFriendRemark(OnSucOrError cb, SetFriendRemarkParams userIDRemark)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_friend_remark(operationID, Utils.ToJson(userIDRemark));
        }
        public static void DeleteFriend(OnSucOrError cb, string friendUserID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.delete_friend(operationID, friendUserID);
        }
        public static void GetFriendApplicationListAsRecipient(OnLocalFriendRequestList cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_friend_application_list_as_recipient(operationID);
        }
        public static void GetFriendApplicationListAsApplicant(OnLocalFriendRequestList cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_friend_application_list_as_applicant(operationID);
        }
        public static void AcceptFriendApplication(OnSucOrError cb, ProcessFriendApplicationParams userIDHandleMsg)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.accept_friend_application(operationID, Utils.ToJson(userIDHandleMsg));
        }
        public static void RefuseFriendApplication(OnSucOrError cb, ProcessFriendApplicationParams userIDHandleMsg)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.refuse_friend_application(operationID, Utils.ToJson(userIDHandleMsg));
        }
        public static void AddBlack(OnSucOrError cb, string blackUserID, string ex)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.add_black(operationID, blackUserID, ex);
        }
        public static void GetBlackList(OnLocalBlackList cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_black_list(operationID);
        }
        public static void RemoveBlack(OnSucOrError cb, string removeUserID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.remove_black(operationID, removeUserID);
        }
        #endregion

        #region group
        public static void CreateGroup(OnGroupInfo cb, CreateGroupReq groupReqInfo)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.create_group(operationID, Utils.ToJson(groupReqInfo));
        }
        public static void JoinGroup(OnSucOrError cb, string groupID, string reqMsg, int cJoinSource, string ex)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.join_group(operationID, groupID, reqMsg, cJoinSource, ex);
        }
        public static void QuitGroup(OnSucOrError cb, string groupID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.quit_group(operationID, groupID);
        }

        public static void DismissGroup(OnSucOrError cb, string groupID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.dismiss_group(operationID, groupID);
        }
        public static void ChangeGroupMute(OnSucOrError cb, string groupID, bool isMute)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.change_group_mute(operationID, groupID, isMute ? 1 : 0);
        }
        public static void ChangeGroupMemberMute(OnSucOrError cb, string groupID, string userID, int mutedSeconds)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.change_group_member_mute(operationID, groupID, userID, mutedSeconds);
        }
        public static void SetGroupMemberRoleLevel(OnSucOrError cb, string groupID, string userID, int roleLevel)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_group_member_role_level(operationID, groupID, userID, roleLevel);
        }
        public static void SetGroupMemberInfo(OnSucOrError cb, SetGroupMemberInfo groupMemberInfo)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_group_member_info(operationID, Utils.ToJson(groupMemberInfo));
        }
        public static void GetJoinedGroupList(OnLocalGroupList cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_joined_group_list(operationID);
        }
        public static void GetSpecifiedGroupsInfo(OnLocalGroupList cb, string[] groupIDList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_specified_groups_info(operationID, Utils.ToJson(groupIDList));
        }
        public static void SearchGroups(OnLocalGroupList cb, SearchGroupsParam searchParam)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.search_groups(operationID, Utils.ToJson(searchParam));
        }
        public static void SetGroupInfo(OnSucOrError cb, GroupInfoForSet groupInfo)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_group_info(operationID, Utils.ToJson(groupInfo));
        }
        public static void SetGroupVerification(OnSucOrError cb, string groupID, int verification)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_group_verification(operationID, groupID, verification);
        }
        public static void SetGroupLookMemberInfo(OnSucOrError cb, string groupID, int rule)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_group_look_member_info(operationID, groupID, rule);
        }
        public static void SetGroupApplyMemberFriend(OnSucOrError cb, string groupID, int rule)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_group_apply_member_friend(operationID, groupID, rule);
        }
        public static void GetGroupMemberList(OnLocalGroupMemberList cb, string groupID, int filter, int offset, int count)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_group_member_list(operationID, groupID, filter, offset, count);
        }
        public static void GetGroupMemberOwnerAndAdmin(OnLocalGroupMemberList cb, string groupID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_group_member_owner_and_admin(operationID, groupID);
        }
        public static void GetGroupMemberListByJoinTimeFilter(OnLocalGroupMemberList cb, string groupID, int offset, int count, long joinTimeBegin, long joinTimeEnd, string[] filterUserIDList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_group_member_list_by_join_time_filter(operationID, groupID, offset, count, joinTimeBegin, joinTimeEnd, Utils.ToJson(filterUserIDList));
        }
        public static void GetSpecifiedGroupMembersInfo(OnLocalGroupMemberList cb, string groupID, string[] userIDList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_specified_group_members_info(operationID, groupID, Utils.ToJson(userIDList));
        }
        public static void KickGroupMember(OnSucOrError cb, string groupID, string reason, string[] userIDList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.kick_group_member(operationID, groupID, reason, Utils.ToJson(userIDList));
        }
        public static void TransferGroupOwner(OnSucOrError cb, string groupID, string newOwnerUserID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.transfer_group_owner(operationID, groupID, newOwnerUserID);
        }
        public static void InviteUserToGroup(OnSucOrError cb, string groupID, string reason, string[] userIDList)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.invite_user_to_group(operationID, groupID, reason, Utils.ToJson(userIDList));
        }
        public static void GetGroupApplicationListAsRecipient(OnLocalAdminGroupRequestList cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_group_application_list_as_recipient(operationID);
        }
        public static void GetGroupApplicationListAsApplicant(OnLocalGroupRequestList cb)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.get_group_application_list_as_applicant(operationID);
        }
        public static void AcceptGroupApplication(OnSucOrError cb, string groupID, string fromUserID, string handleMsg)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.accept_group_application(operationID, groupID, fromUserID, handleMsg);
        }
        public static void RefuseGroupApplication(OnSucOrError cb, string groupID, string fromUserID, string handleMsg)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.refuse_group_application(operationID, groupID, fromUserID, handleMsg);
        }
        public static void SetGroupMemberNickname(OnSucOrError cb, string groupID, string userID, string groupMemberNickname)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.set_group_member_nickname(operationID, groupID, userID, groupMemberNickname);
        }
        public static void SearchGroupMembers(OnLocalGroupMemberList cb, SearchGroupMembersParam searchParam)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.search_group_members(operationID, Utils.ToJson(searchParam));
        }
        public static void IsJoinGroup(OnBool cb, string groupID)
        {
            var operationID = GetOperationID(System.Reflection.MethodBase.GetCurrentMethod().Name);
            callBackDic[operationID] = cb;
            IMNativeSDK.is_join_group(operationID, groupID);
        }
        #endregion
    }
}