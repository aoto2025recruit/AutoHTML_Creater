using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Threading;

namespace auto_member_detail
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            start_id.KeyPress += Start_id_KeyPress;
            end_id.KeyPress += End_id_KeyPress;
        }

        //プログラムを開いた時の操作
        private void Form1_Load(object sender, EventArgs e)
        {
            //エラーメッセージの初期化
            exist_html.Text = "";
            exist_excel.Text = "";
            col_startid.Text = "";
            col_endid.Text = "";
            exist_folder.Text = "";
            error_select.Text = "";

            //ドラッグアンドドロップを有効にする
            //save_fname.AllowDrop = true;
            html_fpass.AllowDrop = true;
            excel_fpass.AllowDrop = true;

            //save_fname.DragDrop += new DragEventHandler(TextBox_DragDrop);
            html_fpass.DragDrop += new DragEventHandler(TextBox_DragDrop);
            excel_fpass.DragDrop += new DragEventHandler(TextBox_DragDrop);
            //save_fname.DragEnter += new DragEventHandler(TextBox_DragEnter);
            html_fpass.DragEnter += new DragEventHandler(TextBox_DragEnter);
            excel_fpass.DragEnter += new DragEventHandler(TextBox_DragEnter);

            //セレクトボックスのテキスト部分を入力不可にする
            selectbox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Icon8のリンクを有効にするためのクラス(消さないで）
        private void Icons8Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        {

            LinkLabel link = (LinkLabel)sender;



            // System.Diagnostics 名前空間の Process クラスの Start メソッドを使って URL を開いています。

            System.Diagnostics.Process.Start("https://icons8.com");

        }

        //マウスイベント
        private void Change_Button_Color(object sender, EventArgs e)
        {
            active.BackColor = Color.FromArgb(211, 211, 255);
        }

        //ボタンを押すとボタンの画像を変える
        private void Change_BottonD_Back(object sender, EventArgs e)
        {
            active.Image = new Bitmap(@"C:\web_app\auto-member-detail\pic\frame\7.その他\Button2.png");
        }

        //ボタンからクリックを離すと画像を戻す
        private void Change_BottonU_Back(object sender, EventArgs e)
        {
            active.Image = new Bitmap(@"C:\web_app\auto-member-detail\pic\frame\7.その他\Button1.png");
        }

        //プログラムを閉じる際のイベント
        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 質問ダイアログを表示する
                DialogResult result = MessageBox.Show("ウィンドウを閉じますか？\n(プログラム実行中に終了しないでください)", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.No)
                {
                    // はいボタンをクリックしたときはウィンドウを閉じる
                    e.Cancel = true;
                }
        }

        //選択項目が変更されるときのイベント
        private void selectbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //アルバム詳細ページを選択した場合は開始IDをロックする
            LockStartID();
        }

        //初期化関数
        public void Init()
        {
            //エラーメッセージの初期化
            exist_html.Text = "";
            exist_excel.Text = "";
            col_startid.Text = "";
            col_endid.Text = "";
            exist_folder.Text = "";
            error_select.Text = "";

            //ここまで
            result_text.Text = "\n実行されるとここにログが表示されます\n";
            result_text.Text += "=====================\n";
            result_text.Text += "プログラムの実行を始めます\n";
            result_text.Text += "実行中にプログラムを終了しないでください\n";
            result_text.Text += "ファイルへの書き込みを開始します！\n";
            result_text.Text += "=====================\n";
        }

        //テキストボックスの入力不可/入力可能を設定する関数
        //(judeg=1でlock,judge=0でunlock)
        public void LockEnter(int judge)
        {
            //ロックするかしないかを判定する
            Boolean flag;

            //ロックする
            if(judge == 1) { flag = true; }
            //ロックしない
            else{ flag = false; }

            //実際の操作
            //参照ファイル(Excel)
            excel_fpass.ReadOnly = flag;
            //参照ファイル(Html)
            html_fpass.ReadOnly = flag;
            //開始ID
            start_id.ReadOnly = flag;
            //終了ID
            end_id.ReadOnly=flag;
            //保存先フォルダ
            save_fname.ReadOnly = flag;
            //出力ファイル選択(Enabledはtrueだと編集可能)
            selectbox.Enabled = !flag;

            //終了ボタンが押せない(Enabledはtrueだと編集可能)
            //end.Enabled = !flag;
        }

        //実行ボタンを押したときの動作
        private void Active_Click(object sender, EventArgs e)
        {
            //辞書型変数を定義
            Dictionary<String, List<string>> data = new Dictionary<String, List<string>>();
            //操作が終了したかを示す変数
            int fin=0;
            //ユーザーからの入力をロックするかどうかについてを判定する(デフォルトはロックする)
            int lock_e = 1;
            //出力ファイルの選択
            String select = selectbox.Text;

            //初期化関数
            Init();

            //実行中のテキストの変更を禁止する
            LockEnter(lock_e);

            //Excelからデータの読み取りとデータのセット
            data = SetfromExcel();
            //フォルダの存在確認(前後のスペースを消す)
            String folder = ConfirmFolder(Delete_file_Uncode(save_fname.Text));

            //辞書型変数にデータが格納されている場合のみ
            if(data.Count > 0)
            {
                //インスタンスの作成(スペースなどを消す前)
                Memory memory = new Memory(excel_fpass.Text,html_fpass.Text, Int32.Parse(start_id.Text)
                                            , Int32.Parse(end_id.Text),save_fname.Text,select);

                //スペースを消す
                memory.Excel_pass = Delete_file_Uncode(memory.Excel_pass);
                memory.Html_pass = Delete_file_Uncode(memory.Html_pass);
                memory.Savepass = Delete_file_Uncode(memory.Savepass);

                //htmlファイルに保存
                fin = WriteHtml(memory , data);

                //区切りを行う
                result_text.Text += "=====================\n";

                //ちゃんと終了したときのみ記述
                if(fin == 1)
                {
                    //メッセージの書き込み
                    result_text.Text += @folder + "に保存を行います\n";
                    result_text.Text += "\n";

                    //ファイル保存完了のメッセージを出力
                    if(select == "メンバー詳細ページ")
                    {
                        foreach (String name in data.Keys)//keyの分回す
                        {
                            result_text.Text += name + ".html の書き込みが完了しました！\n";
                        }
                    }
                    else if(select == "アルバム詳細ページ")
                    {
                        //data["Other_Data"][1]はアルバムの英語名
                        result_text.Text += data["Other_Data"][1] + ".html の書き込みが完了しました！\n";
                    }
                    
                }
            }
            else
            {
                //区切りを行う
                result_text.Text += "=====================\n";
                result_text.Text += "読み込むデータが存在しません\n" +
                                    "(名義(英語名)が空の時は読み込めません)\n";
            }
            //区切りを行う
            result_text.Text += "=====================\n";
            result_text.Text += "終了します！";

            //入力のロックを解除する
            lock_e = 0;
            LockEnter(lock_e);

            //ちゃんと終わったらダイアログを出す
            if (fin == 1)
            {
                MessageBox.Show("ファイルの生成が完了しました","Info", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("ファイルの生成に失敗しました", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //エクセルファイルの参照
        private void Summary_e_Click(object sender, EventArgs e)
        {

            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "default.xslx";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = @Application.StartupPath;
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "Excelファイル(*.xlsx;*.xls;*.xlsm;*.xlsb)|*.xlsx;*.xls;*.xlsm;*.xlsb";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
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
                excel_fpass.Text = ofd.FileName;
            }
        }

        //htmlファイル参照
        private void Summary_h_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "default.html";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = @Application.StartupPath;
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
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
                html_fpass.Text = ofd.FileName;
            }
        }

        //開始IDを入力したときの制約
        private void Start_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            //バックスペースは有効
            if (e.KeyChar == '\b')
            {
                return;
            }

            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        //終了IDを入力したときの制約
        public void End_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            //バックスペースは有効
            if (e.KeyChar == '\b')
            {
                return;
            }

            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        //入力欄の制約
        public void NoSpace_KeyPress(object sender, KeyPressEventArgs e)
        {
            //半角スペースor全角スペースorタブキーはイベントキャンセル
            //(全角スペースはきいてしまうから後でTrimで消去))
            if (e.KeyChar == ' ' || e.KeyChar == '　')
            {
                e.Handled = true;
            }
        }

        //保存先フォルダの参照
        private void Save_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "保存するフォルダーを選択してください。";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.Cancel)
            {
                // [キャンセル] をクリックされた場合は終了
                return;
            }
            // フォルダーパスを取得
            save_fname.Text = folderBrowserDialog.SelectedPath;
            // ダイアログのインスタンスを破棄する
            folderBrowserDialog.Dispose();

        }

        //htmlファイルに書き込む(Excelから得たデータを参照)
        public int WriteHtml(Memory memory ,Dictionary<String, List<string>> data)
        {
            Operate opp = new Operate();
            /*変数まとめ*/
            String filename = memory.Html_pass;//HTMLファイルの名前
            String folderpass = memory.Savepass;//保存フォルダのパス
            String select = memory.Selectfile;//出力ファイルの選択

            //前後の空白文字を削除する
            filename = filename.Trim();
            folderpass = folderpass.Trim();

            //ファイルの存在確認
            if (File.Exists(filename) == false)//存在しない場合
            {
                //スペースを削除
                filename = opp.EraceSpace(filename);

                //エラーメッセージの出力
                Exist_HTML_Error(filename);

                //途中終了
                return 0 ;
            }
            else//存在する場合のみ読み込み
            {
                //インスタンスの作成
                if(select == "メンバー詳細ページ")
                {
                    Member_Operate op = new Member_Operate();
                    //処理の実行
                    op.Operate_HTML(memory, data);
                }
                else if(select == "アルバム詳細ページ")
                {
                    Album_Operate op = new Album_Operate();
                    //処理の実行
                    op.Operate_HTML(memory, data);
                }
                else
                {
                    error_select.Text = "出力ファイルを選択してください\n";
                    result_text.Text += "出力ファイルを選択してください\n";
                    return 0 ;
                }

            }

            return 1;

        }

        //Excelからデータを読み取って辞書型変数にセットする関数
        public Dictionary<String, List<string>> SetfromExcel()
        {
            Operate op = new Operate();
            //辞書型変数を定義
            Dictionary<String, List<string>> personal_dic = new Dictionary<String, List<string>>();
            //エクセルのファイル名
            String filename = excel_fpass.Text;
            //出力ファイル
            String select = selectbox.Text;
            //開始インデックスと終了インデックス
            int start,end;

            //Excelファイルの読み込み

            //前後の空白文字を削除する
            filename = filename.Trim();
            //Excelファイルが存在しない場合はエラーメッセージを出す
            if (File.Exists(filename) == false)
            {
                //スペースを消す
                filename = op.EraceSpace(filename);

                //エラーメッセージの出力
                Exist_Excel_Error(filename);
            }
            else//ファイルが存在する場合のみ読み込みを行う
            {
                //開始行と終了行の数字の確認
                ConfirmNum(select);

                start = Int32.Parse(start_id.Text);
                end = Int32.Parse(end_id.Text);
                //エクセルファイルからデータの読み込み
                //インスタンスの作成
                if (select == "メンバー詳細ページ")
                {
                    Member_Operate op1 = new Member_Operate();
                    personal_dic = op1.Operate_SetfromExcel(filename, start, end);
                }
                else if (select == "アルバム詳細ページ")
                {
                    Album_Operate op2 = new Album_Operate();
                    personal_dic = op2.Operate_SetfromExcel(filename, start, end);
                }
                else
                {
                    error_select.Text = "出力ファイルを選択してください\n";
                    result_text.Text += "出力ファイルを選択してください\n";
                }
            }

            return personal_dic;
        }

        //HTMLファイルがない場合のエラー文出力用関数
        private void Exist_HTML_Error(String filename)
        {
            //状況によってエラーメッセージを変える

            if (filename == "")
            {
                exist_html.Text = "HTMLファイルが選択されていません\n";
                result_text.Text += "HTMLファイルが選択されていません\n"; ;
            }
            else
            {
                if (filename.EndsWith(".html") || filename.EndsWith(".htm"))
                {
                    exist_html.Text = "上記のHTMLファイルは存在しません！\n";
                    result_text.Text += filename + "は存在しません！\n";
                }
                else
                {
                    exist_html.Text = "上記のファイルはHTMLファイルではありません\n";
                    result_text.Text += filename + "はHTMLファイルではありません\n";
                }

            }
        }

        //Excelファイルがない場合のエラー文出力用関数
        private void Exist_Excel_Error(String filename)
        {
            //エラーメッセージを変える
            if (filename == "")
            {
                exist_excel.Text = "Excelファイルが選択されていません";
                result_text.Text += "Excelファイルが選択されていません\n";
            }
            else
            {
                if (filename.EndsWith(".xlsx") || filename.EndsWith(".xls")
                    || filename.EndsWith(".xlsm") || filename.EndsWith(".xlsb"))
                {
                    exist_excel.Text = "上記のExcelファイルは存在しません！";
                    result_text.Text += filename + "は存在しません！\n";
                }
                else
                {
                    exist_excel.Text = "上記ファイルはExcelファイルではありません";
                    result_text.Text += filename + "はExcelファイルではありません\n";
                }

            }
        }

        //開始行と終了行の数字の確認用関数(SetfromExcel関数でのみ参照)
        public void ConfirmNum(String select)
        {
            //初期値を代入
            String start="";
            String end="";

            //空の場合はStringに入れられない
            if (!String.IsNullOrEmpty(start_id.Text))
            { start = start_id.Text; }
            if (!String.IsNullOrEmpty(end_id.Text)) 
            { end = end_id.Text; }


            if(select == "メンバー詳細ページ")
            {
                //未入力の場合は先頭行のみを読み込み(1行目はメニューで埋まってるから2行目から)
                //1を指定したときラベルなのでダメ
                if (String.IsNullOrEmpty(start) || start == "1")
                {
                    start = "2";
                    col_startid.Text = "開始IDが無効なので2に変更しました！\n";
                    result_text.Text += "開始IDが無効なので2に変更しました！\n";
                }
                if (String.IsNullOrEmpty(end) || end == "1")
                {
                    end = "2";
                    col_endid.Text = "終了IDが無効なので2に変更しました！\n";
                    result_text.Text += "終了IDが無効なので2に変更しました！\n";
                }

                if (Int32.Parse(end) < Int32.Parse(start))//スタートの値と終了の値の大小関係がおかしいとき
                {
                    col_endid.Text += "開始IDと終了IDの大小関係が間違っています！";
                    result_text.Text += "開始IDと終了IDの大小関係が間違っています！\n";
                    result_text.Text += "開始IDと終了IDを同じにしました(" + end+ "→" + start + ")\n";
                    end = start;
                }
            }
            else if(select == "アルバム詳細ページ")
            {
                //未入力の場合は先頭行のみを読み込み(1行目はメニューで埋まってるから2行目から)
                //1を指定したときラベルなのでダメ(やらなくてもいいけど)
                if (String.IsNullOrEmpty(start) || start== "1")
                {
                    start = "2";
                }
                //終了IDだけみたらいい(6行目からが曲の詳細が入っている）
                if (String.IsNullOrEmpty(end) || Int32.Parse(end) < 6)
                {
                    end = "6";
                    col_endid.Text = "終了IDが無効なので6に変更しました！\n";
                    result_text.Text += "終了IDが無効なので6に変更しました！\n";
                }
            }
            //出力ファイルを選択していない場合:
            else
            {
                //未入力の場合は先頭行のみを読み込み(1行目はメニューで埋まってるから2行目から)
                //1を指定したときラベルなのでダメ
                if (String.IsNullOrEmpty(start) || start == "1")
                {
                    start = "2";
                    col_startid.Text = "開始IDが無効なので2に変更しました！\n";
                    result_text.Text += "開始IDが無効なので2に変更しました！\n";
                }
                if (String.IsNullOrEmpty(end) || end == "1")
                {
                    end = "2";
                    col_endid.Text = "終了IDが無効なので2に変更しました！\n";
                    result_text.Text += "終了IDが無効なので2に変更しました！\n";
                }
            }

            //代入
            start_id.Text = start;
            end_id.Text = end;

        }

        //フォルダのパスがあるかどうかの確認(存在しない場合ディレクトリを作る)
        public String ConfirmFolder(String foldername)
        {
            String folder = @Application.StartupPath;//現在のパス(実行ファイル)
            String tmp;//一時保存用

            if (!Directory.Exists(@foldername))//もし有効なフォルダではないなら
            {

                //デフォルトの出力ファイルのHTMLディレクトリがないなら
                if (!Directory.Exists(@Path.Combine(@folder, "HTML")))
                {
                    //フォルダのパスをデフォルトに設定
                    tmp = @Path.Combine(@folder, "HTML");

                    //フォルダを作成
                    Directory.CreateDirectory(@tmp);
                }

                //今日の日付を取得
                DateTime dt = DateTime.Now;

                //フォルダのパスをデフォルトに設定
                folder = @Path.Combine(@folder, "HTML");

                //エラーメッセージの書き込み
                exist_folder.Text = "無効なフォルダ名です\n(上記のフォルダに保存を行います)\n";
                result_text.Text += "無効なフォルダ名です\n(" + @folder + "に保存を行います)\n";

                //今日の日付を文字列に変換
                tmp = dt.ToString("yyyy_MM_dd_HH_mm_ss");

                //フォルダのパスを今日のパスに設定
                folder = @Path.Combine(@folder, tmp);

                //今日のフォルダを作成
                Directory.CreateDirectory(@folder);

                save_fname.Text = @folder;

            }
            else//有効なフォルダ名ならそのまま
            {
                folder = @foldername;
            }

            return @folder;
        }

        //アルバム詳細ページを選択した場合は開始IDをロックする
        public void LockStartID()
        {
            if(selectbox.Text == "アルバム詳細ページ")
            {
                start_id.Enabled = false;
            }
            else
            {
                start_id.Enabled = true;
            }
        }

        //ドラッグアンドドロップ用
        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            //ファイルがドラッグされている場合、カーソルを変更する
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        //ドラッグアンドドロップ用
        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたファイルの一覧を取得
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length <= 0)
            {
                return;
            }

            // ドロップ先がTextBoxであるかチェック
            RichTextBox txtTarget = sender as RichTextBox;
            if (txtTarget == null)
            {
                return;
            }

            //TextBoxの内容をファイル名に変更
            txtTarget.Text = fileName[0];
        }

        //ファイル名(pass)に含まれる無効文字を消す関数()
        public String Delete_file_Uncode(String filename)
        {
            String tmp = filename;

            //始めと末尾の半角スペースと全角スペースとタブ文字とャリッジリターンとラインフィードを削除する
            tmp = tmp.TrimStart();
            tmp = tmp.TrimEnd();
            return tmp;
        }
    }


    public class Operate
    {

        //実際のExcelからデータを読み取る関数
        public virtual Dictionary<String, List<string>> Operate_SetfromExcel(String filename, int start, int end)
        {
            //辞書型変数を定義
            Dictionary<String, List<string>> personal_dic = new Dictionary<String, List<string>>();

            return personal_dic;
        }

        //実際のHTMLファイルの記入操作を行う関数
        public virtual void Operate_HTML(Memory memory, Dictionary<String, List<string>> data)
        {
            return;
        }

        //文字列の空欄を消す＋始めの文字を取得(writeHtml関数でのみ参照)
        public String Stringfirst(String text)
        {
            //文字列の整形(空白を消す)
            text = EraceSpace(text);
            //text=""(なし)の対策
            if (String.IsNullOrEmpty(text)) { text += "%"; }

            //一つ目の文字を取得
            String first = text.Substring(0, 1);

            //1文字目を返す
            return first;
        }

        //トークンの識別と置き換え(WriteHtml関数でのみ参照)
        public virtual String JudgeToken(Dictionary<String, List<string>> data, String token, String name, String space = "")
        {
            String personal = "error";

            return personal;
        }

        //文字列の整形(空白を消す)
        public String EraceSpace(String text)
        {
            //文字列の整形(空白を消す)
            if (!String.IsNullOrEmpty(text))
            {
                return System.Text.RegularExpressions.Regex.Replace(text, @"[\s]+", "");
            }
            else//nullならそのまま返す
            {
                return text;
            }

                
        }

        //不必要なところを記述するのかの判定用関数
        public int JudgeErace(String str)
        {
            int judge = 0;//判定用変数(0なら消さない/1なら消す)

            if (String.IsNullOrEmpty(str))//空かnullなら消す
            {
                judge = 1;
            }

            return judge;
        }

        //保存用関数
        public void Savehtml(String text ,Boolean element , String filename)
        {
            //ファイルに書き込み
            using (var writer = new StreamWriter(@filename, element, Encoding.GetEncoding("UTF-8")))
            {
                writer.Write(text);
            }
        }

    }

    public class Member_Operate : Operate
    {
        //メンバー詳細ページを作るときのデータの読み込み
        public override Dictionary<String, List<string>> Operate_SetfromExcel(String filename, int start ,int end)
        {
            //インスタンスの初期化
            Form1 form1 = new Form1();

            //辞書型変数を定義
            Dictionary<String, List<string>> personal_dic = new Dictionary<String, List<string>>();
            //辞書のkey用(一時保存用)
            //key(実行途中で定義)
            //現在の行番号
            String ln;

            //ファイル名(スペースなどを消したもの)
            String file = form1.Delete_file_Uncode(filename);

            //エクセルファイルの読み込み
            using (var workbook = new XLWorkbook(file, XLEventTracking.Disabled))
            {
                //一つ目のworksheetを読み取り
                var worksheet = workbook.Worksheet(1);
                //startが無効なら2行目から
                if (start < 2) { start = 2; }
                //endが無効なら2行目から
                if (end < 2) { end = 2; }

                //Excelから必要な回数辞書に登録する
                for (var i = start; i <= end; i++)
                {
                    //初期化
                    var key = "";
                    //リストを定義
                    List<string> list = new List<string>();

                    //データの取得
                    //現在の行番号を取得
                    ln = i.ToString();
                    //名義(英語)を取得(辞書型変数のkeyになる)
                    key = worksheet.Cell("D" + ln).Value.ToString();

                    //空またはNULLじゃない時&辞に登録されていないときだけ辞書型に登録
                    if (!String.IsNullOrEmpty(key)&&!personal_dic.ContainsKey(key))
                    {
                        //名義(日本語)を取得
                        list.Add(worksheet.Cell("B" + ln).Value.ToString());
                        //DAWを取得
                        list.Add(worksheet.Cell("P" + ln).Value.ToString());
                        //楽器1を取得
                        list.Add(worksheet.Cell("Q" + ln).Value.ToString());
                        //楽器2を取得
                        list.Add(worksheet.Cell("R" + ln).Value.ToString());
                        //楽器3を取得
                        list.Add(worksheet.Cell("S" + ln).Value.ToString());
                        //楽器4を取得
                        list.Add(worksheet.Cell("T" + ln).Value.ToString());
                        //楽器5を取得
                        list.Add(worksheet.Cell("U" + ln).Value.ToString());
                        //アーティスト1を取得
                        list.Add(worksheet.Cell("V" + ln).Value.ToString());
                        //アーティスト2を取得
                        list.Add(worksheet.Cell("W" + ln).Value.ToString());
                        //アーティスト3を取得
                        list.Add(worksheet.Cell("X" + ln).Value.ToString());
                        //アーティスト4を取得
                        list.Add(worksheet.Cell("Y" + ln).Value.ToString());
                        //アーティスト5を取得
                        list.Add(worksheet.Cell("Z" + ln).Value.ToString());
                        //曲1を取得
                        list.Add(worksheet.Cell("AA" + ln).Value.ToString());
                        //曲2を取得
                        list.Add(worksheet.Cell("AB" + ln).Value.ToString());
                        //曲3を取得
                        list.Add(worksheet.Cell("AC" + ln).Value.ToString());
                        //曲4を取得
                        list.Add(worksheet.Cell("AD" + ln).Value.ToString());
                        //曲5を取得
                        list.Add(worksheet.Cell("AE" + ln).Value.ToString());
                        //Twitter_IDを取得
                        list.Add(worksheet.Cell("AF" + ln).Value.ToString());
                        //soundClodを取得
                        list.Add(worksheet.Cell("AG" + ln).Value.ToString());
                        //ニコニコ動画のリンクを取得
                        list.Add(worksheet.Cell("AH" + ln).Value.ToString());
                        //Youtubeのリンクを取得
                        list.Add(worksheet.Cell("AI" + ln).Value.ToString());
                        //ひとことを取得
                        list.Add(worksheet.Cell("AJ" + ln).Value.ToString());
                        //アルバムタイトルを取得
                        /*list.Add(worksheet.Cell("AK" + ln).Value.ToString());*/

                        //辞書に登録
                        personal_dic.Add(key, list);
                    }
                }
            }
            
            return personal_dic;
        }

        //HTMLファイルへの書き込み
        public override void Operate_HTML(Memory memory, Dictionary<String, List<string>> data)
        {
            /*変数一覧*/
            String text;//読み出した1文を格納
            String tmp;//文字列の一時保存用
            List<string> tmpstr = new List<string>();//分割した文章を一時的に格納
            string[] strarr = new string[data.Count];//人ごとに異なるときの文字を格納
            Boolean element = false;//ファイルの追記モードと上書きモードの選択(上書きモード)
            int j;//書き換えの時に使う変数
            int judge = 0;//書き換え文字があるかを判定する変数(あるなら1、無いなら0)
            int[] erace = new int[data.Count];//Excelが未入力の場合飛ばす(erace=0なら消さない/erace=1なら消す)

            /*インスタンスを定義*/

            //Htmlファイルを開く
            StreamReader sr = new StreamReader(memory.Html_pass, Encoding.GetEncoding("UTF-8"));

            //読み込み回数の判定用
            int count = 1;
            //文章がなくなるまでループ
            while (sr.Peek() != -1)
            {
                //分割文字判定用変数を0にする
                judge = 0;
                //分割文字記録用変数を空にする
                //未入力の場合飛ばす変数を0にする(デフォルトでは消さない)
                for (j = 0; j < data.Count; j++)
                {
                    strarr[j] = "";
                    //未入力の場合飛ばす変数を0にする(デフォルトでは消さない)
                    erace[j] = 0;
                }

                //ファイルの追記モードと上書きモードの選択
                if (count == 1) { element = false; }//上書きモード
                else { element = true; }//追記モード

                //一行ずつ読み込む
                text = sr.ReadLine() + "\n";

                if (text.Contains("$"))//もし分割文字があると
                {
                    //分割文字判定用変数を1にする
                    judge = 1;
                    //Listに格納
                    tmpstr = text.Split('$').ToList();
                    //listに格納できたら一応初期化を行う。(変数を使い回すため)
                    text = "";

                    //tmpstr(list)の中に書き換え文字があるかを検索
                    for (var i = 0; i < tmpstr.Count; i++)
                    {
                        //書き換え文字があると書き換える
                        if (Stringfirst(tmpstr[i]) == "@")
                        {
                            j = 0;
                            //書き換え文字をexcelのデータに置き換えて結合
                            foreach (String name in data.Keys)//keyの分回す
                            {
                                //文字列の整形(空白を消す)
                                tmp = EraceSpace(tmpstr[i]);
                                //書き換え
                                tmp = JudgeToken(data, tmp, name);

                                //この書き換え後の文字列が空か判定(つまり入力してるか)
                                erace[j] += JudgeErace(tmp);
                                strarr[j] += tmp;
                                j++;
                            }

                        }
                        else//書き換え文字がない場合はそのまま結合
                        {
                            //書き換え文字をexcelのデータに置き換えて結合
                            for (j = 0; j < data.Count; j++)//keyの分回す
                            {
                                //共通部分をリストに追加
                                strarr[j] += tmpstr[i];
                            }
                        }
                    }
                }

                j = 0;
                //コードを記録
                foreach (String name in data.Keys)//keyの分回す
                {
                    //ファイルに書き込み
                    //パスを更新
                    String savepath = @Path.Combine(memory.Savepass, name + ".html");

                    //分割してたら結合したものを記述
                    if (judge == 1) { text = strarr[j]; }

                    //ファイルに書き込み
                    if (erace[j] == 0)
                    {
                        Savehtml(text, element, @savepath);
                    }
                    j++;
                }
                count++;
            }

            sr.Close();
        }

        //トークンの識別と置き換え(WriteHtml関数でのみ参照)
        public override String JudgeToken(Dictionary<String, List<string>> data, String token, String name, String space = "")
        {
            String personal = "error";
            String year = "";//何年度入会会員なのか格納

            //今日の日にちを取得
            DateTime today = DateTime.Today;
            //1,2,3月入会員は前年度会員になる
            if (today.Month < 4)
            {
                year = (today.Year - 1).ToString();
            }
            else//4月以降は今年度会員になる
            {
                year = today.Year.ToString();
            }

            switch (token)
            {
                case "@meigi":
                    personal = name;
                    break;

                case "@名義":
                    personal = data[name][0];
                    break;

                case "@入会年度":
                    personal = year;
                    break;

                case "@DAW":
                    personal = data[name][1];
                    break;

                case "@楽器1":
                    personal = data[name][2];
                    break;

                case "@楽器2":
                    personal = data[name][3];
                    break;

                case "@楽器3":
                    personal = data[name][4];
                    break;

                case "@楽器4":
                    personal = data[name][5];
                    break;

                case "@楽器5":
                    personal = data[name][6];
                    break;

                case "@アーティスト1":
                    personal = data[name][7];
                    break;

                case "@アーティスト2":
                    personal = data[name][8];
                    break;

                case "@アーティスト3":
                    personal = data[name][9];
                    break;

                case "@アーティスト4":
                    personal = data[name][10];
                    break;

                case "@アーティスト5":
                    personal = data[name][11];
                    break;

                case "@曲1":
                    personal = data[name][12];
                    break;

                case "@曲2":
                    personal = data[name][13];
                    break;

                case "@曲3":
                    personal = data[name][14];
                    break;

                case "@曲4":
                    personal = data[name][15];
                    break;

                case "@曲5":
                    personal = data[name][16];
                    break;

                case "@Twitter_ID":
                    personal = data[name][17];
                    break;

                case "@SoundCloud":
                    personal = data[name][18];
                    break;

                case "@Niconico":
                    personal = data[name][19];
                    break;

                case "@Youtube":
                    personal = data[name][20];
                    break;

                case "@ひとこと":
                    personal = data[name][21];
                    break;

                /*case "@アルバムタイトル":
                    personal = data[name][22];
                    break;*/


                default:
                    personal = "";
                    break;
            }

            return personal;
        }
    }

    public class Album_Operate : Operate
    {
        //アルバム詳細ページを作るときのデータの読み込み
        public override Dictionary<String, List<string>> Operate_SetfromExcel(String filename, int start, int end)
        {
            //インスタンスの初期化
            Form1 form1 = new Form1();

            //辞書型変数を定義
            Dictionary<String, List<string>> album_dic = new Dictionary<String, List<string>>();
            //辞書のkey用(一時保存用)
            String key;
            //現在の行番号
            String ln;
            //ファイル名(スペースなどを消したもの)
            String file = form1.Delete_file_Uncode(filename);

            //エクセルファイルの読み込み
            using (var workbook = new XLWorkbook(file, XLEventTracking.Disabled))
            {
                //一つ目のworksheetを読み取り
                var worksheet = workbook.Worksheet(1);
                //アルバムの場合は2行目から
                if(start != 2) { start = 2; }
                //曲名が入っているのは6行目から
                if(end < 6) { end = 6; }

                //Excelから必要な回数辞書に登録する
                for (var i = start; i <= end; i++)
                {
                    //初期化
                    key = "";
                    //リストを定義
                    List<string> list = new List<string>();

                    //データの取得
                    //現在の行番号を取得
                    ln = i.ToString();

                    //2行目は曲以外のデータが格納されている
                    if (i == 2)
                    {
                        //必要なデータを格納
                        key = "Other_Data";

                        //結合を解除
                        worksheet.Range("B1:C1").Unmerge();
                        //アルバム名を取得
                        list.Add(worksheet.Cell("B" + ln).Value.ToString());
                        //アルバム名(英語)を取得
                        list.Add(worksheet.Cell("D" + ln).Value.ToString());
                        //全体コメントを取得
                        list.Add(worksheet.Cell("L" + ln).Value.ToString());
                        //全体コメントを書いた人を取得
                        list.Add(worksheet.Cell("M" + ln).Value.ToString());
                        //youtubeのリンクを取得
                        list.Add(worksheet.Cell("O" + ln).Value.ToString());
                        //bandcompのリンクを取得
                        list.Add(worksheet.Cell("P" + ln).Value.ToString());

                        //辞書に登録
                        album_dic.Add(key, list);

                        //5行目までは不必要なデータが格納されているので飛ばす
                        i = 5;
                    }
                    else//実際の曲の詳細データを登録
                    {
                        //名義(英語)を取得(辞書型変数のkeyになる)
                        key = (String)worksheet.Cell("D" + ln).Value.ToString();

                        //空またはNULLじゃない時だけ辞書型に登録
                        if (!String.IsNullOrEmpty(key)&&!album_dic.ContainsKey(key))
                        {
                            //曲順(2桁)
                            var num = worksheet.Cell("B" + ln).Value.ToString();
                            num = String.Format("{0:00}",Int32.Parse(num));
                            list.Add(num);
                            //名義(日本語)を取得
                            list.Add(worksheet.Cell("C" + ln).Value.ToString());
                            //曲名を取得
                            list.Add(worksheet.Cell("E" + ln).Value.ToString());
                            //掲載コメントのあるファイル名を取得する(中身を読み込みは後で)(Trimでスペースなどを消してる)
                            list.Add(worksheet.Cell("G" + ln).Value.ToString().Trim());
                            //歌詞の有無を取得
                            list.Add(form1.Delete_file_Uncode(worksheet.Cell("I" + ln).Value.ToString()));
                            //歌詞のファイル名を取得する(中身を読み込みは後で)(Trimでスペースなどを消してる)
                            list.Add(form1.Delete_file_Uncode(worksheet.Cell("L" + ln).Value.ToString()));

                            //辞書に登録
                            album_dic.Add(key, list);
                        }
                    }
                }
            }

            return album_dic;
        }

        //HTMLファイルへの書き込み
        public override void Operate_HTML(Memory memory, Dictionary<String, List<string>> data)
        {
            /*変数一覧*/
            String text;//読み出した1文を格納
            String tmp;//文字列の一時保存用
            List<string> tmpstr = new List<string>();//分割した文章を一時的に格納
            string strarr = "";//人ごとに異なるときの文字を格納
            Boolean element = false;//ファイルの追記モードと上書きモードの選択(上書きモード)
            int judge = 0;//書き換え文字があるかを判定する変数(あるなら1、無いなら0)
            int erace = 0;//Excelが未入力の場合飛ばす(erace=0なら消さない/erace=1なら消す)
            int mode = 0;//モード変更(0:通常/1:テンプレを保存するモード)
            List<string> musiclist = new List<string>();//曲テンプレを保存する変数
            List<string> lyricslist = new List<string>();//歌詞テンプレを保存する変数
            List<string> tmprlist_ex = new List<string>();//テンプレ(歌詞がある場合)
            List<string> tmprlist_unex= new List<string>();//テンプレ(歌詞がない場合)
            List<string> tmprlist = new List<string>();//テンプレ(処理で用いるテンプレリスト)
            String before = ""; 
            String space = "";
            String exist="無";

            //Htmlファイルを開く
            StreamReader sr = new StreamReader(memory.Html_pass, Encoding.GetEncoding("UTF-8"));

            //パスを更新(data["Other_Data"][1] :アルバムの名前)(ファイルを保存するパス)
            String savepath = @Path.Combine(memory.Savepass, data["Other_Data"][1] + ".html");

            //読み込み回数の判定用
            int count = 1;
            //文章がなくなるまでループ
            while (sr.Peek() != -1)
            {
                //分割文字判定用変数を0にする
                judge = 0;
                //分割文字記録用変数を空にする
                strarr = "";
                //未入力の場合飛ばす変数を0にする(デフォルトでは消さない)
                erace = 0;

                //ファイルの追記モードと上書きモードの選択
                if (count == 1) { element = false; }//上書きモード
                else { element = true; }//追記モード

                //一行ずつ読み込む
                text = sr.ReadLine() + "\n";

                //テンプレ保存モードに移行
                if (text.Contains("以下曲テンプレ"))
                {
                    mode = 1;
                }
                else if (text.Contains("以下歌詞テンプレ"))
                {
                    mode = 2;
                }

                //通常モード(ファイルに書き込んでいく)
                if (mode == 0)
                {
                    //曲紹介の時は挙動が異なる
                    if (text.Contains("$@曲紹介$"))
                    {
                        //辞書型変数の行数をカウントする
                        var i=0;

                        /*テンプレリスト(tmprlist_ex/tmprlist_unex)の初期化*/

                        //tmprlist_ex(曲紹介+歌詞テンプレ)
                        tmprlist = CombineText(musiclist, lyricslist);
                        tmprlist_ex = new List<String>(tmprlist);

                        //tmprlist_unex(曲紹介だけ)
                        //歌詞テンプレートの部分は消す
                        foreach (String tmpr in musiclist)
                        {
                            tmp = tmpr;
                            //歌詞テンプレートがあったら
                            if (tmpr.Contains("$@歌詞テンプレート$"))
                            {
                                //歌詞テンプレートの部分は消す
                                tmp = tmpr.Replace("$@歌詞テンプレート$", "");
                            }
                            //テンプレートリスト(tmprlist_unex)に保存
                            tmprlist_unex.Add(tmp);
                        }

                        /*テンプレリスト(tmprlist_ex/tmprlist_unex)の初期化ここまで*/

                        //実際に書き込みを開始する
                        foreach (String name in data.Keys)//keyの分回す
                        {
                            strarr = "";
                            //0行目は曲以外のデータが格納されているので無視
                            if (i != 0) 
                            {
                                //歌詞があるかどうかを入れる
                                exist = data[name][4];

                                //一応リストを初期化
                                tmprlist.Clear();

                                //歌詞がある場合は曲紹介+歌詞テンプレを読み込んで書き込む
                                if (exist == "有")
                                {
                                    tmprlist = new List<String>(tmprlist_ex);
                                }
                                //歌詞がない場合、曲紹介だけ
                                else
                                {
                                    tmprlist = new List<String>(tmprlist_unex);
                                }

                                //置き換え(テンプレリストの分だけ回す)
                                foreach(String tmpr in tmprlist)
                                {
                                    //分割文字判定用変数を0にする
                                    judge = 0;

                                    //write部分を使いまわすために変数を揃える
                                    text = before + tmpr;

                                    if (tmpr.Contains("$"))//もし分割文字があると
                                    {
                                        //分割文字判定用変数を1にする
                                        judge = 1;
                                        //Listに格納
                                        tmpstr = text.Split('$').ToList();
                                        //初期化
                                        strarr = "";

                                        /*
                                         * 歌詞とコメントの時は空欄を予め保存して
                                         * すべての行について付けないと段がおかしくなる
                                         */
                                        if (text.Contains("@コメント") || text.Contains("@歌詞"))
                                        {
                                            space = BeforeSpace(text);
                                        }
                                        else
                                        {
                                            space = "";
                                        }

                                        //tmpstr(list)の中に書き換え文字があるかを検索
                                        for (var j = 0; j < tmpstr.Count; j++)
                                        {
                                            //書き換え文字があると書き換える
                                            if (Stringfirst(tmpstr[j]) == "@")
                                            {
                                                //文字列の整形(空白を消す)
                                                tmp = EraceSpace(tmpstr[j]);

                                                //書き換え
                                                tmp = JudgeToken(data, tmp, name,space);

                                                //この書き換え後の文字列が空か判定(つまり入力してるか)
                                                erace = JudgeErace(tmp);
                                                strarr += tmp;
                                            }
                                            else//書き換え文字がない場合はそのまま結合
                                            {
                                                //書き換え文字をexcelのデータに置き換えて結合
                                                //共通部分をリストに追加
                                                strarr += tmpstr[j];
                                            }
                                        }
                                    }

                                    //分割してたら結合したものを記述
                                    if (judge == 1) { text = strarr; }

                                    //ファイルに書き込み
                                    if (erace == 0)
                                    {
                                        Savehtml(text, element, @savepath);
                                    }

                                }       
                            }
                            //一回目のときは消してOK(1行目は$@曲紹介$だから)
                            else 
                            {
                                //一回目のときは消しておけ
                                erace = 1;
                                //前のスペースを保存する
                                before = BeforeSpace(text);
                            }
                            i++;
                        }
                    }
                    //それ以外のとき
                    else
                    {
                        //置き換え
                        if (text.Contains("$"))//もし分割文字があると
                        {
                            //分割文字判定用変数を1にする
                            judge = 1;
                            //Listに格納
                            tmpstr = text.Split('$').ToList();
                            //listに格納できたら一応初期化を行う。(変数を使い回すため)
                            text = "";

                            //tmpstr(list)の中に書き換え文字があるかを検索
                            for (var i = 0; i < tmpstr.Count; i++)
                            {
                                //書き換え文字があると書き換える
                                if (Stringfirst(tmpstr[i]) == "@")
                                {
                                    //文字列の整形(空白を消す)
                                    tmp = EraceSpace(tmpstr[i]);

                                    //書き換え
                                    tmp = JudgeToken(data, tmp, "Other_Data");

                                    //この書き換え後の文字列が空か判定(つまり入力してるか)
                                    erace = JudgeErace(tmp);
                                    strarr += tmp;
                                }
                                else//書き換え文字がない場合はそのまま結合
                                {
                                    //書き換え文字をexcelのデータに置き換えて結合
                                    //共通部分をリストに追加
                                    strarr += tmpstr[i];
                                }
                            }
                        }

                        //コードを記録
                        //ファイルに書き込み

                        //分割してたら結合したものを記述
                        if (judge == 1) { text = strarr; }

                        //ファイルに書き込み
                        if (erace == 0)
                        {
                            Savehtml(text, element, @savepath);
                        }
                    }
                }
                //コード中の曲テンプレを保存するモード
                else if (mode == 1)
                {
                    //コメントアウト文がない場合はテンプレを保存する
                    if(!(text.Contains("<!--") || text.Contains("-->")))
                    {
                        //テンプレの保存
                        musiclist.Add(text);
                    }

                    //テンプレが終わったらモードを戻す
                    if (text.Contains("以上"))
                    {mode = 0;}
                }
                //コード中の歌詞テンプレを保存するモード
                else if (mode == 2)
                {
                    //コメントアウト文がない場合はテンプレを保存する
                    if (!(text.Contains("<!--") || text.Contains("-->")))
                    {
                        //テンプレの保存
                        lyricslist.Add(text);
                    }

                    //テンプレが終わったらモードを戻す
                    if (text.Contains("以上")) 
                    { mode = 0; }
                }

                count++;
            }

            sr.Close();
        }

        //トークンの識別と置き換え(WriteHtml関数でのみ参照)
        public override String JudgeToken(Dictionary<String, List<string>> data, String token, String name , String space="")
        {
            String personal = "error";
            //他のデータの時と曲紹介の時で分ける

            switch (token)
            {

                //他のデータの時(name = Other_Data)
                case "@アルバム名":
                    personal = data[name][0];
                    break;

                case "@album":
                    personal = data[name][1];
                    break;

                case "@ひとこと":
                    personal = data[name][2];
                    break;

                case "@書いた人":
                    personal = data[name][3];
                    break;

                case "@Youtube":
                    personal = data[name][4];
                    break;

                case "@bandcamp":
                    personal = data[name][5];
                    break;

                //曲紹介のとき
                case "@meigi":
                    personal = name;
                    break;

                case "@曲順":
                    personal = data[name][0];
                    break;

                case "@名義":
                    personal = data[name][1];
                    break;

                case "@曲名":
                    personal = data[name][2];
                    break;

                /*コメントはファイル名からデコードした中身が入る*/
                case "@コメント":
                    personal = Decode_text(data[name][3],"Comment",space);
                    break;

                /*歌詞はファイル名からデコードした中身が入る*/
                case "@歌詞":
                    personal = Decode_text(data[name][5], "Lyrics", space);
                    break;

                default:
                    personal = "error";
                    break;
            }


            return personal;
        }

        /*テキストファイルから中身を読み出す関数(歌詞とコメントで使用)*/
        private String Decode_text(String text,String folderpass,String space="")
        {
            //現在のパスを取得
            String nowpath = Application.StartupPath;
            //歌詞(コメント)が入ってるファイルのパスを取得
            //デバッグ用
            //String path = @Path.Combine(nowpath, folderpass);
            String path = @Path.Combine(nowpath, "Files\\" + folderpass);
            path = @Path.Combine(path, EraceSpace(text));
            //歌詞(コメント)を入れる変数
            String word = "";

            //そのファイルが存在する場合
            if (File.Exists(path) == true)
            {
                //textファイルを開く
                StreamReader ly = new StreamReader(path, Encoding.GetEncoding("UTF-8"));

                var i = 1;
                //文章がなくなるまでループ
                while (ly.Peek() != -1)
                {
                    //1行目は空欄が必要ない
                    if (i != 1)
                    {
                        /*Tab5回*/
                        word += space;
                    }

                    word += ly.ReadLine() + "<br>\n";
                    i++;
                }

            }
            //そのファイルが存在しない場合
            else
            {
                //デフォルトを返す
                word = "なし";
            }
            
            return word;

        }

        /*music_boxにlyric_boxを内包させる*/
        private List<string> CombineText(List<string> musiclist, List<string> lyricslist)
        {
            //一時保存用のlist
            List<string> tmplist = new List<string>();
            String before = "";
            String after = "";
            List<string> result = new List<string>();

            //リストの部分が無くなるまで回す
            foreach (string music in musiclist)
            {
                //歌詞テンプレのところに入れる
                if (music.Contains("$@歌詞テンプレート$"))
                {
                    //music行の置き換え文字の前と後の空欄(文字)を出力する
                    before = BeforeSpace(music,"@歌詞テンプレート");
                    after = AfterSpace(music,"@歌詞テンプレート");

                    //再度初期化
                    int i = 0; 
                    //歌詞リストの分だけ回す
                    foreach(String text in lyricslist)
                    {
                        String str = text;
                        //実際に音楽テンプレートに歌詞テンプレートを組み合わせる
                        //最後の時だけ末尾を加える
                        if(i == lyricslist.Count - 1) { str = text + after; }
                        //出力リストに保存
                        result.Add(before + str);
                        //カウンターを足す
                        i++;
                    }
                }
                else
                {
                    //リストに保存する
                    result.Add(music);
                }
            }

            return result;
        }

        //その行の空欄を出力する関数
        public String BeforeSpace(String text,String key= "@")
        {
            //一時保存用リスト
            List<String> tmplist = new List<String>();
            //スペースを保存するリスト
            String space = "";
            int count = -1;

            //分割文字があったら
            if (text.Contains("$"))
            {
                //切ったものを入れる
                tmplist = text.Split('$').ToList();

                //初期化
                int i = 0;
                //歌詞テンプレから変更するところ以外を保存する
                foreach (string tmp in tmplist)
                {
                    if (tmp.Contains(key))
                    {
                        count = i;
                    }
                    else if (!tmp.Contains(key) && count == -1)
                    {
                        //書き換え文字より前の空欄を保存
                        space += tmp;
                    }
                    i++;
                }
            }

            return space;
        }

        //その行の文字のあとの空欄(文字)を出力する関数
        public String AfterSpace(String text ,String key = "@")
        {
            //一時保存用リスト
            List<String> tmplist = new List<String>();
            //スペースを保存するリスト
            String space = "";
            int count = -1;

            //分割文字があったら
            if (text.Contains("$"))
            {
                //切ったものを入れる
                tmplist = text.Split('$').ToList();

                //リストの分回す
                foreach (String tmp in tmplist)
                {
                    //初期化
                    int i = 0;
                    //歌詞テンプレから変更するところ以外を保存する
                    if (tmp.Contains(key))
                    {
                        count = i;
                    }
                    else if (!tmp.Contains(key) && count != -1)
                    {
                        //書き換え文字より後の空欄(文字列)を保存
                        space += tmp;
                    }
                    i++;
                }
            }

            return space;
        }

    }
}
