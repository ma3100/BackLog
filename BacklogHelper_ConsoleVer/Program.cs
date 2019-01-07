using Backlog4dotnet.api.option;
using Backlog4dotnet.client;
using Backlog4dotnet.conf;
using BacklogHelper.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BacklogHelper_ConsoleVer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // カブコムBacklogは.jp
            var configure = new BacklogJpConfigure(ConfigurationManager.AppSettings["SpaceID"]).ApiKey(ConfigurationManager.AppSettings["ApiKey"]);
            // バックログを操作出来るクライアントを生成
            var backlog = new BacklogClientFactory(configure).newClient();

            var escape = @"&%""#!\'<>/_*[];+:";

            try
            {
                var description = "";
                var summry = "";

                var filePath = OpenFile();
                if (filePath != "")
                {
                    description = String.Join(@"\r\n", File.ReadLines(filePath, System.Text.Encoding.GetEncoding("shift_jis")));
                    summry = System.IO.Path.GetFileNameWithoutExtension(filePath);

                    foreach (ProjectConfig projectConfig in BacklogProjectConfig.Instance.Projects)
                    {
                        // Project取得
                        var project = backlog.getProject(projectConfig.ProjectID);


                        // 課題種別一覧取得(設定Fileで取得予定)
                        var issueTypes = backlog.getIssueTypes(project.id);
                        var registIssueValue = issueTypes.Any(x => x.name == "定期メンテナンス連絡") ? "定期メンテナンス連絡" : "その他";

                        // 優先度一覧を取得
                        var priorityList = backlog.getPriorities();

                        var createIssueParams = new CreateIssueParams(project.id, summry, issueTypes.First(x => x.name == "その他").id, priorityList.First().id);
                        createIssueParams.setParam("description", description);
                        var issue = backlog.createIssue(createIssueParams);
                    }
                }
                else
                    Console.WriteLine("ファイル選択がキャンセルされました。");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("画面キャプチャを取ってシステム担当者にお問い合わせください。");
            }

            Console.WriteLine("終了しました。Enterを押してください。");
            Console.ReadLine();
            // Project一覧の取得
            // var projects = backlog.getProjects();

            //// 何もいれなきゃ上位20件の課題検索　細かい実装は未着手
            //var issueParams = new GetIssueParams();
            //var issues = backlog.getIssues(issueParams);
        }

        private static string OpenFile()
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
//            ofd.FileName = "default.html";

            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = ConfigurationManager.AppSettings["SearchPass"];
            
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            //ofd.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
            
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 2;
            
            //タイトルを設定する
            ofd.Title = "登録ファイルを選択してください";
            
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                return (ofd.FileName);
            }
            
            return "";
        }
    }
}
