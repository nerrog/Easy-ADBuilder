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
using MetroFramework.Forms;


namespace Easy_ADBuilder
{
    public partial class Main : MetroForm
    {
        Thread thread;

        public Main()
        {
            InitializeComponent();
        }
        private void  build()
        {
            //adb環境構築メソッド

            string sourcePath = $@"{(System.Environment.CurrentDirectory)}\platform-tools";
            string driverpath = $@"{(System.Environment.CurrentDirectory)}\usb_driver";
            string destinationPath = @"C:\adb";
            //ディレクトリごとコピーする方法がﾜｶﾗﾝ
            File.Copy($@"{sourcePath}\adb.exe", $@"{destinationPath}\adb.exe", true);
            File.Copy($@"{sourcePath}\AdbWinApi.dll", $@"{destinationPath}\AdbWinApi.dll", true);
            File.Copy($@"{sourcePath}\AdbWinUsbApi.dll", $@"{destinationPath}\AdbWinUsbApi.dll", true);
            File.Copy($@"{sourcePath}\NOTICE.txt", $@"{destinationPath}\NOTICE.txt", true);
            

            System.Diagnostics.Process pro = new System.Diagnostics.Process();

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
            pro.StartInfo.Arguments = "/M path \" % path %;C:\\adb\"";               
            pro.StartInfo.CreateNoWindow = true;            
            pro.StartInfo.UseShellExecute = false;          
            pro.StartInfo.RedirectStandardOutput = true;   

            pro.Start();

            string output = pro.StandardOutput.ReadToEnd();
            output.Replace("\r\r\n", "\n"); // 改行コード変換

            MessageBox.Show($"{output}\r\nadb環境の構築が完了しました！","完了");
            thread.Abort();
            thread.Join();
        }
        private void ChkBox()
        {
            //チェックボックス監視
            while (true)
            {
                if (metroCheckBox1.Checked == true)
                {
                    //metroButton1.Enabled = true;
                    this.Invoke((MethodInvoker)(() => metroButton1.Enabled = true));
                }

                if (metroCheckBox1.Checked == false)
                {
                    this.Invoke((MethodInvoker)(() => metroButton1.Enabled = false));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var textFileContent = Properties.Resources.readme;
            trop.Text = textFileContent;
            thread = new Thread(new ThreadStart(ChkBox));
            thread.Start();
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
            string path = @"C:\adb";
            if (Directory.Exists(path))
            {
                DialogResult result = MessageBox.Show("既にCドライブにadbフォルダが存在します\r\nこのまま続行しますか？",
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
    }
}
