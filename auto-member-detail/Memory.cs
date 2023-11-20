using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto_member_detail
{
    //コンストラクタ(保存用のコンストラクタ)
    public class Memory
    {
        //参照Excelのpass
        private String excel_pass;
        //参照するテンプレートHTMLファイル
        private String html_pass;
        //開始ID
        private int startid;
        //終了ID
        private int endid;
        //セーブするpass
        private String savepass;
        //出力するファイル
        private String selectfile;

        public Memory()
        {

        }

        //入力されたデータをもつインスタンス
        public Memory(String excel_pass, String html_pass, int startid, int endid, String savepass, String selectfile)
        {
            Excel_pass = excel_pass;
            Html_pass = html_pass;
            Startid = startid;
            Endid = endid;
            Savepass = savepass;
            Selectfile = selectfile;
        }

        //getter・setterの設定
        public String Excel_pass { set; get; }
        public String Html_pass { set; get; }
        public int Startid { set; get; }
        public int Endid { set; get; }
        public String Savepass { set; get; }
        public String Selectfile { set; get; }
    }
}
