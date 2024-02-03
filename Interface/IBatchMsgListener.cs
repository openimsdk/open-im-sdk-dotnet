using System.Collections.Generic;

namespace open_im_sdk.listener
{
    public interface IBatchMsgListener
    {
        void OnRecvNewMessages(List<MsgStruct> messageList);
        void OnRecvOfflineNewMessages(List<MsgStruct> messageList);
    }
}