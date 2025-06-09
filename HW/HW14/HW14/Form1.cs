namespace HW14
{
    public partial class Form1 : Form
    {
        int[,] initial = new int[10, 10];
        int[,] shortest = new int[10, 10];
        
        TextBox[] textBoxes = new TextBox[18];
        Label[] labels = new Label[10];
        int[,] graph = new int[18, 2] {
            { 0, 1 }, { 0, 2 }, { 0, 3 },
            { 1, 3 }, { 1, 4 }, { 2, 3 },
            { 3, 4 }, { 2, 5 }, { 3, 5 },
            { 3, 6 }, { 4, 6 }, { 5, 6 },
            { 5, 7 }, { 5, 8 }, { 6, 8 },
            { 6, 9 }, { 7, 8 }, { 8, 9 }
        };

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            textBoxes[4] = textBox5;
            textBoxes[5] = textBox6;
            textBoxes[6] = textBox7;
            textBoxes[7] = textBox8;
            textBoxes[8] = textBox9;
            textBoxes[9] = textBox10;
            textBoxes[10] = textBox11;
            textBoxes[11] = textBox12;
            textBoxes[12] = textBox13;
            textBoxes[13] = textBox14;
            textBoxes[14] = textBox15;
            textBoxes[15] = textBox16;
            textBoxes[16] = textBox17;
            textBoxes[17] = textBox18;
            labels[0] = label1;
            labels[1] = label2;
            labels[2] = label3;
            labels[3] = label4;
            labels[4] = label5;
            labels[5] = label6;
            labels[6] = label7;
            labels[7] = label8;
            labels[8] = label9;
            labels[9] = label10;
            this.Paint += new PaintEventHandler(Form1_Paint);
        }
        // 畫線
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen grayPen = new Pen(Color.Gray, 1);

            for (int i = 0; i < 18; i++)
            {
                g.DrawLine(grayPen,
                    new Point(labels[graph[i, 0]].Location.X + 8, labels[graph[i, 0]].Location.Y + labels[graph[i, 0]].Size.Height / 2),
                    new Point(labels[graph[i, 1]].Location.X + 8, labels[graph[i, 1]].Location.Y + labels[graph[i, 1]].Size.Height / 2));
            }
        }
        // 按下按鈕 "計算最短路徑"
        private void button1_Click(object sender, EventArgs e)
        {
            // 清空
            textBox21.Text = "";
            textBox22.Text = "";
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    initial[i, j] = int.MaxValue/2; // 非通路
            
            // 讀入基本資料
            for(int i = 0; i < 18; i++)
            {
                initial[graph[i, 0], graph[i, 1]] = Convert.ToInt32(textBoxes[i].Text);
                initial[graph[i, 1], graph[i, 0]] = Convert.ToInt32(textBoxes[i].Text);
            }

            // 複製
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    shortest[i, j] = initial[i, j];

            // 製作最小距離矩陣
            for (int k = 0; k < 10; k++)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        shortest[i, j] = Math.Min(shortest[i, j], shortest[i, k] + shortest[k, j]);
                    }
                }
            }

            int start = (int)textBox19.Text[0] - (int)'A';
            int end = (int)textBox20.Text[0] - (int)'A';
            int dis = shortest[start, end];
            textBox21.Text = Convert.ToString(dis);
            string str = textBox19.Text;

            // 回推路徑
            while(start != end)
            {
                for(int k = 0; k < 10; k++)
                {
                    if (initial[start, k] == int.MaxValue / 2) continue;
                    if (initial[start, k] + (k == end ? 0 :shortest[k, end]) == dis)
                    {
                        dis -= initial[start, k];
                        start = k;
                        str += " -> " + (char)((int)'A' + k);
                    }
                }
            }
            textBox22.Text = str;
        }
    }
}
