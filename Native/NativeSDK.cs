using System;
using System.Runtime.InteropServices;

namespace open_im_sdk.native
{
    delegate void MessageHandler(int id, string msg);
    class IMNativeSDK
    {
        #region IMDLLName
#if UNITY_EDITOR
#if UNITY_EDITOR_OSX
                    public const string IMDLLName = "openimsdk";
#else
                    public const string IMDLLName = "openimsdk";
#endif
#else
#if UNITY_IPHONE
                    public const string IMDLLName = "__Internal";
#elif UNITY_ANDROID
                    public const string IMDLLName = "openimsdk";
#elif UNITY_STANDALONE_WIN
                    public const string IMDLLName = "openimsdk";
#elif UNITY_STANDALONE_OSX
                    public const string IMDLLName = "openimsdk";
#elif UNITY_WEBGL
                    public const string IMDLLName = "__Internal";
#else
#if WINDOWS
        public const string IMDLLName = "Plugins/x86_64/openimsdk.dll";
#elif LINUX
        public const string IMDLLName = "Plugins/linux/openimsdk.so";
#elif OSX
        public const string IMDLLName = "Plugins/osx/openimsdk.dylib";
#endif
#endif
#endif
        #endregion

        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMessageHandler(MessageHandler handler);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void free_memory(IntPtr memPointer);

