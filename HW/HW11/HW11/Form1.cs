using System.Xml.Linq;

namespace HW11
{
    public partial class Form1 : Form
    {
        node head = new node(0);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            show_list();
        }
        //Insert
        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            try
            {
                n = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("輸入字串格式不正確", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            node x = new node(n);
            node ptr1 = head;
            node ptr2 = head.getNext();
            while (ptr2 != null)
            {
                if (ptr2.getData() > n)
                {
                    ptr1.setNext(x);
                    x.setNext(ptr2);
                    show_list();
                    return;
                }
                else if (ptr2.getData() == n)
                {
                    MessageBox.Show("資料" + n + "重複", "新增失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ptr1 = ptr2;
                ptr2 = ptr2.getNext();
            }
            ptr1.setNext(x);
            show_list();
        }
        //Delete
        private void button2_Click(object sender, EventArgs e)
        {
            int n;
            try
            {
                n = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("輸入字串格式不正確", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            node ptr1 = head;
            node ptr2 = head.getNext();
            while (ptr2 != null)
            {
                if (ptr2.getData() == n)
                {
                    ptr1.setNext(ptr2.getNext());
                    show_list();
                    return;
                }
                if (ptr2.getData() > n) break;
                ptr1 = ptr2;
                ptr2 = ptr2.getNext();
            }
            MessageBox.Show("串列中沒有" + n + "，無法刪除", "刪除失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void show_list()
        {
            string result = "head->";
            node x = head.getNext();
            while (x != null)
            {
                result += Convert.ToString(x.getData()) + "->";
                x = x.getNext();
            }
            result += "null";
            textBox1.Text = result;
        }
    }
    class node
    {
        int data;
        node next;
        public node(int n)
        {
            data = n;
            next = null;
        }
        public int getData()
        {
            return data;
        }
        public node getNext()
        {
            return next;
        }
        public void setData(int n)
        {
            data = n;
        }
        public void setNext(node d)
        {
            next = d;
        }
    }
}
