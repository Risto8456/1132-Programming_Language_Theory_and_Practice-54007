﻿namespace HW12
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            textBox2 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(122, 73);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 0;
            label1.Text = "輸入值";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(191, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(454, 68);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "新增";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(580, 68);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "刪除";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(122, 183);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(363, 143);
            textBox2.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(567, 183);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 5;
            button3.Text = "前序走訪";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(567, 242);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 6;
            button4.Text = "中序走訪";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(567, 297);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 7;
            button5.Text = "後序走訪";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "二元搜尋樹(Binary Search Tree)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private TextBox textBox2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}
