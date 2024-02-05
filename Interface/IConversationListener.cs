using System.Collections.Generic;

namespace open_im_sdk.listener
{
    public interface IConversationListener
    {
        void OnSyncServerStart();
        void OnSyncServerFinish();
        void OnSyncServerFailed();
        void OnNewConversation(List<LocalConversation> conversationList);
        void OnConversationChanged(List<LocalConversation> conversationList);
        void OnTotalUnreadMessageCountChanged(int totalUnreadCount);
        void OnConversationUserInputStatusChanged(InputStatesChangedData data);
    }
}