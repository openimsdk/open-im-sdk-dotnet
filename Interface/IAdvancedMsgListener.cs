using System.Collections.Generic;

namespace OpenIM.IMSDK.Listener
{
    public interface IAdvancedMsgListener
    {
        void OnRecvNewMessage(Message message);
        void OnRecvC2CReadReceipt(List<MessageReceipt> msgReceiptList);
        void OnRecvGroupReadReceipt(List<MessageReceipt> groupMsgReceiptList);
        void OnNewRecvMessageRevoked(MessageRevoked messageRevoked);
        void OnRecvMessageExtensionsChanged(string msgID, string reactionExtensionList);
        void OnRecvMessageExtensionsDeleted(string msgID, string reactionExtensionKeyList);
        void OnRecvMessageExtensionsAdded(string msgID, string reactionExtensionList);
        void OnRecvOfflineNewMessage(Message message);
        void OnMsgDeleted(Message message);
        void OnRecvOnlineOnlyMessage(Message message);
    }
}