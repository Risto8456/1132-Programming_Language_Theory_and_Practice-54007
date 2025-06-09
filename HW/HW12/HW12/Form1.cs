namespace HW12
{
    public partial class Form1 : Form
    {
        node root = new node(0);
        int mode = 1;
        public Form1()
        {
            InitializeComponent();
        }

        // 按下新增
        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            try
            {
                n = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("輸入字串格式不正確", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            node ptr1 = root; // father
            node ptr2 = root.getLeft(); // son
            node x = new node(n); // 加入資料 n
            if (ptr2 == null)
            {
                root.setLeft(x);
            }
            else
            {
                while (ptr2 != null)
                {
                    if (ptr2.getData() == n)
                    {
                        MessageBox.Show("資料" + n + "已存在", "新增失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ptr1 = ptr2;
                    if (n < ptr2.getData()) ptr2 = ptr2.getLeft();
                    else ptr2 = ptr2.getRight();
                }
                if (n < ptr1.getData()) ptr1.setLeft(x);
                else ptr1.setRight(x);
            }
            showData();
        }
        // 按下刪除
        private void button2_Click(object sender, EventArgs e)
        {
            int n;
            try
            {
                n = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("輸入字串格式不正確", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 搜尋
            node ptr1 = root;
            node ptr2 = root.getLeft();
            while (ptr2 != null)
            {
                // 搜尋到資料 n 在 ptr2
                if (ptr2.getData() == n) break;
                ptr1 = ptr2;
                if (n < ptr2.getData()) ptr2 = ptr2.getLeft();
                else ptr2 = ptr2.getRight();
            }
            if (ptr2 == null)
            {
                MessageBox.Show("資料" + n + "不存在", "刪除失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            delete(ptr1, ptr2);
            showData();
        }
        // 刪除節點 son
        private void delete(node father, node son)
        {
            bool sonAtfatherLeft = father.getData() > son.getData();
            bool sonHaveLeft = son.getLeft() != null;
            bool sonHaveRight = son.getRight() != null;
            if (!sonHaveLeft && !sonHaveRight)
            {
                // son 沒有子節點
                if (sonAtfatherLeft) father.setLeft(null);
                else father.setRight(null);
            }
            else if (sonHaveLeft != sonHaveRight)
            {
                // son 只有一個子節點 grandson
                node grandson = sonHaveLeft ? son.getLeft() : son.getRight();
                if (sonAtfatherLeft) father.setLeft(grandson);
                else father.setRight(grandson);
            }
            else
            {
                // son 有兩個子節點
                // ptr3 = son 的左子樹中資料值最大的節點
                node ptr3 = son.getLeft();
                node ptr3_f = son;
                while (ptr3.getRight() != null)
                {
                    ptr3_f = ptr3;
                    ptr3 = ptr3.getRight();
                }
                int data = ptr3.getData();
                delete(ptr3_f, ptr3);
                son.setData(data);
            }
        }
        void showData()
        {
            textBox2.Text = "";
            switch (mode)
            {
                case 1: preorder(root.getLeft()); break;
                case 2: inorder(root.getLeft());  break;
                case 3: postorder(root.getLeft());break;
            }
        }
        // 按下前序 preorder
        private void button3_Click(object sender, EventArgs e)
        {
            mode = 1;
            showData();
        }
        // 按下中序 inorder
        private void button4_Click(object sender, EventArgs e)
        {
            mode = 2;
            showData();
        }
        // 按下後序 postorder
        private void button5_Click(object sender, EventArgs e)
        {
            mode = 3;
            showData();
        }
        void preorder(node ptr)
        {
            if (ptr != null)
            {
                textBox2.Text = textBox2.Text + " " + ptr.getData();
                preorder(ptr.getLeft());
                preorder(ptr.getRight());
            }
        }
        void inorder(node ptr)
        {
            if (ptr != null)
            {
                inorder(ptr.getLeft());
                textBox2.Text = textBox2.Text + " " + ptr.getData();
                inorder(ptr.getRight());
            }
        }
        void postorder(node ptr)
        {
            if (ptr != null)
            {
                postorder(ptr.getLeft());
                postorder(ptr.getRight());
                textBox2.Text = textBox2.Text + " " + ptr.getData();
            }
        }
    }
    class node
    {
        int data;
        node left;
        node right;
        public node(int n)
        {
            data = n;
            left = null;
            right = null;
        }
        public int getData()
        { return data; }
        public node getLeft()
        { return left; }
        public node getRight()
        { return right; }
        public void setData(int n)
        { data = n; }
        public void setLeft(node d)
        { left = d; }
        public void setRight(node d)
        { right = d; }
    }
}
