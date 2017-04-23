# Azure-Media-Services-AzureMediaIndexer2-Demo
Azure Media Indexer 2 と Microsoft Translatorを使った字幕自動生成のアプリケーションです。

## 概要
2つのプロジェクトで成り立っています。

1. Web CMS
- Azure-Media-Services-Samples-SimpleVCMS

シンプルなASP.MET MVC に、Azure Media Player を埋め込んだアプリになります。SQL Databaseに、動画、字幕ファイルの場所を保持管理しています。

2. ファイルアップローダー
- Azure-Media-Services-Samples-FileUploader(Indexer_Translator)

.NETのコンソールアプリケーションで、以下の処理を行います。
   - ファイルアップロード
   - エンコード
   - 公開URL作成
   - 字幕ファイル作成 (Indexer2)
   - 機械翻訳 (Microsoft Trasnlator)
   - 動画、字幕ファイルの場所を、SQL Database に登録

SQL Databaseではファイル名がPrimari Keyになっていますので、同じファイルをアップロードする事ができません。ご注意ください。

<img src="/img/architecture.jpg">

<a href="/doc/AzureAIWorkshop_CC_Translator.pptx" target="_blank">ドキュメント</a>