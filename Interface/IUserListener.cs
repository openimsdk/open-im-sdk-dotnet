namespace open_im_sdk.listener
{
    public interface IUserListener
    {
        void OnSelfInfoUpdated(LocalUser userInfo);
        void OnUserStatusChanged(OnlineStatus userOnlineStatus);
    }
}