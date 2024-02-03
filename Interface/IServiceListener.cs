namespace open_im_sdk.listener
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