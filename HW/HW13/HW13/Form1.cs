using System;
using System.Windows.Forms;

namespace HW13
{
    public partial class Form1 : Form
    {
        TextBox[] arr = new TextBox[15];
        int num = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(Form1_Paint);
            arr[0] = textBox3;
            arr[1] = textBox4;
            arr[2] = textBox5;
            arr[3] = textBox6;
            arr[4] = textBox7;
            arr[5] = textBox8;
            arr[6] = textBox9;
            arr[7] = textBox10;
            arr[8] = textBox11;
            arr[9] = textBox12;
            arr[10] = textBox13;
            arr[11] = textBox14;
            arr[12] = textBox15;
            arr[13] = textBox16;
            arr[14] = textBox17;
        }
        // �e�u
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen grayPen = new Pen(Color.Gray, 1);
            for (int i = 0; i < 7; i++)
            {
                g.DrawLine(grayPen, new Point(arr[i].Location.X, arr[i].Location.Y + arr[i].Size.Height),
                    new Point(arr[i * 2 + 1].Location.X + arr[i * 2 + 1].Size.Width / 2, arr[i * 2 + 1].Location.Y));
                g.DrawLine(grayPen, new Point(arr[i].Location.X + arr[i].Size.Width, arr[i].Location.Y + arr[i].Size.Height),
                    new Point(arr[i * 2 + 2].Location.X + arr[i * 2 + 2].Size.Width / 2, arr[i * 2 + 2].Location.Y));
            }
        }
        // ���U�[�J���
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = "";
                if (num == 15)
                    throw new Exception("��n��w��");
                if (textBox1.Text == "" || !int.TryParse(textBox1.Text, out _))
                    throw new Exception("��J�r��榡�����T");
                num++;
                arr[num - 1].Text = textBox1.Text;
                // �p�G�u���@�Ӹ`�I(num == 1)�N���νվ�
                if (num > 1)
                {
                    int i = num - 1; // i ���ثe�`�I
                    // �ثe�`�I i > ���`�I (i-1)/2 
                    while (Convert.ToInt32(arr[i].Text) > Convert.ToInt32(arr[(i - 1) / 2].Text))
                    {
                        // ����
                        String temp = arr[i].Text;
                        arr[i].Text = arr[(i - 1) / 2].Text;
                        arr[(i - 1) / 2].Text = temp;
                        i = (i - 1) / 2;
                        if(i == 0) break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "���~�T��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ���U���X���
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                if (num == 0)
                    throw new Exception("��n�𬰪�");
                textBox2.Text = arr[0].Text;
                arr[0].Text = arr[num-1].Text;
                arr[num - 1].Text = "";
                num--;
                // �p�G�u�Ѥ@�Ӹ`�I(num == 1)�N���νվ�
                if (num > 1)
                {
                    int i = 0; // i ���ثe�`�I

                    // i * 2 + 1 < num : �ܤֲĤ@�Ӥl�`�I�s�b
                    while (i * 2 + 1 < num)
                    {
                        int root = Convert.ToInt32(arr[i].Text);
                        int left = Convert.ToInt32(arr[(i * 2 + 1)].Text);
                        int right = i * 2 + 2 < num ?  Convert.ToInt32(arr[(i * 2 + 2)].Text) : -1;
                        int add = (left > right ? 1 : 2);
                        // �ثe�`�I i < �l�`�I i*2+1 or i*2+2
                        if (root < Math.Max(right, left))
                        {
                            // ����
                            String temp = arr[i].Text;
                            arr[i].Text = arr[i * 2 + add].Text;
                            arr[i * 2 + add].Text = temp;
                            i = i * 2 + add;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "���~�T��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
