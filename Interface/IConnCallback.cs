namespace open_im_sdk
{
    public interface IConnCallBack
    {
        void OnConnecting();
        void OnConnectSuccess();
        void OnConnectFailed(int errCode, string errMsg);
        void OnKickedOffline();
        void OnUserTokenExpired();
    }
}