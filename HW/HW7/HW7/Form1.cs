using System.Numerics;

namespace HW7
{
    public partial class Form1 : Form
    {
        String result = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            result = "";
            String str = textBox1.Text;

            int sum = 1;
            for(int i = 2; i <= str.Length; i++)
            {
                sum *= i;
            }
            textBox2.Text = Convert.ToString(sum);

            char[] chars = str.ToCharArray();
            dfs(chars, 0);
            textBox3.Text = result;
        }


        void dfs(char[] chars, int now)
        {
            if (now == chars.Length - 1) // base case
            {
                result += new string(chars) + ", ";
                return;
            }

            for (int i = now; i < chars.Length ; i++) // �C�@�� now ���᪺�Ʀr
            {
                swap(chars, i, now); // ���� now ���ӼƦr����
                dfs(chars, now+1);
                swap(chars, i, now); // ���^�ӡA�^�� (back tracing)
            }
        }
        void swap(char[] chars, int a, int b)
        {
            char c = chars[a];
            chars[a] = chars[b];
            chars[b] = c;
        }

    }
}
