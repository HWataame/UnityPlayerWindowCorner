/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
kernel32.dllの関数を呼び出せるようにするラッパークラス

Kernel32Wrapper.cs
────────────────────────────────────────
バージョン: 1.0.1
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
#if (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN) && !HAS_COMMON_MAIN_WINDOW_HANDLE_GETTER_HW
using System.Runtime.InteropServices;

namespace HW.UnityPlayerWindowCorner.Libraries
{
    /// <summary>
    /// kernel32.dllの関数を呼び出せるようにするラッパークラス
    /// </summary>
    internal static class Kernel32Wrapper
    {
        /// <summary>
        /// 現在のプロセスIDを取得する
        /// </summary>
        /// <returns>現在のプロセスID</returns>
        [DllImport("kernel32.dll", EntryPoint = "GetCurrentProcessId", CallingConvention = CallingConvention.Winapi)]
        internal static extern uint GetCurrentProcessId();
    }
}
#endif