        #region init_login
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool init_sdk(string operationID, string config);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void un_init_sdk(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void login(string operationID, string uid, string token);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void logout(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_app_background_status(string operationId, int isBackGround);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void network_status_changed(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_login_status(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr get_login_user();
        #endregion

        #region conversation_msg
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_text_message(string operationID, string text);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_advanced_text_message(string operationID, string text, string messageEntityList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_text_at_message(string operationID, string text, string atUserList, string atUsersInfo, string message);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_location_message(string operationID, string description, double longitude, double latitude);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_custom_message(string operationID, string data, string extension, string description);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_quote_message(string operationID, string text, string message);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_advanced_quote_message(string operationID, string text, string message, string messageEntityList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_card_message(string operationID, string cardInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_video_message_from_full_path(string operationID, string videoFullPath, string videoType, long duration, string snapshotFullPath);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_image_message_from_full_path(string operationID, string imageFullPath);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_sound_message_from_full_path(string operationID, string soundPath, long duration);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_file_message_from_full_path(string operationID, string fileFullPath, string fileName);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_image_message(string operationID, string imagePath);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_image_message_by_url(string operationID, string sourcePath, string sourcePicture, string bigPicture, string snapshotPicture);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_sound_message_by_url(string operationID, string soundBaseInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_sound_message(string operationID, string soundPath, Int64 duration);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_video_message_by_url(string operationID, string videoBaseInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_video_message(string operationID, string videoPath, string videoType, Int64 duration, string snapshotPath);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_file_message_by_url(string operationID, string fileBaseInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_file_message(string operationID, string filePath, string fileName);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_merger_message(string operationID, string messageList, string title, string summaryList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_face_message(string operationID, int index, string data);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr create_forward_message(string operationID, string m);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_all_conversation_list(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_conversation_list_split(string operationID, int offset, int count);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_one_conversation(string operationID, int sessionType, string sourceID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_multiple_conversation(string operationID, string conversationIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_msg_destruct_time(string operationID, string conversationID, long msgDestructTime);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_is_msg_destruct(string operationID, string conversationID, int isMsgDestruct);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void hide_conversation(string operationID, string conversationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_conversation_recv_message_opt(string operationID, string conversationIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_draft(string operationID, string conversationID, string draftText);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void reset_conversation_group_at_type(string operationID, string conversationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void pin_conversation(string operationID, string conversationID, int isPinned);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_private_chat(string operationID, string conversationID, int isPrivate);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_burn_duration(string operationID, string conversationID, int duration);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_conversation_recv_message_opt(string operationID, string conversationID, int opt);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_total_unread_msg_count(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr get_at_all_tag(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr get_conversation_id_by_session_type(string operationID, string sourceID, int sessionType);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void send_message(string operationID, string message, string recvID, string groupID, string offlinePushInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void send_message_not_oss(string operationID, string message, string recvID, string groupID, string offlinePushInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void find_message_list(string operationID, string findMessageOptions);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_advanced_history_message_list(string operationID, string getMessageOptions);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_advanced_history_message_list_reverse(string operationID, string getMessageOptions);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void revoke_message(string operationID, string conversationID, string clientMsgID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void typing_status_update(string operationID, string recvID, string msgTip);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void mark_conversation_message_as_read(string operationID, string conversationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_message_from_local_storage(string operationID, string conversationID, string clientMsgID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_message(string operationID, string conversationID, string clientMsgID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void hide_all_conversations(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_all_msg_from_local_and_svr(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_all_msg_from_local(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void clear_conversation_and_delete_all_msg(string operationID, string conversationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_conversation_and_delete_all_msg(string operationID, string conversationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void insert_single_message_to_local_storage(string operationID, string message, string recvID, string sendID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void insert_group_message_to_local_storage(string operationID, string message, string groupID, string sendID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_local_messages(string operationID, string searchParam);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_message_local_ex(string operationID, string conversationID, string clientMsgID, string localEx);
        #endregion

        #region user
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_users_info(string operationID, string userIDs);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_users_info_with_cache(string operationID, string userIDs, string groupID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_users_info_from_srv(string operationID, string userIDs);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_self_info(string operationID, string userInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_global_recv_message_opt(string operationId, int opt);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_self_user_info(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void update_msg_sender_info(string operationID, string nickname, string faceURL);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void subscribe_users_status(string operationID, string userIDs);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void unsubscribe_users_status(string operationID, string userIDs);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_subscribe_users_status(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_user_status(string operationID, string userIDs);
        #endregion

        #region friend
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_specified_friends_info(string operationID, string userIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_list(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_list_page(string operationID, int offset, int count);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_friends(string operationID, string searchParam);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void check_friend(string operationID, string userIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void add_friend(string operationID, string userIDReqMsg);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_friend_remark(string operationID, string userIDRemark);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_friend(string operationID, string friendUserID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_application_list_as_recipient(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_application_list_as_applicant(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void accept_friend_application(string operationID, string userIDHandleMsg);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void refuse_friend_application(string operationID, string userIDHandleMsg);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void add_black(string operationID, string blackUserID, string ex);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_black_list(string operationID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void remove_black(string operationID, string removeUserID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        #endregion

        #region group
        public static extern void create_group(string operationId, string groupReqInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void join_group(string operationId, string groupId, string reqMsg, int joinSource, string ex);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void quit_group(string operationId, string groupId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void dismiss_group(string operationId, string groupId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void change_group_mute(string operationId, string groupId, int isMute);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void change_group_member_mute(string operationId, string groupId, string userID, int mutedSeconds);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_member_role_level(string operationId, string groupId, string userID, int roleLevel);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_member_info(string operationId, string cGroupMemberInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_joined_group_list(string operationId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_specified_groups_info(string operationId, string groupIdList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_groups(string operationId, string cSearchParam);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_info(string operationId, string groupInfo);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_verification(string operationId, string groupId, int verification);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_look_member_info(string operationId, string groupId, int rule);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_apply_member_friend(string operationId, string groupId, int rule);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_member_list(string operationId, string groupId, int filter, int offset, int count);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_member_owner_and_admin(string operationId, string groupId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_member_list_by_join_time_filter(string operationId, string groupId, int offset, int count, long joinTimeBegin, Int64 joinTimeEnd, string filterUserIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_specified_group_members_info(string operationId, string groupId, string userIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void kick_group_member(string operationId, string groupId, string reason, string userIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void transfer_group_owner(string operationId, string groupId, string newOwnerUserID);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void invite_user_to_group(string operationId, string groupId, string reason, string userIDList);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_application_list_as_recipient(string operationId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_application_list_as_applicant(string operationId);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void accept_group_application(string operationId, string groupId, string fromUserID, string handleMsg);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void refuse_group_application(string operationId, string groupId, string fromUserID, string handleMsg);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_member_nickname(string operationId, string groupId, string userID, string groupMemberNickname);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_group_members(string operationId, string searchParam);
        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void is_join_group(string operationId, string groupId);
        #endregion

    }
}