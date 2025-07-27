/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの角の種類を示す列挙型

WindowCornerType.cs
────────────────────────────────────────
バージョン: 1.0.1
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
namespace HW.UnityPlayerWindowCorner
{
    /// <summary>
    /// JP: ウィンドウの角の種類を示す列挙型<br />
    /// EN: Type of window corner
    /// </summary>
    public enum WindowCornerType : uint
    {
        /// <summary>
        /// JP: 既定値<br />
        /// EN: Default Corner
        /// </summary>
        /// <remarks>
        /// JP: OSに委任する<br />
        /// EN: Use OS default-style window corner
        /// </remarks>
        Default = 0,
        /// <summary>
        /// JP: 角を丸めない<br />
        /// EN: Not rounded window corner
        /// </summary>
        DoNotRound = 1,
        /// <summary>
        /// JP: 角を丸める<br />
        /// EN: Rounded window corner
        /// </summary>
        Round = 2,
        /// <summary>
        /// JP: 角を小さく丸める<br />
        /// EN: Small rounded window corner
        /// </summary>
        RoundSmall = 3
    }
}
