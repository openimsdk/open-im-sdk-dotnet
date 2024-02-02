namespace openim_sdk_unity
{
    public enum LoginStatus
    {
        Empty = 0,
        Logout = 1,
        Logging = 2,
        Logged = 3,
    }
    public enum MsgStatus
    {
        Default,
        Sending,
        SendSuccess,
        SendFailed,
        Deleted,
        Filtered,
    }
    public enum ContentType
    {
        Text = 101,

        Picture = 102,

        Sound = 103,

        Video = 104,

        File = 105,

        AtText = 106,

        Merger = 107,

        Card = 108,

        Location = 109,

        Custom = 110,

        Typing = 113,

        Quote = 114,

        Face = 115,

        AdvancedText = 117,

        CustomMsgNotTriggerConversation = 119,

        CustomMsgOnlineOnly = 120,

        ReactionMessageModifier = 121,

        ReactionMessageDeleter = 122,
    }

}