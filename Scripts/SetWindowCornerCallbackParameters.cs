/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
SetWindowCornerCallback用のパラメーターの構造体

SetWindowCornerCallbackParameters.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System.Runtime.CompilerServices;

namespace HW.UnityPlayerWindowCorner
{
    /// <summary>
    /// SetWindowCornerCallback用のパラメーターの構造体
    /// </summary>
    internal readonly ref struct SetWindowCornerCallbackParameters
    {
        /// <summary>
        /// 自身のプロセスID
        /// </summary>
        private readonly uint processId;
        /// <summary>
        /// ウィンドウの角の種類
        /// </summary>
        private readonly WindowCornerType cornerType;

        /// <summary>
        /// 自身のプロセスID
        /// </summary>
        internal readonly uint ProcessId
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => processId;
        }

        /// <summary>
        /// ウィンドウの角の種類
        /// </summary>
        internal readonly WindowCornerType CornerType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => cornerType;
        }


        /// <summary>
        /// 構造体を構築する
        /// </summary>
        /// <param name="processId">プロセスID</param>
        /// <param name="cornerType">ウィンドウの角の種類</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal SetWindowCornerCallbackParameters(
            uint processId, WindowCornerType cornerType)
        {
            // 値を受け取る
            this.processId = processId;
            this.cornerType = cornerType;
        }
    }
}
