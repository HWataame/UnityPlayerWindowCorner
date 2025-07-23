# UnityPlayer Window Corner
<img alt="トップ画像" src="https://github.com/user-attachments/assets/d6f85ffd-f064-43ca-bb08-5fb06cfb31b0" />

## 概要 / Overview
Windows11で動作するUnityのスタンドアロンプレイヤーのウィンドウの角を変更する機能を提供します
(導入したプロジェクトをビルドしたWindows用のプレイヤーアプリケーションでのみ機能します)

Set Standalone Player window's corner type running on Windows11
(This feature only works for Windows player applications built with the installed project)

## 動作環境 / Requirements
- Windows 11(21H2以上)
  
  Windows 11 (version 21H2 or later)


- Unity 2021.3以上
  
  Unity 2021.3 or later
  
  
## 動作を確認した環境 / Verified Environment
- Windows 11 24H2 (26100)
- Unity 2021.3.45f1, Unity 2022.3.62f1, Unity 6000.0.53f1

## 使用方法 / English "Usage" is below this
### ウィンドウの角の種類を変更する
名前空間`HW.UnityPlayerWindowCorner`内の`WindowCorner.Set(WindowCornerType cornerType)`を実行すると、ウィンドウの角の種類を変更することができます

以下の例では、ウィンドウの角を丸めないように設定します
```csharp
// 角の種類(Default、DoNotRound、Round、RoundSmallの4種類から選択可能)
var cornerType = HW.UnityPlayerWindowCorner.WindowCornerType.DoNotRound;

// スタンドアロンプレイヤーのウィンドウの角の種類を変更する
HW.UnityPlayerWindowCorner.WindowCorner.Set(cornerType);
```
ウィンドウの角の種類ごとの角の見た目は以下のようになります(OSバージョン24H2時点)

<img alt="ウィンドウの角" src="https://github.com/user-attachments/assets/2c5c9b65-94c3-4874-a90d-7ac77a4e6c09" />


### 非対応環境で実行した時のログの出力を設定する
名前空間`HW.UnityPlayerWindowCorner`内の`WindowCorner.IsOutputLog`(`bool`型のプロパティ)に値を設定すると、Windows11以前以外の非対応環境で`WindowCorner.Set(WindowCornerType cornerType)``を実行した時に警告ログを出力するかを設定できます

## Usage / 日本語の「使用方法」は上にあります
### Change Standalone Player window corner type
Call `WindowCorner.Set(WindowCornerType cornerType)`(namespace: `HW.UnityPlayerWindowCorner`) to change Standalone Player window corner type

The following example changes Standalone Player window corner to unrounded
```csharp
// Corner Type(4 options: Default, DoNotRound, Round, RoundSmall)
var cornerType = HW.UnityPlayerWindowCorner.WindowCornerType.DoNotRound;

// Change Standalone Player window corner type
HW.UnityPlayerWindowCorner.WindowCorner.Set(cornerType);
```
The appearance of the corners of each types of window corner is as follows(on Windows 11 version 24H2)

<img alt="ウィンドウの角" src="https://github.com/user-attachments/assets/2c5c9b65-94c3-4874-a90d-7ac77a4e6c09" />


### Configure log output when executing in unsupported environments
Set `bool` value to `WindowCorner.IsOutputLog` property (namespace: `HW.UnityPlayerWindowCorner`), configure warning log when executing in unsupported environments without old Windows environment. 

## 導入方法 / English "How to introduction" is below this
1. Gitをインストールする
2. 追加したいプロジェクトを開き、Package Managerを開く
3. 以下のGit URLをコピー、またはこのページ上部の「<> Code」からClone URLをコピーする

   https://github.com/HWataame/UnityPlayerWindowCorner.git

4. 「Package Manager」ウィンドウの左上の「＋」ボタンをクリックし、「Install package from git URL...」を選択する

    <img alt="導入方法01" src="https://github.com/user-attachments/assets/0efdf21a-181e-4a5d-8064-e0f873887794" />
5. 入力欄に手順2でコピーしたURLを貼り付け、「Install」ボタンを押す

    <img alt="導入方法02" src="https://github.com/user-attachments/assets/40d4bcc1-b69b-4941-b69c-16c544ad9e73" />
6. (必要に応じて)Assembly Definition Assetの管理下のエディターコードで利用する場合は、`HW.UnityPlayerWindowCorner`をAssembly Definition Referencesに追加する

    <img alt="導入方法03(必要に応じて)" src="https://github.com/user-attachments/assets/6c478ec1-58b9-4da9-a288-2d16c1289e8b" />

## How to introduction / 日本語の「導入方法」は上にあります
1. Install Git to your computer.
2. Open Package Manager in the Unity project to which you want to add this feature.
3. Copy the following Git URL, or copy the Clone URL from "<> Code" at the top of this page

   https://github.com/HWataame/UnityPlayerWindowCorner.git

4. Click the "+" button in the "Package Manager" window and select "Install package from git URL...".

    <img alt="導入方法01" src="https://github.com/user-attachments/assets/0efdf21a-181e-4a5d-8064-e0f873887794" />
5. Paste the URL copied in Step 2 into the input field and press the "Install" button.

    <img alt="導入方法02" src="https://github.com/user-attachments/assets/40d4bcc1-b69b-4941-b69c-16c544ad9e73" />
6. (If necessary) For use in editor code under the control of Assembly Definition Asset...

   Add `HW.UnityPlayerWindowCorner` to "Assembly Definition References" in your Assembly Definition Asset.

    <img alt="導入方法03(必要に応じて)" src="https://github.com/user-attachments/assets/6c478ec1-58b9-4da9-a288-2d16c1289e8b" />

## ライセンス / License
[MITライセンス](/LICENSE)です

Using ["MIT license"](/LICENSE)
