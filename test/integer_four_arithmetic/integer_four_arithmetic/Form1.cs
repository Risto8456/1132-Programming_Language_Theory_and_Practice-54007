namespace integer_four_arithmetic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(textBox1.Text);
                if (num1 < 0) throw new Exception("计ぃ璽计");
                int num2 = Convert.ToInt32(textBox2.Text);
                if (num2 < 0) throw new Exception("计ぃ璽计");
                textBox3.Text = num1 + " + " + num2 + " = " + (num1 + num2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "岿粇癟", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(textBox1.Text);
                if (num1 < 0) throw new Exception("计ぃ璽计");
                int num2 = Convert.ToInt32(textBox2.Text);
                if (num2 < 0) throw new Exception("计ぃ璽计");
                textBox3.Text = num1 + " - " + num2 + " = " + (num1 - num2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "岿粇癟", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(textBox1.Text);
                if (num1 < 0) throw new Exception("计ぃ璽计");
                int num2 = Convert.ToInt32(textBox2.Text);
                if (num2 < 0) throw new Exception("计ぃ璽计");
                textBox3.Text = num1 + " * " + num2 + " = " + (num1 * num2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "岿粇癟", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(textBox1.Text);
                if (num1 < 0) throw new Exception("计ぃ璽计");
                int num2 = Convert.ToInt32(textBox2.Text);
                if (num2 < 0) throw new Exception("计ぃ璽计");
                textBox3.Text = num1 + " / " + num2 + " = " + (num1 / num2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "岿粇癟", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
