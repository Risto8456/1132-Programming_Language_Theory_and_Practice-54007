using System.Windows.Forms;

namespace HW6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //讀檔輸入所有選票
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "二元檔案(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                int cn = br.ReadInt32(); //候選人數量
                int bn = br.ReadInt32(); //選票數量
                int[,] ballot = new int[bn, cn]; //儲存bn張選票的選擇順序 
                int[] count = new int[cn + 1]; //儲存每個候選人的得票數
                bool[] remove = new bool[cn + 1]; //儲存候選人是否被淘汰 
                int i, j, round = 0;
                textBox1.Text = "";

                for (i = 0; i < bn; i++)
                    for (j = 0; j < cn; j++)
                        ballot[i, j] = br.ReadInt32();

                for (i = 0; i <= cn; i++)
                    remove[i] = false;

                bool end = false;
                while (true)
                {
                    round++;
                    textBox1.Text += "第" + round + "回合:\r\n";

                    //檢查是否全部候選人皆被淘汰
                    for (i = 1; i <= cn; i++)
                    {
                        if (!remove[i]) break;
                        if (i == cn)
                        {
                            textBox1.Text += "無法決定當選者\r\n";
                            end = true;
                            break;
                        }
                    }
                    if (end) break;

                    for (i = 1; i <= cn; i++) //得票歸零
                    {
                        count[i] = 0;
                    }

                    for (i = 0; i < bn; i++) //計算得票
                    {
                        for (j = 0; j < cn; j++)
                        {
                            if (remove[ballot[i, j]]) continue; //候選人已被淘汰
                            count[ballot[i, j]]++;
                            break;
                        }
                    }

                    for (i = 1; i <= cn; i++) //是否有候選人得票過半
                    {
                        if (remove[i]) continue;
                        if (count[i] > bn / 2)
                        {
                            textBox1.Text += "號碼" + i + "候選人過半數當選\r\n";
                            end = true;
                            break;
                        }
                    }
                    if (end) break;


                    int mn = bn, mn_count = 0;
                    int[] mn_num = new int[cn];
                    //找出最低得票者
                    for(i = 1; i <= cn; i++)
                    {
                        if (remove[i]) continue;
                        if (count[i] < mn)
                        {
                            mn = count[i];
                            mn_num[0] = i;
                            mn_count = 1;
                        }else if (count[i] == mn)
                        {
                            mn_num[mn_count] = i;
                            mn_count++;
                        }
                    }

                    //淘汰最低得票者
                    for(i = 0; i < mn_count; i++)
                    {
                        remove[mn_num[i]] = true;
                        textBox1.Text += "號碼" + mn_num[i] + "候選人 ";
                    }
                    textBox1.Text += "本回合最低票被淘汰\r\n\r\n";
                }
            } 
        }
    }
}
