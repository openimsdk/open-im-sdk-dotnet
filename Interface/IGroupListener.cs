namespace openim_sdk_unity.listener
{
    public interface IGroupListener
    {
        void OnJoinedGroupAdded(LocalGroup groupInfo);
        void OnJoinedGroupDeleted(LocalGroup groupInfo);
        void OnGroupMemberAdded(LocalGroupMember groupMemberInfo);
        void OnGroupMemberDeleted(LocalGroupMember groupMemberInfo);
        void OnGroupApplicationAdded(LocalGroupRequest groupApplication);
        void OnGroupApplicationDeleted(LocalGroupRequest groupApplication);
        void OnGroupInfoChanged(LocalGroup groupInfo);
        void OnGroupDismissed(LocalGroup groupInfo);
        void OnGroupMemberInfoChanged(LocalGroupMember groupMemberInfo);
        void OnGroupApplicationAccepted(LocalGroupRequest groupApplication);
        void OnGroupApplicationRejected(LocalGroupRequest groupApplication);
    }
}