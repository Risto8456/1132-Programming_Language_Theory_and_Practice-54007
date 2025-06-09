using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW8
{
    public partial class Form1 : Form
    {
        Picture g = new Picture("Graph");
        List<Picture> allPicture = new List<Picture>();
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "{Picture Graph:}";
            allPicture.Add(g);
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.DialogResult == DialogResult.Cancel) return;

            string PictureName, ContainerName;
            f2.getData(out PictureName, out ContainerName);

            int i;
            for (i = 0; i < allPicture.Count; i++)
            {
                if(allPicture[i].getname() == ContainerName)
                {
                    break;
                }
            }
            if(i == allPicture.Count)
            {
                MessageBox.Show("不存在的 Picture 容器: " + ContainerName, "錯誤訊息" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Picture newPicture = new Picture(PictureName);
            allPicture.Add(newPicture);
            allPicture[i].addComponent(newPicture);
            textBox1.Text = g.show(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            if (f3.DialogResult == DialogResult.Cancel) return;

            string RectangleName, PictureName;
            double length, width;
            f3.getData(out RectangleName, out PictureName, out length, out width);

            int i;
            for (i = 0; i < allPicture.Count; i++)
            {
                if (allPicture[i].getname() == PictureName)
                {
                    break;
                }
            }
            if (i == allPicture.Count)
            {
                MessageBox.Show("不存在的 Picture 容器: " + PictureName, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Rectangle newRectangle = new Rectangle(RectangleName, length, width);
            allPicture[i].addComponent(newRectangle);
            textBox1.Text = g.show(0);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
            if (f4.DialogResult == DialogResult.Cancel) return;

            string CircleName, PictureName;
            double radius;
            f4.getData(out CircleName, out PictureName, out radius);

            int i;
            for (i = 0; i < allPicture.Count; i++)
            {
                if (allPicture[i].getname() == PictureName)
                {
                    break;
                }
            }
            if (i == allPicture.Count)
            {
                MessageBox.Show("不存在的 Picture 容器: " + PictureName, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Circle newCircle = new Circle(CircleName, radius);
            allPicture[i].addComponent(newCircle);
            textBox1.Text = g.show(0);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
            if (f5.DialogResult == DialogResult.Cancel) return;

            string TriangleName, PictureName;
            double tbase, height;
            f5.getData(out TriangleName, out PictureName, out tbase, out height);

            int i;
            for (i = 0; i < allPicture.Count; i++)
            {
                if (allPicture[i].getname() == PictureName)
                {
                    break;
                }
            }
            if (i == allPicture.Count)
            {
                MessageBox.Show("不存在的 Picture 容器: " + PictureName, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Triangle newTriangle = new Triangle(TriangleName, tbase, height);
            allPicture[i].addComponent(newTriangle);
            textBox1.Text = g.show(0);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(g.area());
        }
    }
    abstract class Component
    {
        protected string name;
        public abstract double area();
        public abstract string show(int n);
        public string getname()
        {
            return name;
        }
    }
    abstract class Shape : Component { }
    class Rectangle : Shape
    {
        private double length;
        private double width;
        public Rectangle(string n, double l, double w)
        {
            name = n;
            length = l;
            width = w;
        }
        public override double area()
        {
            return length * width;
        }
        public override string show(int n)
        {
            string str = "";
            for (int i = 0; i < n; i++) str += "\t";
            str += "Rectangle " + name +
                   "(" + length +
                   ", " + width + ")\r\n";
            return str;
        }
    }
    class Circle : Shape
    {
        private double radius;
        public Circle(string n, double r)
        {
            name = n;
            radius = r;
        }
        public override double area()
        {
            return Math.PI * radius * radius;
        }
        public override string show(int n)
        {
            string str = "";
            for (int i = 0; i < n; i++) str += "\t";
            str += "Circle " + name +
                   "(" + radius + ")\r\n";
            return str;
        }
    }
    class Triangle : Shape
    {
        private double tbase;
        private double height;
        public Triangle(string n, double t, double h)
        {
            name = n;
            tbase = t;
            height = h;
        }
        public override double area()
        {
            return 0.5 * tbase * height;
        }
        public override string show(int n)
        {
            string str = "";
            for (int i = 0; i < n; i++) str += "\t";
            str += "Triangle " + name +
                   "(" + tbase +
                   ", " + height + ")\r\n";
            return str;
        }
    }
    class Picture : Component
    {
        private List<Component> coms = new List<Component>();
        public Picture(String n)
        {
            name = n;
        }
        public void addComponent(Component c)
        {
            coms.Add(c);
        }
        public override double area()
        {
            double total = 0.0;
            for (int i = 0; i < coms.Count; i++)
            {
                total += coms[i].area();
            }
            return total;
        }
        public override string show(int n)
        {
            string str = "";
            for (int i = 0; i < n; i++) str += "\t";
            str += "{Picture " + name + ":\r\n";
            for (int i = 0; i < coms.Count; i++)
            {
                str = str + " " + coms[i].show(n+1);
            }
            for (int i = 0; i < n; i++) str += "\t";
            str = str + "}\r\n";
            return str;
        }
    }
}
