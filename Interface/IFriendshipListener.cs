namespace openim_sdk_unity.listener
{
    public interface IFriendShipListener
    {
        void OnFriendApplicationAdded(LocalFriendRequest friendApplication);
        void OnFriendApplicationDeleted(LocalFriendRequest friendApplication);
        void OnFriendApplicationAccepted(LocalFriendRequest friendApplication);
        void OnFriendApplicationRejected(LocalFriendRequest friendApplication);
        void OnFriendAdded(LocalFriend friendInfo);
        void OnFriendDeleted(LocalFriend friendInfo);
        void OnFriendInfoChanged(LocalFriend friendInfo);
        void OnBlackAdded(LocalBlack blackInfo);
        void OnBlackDeleted(LocalBlack blackInfo);
    }
}