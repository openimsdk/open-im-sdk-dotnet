using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace OpenIM.IMSDK.Util
{
    public static class Utils
    {
        public static void Log(params object[] args)
        {
#if IMSDK_LOG_ENABLE
            string prefix = "IMSDK";
            var info = "";
            foreach (var v in args)
            {
                info += v.ToString() + " ";
            }
            Console.WriteLine(string.Format("[{0}]:{1}", prefix, info));
#endif
        }

        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static IntPtr String2IntPtr(string str)
        {
            if (str == null)
            {
                return Marshal.StringToHGlobalAnsi("");
            }
            return Marshal.StringToHGlobalAnsi(str);
        }
        public static string IntPtr2String(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                return "";
            }
            return Marshal.PtrToStringAnsi(ptr) ?? "";
        }
        private static int randomIndex = 0;
        public static string GetOperationIndex()
        {
            return string.Format("{0}", randomIndex++);
        }
    }
};