/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの角に対する処理を保持するクラス

WindowCorner.cs
────────────────────────────────────────
バージョン: 1.0.1
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using HW.UnityPlayerWindowCorner.Libraries;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace HW.UnityPlayerWindowCorner
{
    /// <summary>
    /// ウィンドウの角に対する処理を保持するクラス
    /// </summary>
    public static class WindowCorner
    {
        /// <summary>
        /// ログを出力するか
        /// </summary>
        private static bool isOutputLog = true;

        /// <summary>
        /// ログを出力するか
        /// </summary>
        public static bool IsOutputLog
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => isOutputLog;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => isOutputLog = value;
        }


        /// <summary>
        /// ウィンドウの角の種類を取得する
        /// </summary>
        /// <param name="cornerType">角の種類</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Get(out WindowCornerType cornerType)
        {
            // 参照渡し引数に既定値を代入する
            cornerType = default;

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            if (IsHandleValid())
            {
                // スタンドアロンプレイヤーのメインウィンドウの
                // ウィンドウハンドルが有効である場合は角の種類を取得する
                return DwmApiWrapper.DwmGetWindowAttribute(
                    GetWindowHandle(), DwmApiWrapper.DwmWindowCornerPreference,
                    ref cornerType, DwmApiWrapper.WindowCornerTypeDataSize) == HResult.Ok;
            }
            else
            {
                // スタンドアロンプレイヤーのメインウィンドウのウィンドウハンドルが
                // 有効ではない(WindowsのUnityEditorなど)場合は失敗
                if (isOutputLog)
                {
                    Debug.LogWarning("[UnityPlayerWindowCorner] Windowsのスタンドアロンプレイヤー以外の環境" +
                        $"({Application.platform})からウィンドウの角を取得しようとしました");
                }
                return false;
            }
#else
            // Windows環境以外である場合は失敗
            if (isOutputLog)
            {
                Debug.LogWarning("[UnityPlayerWindowCorner] Windows以外の環境" +
                    $"({Application.platform})からウィンドウの角を取得しようとしました");
            }
            return false;
#endif
        }

        /// <summary>
        /// ウィンドウの角の種類を設定する
        /// </summary>
        /// <param name="cornerType">角の種類</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(WindowCornerType cornerType)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            if (IsHandleValid())
            {
                // スタンドアロンプレイヤーのメインウィンドウの
                // ウィンドウハンドルが有効である場合は角の種類を設定する
                return DwmApiWrapper.DwmSetWindowAttribute(
                    GetWindowHandle(), DwmApiWrapper.DwmWindowCornerPreference,
                    ref cornerType, DwmApiWrapper.WindowCornerTypeDataSize) == HResult.Ok;
            }
            else
            {
                // スタンドアロンプレイヤーのメインウィンドウのウィンドウハンドルが
                // 有効ではない(WindowsのUnityEditorなど)場合は失敗
                if (isOutputLog)
                {
                    Debug.LogWarning("[UnityPlayerWindowCorner] Windowsのスタンドアロンプレイヤー以外の環境" +
                        $"({Application.platform})からウィンドウの角を設定しようとしました");
                }
                return false;
            }
#else
            // Windows環境以外である場合は失敗
            if (isOutputLog)
            {
                Debug.LogWarning("[UnityPlayerWindowCorner] Windows以外の環境" +
                    $"({Application.platform})からウィンドウの角を設定しようとしました");
            }
            return false;
#endif
        }

        /// <summary>
        /// ウィンドウハンドルが有効か判定する
        /// </summary>
        /// <returns>判定結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsHandleValid()
        {
            return UnityPlayerWindow.IsHandleValid;
        }

        /// <summary>
        /// ウィンドウハンドルを取得する
        /// </summary>
        /// <returns>ウィンドウハンドル</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static nint GetWindowHandle()
        {
            return UnityPlayerWindow.MainWindowHandle;
        }
    }
}
