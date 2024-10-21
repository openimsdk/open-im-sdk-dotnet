using System.Collections.Generic;

namespace OpenIM.IMSDK.Listener
{
    public interface IConversationListener
    {
        void OnSyncServerStart();
        void OnSyncServerFinish();
        void OnSyncServerProgress(int progress);
        void OnSyncServerFailed();
        void OnNewConversation(List<Conversation> conversationList);
        void OnConversationChanged(List<Conversation> conversationList);
        void OnTotalUnreadMessageCountChanged(int totalUnreadCount);
        void OnConversationUserInputStatusChanged(InputStatesChangedData data);
    }
}