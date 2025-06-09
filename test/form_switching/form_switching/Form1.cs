namespace form_switching
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.DialogResult == DialogResult.OK)
                MessageBox.Show("你輸入了" + f2.getInput() + "!");
            if (f2.DialogResult == DialogResult.Cancel)
                MessageBox.Show("你按了取消鍵");
        }
    }
}
