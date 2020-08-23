using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Easy_ADBuilder
{
    public partial class config : MetroForm
    {

        public config()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
        }

        private void config_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //TextBoxの値をテキストファイルに書き込む
            string conf = $@"{(System.Environment.CurrentDirectory)}\config";
            if (System.IO.File.Exists(conf))
            {
                File.Delete(conf);
            }
            else
            {
                ;
            }
            File.WriteAllText(conf, metroTextBox1.Text);
            this.Close();
        }
    }
}
