using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HW1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public Form2 preForm;

        // 按鈕 "回上一步"
        private void button1_Click(object sender, EventArgs e)
        {
            this.preForm.Show();
            this.Close();
        }

        // 按鈕 "結束"
        private void button2_Click(object sender, EventArgs e)
        {
            this.preForm.preForm.Close();
            this.preForm.Close();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            count_money();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            count_money();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            count_money();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            count_money();
        }


        // 將 "薯條" 區啟用
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                count_money();
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
        }

        // 將 "飲料" 區啟用
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
            }
            else
            {
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                count_money();
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
            }
        }

        private void count_money()
        {
            int sum = 0;
            sum += checkBox1.Checked ? 69 : 0;
            sum += checkBox2.Checked ? 49 : 0;
            sum += checkBox3.Checked ? 59 : 0;
            sum += checkBox4.Checked ? 79 : 0;
            sum += radioButton1.Checked ? 35 : 0;
            sum += radioButton2.Checked ? 25 : 0;
            sum += radioButton3.Checked ? 35 : 0;
            sum += radioButton4.Checked ? 25 : 0;
            sum += radioButton5.Checked ? 45 : 0;
            textBox1.Text = Convert.ToString(sum);
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            count_money();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            count_money();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            count_money();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            count_money();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            count_money();
        }
    }
}
