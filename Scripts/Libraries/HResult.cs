/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
HRESULTの値を示す列挙型

HResult.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
namespace HW.UnityPlayerWindowCorner.Libraries
{
    /// <summary>
    /// HRESULTの値を示す列挙型
    /// </summary>
    public enum HResult : uint
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <remarks>S_OKと等価</remarks>
        Ok = 0x00000000,
        /// <summary>
        /// ハンドルが無効である
        /// </summary>
        /// <remarks>E_HANDLEと等価</remarks>
        InvalidHandle = 0x80070006
    }
}
#endif
