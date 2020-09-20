using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MetroFramework.Forms;


namespace Easy_ADBuilder
{
    public partial class Main : MetroForm
    {
        Thread thread;

        public Main()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
        }
        private void FileChk()
        {
            //ファイルチェック
            string homeP = $@"{(System.Environment.CurrentDirectory)}";
            if (Directory.Exists(homeP+ @"\platform-tools"))
            {
                //adb.exeとかのファイルがあったら次へ
                if (Directory.Exists(homeP+ @"\usb_driver"))
                {
                    //adb・ドライバ類の確認ができたら
                    ;
                }
                else
                {
                    MessageBox.Show("usb_driverフォルダがありません\r\nプログラムを終了します");
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("platform-toolsフォルダがありません\r\nプログラムを終了します");
                Application.Exit();
            }
        }
        private void  build()
        {
            //adb環境構築メソッド

            string sourcePath = $@"{(System.Environment.CurrentDirectory)}\platform-tools";
            string driverpath = $@"{(System.Environment.CurrentDirectory)}\usb_driver";
            
            string tmp;
            //configを確認
            string conf = $@"{(System.Environment.CurrentDirectory)}\config";
            if (System.IO.File.Exists(conf))
            {
                
                //configが存在すれば変数に代入する
                tmp = File.ReadAllText(conf);
            }
            else
            {
                tmp = @"C:\adb";
            }
            string destinationPath = tmp;

            try
            {
                File.Copy($@"{sourcePath}\adb.exe", $@"{destinationPath}\adb.exe", true);
                File.Copy($@"{sourcePath}\AdbWinApi.dll", $@"{destinationPath}\AdbWinApi.dll", true);
                File.Copy($@"{sourcePath}\AdbWinUsbApi.dll", $@"{destinationPath}\AdbWinUsbApi.dll", true);
                File.Copy($@"{sourcePath}\NOTICE.txt", $@"{destinationPath}\NOTICE.txt", true);
            }
            catch (IOException e)
            {
                MessageBox.Show("例外が発生しました\n\r"+e);
                Application.Exit();
            }

            System.Diagnostics.Process pro = new System.Diagnostics.Process();
            try
            {
                //Google USB Driverをインストール
                pro.StartInfo.FileName = @"C:\Windows\System32\rundll32.exe";
                pro.StartInfo.Arguments = $@"SETUPAPI.DLL,InstallHinfSection DefaultInstall 132 {driverpath}\android_winusb.inf";
                pro.StartInfo.CreateNoWindow = true;
                pro.StartInfo.UseShellExecute = false;
                pro.StartInfo.RedirectStandardOutput = true;
                pro.StartInfo.Verb = "RunAs";
                pro.Start();

                //環境変数pathへ追加
                pro.StartInfo.FileName = "setx";
                pro.StartInfo.Arguments = $"/M path \" % path %;{tmp}";
                pro.StartInfo.CreateNoWindow = true;
                pro.StartInfo.UseShellExecute = false;
                pro.StartInfo.RedirectStandardOutput = true;

                pro.Start();

            }
            catch (IOException e)
            {
                MessageBox.Show("例外が発生しました\n\r" + e);
                Application.Exit();
            }
            MessageBox.Show($"adb環境の構築が完了しました！","完了");
            thread.Abort();
            thread.Join();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(FileChk));
            thread.Start();
            var textFileContent = Properties.Resources.readme;
            trop.Text = textFileContent;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
            thread.Join();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //メイン処理開始
            thread.Abort();
            thread.Join();
            string tmp;
            //configを確認
            string conf = $@"{(System.Environment.CurrentDirectory)}\config";
            if (System.IO.File.Exists(conf))
            {

                //configが存在すれば変数に代入する
                tmp = File.ReadAllText(conf);
            }
            else
            {
                tmp = @"C:\adb";
            }
            //configが空だと例外が発生するのでここでチェック
            if (tmp == "")
            {
                tmp = @"C:\adb";
            }


            string path = tmp;
            if (Directory.Exists(path))
            {
                DialogResult result = MessageBox.Show("既にインストール先にディレクトリが存在します\r\nこのまま続行しますか？",
                "質問",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    thread = new Thread(new ThreadStart(build));
                    thread.Start();
                }
                else if (result == DialogResult.No)
                {
                   MessageBox.Show("いいえが選択されました\r\nプログラムを終了します");
                    Application.Exit();
                }
            }
            else
            {
                Directory.CreateDirectory(path);
                thread = new Thread(new ThreadStart(build));
                thread.Start();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://nerrog.net");
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            config config_F = new config();
            config_F.Show();
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {
                metroButton1.Enabled = true;
            }

            if (metroCheckBox1.Checked == false)
            {
                metroButton1.Enabled = false;
            }
        }
    }
}
