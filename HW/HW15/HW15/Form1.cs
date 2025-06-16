using System.Collections.Generic;

namespace HW15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string>[] table = new List<string>[13];
        List<int> list = new List<int>();
        TextBox[] arr = new TextBox[13];
        private void Form1_Load(object sender, EventArgs e)
        {
            table[0] = new List<string>();
            table[1] = new List<string>();
            table[2] = new List<string>();
            table[3] = new List<string>();
            table[4] = new List<string>();
            table[5] = new List<string>();
            table[6] = new List<string>();
            table[7] = new List<string>();
            table[8] = new List<string>();
            table[9] = new List<string>();
            table[10] = new List<string>();
            table[11] = new List<string>();
            table[12] = new List<string>();
            arr[0] = textBox4;
            arr[1] = textBox5;
            arr[2] = textBox6;
            arr[3] = textBox7;
            arr[4] = textBox8;
            arr[5] = textBox9;
            arr[6] = textBox10;
            arr[7] = textBox11;
            arr[8] = textBox12;
            arr[9] = textBox13;
            arr[10] = textBox14;
            arr[11] = textBox15;
            arr[12] = textBox16;
        }
        // 搜尋授權碼，並回傳相關參數
        public void searchHash(string str, out string fold, out int total, out bool found)
        {
            fold = "";
            total = 0;
            found = false;

            //fold
            for (int i = 0; i < str.Length; i += 6)
            {
                for (int j = i; j < Math.Min(i + 3, str.Length); j++)
                {
                    fold += str[j];
                }
                for (int j = Math.Min(i + 6, str.Length) - 1; j >= i + 3; j--)
                {
                    fold += str[j];
                }
            }

            //total
            for (int i = 0; i < fold.Length / 3; i++)
            {
                total += Convert.ToInt32(fold.Substring(i * 3, 3));
            }
            if(fold.Length % 3 != 0)
                total += Convert.ToInt32(fold.Substring(fold.Length / 3 * 3));

            //found
            for (int i = 0; i < table[total % 13].Count; i++)
            {
                if (table[total % 13][i] == str)
                {
                    found = true;
                    break;
                }
            }
        }
        // 顯示 Hash 內容
        public void printHash()
        {
            int i, j;
            for (i = 0; i < 13; i++)
                arr[i].Text = "";
            for (i = 0; i < 13; i++)
                for (j = 0; j < table[i].Count; j++)
                    arr[i].Text = arr[i].Text + " -> " + table[i][j];
        }
        // 按下"加入授權碼"按鈕
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                string fold;
                int total;
                bool found;
                searchHash(str, out fold, out total, out found);
                textBox2.Text = fold;
                textBox3.Text = total + " % 13 = " + total % 13;
                if (found)
                    throw new Exception("授權碼" + str + "重複");
                else
                    table[total % 13].Add(str);
                printHash();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "新增失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 按下"刪除授權碼"按鈕
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                string fold;
                int total;
                bool found;
                searchHash(str, out fold, out total, out found);
                textBox2.Text = fold;
                textBox3.Text = total + " % 13 = " + total % 13;
                if (found)
                    table[total % 13].Remove(str);
                else
                    throw new Exception("授權碼" + str + "不存在");
                printHash();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "刪除失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 按下"查詢授權碼"按鈕
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                string fold;
                int total;
                bool found;
                searchHash(str, out fold, out total, out found);
                textBox2.Text = fold;
                textBox3.Text = total + " % 13 = " + total % 13;
                if (found)
                    throw new Exception("授權碼" + str + "正確");
                else
                    throw new Exception("授權碼" + str + "不存在");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "查詢授權碼", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
