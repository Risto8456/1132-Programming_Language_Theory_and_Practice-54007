namespace HW1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ���s "�U�@�B"
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.preForm = this;
            f.Show();
            this.Hide();
        }

        // ���s "����"
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ��� "�K�X�T�{"
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            textBox3.Visible = true;
        }

        // �N���s "�U�@�B" �ҥ�
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox2.Text == textBox3.Text;
        }
    }
}
