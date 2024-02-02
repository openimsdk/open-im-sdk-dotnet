using System.Collections.Generic;

namespace openim_sdk_unity.listener
{
    public interface IConversationListener
    {
        void OnSyncServerStart();
        void OnSyncServerFinish();
        void OnSyncServerFailed();
        void OnNewConversation(List<LocalConversation> conversationList);
        void OnConversationChanged(List<LocalConversation> conversationList);
        void OnTotalUnreadMessageCountChanged(int totalUnreadCount);
    }
}