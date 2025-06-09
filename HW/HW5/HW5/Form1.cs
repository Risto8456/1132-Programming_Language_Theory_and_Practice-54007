using System.IO;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace HW5
{
    public partial class Form1 : Form
    {
        TextBox[,] board = new TextBox[6, 6];
        int[,] arr = new int[6, 6];
        int[,] max = new int[6, 6];
        public Form1()
        {
            InitializeComponent();
        }

        //存檔輸出
        private void button2_Click(object sender, EventArgs e)
        {
            RenewData();
            saveFileDialog1.Filter = "二元檔案(*.dat)|*.dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        bw.Write(Convert.ToString(arr[i, j]));

                    }
                }
                bw.Flush();
                bw.Close();
                fs.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board[0, 0] = textBox1;
            board[0, 1] = textBox2;
            board[0, 2] = textBox3;
            board[0, 3] = textBox4;
            board[0, 4] = textBox5;
            board[0, 5] = textBox6;
            board[1, 0] = textBox7;
            board[1, 1] = textBox8;
            board[1, 2] = textBox9;
            board[1, 3] = textBox10;
            board[1, 4] = textBox11;
            board[1, 5] = textBox12;
            board[2, 0] = textBox13;
            board[2, 1] = textBox14;
            board[2, 2] = textBox15;
            board[2, 3] = textBox16;
            board[2, 4] = textBox17;
            board[2, 5] = textBox18;
            board[3, 0] = textBox19;
            board[3, 1] = textBox20;
            board[3, 2] = textBox21;
            board[3, 3] = textBox22;
            board[3, 4] = textBox23;
            board[3, 5] = textBox24;
            board[4, 0] = textBox25;
            board[4, 1] = textBox26;
            board[4, 2] = textBox27;
            board[4, 3] = textBox28;
            board[4, 4] = textBox29;
            board[4, 5] = textBox30;
            board[5, 0] = textBox31;
            board[5, 1] = textBox32;
            board[5, 2] = textBox33;
            board[5, 3] = textBox34;
            board[5, 4] = textBox35;
            board[5, 5] = textBox36;
        }

        //讀檔輸入
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "二元檔案(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        arr[i, j] = Convert.ToInt32(br.ReadString());
                    }
                }
                br.Close();
                fs.Close();
                ShowData();
                RenewData();
            }

        }

        //顯示資料
        private void ShowData()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    board[i, j].Text = Convert.ToString(arr[i, j]);
                }
            }
        }

        //更新資料
        private void RenewData()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    board[i, j].ForeColor = Color.Black;
                    arr[i, j] = Convert.ToInt32(board[i, j].Text);
                    max[i, j] = 0;
                }
            }
            textBox37.Text = ("");
        }

        //生產最佳路線
        private void button1_Click(object sender, EventArgs e)
        {
            RenewData();
            dfs(0, 0);
            int i = 0, j = 0;
            while (i != 5 || j != 5)
            {
                board[i, j].ForeColor = Color.Red;
                int right = j + 1 >= 6 ? -1 : max[i, j + 1];
                int down = i + 1 >= 6 ? -1 : max[i + 1, j];
                if (down > right) i++;
                else j++;
            }
            board[5, 5].ForeColor = Color.Red;

            textBox37.Text = Convert.ToString(max[0, 0]);
        }

        private int dfs(int i, int j)
        {
            if (i == 5 && j == 5) return arr[i, j]; // 終點
            if (i >= 6 || j >= 6) return 0; // 界外

            if (max[i, j] != 0) return max[i, j];

            max[i, j] = arr[i, j] + Math.Max(dfs(i + 1, j), dfs(i, j + 1)); // 往右 or 下            
            return max[i, j];
        }
    }
}
