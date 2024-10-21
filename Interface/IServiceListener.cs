namespace OpenIM.IMSDK.Listener
{
    public interface IServiceListener
    {
        void OnGroupApplicationAdded(GroupApplicationInfo groupApplication);
        void OnGroupApplicationAccepted(GroupApplicationInfo groupApplication);
        void OnFriendApplicationAdded(FriendApplicationInfo friendApplication);
        void OnFriendApplicationAccepted(FriendApplicationInfo groupApplication);
        void OnRecvNewMessage(Message message);
    }
}