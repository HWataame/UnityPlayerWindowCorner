/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
dwmapi.dllの関数を呼び出せるようにするラッパークラス

DwmApiWrapper.cs
────────────────────────────────────────
バージョン: 1.0.1
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
using System.Runtime.InteropServices;

namespace HW.UnityPlayerWindowCorner.Libraries
{
    /// <summary>
    /// dwmapi.dllの関数を呼び出せるようにするラッパークラス
    /// </summary>
    internal static class DwmApiWrapper
    {
        /// <summary>
        /// DwmSetWindowAttributeにウィンドウの角の種類の処理であることを示す属性値
        /// </summary>
        internal const int DwmWindowCornerPreference = 33;
        /// <summary>
        /// ウィンドウの角の種類のデータサイズ
        /// </summary>
        internal const int WindowCornerTypeDataSize = 4;


        /// <summary>
        /// ウィンドウの領域外の属性を取得する
        /// </summary>
        /// <remarks>ウィンドウの角の種類用に引数を変更した版</remarks>
        /// <param name="windowHandle">ウィンドウのハンドル</param>
        /// <param name="attribute">取得する属性</param>
        /// <param name="cornerType">取得する属性の値</param>
        /// <param name="dataSize">データサイズ</param>
        /// <returns>処理結果のHRESULT値</returns>
        [DllImport("dwmapi.dll", EntryPoint = "DwmGetWindowAttribute", CallingConvention = CallingConvention.Winapi)]
        internal static extern HResult DwmGetWindowAttribute(nint windowHandle,
            uint attribute, ref WindowCornerType cornerType, uint dataSize);

        /// <summary>
        /// ウィンドウの領域外の属性を設定する
        /// </summary>
        /// <remarks>ウィンドウの角の種類用に引数を変更した版</remarks>
        /// <param name="windowHandle">ウィンドウのハンドル</param>
        /// <param name="attribute">変更する属性</param>
        /// <param name="cornerType">変更する属性の値</param>
        /// <param name="dataSize">データサイズ</param>
        /// <returns>処理結果のHRESULT値</returns>
        [DllImport("dwmapi.dll", EntryPoint = "DwmSetWindowAttribute", CallingConvention = CallingConvention.Winapi)]
        internal static extern HResult DwmSetWindowAttribute(nint windowHandle,
            uint attribute, ref WindowCornerType cornerType, uint dataSize);
    }
}
#endif
