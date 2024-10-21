using System;
using System.Runtime.InteropServices;

namespace OpenIM.IMSDK.Native
{
    delegate void MessageHandler(int id, IntPtr msg);
    class NativeSDK
    {
        const string IMDLLName = "openimsdk";

        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        static extern void set_msg_handler_func(MessageHandler handler);

        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr call_api(int apiKey, string apiArgs);

        [DllImport(IMDLLName, CallingConvention = CallingConvention.Cdecl)]
        static extern void free_data(IntPtr memPointer);

        public static void SetMessageHandler(MessageHandler handler)
        {
            set_msg_handler_func(handler);
        }
        public static T CallAPI<T>(APIKey key, string apiArgs) where T : class
        {
            Util.Utils.Log(string.Format("[{0}]->{1}", key, apiArgs));
            IntPtr res = call_api((int)key, apiArgs);
            var str = Marshal.PtrToStringUTF8(res);
            free_data(res);
            Util.Utils.Log(string.Format("[{0}]<-{1}", key, str));
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    return Util.Utils.FromJson<T>(str);
                }
            }
            catch (Exception e)
            {
                Util.Utils.Log(string.Format("Convert Type Error {0}:{1}", typeof(T), str), e.ToString());
            }
            return default;
        }
    }
}