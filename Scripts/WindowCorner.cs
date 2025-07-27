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
#if HAS_COMMON_MAIN_WINDOW_HANDLE_GETTER_HW
using CommonMainWindowHandle = HW.UnityPlayerWindowHandle.UnityPlayerWindow;
#endif

namespace HW.UnityPlayerWindowCorner
{
    /// <summary>
    /// JP: ウィンドウの角に対する処理を保持するクラス<br />
    /// EN: Processes of Standalone Player window corner
    /// </summary>
    public static class WindowCorner
    {
        /// <summary>
        /// ログを出力するか
        /// </summary>
        private static bool isOutputLog = true;

        /// <summary>
        /// JP: ログを出力するか<br />
        /// EN: Does output "executing from unsupported environment" warning logs?
        /// </summary>
        public static bool IsOutputLog
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => isOutputLog;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => isOutputLog = value;
        }


        /// <summary>
        /// JP: ウィンドウの角の種類を取得する<br />
        /// EN: Get type of Standalone Player window corner
        /// </summary>
        /// <param name="cornerType">
        /// JP: 角の種類<br />
        /// EN: Type of Window corner
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
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
                    Debug.LogWarning("[UnityPlayerWindowCorner]\n\tJP: Windowsのスタンドアロンプレイヤー以外の環境" +
                        $"({Application.platform})からウィンドウの角を取得しようとしました\n" +
                        "\tEN: Trying to get window corner from except Windows Standalone Player on Windows" +
                        $" ({Application.platform})");
                }
                return false;
            }
#else
            // Windows環境以外である場合は失敗
            if (isOutputLog)
            {
                Debug.LogWarning("[UnityPlayerWindowCorner]\n\tJP: Windows以外の環境" +
                    $"({Application.platform})からウィンドウの角を取得しようとしました\n" +
                    $"\tEN: Trying to get window corner from except Windows ({Application.platform})");
            }
            return false;
#endif
        }

        /// <summary>
        /// JP: ウィンドウの角の種類を設定する<br />
        /// EN: Set type of Standalone Player window corner
        /// </summary>
        /// <param name="cornerType">
        /// JP: 角の種類<br />
        /// EN: Type of Window corner
        /// </param>
        /// <returns>
        /// JP: 処理結果<br />
        /// EN: Is Process succeed?
        /// </returns>
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
                    Debug.LogWarning("[UnityPlayerWindowCorner]\n\tJP: Windowsのスタンドアロンプレイヤー以外の環境" +
                        $"({Application.platform})からウィンドウの角を設定しようとしました\n" +
                        "\tEN: Trying to set window corner from except Windows Standalone Player on Windows" +
                        $" ({Application.platform})");
                }
                return false;
            }
#else
            // Windows環境以外である場合は失敗
            if (isOutputLog)
            {
                Debug.LogWarning("[UnityPlayerWindowCorner]\n\tJP: Windows以外の環境" +
                    $"({Application.platform})からウィンドウの角を設定しようとしました\n" +
                    $"\tEN: Trying to set window corner from except Windows ({Application.platform})");
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
#if HAS_COMMON_MAIN_WINDOW_HANDLE_GETTER_HW
            // 共通のウィンドウハンドル取得クラスが存在する場合
            return CommonMainWindowHandle.IsHandleValid;
#else
            // 共通のウィンドウハンドル取得クラスが存在しない場合
            return UnityPlayerWindow.IsHandleValid;
#endif
        }

        /// <summary>
        /// ウィンドウハンドルを取得する
        /// </summary>
        /// <returns>ウィンドウハンドル</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static nint GetWindowHandle()
        {
#if HAS_COMMON_MAIN_WINDOW_HANDLE_GETTER_HW
            // 共通のウィンドウハンドル取得クラスが存在する場合
            return CommonMainWindowHandle.MainWindowHandle;
#else
            // 共通のウィンドウハンドル取得クラスが存在しない場合
            return UnityPlayerWindow.MainWindowHandle;
#endif
        }
    }
}
