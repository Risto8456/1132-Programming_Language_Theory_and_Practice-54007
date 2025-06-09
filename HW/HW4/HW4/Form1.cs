using System.IO;
namespace HW4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "mining-data1(*.txt)|*.txt";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string[,] record = new string[50, 101];
                int recordNo = 0;
                int[] itemNum = new int[50];
                string[] input = null;
                textBox1.Text = "客戶 購買商品代號\r\n";
                while(sr.Peek() >= 0)
                {
                    input = sr.ReadLine().Split();
                    itemNum[recordNo] = input.Length;
                    for(int i = 0; i < input.Length; i++)
                    {
                        record[recordNo, i] = input[i];
                        textBox1.Text += input[i] + " ";
                    }
                    textBox1.Text += "\r\n";
                    recordNo++;
                }

                // ===== 以上為題目提供 =====
                textBox2.Text = "客戶 相似客戶 推薦商品代號\r\n";
                for(int i = 0; i < recordNo; i++) // 目前是第 i 個客戶
                {
                    textBox2.Text += record[i, 0] + " (";
                    
                    // # 相似客戶
                    // 紀錄與客戶 i 購買重複商品數量最多的相似客戶(們)
                    int[] similar = new int[recordNo]; // 相似客戶編號
                    int similarNo = 0; // 相似客戶數量
                    int mx_same = -1; // 最多的重複商品數量
                    for(int j = 0; j < recordNo; j++) // 檢查第 j 個客戶
                    {
                        int cur_same = count_same(record, itemNum, i, j);
                        //textBox2.Text += "{" + i + "," + j + "," + cur + "}";
                        if (cur_same > mx_same)
                        {
                            mx_same = cur_same;
                            similar[0] = j;
                            similarNo = 1;
                        }
                        else if (cur_same == mx_same)
                        {
                            similar[similarNo] = j;
                            similarNo++;
                        }
                    }

                    // 輸出相似客戶
                    for (int j = 0; j < similarNo; j++)
                    {
                        if (j != 0) textBox2.Text += " ";
                        textBox2.Text += record[similar[j], 0];
                    }
                    textBox2.Text += ")";

                    // # 推薦商品
                    string[] recommends = new string[100]; // 推薦商品清單
                    int recommendNo = 0; // 推薦商品數量
                    for (int j = 0; j < similarNo; j++) // 第 j 個相似客戶
                    {

                        for(int k = 1; k < itemNum[similar[j]]; k++) // 該相似客戶的第 k-1 件商品
                        {
                            // 在客戶 i 中尋找該商品
                            if (find(record, itemNum, i, record[similar[j], k])) continue;
                            // 檢查該商品是否已經計入推薦商品清單
                            if (find(recommends, recommendNo, record[similar[j], k])) continue;

                            // 放入推薦商品清單中
                            recommends[recommendNo] = record[similar[j], k];
                            recommendNo++;
                        }
                    }

                    // 輸出推薦商品清單
                    for(int j = 0; j < recommendNo; j++)
                    {
                        textBox2.Text += " " + recommends[j];
                    }
                    textBox2.Text += "\r\n";
                }

            }
        }

        // 客戶 i, j 有幾個相同的商品
        private int count_same(string[,] record, int[] itemNum, int i, int j)
        {
            if (i == j) return -2; // 不計入

            int count = 0; 
            for(int k = 1; k < itemNum[i]; k++) // 客戶 i 的第 k-1 個商品
            {
                if (find(record, itemNum, j, record[i, k]))
                {
                    count++;
                }
            }
            return count;
        }
        // 在客戶 i 中尋找商品 target
        private bool find(string[,] record, int[] itemNum, int i, string target)
        {
            for(int j = 1; j < itemNum[i]; j++)
            {
                if (record[i, j] == target)
                {
                    return true;
                }
            }
            return false;
        }
        // 在 str_arr 字串陣列中尋找 str 字串
        private bool find(string[] str_arr, int size, string str)
        {
            for(int i = 0; i < size; i++)
            {
                if (str_arr[i] == str) return true;
            }
            return false;
        }



        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
