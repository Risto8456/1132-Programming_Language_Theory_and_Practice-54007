namespace HW2
{
    public partial class Form1 : Form
    {
        double n1 = 0, n2 = 0;
        char op = ' ';
        bool num = true;
        bool point = false;
        bool pre = false;
        bool equ = false;
        public Form1()
        {
            InitializeComponent();
        }

        //歸零
        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            n1 = 0; n2 = 0;
            op = ' ';
            num = true;
            point = false;
            pre = false;
            equ = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (num == true || textBox1.Text == "0")
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text += "1";
            }
            num = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (num == true || textBox1.Text == "0")
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text += "2";
            }
            num = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (num == true || textBox1.Text == "0")
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text += "3";
            }
            num = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (num == true || textBox1.Text == "0")
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text += "4";
            }
            num = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (num == true || textBox1.Text == "0")
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text += "5";
            }
            num = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (num == true || textBox1.Text == "0")
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text += "6";
            }
            num = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (num == true || textBox1.Text == "0")
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text += "7";
            }
            num = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (num == true || textBox1.Text == "0")
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text += "8";
            }
            num = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (num == true || textBox1.Text == "0")
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text += "9";
            }
            num = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (num == true || textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text += "0";
            }
            num = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (num == true)
            {
                textBox1.Text = "0.";
            }
            else if (point == false)
            {
                textBox1.Text += ".";
            }
            point = true;
            num = false;
        }

        //運算
        private void Operation()
        {
            double result = 0;
            switch (op)
            {
                case '+':
                    result = n1 + n2;
                    break;
                case '-':
                    result = n1 - n2;
                    break;
                case '*':
                    result = n1 * n2;
                    break;
                case '/':
                    try
                    {
                        if (n2 == 0) throw new Exception("嘗試以零除");
                        result = n1 / n2;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            n1 = result;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (num == false)
            {
                if (pre == true)
                {
                    n2 = Convert.ToDouble(textBox1.Text);
                    Operation();
                }
                else
                {
                    n1 = Convert.ToDouble(textBox1.Text);
                }
            }
            op = '+';
            num = true;
            pre = true;
            point = false;
            equ = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (num == false)
            {
                if (pre == true)
                {
                    n2 = Convert.ToDouble(textBox1.Text);
                    Operation();
                }
                else
                {
                    n1 = Convert.ToDouble(textBox1.Text);
                }
            }
            op = '-';
            num = true;
            pre = true;
            point = false;
            equ = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (num == false)
            {
                if (pre == true)
                {
                    n2 = Convert.ToDouble(textBox1.Text);
                    Operation();
                }
                else
                {
                    n1 = Convert.ToDouble(textBox1.Text);
                }
            }
            op = '*';
            num = true;
            pre = true;
            point = false;
            equ = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (num == false)
            {
                if (pre == true)
                {
                    n2 = Convert.ToDouble(textBox1.Text);
                    Operation();
                }
                else
                {
                    n1 = Convert.ToDouble(textBox1.Text);
                }
            }
            op = '/';
            num = true;
            pre = true;
            point = false;
            equ = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(pre == true)
            {
                if(equ == false)
                {
                    n2 = Convert.ToDouble(textBox1.Text);
                }
                Operation();
                textBox1.Text = "" + n1;
                num = true;
                pre = true;
                point = false;
                equ = true;
            }
        }
    }
}
