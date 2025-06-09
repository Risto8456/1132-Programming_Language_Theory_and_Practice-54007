using System.Windows.Forms;

namespace HW6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Ū�ɿ�J�Ҧ��ﲼ
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "�G���ɮ�(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                int cn = br.ReadInt32(); //�Կ�H�ƶq
                int bn = br.ReadInt32(); //�ﲼ�ƶq
                int[,] ballot = new int[bn, cn]; //�x�sbn�i�ﲼ����ܶ��� 
                int[] count = new int[cn + 1]; //�x�s�C�ӭԿ�H���o����
                bool[] remove = new bool[cn + 1]; //�x�s�Կ�H�O�_�Q�^�O 
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
                    textBox1.Text += "��" + round + "�^�X:\r\n";

                    //�ˬd�O�_�����Կ�H�ҳQ�^�O
                    for (i = 1; i <= cn; i++)
                    {
                        if (!remove[i]) break;
                        if (i == cn)
                        {
                            textBox1.Text += "�L�k�M�w����\r\n";
                            end = true;
                            break;
                        }
                    }
                    if (end) break;

                    for (i = 1; i <= cn; i++) //�o���k�s
                    {
                        count[i] = 0;
                    }

                    for (i = 0; i < bn; i++) //�p��o��
                    {
                        for (j = 0; j < cn; j++)
                        {
                            if (remove[ballot[i, j]]) continue; //�Կ�H�w�Q�^�O
                            count[ballot[i, j]]++;
                            break;
                        }
                    }

                    for (i = 1; i <= cn; i++) //�O�_���Կ�H�o���L�b
                    {
                        if (remove[i]) continue;
                        if (count[i] > bn / 2)
                        {
                            textBox1.Text += "���X" + i + "�Կ�H�L�b�Ʒ��\r\n";
                            end = true;
                            break;
                        }
                    }
                    if (end) break;


                    int mn = bn, mn_count = 0;
                    int[] mn_num = new int[cn];
                    //��X�̧C�o����
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

                    //�^�O�̧C�o����
                    for(i = 0; i < mn_count; i++)
                    {
                        remove[mn_num[i]] = true;
                        textBox1.Text += "���X" + mn_num[i] + "�Կ�H ";
                    }
                    textBox1.Text += "���^�X�̧C���Q�^�O\r\n\r\n";
                }
            } 
        }
    }
}
