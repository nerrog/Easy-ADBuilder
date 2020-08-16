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

            Task task = Task.Run(() => {
                ChkBox();
            });
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {

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
            }
            //コピー処理
            string sourcePath = $@"{(System.Environment.CurrentDirectory)}\platform-tools";
            string destinationPath = @"C:\adb";

        }
    }
}
