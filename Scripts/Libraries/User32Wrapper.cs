/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
user32.dllの関数を呼び出せるようにするラッパークラス

User32Wrapper.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System.Runtime.InteropServices;

namespace HW.UnityPlayerWindowCorner.Libraries
{
    /// <summary>
    /// user32.dllの関数を呼び出せるようにするラッパークラス
    /// </summary>
    internal static class User32Wrapper
    {
        /// <summary>
        /// EnumWindowsのコールバック用のデリゲート型
        /// </summary>
        /// <remarks>SetWindowCornerCallbackParametersをパラメーターとして渡す用に引数を変更した版</remarks>
        /// <param name="windowHandle">ウィンドウハンドル</param>
        /// <param name="parameters">パラメーター</param>
        /// <returns>列挙を続行するか</returns>
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate bool EnumWindowsProc(
            nint windowHandle, ref SetWindowCornerCallbackParameters parameters);


        /// <summary>
        /// ウィンドウを列挙する
        /// </summary>
        /// <remarks>SetWindowCornerCallbackParametersをパラメーターとして渡す用に引数を変更した版</remarks>
        /// <param name="callback">列挙用のコールバック</param>
        /// <param name="parameters">パラメーター</param>
        /// <returns>処理結果</returns>
        [DllImport("user32.dll", EntryPoint = "EnumWindows", CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumWindows(
            EnumWindowsProc callback, ref SetWindowCornerCallbackParameters parameters);
    }
}
