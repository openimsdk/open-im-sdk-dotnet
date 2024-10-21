namespace OpenIM.IMSDK.Listener
{
    public interface IGroupListener
    {
        void OnJoinedGroupAdded(GroupInfo groupInfo);
        void OnJoinedGroupDeleted(GroupInfo groupInfo);
        void OnGroupMemberAdded(GroupMember groupMemberInfo);
        void OnGroupMemberDeleted(GroupMember groupMemberInfo);
        void OnGroupApplicationAdded(GroupApplicationInfo groupApplication);
        void OnGroupApplicationDeleted(GroupApplicationInfo groupApplication);
        void OnGroupInfoChanged(GroupInfo groupInfo);
        void OnGroupDismissed(GroupInfo groupInfo);
        void OnGroupMemberInfoChanged(GroupMember groupMemberInfo);
        void OnGroupApplicationAccepted(GroupApplicationInfo groupApplication);
        void OnGroupApplicationRejected(GroupApplicationInfo groupApplication);
    }
}