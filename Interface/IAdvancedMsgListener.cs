using System.Collections.Generic;

namespace openim_sdk_unity.listener
{
    public interface IAdvancedMsgListener
    {
        void OnRecvNewMessage(MsgStruct message);
        void OnRecvC2CReadReceipt(List<MessageReceipt> msgReceiptList);
        void OnRecvGroupReadReceipt(List<MessageReceipt> groupMsgReceiptList);
        void OnNewRecvMessageRevoked(MessageRevoked messageRevoked);
        void OnRecvMessageExtensionsChanged(string msgID, string reactionExtensionList);
        void OnRecvMessageExtensionsDeleted(string msgID, string reactionExtensionKeyList);
        void OnRecvMessageExtensionsAdded(string msgID, string reactionExtensionList);
        void OnRecvOfflineNewMessage(MsgStruct message);
        void OnMsgDeleted(MsgStruct message);
    }
}