namespace OpenIM.IMSDK.Listener
{
    public interface IFriendShipListener
    {
        void OnFriendApplicationAdded(FriendApplicationInfo friendApplication);
        void OnFriendApplicationDeleted(FriendApplicationInfo friendApplication);
        void OnFriendApplicationAccepted(FriendApplicationInfo friendApplication);
        void OnFriendApplicationRejected(FriendApplicationInfo friendApplication);
        void OnFriendAdded(FriendInfo friendInfo);
        void OnFriendDeleted(FriendInfo friendInfo);
        void OnFriendInfoChanged(FriendInfo friendInfo);
        void OnBlackAdded(BlackInfo blackInfo);
        void OnBlackDeleted(BlackInfo blackInfo);
    }
}