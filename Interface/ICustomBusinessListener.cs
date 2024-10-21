namespace OpenIM.IMSDK.Listener
{
    public interface ICustomBusinessListener
    {
        void OnRecvCustomBusinessMessage(string businessMessage);
    }
}