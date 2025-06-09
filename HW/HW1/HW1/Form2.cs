using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // 開啟 Form2 時設定
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "" +
                "1. 上課認真聽\r\n" +
                "2. 作業認真寫\r\n" +
                "3. 晚上認真睡\r\n" +
                "4. 一天一程式，Fail遠離我";
        }

        public Form1 preForm;

        // 按鈕 "下一步"
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.preForm = this;
            f.Show();
            this.Hide();
        }

        // 按鈕 "回上一步"
        private void button2_Click(object sender, EventArgs e)
        {
            this.preForm.Show();
            this.Close();
        }

        // 按鈕 "結束"
        private void button3_Click(object sender, EventArgs e)
        {
            this.preForm.Close();
            this.Close();
        }

        // 將按鈕 "下一步" 啟用
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
        }
    }
}
