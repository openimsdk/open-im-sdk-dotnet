using System;
using System.Runtime.InteropServices;

namespace open_im_sdk.native
{
    delegate void MessageHandler(int id, IntPtr msg);
    class IMNativeSDK
    {

        public const string IMDLLName = "openimsdk";

        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMessageHandler(MessageHandler handler);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void free_memory(IntPtr memPointer);

        #region init_login
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool init_sdk([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string config);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void un_init_sdk([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void login([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string uid, [MarshalAs(UnmanagedType.LPUTF8Str)] string token);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void logout([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_app_background_status([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, int isBackGround);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void network_status_changed([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_login_status([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr get_login_user();
        #endregion

        #region conversation_msg
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_text_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string text);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_advanced_text_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, [MarshalAs(UnmanagedType.LPUTF8Str)] string messageEntityList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_text_at_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, [MarshalAs(UnmanagedType.LPUTF8Str)] string atUserList, [MarshalAs(UnmanagedType.LPUTF8Str)] string atUsersInfo, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_location_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string description, double longitude, double latitude);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_custom_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string data, [MarshalAs(UnmanagedType.LPUTF8Str)] string extension, [MarshalAs(UnmanagedType.LPUTF8Str)] string description);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_quote_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_advanced_quote_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, [MarshalAs(UnmanagedType.LPUTF8Str)] string message, [MarshalAs(UnmanagedType.LPUTF8Str)] string messageEntityList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_card_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string cardInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_video_message_from_full_path([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string videoFullPath, [MarshalAs(UnmanagedType.LPUTF8Str)] string videoType, long duration, [MarshalAs(UnmanagedType.LPUTF8Str)] string snapshotFullPath);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_image_message_from_full_path([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string imageFullPath);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_sound_message_from_full_path([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string soundPath, long duration);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_file_message_from_full_path([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string fileFullPath, [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_image_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string imagePath);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_image_message_by_url([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string sourcePath, [MarshalAs(UnmanagedType.LPUTF8Str)] string sourcePicture, [MarshalAs(UnmanagedType.LPUTF8Str)] string bigPicture, [MarshalAs(UnmanagedType.LPUTF8Str)] string snapshotPicture);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_sound_message_by_url([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string soundBaseInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_sound_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string soundPath, Int64 duration);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_video_message_by_url([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string videoBaseInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_video_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string videoPath, [MarshalAs(UnmanagedType.LPUTF8Str)] string videoType, Int64 duration, [MarshalAs(UnmanagedType.LPUTF8Str)] string snapshotPath);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_file_message_by_url([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string fileBaseInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_file_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string filePath, [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_merger_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string messageList, [MarshalAs(UnmanagedType.LPUTF8Str)] string title, [MarshalAs(UnmanagedType.LPUTF8Str)] string summaryList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_face_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, int index, [MarshalAs(UnmanagedType.LPUTF8Str)] string data);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_forward_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string m);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_all_conversation_list([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_conversation_list_split([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, int offset, int count);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_one_conversation([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, int sessionType, [MarshalAs(UnmanagedType.LPUTF8Str)] string sourceID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_multiple_conversation([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_msg_destruct_time([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, long msgDestructTime);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_is_msg_destruct([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, int isMsgDestruct);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void hide_conversation([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_conversation_recv_message_opt([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_draft([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string draftText);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void reset_conversation_group_at_type([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pin_conversation([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, int isPinned);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_private_chat([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, int isPrivate);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_burn_duration([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, int duration);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_recv_message_opt([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, int opt);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_total_unread_msg_count([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr get_at_all_tag([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr get_conversation_id_by_session_type([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string sourceID, int sessionType);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void send_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string message, [MarshalAs(UnmanagedType.LPUTF8Str)] string recvID, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupID, [MarshalAs(UnmanagedType.LPUTF8Str)] string offlinePushInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void send_message_not_oss([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string message, [MarshalAs(UnmanagedType.LPUTF8Str)] string recvID, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupID, [MarshalAs(UnmanagedType.LPUTF8Str)] string offlinePushInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void find_message_list([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string findMessageOptions);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_advanced_history_message_list([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string getMessageOptions);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_advanced_history_message_list_reverse([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string getMessageOptions);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void revoke_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string clientMsgID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void typing_status_update([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string recvID, [MarshalAs(UnmanagedType.LPUTF8Str)] string msgTip);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void mark_conversation_message_as_read([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_message_from_local_storage([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string clientMsgID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_message([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string clientMsgID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void hide_all_conversations([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_all_msg_from_local_and_svr([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_all_msg_from_local([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void clear_conversation_and_delete_all_msg([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_conversation_and_delete_all_msg([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void insert_single_message_to_local_storage([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string message, [MarshalAs(UnmanagedType.LPUTF8Str)] string recvID, [MarshalAs(UnmanagedType.LPUTF8Str)] string sendID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void insert_group_message_to_local_storage([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string message, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupID, [MarshalAs(UnmanagedType.LPUTF8Str)] string sendID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_local_messages([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string searchParam);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_message_local_ex([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string conversationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string clientMsgID, [MarshalAs(UnmanagedType.LPUTF8Str)] string localEx);
        #endregion

        #region user
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_users_info([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDs);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_users_info_with_cache([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDs, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_users_info_from_srv([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDs);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_self_info([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_global_recv_message_opt([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, int opt);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_self_user_info([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void update_msg_sender_info([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string nickname, [MarshalAs(UnmanagedType.LPUTF8Str)] string faceURL);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void subscribe_users_status([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDs);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void unsubscribe_users_status([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDs);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_subscribe_users_status([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_user_status([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDs);
        #endregion

        #region friend
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_specified_friends_info([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_list([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_list_page([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, int offset, int count);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_friends([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string searchParam);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void check_friend([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void add_friend([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDReqMsg);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_friend_remark([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDRemark);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_friend([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string friendUserID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_application_list_as_recipient([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_application_list_as_applicant([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void accept_friend_application([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDHandleMsg);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void refuse_friend_application([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDHandleMsg);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void add_black([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string blackUserID, [MarshalAs(UnmanagedType.LPUTF8Str)] string ex);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_black_list([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void remove_black([MarshalAs(UnmanagedType.LPUTF8Str)] string operationID, [MarshalAs(UnmanagedType.LPUTF8Str)] string removeUserID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        #endregion

        #region group
        public static extern void create_group([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupReqInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void join_group([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, [MarshalAs(UnmanagedType.LPUTF8Str)] string reqMsg, int joinSource, [MarshalAs(UnmanagedType.LPUTF8Str)] string ex);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void quit_group([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void dismiss_group([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void change_group_mute([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, int isMute);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void change_group_member_mute([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, [MarshalAs(UnmanagedType.LPUTF8Str)] string userID, int mutedSeconds);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_member_role_level([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, [MarshalAs(UnmanagedType.LPUTF8Str)] string userID, int roleLevel);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_member_info([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string cGroupMemberInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_joined_group_list([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_specified_groups_info([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupIdList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_groups([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string cSearchParam);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_info([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_verification([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, int verification);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_look_member_info([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, int rule);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_apply_member_friend([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, int rule);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_member_list([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, int filter, int offset, int count);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_member_owner_and_admin([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_member_list_by_join_time_filter([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, int offset, int count, long joinTimeBegin, Int64 joinTimeEnd, [MarshalAs(UnmanagedType.LPUTF8Str)] string filterUserIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_specified_group_members_info([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void kick_group_member([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, [MarshalAs(UnmanagedType.LPUTF8Str)] string reason, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void transfer_group_owner([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, [MarshalAs(UnmanagedType.LPUTF8Str)] string newOwnerUserID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void invite_user_to_group([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, [MarshalAs(UnmanagedType.LPUTF8Str)] string reason, [MarshalAs(UnmanagedType.LPUTF8Str)] string userIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_application_list_as_recipient([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_application_list_as_applicant([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void accept_group_application([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, [MarshalAs(UnmanagedType.LPUTF8Str)] string fromUserID, [MarshalAs(UnmanagedType.LPUTF8Str)] string handleMsg);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void refuse_group_application([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, [MarshalAs(UnmanagedType.LPUTF8Str)] string fromUserID, [MarshalAs(UnmanagedType.LPUTF8Str)] string handleMsg);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_member_nickname([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId, [MarshalAs(UnmanagedType.LPUTF8Str)] string userID, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupMemberNickname);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_group_members([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string searchParam);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void is_join_group([MarshalAs(UnmanagedType.LPUTF8Str)] string operationId, [MarshalAs(UnmanagedType.LPUTF8Str)] string groupId);
        #endregion

    }
}