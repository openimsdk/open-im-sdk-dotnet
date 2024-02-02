namespace openim_sdk_unity.listener
{
    public interface IUserListener
    {
        void OnSelfInfoUpdated(LocalUser userInfo);
        void OnUserStatusChanged(OnlineStatus userOnlineStatus);
    }
}