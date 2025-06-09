namespace HW1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 按鈕 "下一步"
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.preForm = this;
            f.Show();
            this.Hide();
        }

        // 按鈕 "結束"
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 顯示 "密碼確認"
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            textBox3.Visible = true;
        }

        // 將按鈕 "下一步" 啟用
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox2.Text == textBox3.Text;
        }
    }
}
