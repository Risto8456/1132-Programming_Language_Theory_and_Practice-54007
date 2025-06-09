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
                textBox1.Text = "�Ȥ� �ʶR�ӫ~�N��\r\n";
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

                // ===== �H�W���D�ش��� =====
                textBox2.Text = "�Ȥ� �ۦ��Ȥ� ���˰ӫ~�N��\r\n";
                for(int i = 0; i < recordNo; i++) // �ثe�O�� i �ӫȤ�
                {
                    textBox2.Text += record[i, 0] + " (";
                    
                    // # �ۦ��Ȥ�
                    // �����P�Ȥ� i �ʶR���ưӫ~�ƶq�̦h���ۦ��Ȥ�(��)
                    int[] similar = new int[recordNo]; // �ۦ��Ȥ�s��
                    int similarNo = 0; // �ۦ��Ȥ�ƶq
                    int mx_same = -1; // �̦h�����ưӫ~�ƶq
                    for(int j = 0; j < recordNo; j++) // �ˬd�� j �ӫȤ�
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

                    // ��X�ۦ��Ȥ�
                    for (int j = 0; j < similarNo; j++)
                    {
                        if (j != 0) textBox2.Text += " ";
                        textBox2.Text += record[similar[j], 0];
                    }
                    textBox2.Text += ")";

                    // # ���˰ӫ~
                    string[] recommends = new string[100]; // ���˰ӫ~�M��
                    int recommendNo = 0; // ���˰ӫ~�ƶq
                    for (int j = 0; j < similarNo; j++) // �� j �Ӭۦ��Ȥ�
                    {

                        for(int k = 1; k < itemNum[similar[j]]; k++) // �Ӭۦ��Ȥ᪺�� k-1 ��ӫ~
                        {
                            // �b�Ȥ� i ���M��Ӱӫ~
                            if (find(record, itemNum, i, record[similar[j], k])) continue;
                            // �ˬd�Ӱӫ~�O�_�w�g�p�J���˰ӫ~�M��
                            if (find(recommends, recommendNo, record[similar[j], k])) continue;

                            // ��J���˰ӫ~�M�椤
                            recommends[recommendNo] = record[similar[j], k];
                            recommendNo++;
                        }
                    }

                    // ��X���˰ӫ~�M��
                    for(int j = 0; j < recommendNo; j++)
                    {
                        textBox2.Text += " " + recommends[j];
                    }
                    textBox2.Text += "\r\n";
                }

            }
        }

        // �Ȥ� i, j ���X�ӬۦP���ӫ~
        private int count_same(string[,] record, int[] itemNum, int i, int j)
        {
            if (i == j) return -2; // ���p�J

            int count = 0; 
            for(int k = 1; k < itemNum[i]; k++) // �Ȥ� i ���� k-1 �Ӱӫ~
            {
                if (find(record, itemNum, j, record[i, k]))
                {
                    count++;
                }
            }
            return count;
        }
        // �b�Ȥ� i ���M��ӫ~ target
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
        // �b str_arr �r��}�C���M�� str �r��
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
