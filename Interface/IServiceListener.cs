namespace openim_sdk_unity.listener
{
    public interface IServiceListener
    {
        void OnGroupApplicationAdded(LocalGroupRequest groupApplication);
        void OnGroupApplicationAccepted(LocalAdminGroupRequest groupApplication);
        void OnFriendApplicationAdded(LocalFriendRequest friendApplication);
        void OnFriendApplicationAccepted(LocalFriendRequest groupApplication);
        void OnRecvNewMessage(MsgStruct message);
    }
}