/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ウィンドウの角に対する処理を保持するクラス

WindowCorner.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using AOT;
using HW.UnityPlayerWindowCorner.Libraries;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace HW.UnityPlayerWindowCorner
{
    /// <summary>
    /// ウィンドウの角に対する処理を保持するクラス
    /// </summary>
    public static class WindowCorner
    {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        /// <summary>
        /// 処理を許可するか
        /// </summary>
        private static readonly bool IsAllowProcess;
        /// <summary>
        /// SetWindowCornerCallbackのデリゲートのキャッシュ
        /// </summary>
        private static readonly User32Wrapper.EnumWindowsProc SetWindowCornerCallbackCache;
#endif

        /// <summary>
        /// ログを出力するか
        /// </summary>
        private static bool isOutputLog;

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
        /// 初期化処理
        /// </summary>
        static WindowCorner()
        {
            // ログ出力を有効化する
            isOutputLog = true;

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            // 現在の環境がWindowsのスタンドアロンプレイヤーか判定する
            IsAllowProcess = Application.platform == RuntimePlatform.WindowsPlayer;

            // SetWindowCornerCallbackのデリゲートをキャッシュする
            SetWindowCornerCallbackCache = SetWindowCornerCallback;
#endif
        }

        /// <summary>
        /// ウィンドウの角の種類を設定する
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル</param>
        /// <param name="cornerType">角の種類</param>
        /// <returns>処理結果</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Set(WindowCornerType cornerType)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            if (IsAllowProcess)
            {
                // 実行が許可される場合
                // パラメーターを準備する
                var parameters = new SetWindowCornerCallbackParameters(
                    Kernel32Wrapper.GetCurrentProcessId(), cornerType);

                // トップレベルのウィンドウの角を処理する
                return User32Wrapper.EnumWindows(SetWindowCornerCallbackCache, ref parameters);
            }
            else
            {
                // 実行が許可されない(WindowsのUnityEditor)場合は失敗
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

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        /// <summary>
        /// SetWindowCornerの内部処理
        /// </summary>
        /// <param name="windowHandle">ウィンドウハンドル</param>
        /// <param name="parameters">パラメーター</param>
        /// <returns>処理を続行するか</returns>
        [MonoPInvokeCallback(typeof(User32Wrapper.EnumWindowsProc))]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static bool SetWindowCornerCallback(
            nint windowHandle, ref SetWindowCornerCallbackParameters parameters)
        {
            if (User32Wrapper.GetWindowThreadProcessId(windowHandle, out var processId) == 0 ||
                parameters.ProcessId != processId)
            {
                // 現在のプロセスIDとウィンドウを生成したプロセスのIDが異なる場合は何もしない
                return true;
            }

            // ウィンドウの角の種類を設定する
            var cornerType = parameters.CornerType;
            DwmApiWrapper.DwmSetWindowAttribute(
                windowHandle, DwmApiWrapper.DwmWindowCornerPreference,
                ref cornerType, DwmApiWrapper.WindowCornerTypeDataSize);

            return true;
        }
#endif
    }
}
