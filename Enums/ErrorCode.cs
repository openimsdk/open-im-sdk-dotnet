namespace open_im_sdk
{
    public enum ErrorCode
    {
        None = 0,
        NetworkError = 10000,
        NetworkTimeoutError = 10001,
        ArgsError = 10002,
        CtxDeadlineExceededError = 10003,
        ResourceLoadNotCompleteError = 10004,
        UnknownCode = 10005,
        SdkInternalError = 10006,
        NoUpdateError = 10007,
        UserIDNotFoundError = 10100,
        LoginOutError = 10101,
        LoginRepeatError = 10102,
        FileNotFoundError = 10200,
        MsgDeCompressionError = 10201,
        MsgDecodeBinaryWsError = 10202,
        MsgBinaryTypeNotSupportError = 10203,
        MsgRepeatError = 10204,
        MsgContentTypeNotSupportError = 10205,
        MsgHasNoSeqError = 10206,
        NotSupportOptError = 10301,
        NotSupportTypeError = 10302,
        UnreadCountError = 10303,
        GroupIDNotFoundError = 10400,
        GroupTypeErr = 10401,
    }
}