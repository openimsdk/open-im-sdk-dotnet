using Newtonsoft.Json;
using OpenIM.IMSDK.Util;
namespace OpenIM.IMSDK
{
    public class UserInfoUpdatedTips
    {
        [JsonProperty("userID")]
        public string UserID { get; set; }
    }

    public class UserStatusChangeTips
    {
        [JsonProperty("fromUserID")]
        public string FromUserID { get; set; }

        [JsonProperty("toUserID")]
        public string ToUserID { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("platformID")]
        public int PlatformID { get; set; }
    }

    public class UserCommandAddTips
    {
        [JsonProperty("fromUserID")]
        public string FromUserID { get; set; }

        [JsonProperty("toUserID")]
        public string ToUserID { get; set; }
    }

    public class UserCommandUpdateTips
    {
        [JsonProperty("fromUserID")]
        public string FromUserID { get; set; }

        [JsonProperty("toUserID")]
        public string ToUserID { get; set; }
    }

    public class UserCommandDeleteTips
    {
        [JsonProperty("fromUserID")]
        public string FromUserID { get; set; }

        [JsonProperty("toUserID")]
        public string ToUserID { get; set; }
    }

    public class ConversationUpdateTips
    {
        [JsonProperty("userID")]
        public string UserID { get; set; }

        [JsonProperty("conversationIDList")]
        public List<string> ConversationIDList { get; set; }
    }

    public class ConversationSetPrivateTips
    {
        [JsonProperty("recvID")]
        public string RecvID { get; set; }

        [JsonProperty("sendID")]
        public string SendID { get; set; }

        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; set; }

