using NUnit.Framework;
using auto_member_detail;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace NunitTest
{

    //�t�H�[���̒��g�̊֐����e�X�g����
    [TestFixture]
    public class FormTest
    {
        //�t�H�[���̃N���X��ݒ�
        Form1 form1 = new Form1();
        //�p�X
        static String dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static String testpass = @Path.Combine(dir, "Test.xlsx");

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Form1�C���X�^���X�̃e�X�g�J�n\n");
            TestContext.WriteLine(dir);
        }

        /*���̐�΃p�X�͕ۑ����ύX���Ă�������
         * (���݂��Ȃ��p�X�̎���system�t�H���_�ɍ���Ă��܂��̂ŃG���[���o���Ǝv���܂�)*/
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Save")]//�������Ƃ�
        /*[TestCase(@"C:\Users\aoto0\Test.xlsx")]//����Ă���Ƃ�*/
        public void ConfirmFolder_Test(String @foldername)
        {
            String folder_exist = form1.ConfirmFolder(@foldername);

            if (!Directory.Exists(@foldername))//�����L���ȃt�H���_�ł͂Ȃ��Ȃ�
            {
                Assert.AreNotEqual(@foldername, @folder_exist);
            }
            else//�����L���ȃt�H���_�Ȃ炻�̂܂�
            {
                Assert.AreEqual(@foldername, @folder_exist);
            }
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Form1�C���X�^���X�̃e�X�g�I��");
        }
    }

    //Operte�N���X�̊֐����e�X�g����
    [TestFixture]
    public class OperateTest
    {
        //Operate�̃C���X�^���X��ݒ�
        Operate operate = new Operate();

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Operate�C���X�^���X�̃e�X�g�J�n");
        }

        /*���̐�΃p�X�̓e�X�g���ƂɕύX���Ă�������*/
        [TestCase(@"C:\Users\aoto0\Test.xlsx",2,2)]//�����ȏꍇ
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test.xlsx", 2, 2)]//�L���ȏꍇ
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test.xlsx ", 2, 2)]//�L���ȏꍇ(�X�y�[�X����)
        [TestCase(@"�@C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test.xlsx", 2, 2)]//�L���ȏꍇ(�X�y�[�X����)
        //Operate_SetfromExcel�֐��̃e�X�g
        public void SetExcel_Test(String filename,int start,int end)
        {
            //�����^�ϐ����`
            Dictionary<String, List<string>> personal_dic = new Dictionary<String, List<string>>(
                                                                operate.Operate_SetfromExcel(@filename,start,end)
                                                            );

            //�����^�ϐ����󂩂ǂ����𔻒�
            Boolean bl = SS.IsEmpty(personal_dic);

            //��̂͂�
            Assert.True(bl);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Test")]
        //JudgeErace�֐��̃e�X�g
        public void JudgeErace_Test(String str)
        {
            int num = operate.JudgeErace(str);

            //��null�Ȃ����
            if (String.IsNullOrEmpty(str))
            {
                Assert.AreEqual(1, num);
            }
            else//��������Ȃ��Ȃ炻�̂܂�
            {
                Assert.AreEqual(0, num);
            }
        }

        [Test]
        //EraceSpace�֐��̃e�X�g
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
        //JudgeToken�֐��̃e�X�g
        public void JudgeToken_Test()
        {
            //�֋X�I�ɕK�v�ȃe�X�g
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
        //Stringfirst�֐��̃e�X�g
        public void Stringfirst_Test(String str)
        {
            String text = operate.Stringfirst(str);
            //�� or null�Ȃ�"%"
            if (String.IsNullOrEmpty(operate.EraceSpace(str)))
            {
                Assert.AreEqual(text, "%");
            }
            else//����ȊO�Ȃ�@
            {
                Assert.AreEqual(text, "@");
            }
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Operate�C���X�^���X�̃e�X�g�I��");
        }
    }

    //MemberOperte�N���X�̊֐����e�X�g����
    [TestFixture]
    public class MemberTest
    {
        //Member_Operate�̃C���X�^���X��ݒ�
        Member_Operate member = new Member_Operate();

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Member_Operate�C���X�^���X�̃e�X�g�J�n");
        }

        /*���̐�΃p�X�̓e�X�g���ƂɕύX���Ă�������*/
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx", 2, 2)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx", 1, 2)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx", 2, 1)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx", 1, 1)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx ", 2, 2)]//�L���ȏꍇ(�X�y�[�X����)
        [TestCase(@"�@C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test1.xlsx", 2, 2)]//�L���ȏꍇ(�X�y�[�X����)
        //Operate_SetfromExcel�֐��̃e�X�g
        public void SetExcel_Test(String pass,int start,int end)
        {
            //�����^�ϐ����`
            //�����ȏꍇ(�K���G���[���o��̂Ń_��)
            /*Dictionary<String, List<string>> personal_dic1 = new Dictionary<String, List<string>>(
                                                                member.Operate_SetfromExcel(@"C:\Users\aoto0\Test.xlsx",2,2)
                                                            );*/
            //�L���ȏꍇ
            Dictionary<String, List<string>> personal_dic1 = new Dictionary<String, List<string>>(
                                                                member.Operate_SetfromExcel(@pass,start,end)
                                                            );

            Boolean bl1 = SS.IsEmpty(personal_dic1);

            //�󂶂�Ȃ�
            Assert.False(bl1);
            Assert.AreEqual("��", personal_dic1["kusuriya"][0]);
            Assert.AreEqual("�������", personal_dic1["kusuriya"][1]);
            Assert.AreEqual("�s�A�m", personal_dic1["kusuriya"][2]);
            Assert.AreEqual("�g�����y�b�g", personal_dic1["kusuriya"][3]);
            Assert.AreEqual("�V���Z�T�C�U�[", personal_dic1["kusuriya"][4]);
            Assert.AreEqual("�g�����{�[��", personal_dic1["kusuriya"][5]);
            Assert.AreEqual("�}�����o", personal_dic1["kusuriya"][6]);
            Assert.AreEqual("YOASOBI", personal_dic1["kusuriya"][7]); 
            Assert.AreEqual("�������̂�����", personal_dic1["kusuriya"][8]);
            Assert.AreEqual("�R�u�N��", personal_dic1["kusuriya"][9]);
            Assert.AreEqual("Official�E�jdism", personal_dic1["kusuriya"][10]); 
            Assert.AreEqual("Caravan Palace", personal_dic1["kusuriya"][11]);
            Assert.AreEqual("��ɂ�����", personal_dic1["kusuriya"][12]);
            Assert.AreEqual("�C�܂��ꃍ�}���e�B�b�N", personal_dic1["kusuriya"][13]);
            Assert.AreEqual("blue bird", personal_dic1["kusuriya"][14]);
            Assert.AreEqual("�~�b�N�X�i�b�c", personal_dic1["kusuriya"][15]);
            Assert.AreEqual("Lone digger", personal_dic1["kusuriya"][16]);
            Assert.AreEqual("twitter1", personal_dic1["kusuriya"][17]);
            Assert.AreEqual("sound1", personal_dic1["kusuriya"][18]);
            Assert.AreEqual("", personal_dic1["kusuriya"][19]);
            Assert.AreEqual("", personal_dic1["kusuriya"][20]);
            Assert.AreEqual("�e�X�g", personal_dic1["kusuriya"][21]);
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Member_Operate�C���X�^���X�̃e�X�g�I��");
        }
    }

    //AlbumOperte�N���X�̊֐����e�X�g����
    [TestFixture]
    public class AlbumTest
    {
        //Album_Operate�̃C���X�^���X��ݒ�
        Album_Operate album = new Album_Operate();

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Album_Operate�C���X�^���X�̃e�X�g�J�n");
        }

        /*���̐�΃p�X�̓e�X�g���ƂɕύX���Ă�������*/
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx", 2, 6)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx", 1, 6)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx", 2, 1)]
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx", 1, 1)]
        [TestCase(@"�@C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx", 2, 6)]//�X�y�[�X����(�S�p)
        [TestCase(@"C:\Users\aoto0\Desktop\otomi_app-ver2.1\Test_file\Test2.xlsx ", 2, 6)]//�X�y�[�X����(���p)
        //Operate_SetfromExcel�֐��̃e�X�g
        public void SetExcel_Test(String pass, int start, int end)
        {
            //�����^�ϐ����`
            //�����ȏꍇ(�K���G���[���o��̂Ń_��)
            /*Dictionary<String, List<string>> personal_dic1 = new Dictionary<String, List<string>>(
                                                                member.Operate_SetfromExcel(@"C:\Users\aoto0\Test.xlsx",2,2)
                                                            );*/
            //�L���ȏꍇ
            Dictionary<String, List<string>> personal_dic1 = new Dictionary<String, List<string>>(
                                                                album.Operate_SetfromExcel(@pass, start, end)
                                                            );

            Boolean bl1 = SS.IsEmpty(personal_dic1);

            //�󂶂�Ȃ�
            Assert.False(bl1);
            //�A���o���f�[�^
            Assert.AreEqual("Autumn Collection", personal_dic1["Other_Data"][0]);
            Assert.AreEqual("combi", personal_dic1["Other_Data"][1]);
            Assert.AreEqual("�H�̖K��A���D�̔O", personal_dic1["Other_Data"][2]);
            Assert.AreEqual("��", personal_dic1["Other_Data"][3]);
            Assert.AreEqual("youtube", personal_dic1["Other_Data"][4]);
            Assert.AreEqual("bandcomp", personal_dic1["Other_Data"][5]);

            //�Ȃ̃f�[�^
            Assert.AreEqual("01", personal_dic1["kusuriya"][0]);
            Assert.AreEqual("��", personal_dic1["kusuriya"][1]);
            Assert.AreEqual("�����f�B�[", personal_dic1["kusuriya"][2]);
            Assert.AreEqual("melody_comment.txt", personal_dic1["kusuriya"][3]);
            Assert.AreEqual("�L", personal_dic1["kusuriya"][4]);
            Assert.AreEqual("lyrics.txt", personal_dic1["kusuriya"][5]);
        }

        //BeforeSapce�֐��̃e�X�g
        [Test]
        public void BeforeSpace_Test()
        {
            String str1 = "test";
            String str2 = "test$@���`$";
            String str3 = "$@���`$test";
            String str4 = " ";

            Assert.AreEqual(album.BeforeSpace(str1), "");
            Assert.AreEqual(album.BeforeSpace(str2), "test");
            Assert.AreEqual(album.BeforeSpace(str3), "");
            Assert.AreEqual(album.BeforeSpace(str4), "");
        }

        //AfterSapce�֐��̃e�X�g
        [Test]
        public void AfterSpace_Test()
        {
            String str1 = "test";
            String str2 = "test$@���`$";
            String str3 = "$@���`$test";
            String str4 = " ";

            Assert.AreEqual(album.AfterSpace(str1), "");
            Assert.AreEqual(album.AfterSpace(str2), "");
            Assert.AreEqual(album.AfterSpace(str3), "test");
            Assert.AreEqual(album.AfterSpace(str4), "");
        }

        [TearDown]
        public void TearDown()
        {
            TestContext.WriteLine("Album_Operate�C���X�^���X�̃e�X�g�I��");
        }
    }

    //Memory�N���X�̊֐����e�X�g����
    [TestFixture]
    public class MemoryTest
    {
        //Memory�̃C���X�^���X��ݒ�
        Memory memory = new Memory();

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Memory�C���X�^���X�̃e�X�g�J�n");
        }

        
        [TestCase("excel1","html1",1,2,"save1","�����o�[�ڍ׃y�[�W")]
        [TestCase("excel2", "html2",2,4, "save2", "�A���o���ڍ׃y�[�W")]
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
            TestContext.WriteLine("Memory�C���X�^���X�̃e�X�g�I��");
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