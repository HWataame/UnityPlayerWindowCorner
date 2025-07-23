/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの角の種類を示す列挙型

WindowCornerType.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
namespace HW.UnityPlayerWindowCorner
{
    /// <summary>
    /// ウィンドウの角の種類を示す列挙型
    /// </summary>
    public enum WindowCornerType : uint
    {
        /// <summary>
        /// 既定値
        /// </summary>
        /// <remarks>OSに委任する</remarks>
        Default = 0,
        /// <summary>
        /// 角を丸めない
        /// </summary>
        DoNotRound = 1,
        /// <summary>
        /// 角を丸める
        /// </summary>
        Round = 2,
        /// <summary>
        /// 角を小さく丸める
        /// </summary>
        RoundSmall = 3
    }
}