        [JsonProperty("conversationID")]
        public string ConversationID { get; set; }
    }

    public class ConversationHasReadTips
    {
        [JsonProperty("userID")]
        public string UserID { get; set; }

        [JsonProperty("conversationID")]
        public string ConversationID { get; set; }

        [JsonProperty("hasReadSeq")]
        public long HasReadSeq { get; set; }

        [JsonProperty("unreadCountTime")]
        public long UnreadCountTime { get; set; }
    }

    public class ClearConversationTips
    {
        [JsonProperty("userID")]
        public string UserID { get; set; }

        [JsonProperty("conversationIDs")]
        public List<string> ConversationIDs { get; set; }
    }

    public class DeleteMsgsTips
    {
        [JsonProperty("userID")]
        public string UserID { get; set; }

        [JsonProperty("conversationID")]
        public string ConversationID { get; set; }

        [JsonProperty("seqs")]
        public List<long> Seqs { get; set; }
    }

    public class MarkAsReadTips
    {
        [JsonProperty("markAsReadUserID")]
        public string MarkAsReadUserID { get; set; }

        [JsonProperty("conversationID")]
        public string ConversationID { get; set; }

        [JsonProperty("seqs")]
        public List<long> Seqs { get; set; }

        [JsonProperty("hasReadSeq")]
        public long HasReadSeq { get; set; }
    }

    public class DeleteMessageTips
    {
        [JsonProperty("opUserID")]
        public string OpUserID { get; set; }

        [JsonProperty("userID")]
        public string UserID { get; set; }

        [JsonProperty("seqs")]
        public List<long> Seqs { get; set; }
    }

    public class RevokeMsgTips
    {
        [JsonProperty("revokerUserID")]
        public string RevokerUserID { get; set; }

        [JsonProperty("clientMsgID")]
        public string ClientMsgID { get; set; }

        [JsonProperty("revokeTime")]
        public long RevokeTime { get; set; }

        [JsonProperty("sesstionType")]
        public int SessionType { get; set; }

        [JsonProperty("seq")]
        public long Seq { get; set; }

        [JsonProperty("conversationID")]
        public string ConversationID { get; set; }

        [JsonProperty("isAdminRevoke")]
        public bool IsAdminRevoke { get; set; }
    }

    public class FromToUserID
    {
        [JsonProperty("fromUserID")]
        public string FromUserID { get; set; }

        [JsonProperty("toUserID")]
        public string ToUserID { get; set; }
    }
    public class FriendsInfoUpdateTips
    {
        [JsonProperty("fromToUserID")]
        public FromToUserID FromToUserID { get; set; }

        [JsonProperty("friendIDs")]
        public List<string> FriendIDs { get; set; }

        [JsonProperty("friendVersion")]
        public ulong FriendVersion { get; set; }

        [JsonProperty("friendVersionID")]
        public string FriendVersionID { get; set; }
    }
    public class SubUserOnlineStatusElem
    {
        [JsonProperty("userID")]
        public string UserID { get; set; }

        [JsonProperty("onlinePlatformIDs")]
        public List<int> OnlinePlatformIDs { get; set; }
    }
    public class SubUserOnlineStatusTips
    {
        [JsonProperty("subscribers")]
        public List<SubUserOnlineStatusElem> Subscribers { get; set; }
    }
    public class FriendApplicationTips
    {
        [JsonProperty("fromToUserID")]
        public FromToUserID FromToUserID { get; set; }
    }

    public class FriendApplicationApprovedTips
    {
        [JsonProperty("fromToUserID")]
        public FromToUserID FromToUserID { get; set; }

        [JsonProperty("handleMsg")]
        public string HandleMsg { get; set; }

        [JsonProperty("friendVersion")]
        public ulong FriendVersion { get; set; }

        [JsonProperty("friendVersionID")]
        public string FriendVersionID { get; set; }
    }

    public class FriendApplicationRejectedTips
    {
        [JsonProperty("fromToUserID")]
        public FromToUserID FromToUserID { get; set; }

        [JsonProperty("handleMsg")]
        public string HandleMsg { get; set; }
    }

    public class FriendAddedTips
    {
        [JsonProperty("friend")]
        public FriendInfo Friend { get; set; }

        [JsonProperty("operationTime")]
        public long OperationTime { get; set; }

        [JsonProperty("opUser")]
        public PublicUserInfo OpUser { get; set; }

        [JsonProperty("friendVersion")]
        public ulong FriendVersion { get; set; }

        [JsonProperty("friendVersionID")]
        public string FriendVersionID { get; set; }
    }

    public class FriendDeletedTips
    {
        [JsonProperty("fromToUserID")]
        public FromToUserID FromToUserID { get; set; }

        [JsonProperty("friendVersion")]
        public ulong FriendVersion { get; set; }

        [JsonProperty("friendVersionID")]
        public string FriendVersionID { get; set; }
    }

    public class BlackAddedTips
    {
        [JsonProperty("fromToUserID")]
        public FromToUserID FromToUserID { get; set; }
    }

    public class BlackDeletedTips
    {
        [JsonProperty("fromToUserID")]
        public FromToUserID FromToUserID { get; set; }
    }

    public class FriendInfoChangedTips
    {
        [JsonProperty("fromToUserID")]
        public FromToUserID FromToUserID { get; set; }

        [JsonProperty("friendVersion")]
        public ulong FriendVersion { get; set; }

        [JsonProperty("friendVersionID")]
        public string FriendVersionID { get; set; }
    }


    public class GroupCreatedTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("memberList")]
        public List<GroupMember> MemberList;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("groupOwnerUser")]
        public GroupMember GroupOwnerUser;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class GroupInfoSetTips
    {
        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("muteTime")]
        public long MuteTime;

        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class GroupInfoSetNameTips
    {
        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class GroupInfoSetAnnouncementTips
    {
        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class JoinGroupApplicationTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("applicant")]
        public PublicUserInfo Applicant;

        [JsonProperty("reqMsg")]
        public string ReqMsg;
    }

    public class MemberQuitTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("quitUser")]
        public GroupMember QuitUser;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class GroupApplicationAcceptedTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("handleMsg")]
        public string HandleMsg;

        [JsonProperty("receiverAs")]
        public int ReceiverAs;
    }

    public class GroupApplicationRejectedTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("handleMsg")]
        public string HandleMsg;

        [JsonProperty("receiverAs")]
        public int ReceiverAs;
    }

    public class GroupOwnerTransferredTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("newGroupOwner")]
        public GroupMember NewGroupOwner;

        [JsonProperty("oldGroupOwner")]
        public string OldGroupOwner;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("oldGroupOwnerInfo")]
        public GroupMember OldGroupOwnerInfo;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class MemberKickedTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("kickedUserList")]
        public List<GroupMember> KickedUserList;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class MemberInvitedTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("invitedUserList")]
        public List<GroupMember> InvitedUserList;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class MemberEnterTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("entrantUser")]
        public GroupMember EntrantUser;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class GroupDismissedTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("operationTime")]
        public long OperationTime;
    }

    public class GroupMemberMutedTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("mutedUser")]
        public GroupMember MutedUser;

        [JsonProperty("mutedSeconds")]
        public uint MutedSeconds;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class GroupMemberCancelMutedTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("mutedUser")]
        public GroupMember MutedUser;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class GroupMutedTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class GroupCancelMutedTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class GroupMemberInfoSetTips
    {
        [JsonProperty("group")]
        public GroupInfo Group;

        [JsonProperty("opUser")]
        public GroupMember OpUser;

        [JsonProperty("operationTime")]
        public long OperationTime;

        [JsonProperty("changedUser")]
        public GroupMember ChangedUser;

        [JsonProperty("groupMemberVersion")]
        public ulong GroupMemberVersion;

        [JsonProperty("groupMemberVersionID")]
        public string GroupMemberVersionID;
    }

    public class Notification
    {
        public static object Parse(ContentType contentType, string detail)
        {
            switch (contentType)
            {
                case ContentType.FriendApplicationApprovedNotification:
                    return Utils.FromJson<FriendApplicationApprovedTips>(detail);

                case ContentType.FriendApplicationRejectedNotification:
                    return Utils.FromJson<FriendApplicationRejectedTips>(detail);

                case ContentType.FriendApplicationNotification:
                    return Utils.FromJson<FriendApplicationTips>(detail);

                case ContentType.FriendAddedNotification:
                    return Utils.FromJson<FriendAddedTips>(detail);

                case ContentType.FriendDeletedNotification:
                    return Utils.FromJson<FriendDeletedTips>(detail);

                case ContentType.FriendRemarkSetNotification:
                    return Utils.FromJson<FriendInfoChangedTips>(detail);

                case ContentType.BlackAddedNotification:
                    return Utils.FromJson<BlackAddedTips>(detail);

                case ContentType.BlackDeletedNotification:
                    return Utils.FromJson<BlackDeletedTips>(detail);

                case ContentType.FriendInfoUpdatedNotification:
                    return Utils.FromJson<FriendInfoChangedTips>(detail);

                case ContentType.FriendsInfoUpdateNotification:
                    return Utils.FromJson<FriendsInfoUpdateTips>(detail);

                case ContentType.ConversationChangeNotification:
                    return Utils.FromJson<ConversationUpdateTips>(detail);

                case ContentType.UserInfoUpdatedNotification:
                    return Utils.FromJson<UserInfoUpdatedTips>(detail);

                case ContentType.UserStatusChangeNotification:
                    return Utils.FromJson<UserStatusChangeTips>(detail);

                case ContentType.UserCommandAddNotification:
                    return Utils.FromJson<UserCommandAddTips>(detail);

                case ContentType.UserCommandDeleteNotification:
                    return Utils.FromJson<UserCommandDeleteTips>(detail);

                case ContentType.UserCommandUpdateNotification:
                    return Utils.FromJson<UserCommandUpdateTips>(detail);

                case ContentType.GroupCreatedNotification:
                    return Utils.FromJson<GroupCreatedTips>(detail);

                case ContentType.GroupInfoSetNotification:
                    return Utils.FromJson<GroupInfoSetTips>(detail);

                case ContentType.JoinGroupApplicationNotification:
                    return Utils.FromJson<JoinGroupApplicationTips>(detail);

                case ContentType.MemberQuitNotification:
                    return Utils.FromJson<MemberQuitTips>(detail);

                case ContentType.GroupApplicationAcceptedNotification:
                    return Utils.FromJson<GroupApplicationAcceptedTips>(detail);

                case ContentType.GroupApplicationRejectedNotification:
                    return Utils.FromJson<GroupApplicationRejectedTips>(detail);

                case ContentType.GroupOwnerTransferredNotification:
                    return Utils.FromJson<GroupOwnerTransferredTips>(detail);

                case ContentType.MemberKickedNotification:
                    return Utils.FromJson<MemberKickedTips>(detail);

                case ContentType.MemberInvitedNotification:
                    return Utils.FromJson<MemberInvitedTips>(detail);

                case ContentType.MemberEnterNotification:
                    return Utils.FromJson<MemberEnterTips>(detail);

                case ContentType.GroupDismissedNotification:
                    return Utils.FromJson<GroupDismissedTips>(detail);

                case ContentType.GroupMemberMutedNotification:
                    return Utils.FromJson<GroupMemberMutedTips>(detail);

                case ContentType.GroupMemberCancelMutedNotification:
                    return Utils.FromJson<GroupMemberCancelMutedTips>(detail);

                case ContentType.GroupMutedNotification:
                    return Utils.FromJson<GroupMutedTips>(detail);

                case ContentType.GroupCancelMutedNotification:
                    return Utils.FromJson<GroupCancelMutedTips>(detail);

                case ContentType.GroupMemberInfoSetNotification:
                    return Utils.FromJson<GroupMemberInfoSetTips>(detail);

                case ContentType.GroupMemberSetToAdminNotification:
                    return Utils.FromJson<GroupMemberInfoSetTips>(detail);

                case ContentType.GroupMemberSetToOrdinaryUserNotification:
                    return Utils.FromJson<GroupMemberInfoSetTips>(detail);

                case ContentType.GroupInfoSetAnnouncementNotification:
                    return Utils.FromJson<GroupInfoSetAnnouncementTips>(detail);

                case ContentType.GroupInfoSetNameNotification:
                    return Utils.FromJson<GroupInfoSetNameTips>(detail);

                default:
                    return null;
            }
        }

    }
}