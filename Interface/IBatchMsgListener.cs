using System.Collections.Generic;

namespace openim_sdk_unity.listener
{
    public interface IBatchMsgListener
    {
        void OnRecvNewMessages(List<MsgStruct> messageList);
        void OnRecvOfflineNewMessages(List<MsgStruct> messageList);
    }
}