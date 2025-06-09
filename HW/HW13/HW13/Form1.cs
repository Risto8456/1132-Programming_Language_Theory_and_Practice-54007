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
        // 畫線
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
        // 按下加入資料
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = "";
                if (num == 15)
                    throw new Exception("堆積樹已滿");
                if (textBox1.Text == "" || !int.TryParse(textBox1.Text, out _))
                    throw new Exception("輸入字串格式不正確");
                num++;
                arr[num - 1].Text = textBox1.Text;
                // 如果只有一個節點(num == 1)就不用調整
                if (num > 1)
                {
                    int i = num - 1; // i 為目前節點
                    // 目前節點 i > 父節點 (i-1)/2 
                    while (Convert.ToInt32(arr[i].Text) > Convert.ToInt32(arr[(i - 1) / 2].Text))
                    {
                        // 互換
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
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 按下取出資料
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                if (num == 0)
                    throw new Exception("堆積樹為空");
                textBox2.Text = arr[0].Text;
                arr[0].Text = arr[num-1].Text;
                arr[num - 1].Text = "";
                num--;
                // 如果只剩一個節點(num == 1)就不用調整
                if (num > 1)
                {
                    int i = 0; // i 為目前節點

                    // i * 2 + 1 < num : 至少第一個子節點存在
                    while (i * 2 + 1 < num)
                    {
                        int root = Convert.ToInt32(arr[i].Text);
                        int left = Convert.ToInt32(arr[(i * 2 + 1)].Text);
                        int right = i * 2 + 2 < num ?  Convert.ToInt32(arr[(i * 2 + 2)].Text) : -1;
                        int add = (left > right ? 1 : 2);
                        // 目前節點 i < 子節點 i*2+1 or i*2+2
                        if (root < Math.Max(right, left))
                        {
                            // 互換
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
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
