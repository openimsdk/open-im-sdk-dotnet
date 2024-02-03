namespace open_im_sdk.callback
{
    public interface IUploadFileCallback
    {
        void Open(long size);
        void PartSize(long partSize, int num);
        void HashPartProgress(int index, long size, string partHash);
        void HashPartComplete(string partsHash, string fileHash);
        void UploadID(string uploadID);
        void UploadPartComplete(int index, long partSize, string partHash);
        void UploadComplete(long fileSize, long streamSize, long storageSize);

        void Complete(long size, string url, int typ);
    }
}