namespace HW10
{
    public partial class Form1 : Form
    {
        MyQueue queue = new MyQueue();
        TextBox[] TextBoxArray = new TextBox[8];
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TextBoxArray[0] = textBox3;
            TextBoxArray[1] = textBox4;
            TextBoxArray[2] = textBox5;
            TextBoxArray[3] = textBox6;
            TextBoxArray[4] = textBox7;
            TextBoxArray[5] = textBox8;
            TextBoxArray[6] = textBox9;
            TextBoxArray[7] = textBox10;
            textBox11.Text = Convert.ToString(queue.front);
            textBox12.Text = Convert.ToString(queue.rear);
        }
        // enqueue
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int input = Convert.ToInt32(textBox1.Text);
                queue.enqueue(input);
                textBox12.Text = Convert.ToString(queue.rear);
                TextBoxArray[queue.rear].Text = Convert.ToString(input);
            }
            catch (Exception ex)
            {
                MessageBox.Show("輸入字串格式不正確", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // dequeue
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int output = queue.dequeue();
                textBox2.Text = Convert.ToString(output);
                textBox11.Text = Convert.ToString(queue.front);
                TextBoxArray[queue.front].Text = "";
            }
            catch (Exception ex)
            {  

            }
        }
    }
    class MyQueue
    {
        const int MAX = 8;
        public int[] queue = new int[MAX];
        public int front = MAX - 1, rear = MAX - 1;
        public void enqueue(int item)
        {
            if (front == (rear + 1) % MAX)
                MessageBox.Show("空間已滿", "錯誤訊息" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                rear = (rear + 1) % MAX;
                queue[rear] = item;
            }
        }
        public bool isEmpty()
        {
            if (front == rear)
                return true;
            else
                return false;
        }
        public int dequeue()
        {
            if (isEmpty())
            {
                MessageBox.Show("沒有資料", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else
            {
                front = (front + 1) % MAX;
                return queue[front];
            }
        }
    }
}