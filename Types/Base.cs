using System;
using Newtonsoft.Json;

namespace OpenIM.IMSDK
{
    public class IMConfig
    {
        [JsonProperty("platformID")]
        public int PlatformID;
        [JsonProperty("apiAddr")]
        public string ApiAddr;
        [JsonProperty("wsAddr")]
        public string WsAddr;
        [JsonProperty("dataDir")]
        public string DataDir;
        [JsonProperty("logLevel")]
        public uint LogLevel;
        [JsonProperty("isLogStandardOutput")]
        public bool IsLogStandardOutput;
        [JsonProperty("logFilePath")]
        public string LogFilePath;
        [JsonProperty("isExternalExtensions")]
        public bool IsExternalExtensions;
    }

    public class BoolValue
    {
        [JsonProperty("value")]
        public bool Value;
    }
    public class Int32Value
    {
        [JsonProperty("value")]
        public int Value;
    }
    public class Int64Value
    {
        [JsonProperty("value")]
        public long Value;
    }
    public class StringValue
    {
        [JsonProperty("value")]
        public string Value;
    }
}