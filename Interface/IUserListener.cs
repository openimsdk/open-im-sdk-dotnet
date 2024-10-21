namespace OpenIM.IMSDK.Listener
{
    public interface IUserListener
    {
        void OnSelfInfoUpdated(UserInfo userInfo);
        void OnUserStatusChanged(OnlineStatus userOnlineStatus);
        void OnUserCommandAdd(string userCommand);
        void OnUserCommandDelete(string userCommand);
        void OnUserCommandUpdate(string userCommand);
    }
}