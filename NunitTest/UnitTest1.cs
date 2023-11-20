using NUnit.Framework;
using auto_member_detail;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace NunitTest
{

    //フォームの中身の関数をテストする
    [TestFixture]
    public class FormTest
    {
        //フォームのクラスを設定
        Form1 form1 = new Form1();
        //パス
        static String dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static String testpass = @Path.Combine(dir, "Test.xlsx");

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Form1インスタンスのテスト開始\n");
            TestContext.WriteLine(dir);
        }

        /*この絶対パスは保存先を変更してください
         * (実在しないパスの時はsystemフォルダに作ってしまうのでエラーを出すと思います)*/
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Save")]//正しいとき
        /*[TestCase(@"C:\Users\aoto0\Test.xlsx")]//誤っているとき*/
        public void ConfirmFolder_Test(String @foldername)
        {
            String folder_exist = form1.ConfirmFolder(@foldername);

            if (!Directory.Exists(@foldername))//もし有効なフォルダではないなら
            {
                Assert.AreNotEqual(@foldername, @folder_exist);
            }
            else//もし有効なフォルダならそのまま
            {
                Assert.AreEqual(@foldername, @folder_exist);
            }
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Form1インスタンスのテスト終了");
        }
    }

    //Operteクラスの関数をテストする
    [TestFixture]
    public class OperateTest
    {
        //Operateのインスタンスを設定
        Operate operate = new Operate();

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Operateインスタンスのテスト開始");
        }

        /*この絶対パスはテストごとに変更してください*/
        [TestCase(@"C:\Users\aoto0\Test.xlsx",2,2)]//無効な場合
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test.xlsx", 2, 2)]//有効な場合
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test.xlsx ", 2, 2)]//有効な場合(スペースあり)
        [TestCase(@"　C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test.xlsx", 2, 2)]//有効な場合(スペースあり)
        //Operate_SetfromExcel関数のテスト
        public void SetExcel_Test(String filename,int start,int end)
        {
            //辞書型変数を定義
            Dictionary<String, List<string>> personal_dic = new Dictionary<String, List<string>>(
                                                                operate.Operate_SetfromExcel(@filename,start,end)
                                                            );

            //辞書型変数が空かどうかを判定
            Boolean bl = SS.IsEmpty(personal_dic);

            //空のはず
            Assert.True(bl);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Test")]
        //JudgeErace関数のテスト
        public void JudgeErace_Test(String str)
        {
            int num = operate.JudgeErace(str);

            //空かnullなら消す
            if (String.IsNullOrEmpty(str))
            {
                Assert.AreEqual(1, num);
            }
            else//そうじゃないならそのまま
            {
                Assert.AreEqual(0, num);
            }
        }

        [Test]
        //EraceSpace関数のテスト
        public void EraceSpace_Test()
        {
            String str1 = "";
            String str2 = " ";
            String str3 = "te st";
            String str4 = "test";
            String str5 = null;


            Assert.AreEqual(operate.EraceSpace(str1), "");
            Assert.AreEqual(operate.EraceSpace(str2), "");
            Assert.AreEqual(operate.EraceSpace(str3), "test");
            Assert.AreEqual(operate.EraceSpace(str4), "test");
            Assert.AreEqual(operate.EraceSpace(str5), null);
            Assert.Null(operate.EraceSpace(str5));
        }

        [Test]
        //JudgeToken関数のテスト
        public void JudgeToken_Test()
        {
            //便宜的に必要なテスト
            Dictionary<String, List<string>> data = new Dictionary<String, List<string>>();
            String token="";
            String name="";

            String value1 = operate.JudgeToken(data,token,name);
            String value2 = operate.JudgeToken(data, token, name,"");
            String value3 = operate.JudgeToken(data, token, name," ");

            Assert.AreEqual(value1, "error");
            Assert.AreEqual(value2, "error");
            Assert.AreEqual(value3, "error");
        }

        [TestCase("@test")]
        [TestCase("@te st")]
        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]
        //Stringfirst関数のテスト
        public void Stringfirst_Test(String str)
        {
            String text = operate.Stringfirst(str);
            //空 or nullなら"%"
            if (String.IsNullOrEmpty(operate.EraceSpace(str)))
            {
                Assert.AreEqual(text, "%");
            }
            else//それ以外なら@
            {
                Assert.AreEqual(text, "@");
            }
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Operateインスタンスのテスト終了");
        }
    }

    //MemberOperteクラスの関数をテストする
    [TestFixture]
    public class MemberTest
    {
        //Member_Operateのインスタンスを設定
        Member_Operate member = new Member_Operate();

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Member_Operateインスタンスのテスト開始");
        }

        /*この絶対パスはテストごとに変更してください*/
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx", 2, 2)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx", 1, 2)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx", 2, 1)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx", 1, 1)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx ", 2, 2)]//有効な場合(スペースあり)
        [TestCase(@"　C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx", 2, 2)]//有効な場合(スペースあり)
        //Operate_SetfromExcel関数のテスト
        public void SetExcel_Test(String pass,int start,int end)
        {
            //辞書型変数を定義
            //無効な場合(必ずエラーが出るのでダメ)
            /*Dictionary<String, List<string>> personal_dic1 = new Dictionary<String, List<string>>(
                                                                member.Operate_SetfromExcel(@"C:\Users\aoto0\Test.xlsx",2,2)
                                                            );*/
            //有効な場合
            Dictionary<String, List<string>> personal_dic1 = new Dictionary<String, List<string>>(
                                                                member.Operate_SetfromExcel(@pass,start,end)
                                                            );

            Boolean bl1 = SS.IsEmpty(personal_dic1);

            //空じゃない
            Assert.False(bl1);
            Assert.AreEqual("薬屋", personal_dic1["kusuriya"][0]);
            Assert.AreEqual("すたわん", personal_dic1["kusuriya"][1]);
            Assert.AreEqual("ピアノ", personal_dic1["kusuriya"][2]);
            Assert.AreEqual("トランペット", personal_dic1["kusuriya"][3]);
            Assert.AreEqual("シンセサイザー", personal_dic1["kusuriya"][4]);
            Assert.AreEqual("トロンボーン", personal_dic1["kusuriya"][5]);
            Assert.AreEqual("マリンバ", personal_dic1["kusuriya"][6]);
            Assert.AreEqual("YOASOBI", personal_dic1["kusuriya"][7]); 
            Assert.AreEqual("いきものがかり", personal_dic1["kusuriya"][8]);
            Assert.AreEqual("コブクロ", personal_dic1["kusuriya"][9]);
            Assert.AreEqual("Official髭男dism", personal_dic1["kusuriya"][10]); 
            Assert.AreEqual("Caravan Palace", personal_dic1["kusuriya"][11]);
            Assert.AreEqual("夜にかける", personal_dic1["kusuriya"][12]);
            Assert.AreEqual("気まぐれロマンティック", personal_dic1["kusuriya"][13]);
            Assert.AreEqual("blue bird", personal_dic1["kusuriya"][14]);
            Assert.AreEqual("ミックスナッツ", personal_dic1["kusuriya"][15]);
            Assert.AreEqual("Lone digger", personal_dic1["kusuriya"][16]);
            Assert.AreEqual("twitter1", personal_dic1["kusuriya"][17]);
            Assert.AreEqual("sound1", personal_dic1["kusuriya"][18]);
            Assert.AreEqual("", personal_dic1["kusuriya"][19]);
            Assert.AreEqual("", personal_dic1["kusuriya"][20]);
            Assert.AreEqual("テスト", personal_dic1["kusuriya"][21]);
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Member_Operateインスタンスのテスト終了");
        }
    }

    //AlbumOperteクラスの関数をテストする
    [TestFixture]
    public class AlbumTest
    {
        //Album_Operateのインスタンスを設定
        Album_Operate album = new Album_Operate();

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Album_Operateインスタンスのテスト開始");
        }

        /*この絶対パスはテストごとに変更してください*/
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx", 2, 6)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx", 1, 6)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx", 2, 1)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx", 1, 1)]
        [TestCase(@"　C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx", 2, 6)]//スペースあり(全角)
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx ", 2, 6)]//スペースあり(半角)
        //Operate_SetfromExcel関数のテスト
        public void SetExcel_Test(String pass, int start, int end)
        {
            //辞書型変数を定義
            //無効な場合(必ずエラーが出るのでダメ)
            /*Dictionary<String, List<string>> personal_dic1 = new Dictionary<String, List<string>>(
                                                                member.Operate_SetfromExcel(@"C:\Users\aoto0\Test.xlsx",2,2)
                                                            );*/
            //有効な場合
            Dictionary<String, List<string>> personal_dic1 = new Dictionary<String, List<string>>(
                                                                album.Operate_SetfromExcel(@pass, start, end)
                                                            );

            Boolean bl1 = SS.IsEmpty(personal_dic1);

            //空じゃない
            Assert.False(bl1);
            //アルバムデータ
            Assert.AreEqual("Autumn Collection", personal_dic1["Other_Data"][0]);
            Assert.AreEqual("combi", personal_dic1["Other_Data"][1]);
            Assert.AreEqual("秋の訪れ、郷愁の念", personal_dic1["Other_Data"][2]);
            Assert.AreEqual("薬屋", personal_dic1["Other_Data"][3]);
            Assert.AreEqual("youtube", personal_dic1["Other_Data"][4]);
            Assert.AreEqual("bandcomp", personal_dic1["Other_Data"][5]);

            //曲のデータ
            Assert.AreEqual("01", personal_dic1["kusuriya"][0]);
            Assert.AreEqual("薬屋", personal_dic1["kusuriya"][1]);
            Assert.AreEqual("メロディー", personal_dic1["kusuriya"][2]);
            Assert.AreEqual("melody_comment.txt", personal_dic1["kusuriya"][3]);
            Assert.AreEqual("有", personal_dic1["kusuriya"][4]);
            Assert.AreEqual("lyrics.txt", personal_dic1["kusuriya"][5]);
        }

        //BeforeSapce関数のテスト
        [Test]
        public void BeforeSpace_Test()
        {
            String str1 = "test";
            String str2 = "test$@名義$";
            String str3 = "$@名義$test";
            String str4 = " ";

            Assert.AreEqual(album.BeforeSpace(str1), "");
            Assert.AreEqual(album.BeforeSpace(str2), "test");
            Assert.AreEqual(album.BeforeSpace(str3), "");
            Assert.AreEqual(album.BeforeSpace(str4), "");
        }

        //AfterSapce関数のテスト
        [Test]
        public void AfterSpace_Test()
        {
            String str1 = "test";
            String str2 = "test$@名義$";
            String str3 = "$@名義$test";
            String str4 = " ";

            Assert.AreEqual(album.AfterSpace(str1), "");
            Assert.AreEqual(album.AfterSpace(str2), "");
            Assert.AreEqual(album.AfterSpace(str3), "test");
            Assert.AreEqual(album.AfterSpace(str4), "");
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Album_Operateインスタンスのテスト終了");
        }
    }

    //Memoryクラスの関数をテストする
    [TestFixture]
    public class MemoryTest
    {
        //Memoryのインスタンスを設定
        Memory memory = new Memory();

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Memoryインスタンスのテスト開始");
        }

        
        [TestCase("excel1","html1",1,2,"save1","メンバー詳細ページ")]
        [TestCase("excel2", "html2",2,4, "save2", "アルバム詳細ページ")]
        public void Memory_Test(String excel_pass, String html_pass,int startid,int endid, String savepass, String selectfile)//, String html_pass, int startid, int endid, String savepass, String selectfile
        {
            
            Memory mem1 = new Memory(excel_pass,html_pass,startid,endid,savepass,selectfile);
            Assert.AreEqual(excel_pass, mem1.Excel_pass);
            Assert.AreEqual(html_pass, mem1.Html_pass);
            Assert.AreEqual(startid, mem1.Startid);
            Assert.AreEqual(endid, mem1.Endid);
            Assert.AreEqual(savepass, mem1.Savepass);
            Assert.AreEqual(selectfile, mem1.Selectfile);
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Memoryインスタンスのテスト終了");
        }
    }

    [TestFixture]
    public class SSTest
    {
        [Test]
        public void IsEmpty_Test()
        {
            Dictionary<String, List<string>> emptyDic = new Dictionary<String, List<string>>();
            Dictionary<String, List<string>> nullDic = null;
            List<String> emptylist = new List<String>();
            List<String> nulllist = null;
            List<String> normallist = new List<String>() { "test1", "test2" };
            Dictionary<String, List<string>> normalDic = new Dictionary<String, List<string>>() { { "test", normallist}};

            // IsEmpty
            //list
            Assert.IsTrue(SS.IsEmpty(emptylist));
            Assert.IsTrue(SS.IsEmpty(nulllist));
            Assert.IsFalse(SS.IsEmpty(normallist));
            //Dic
            Assert.IsTrue(SS.IsEmpty(emptyDic));
            Assert.IsTrue(SS.IsEmpty(nullDic));
            Assert.IsFalse(SS.IsEmpty(normalDic));

            // IsNotEmpty
            //list
            Assert.IsFalse(SS.IsNotEmpty(emptylist));
            Assert.IsFalse(SS.IsNotEmpty(nulllist));
            Assert.IsTrue(SS.IsNotEmpty(normallist));
            //Dic
            Assert.IsFalse(SS.IsNotEmpty(emptyDic));
            Assert.IsFalse(SS.IsNotEmpty(nullDic));
            Assert.IsTrue(SS.IsNotEmpty(normalDic));

        }
    }
}