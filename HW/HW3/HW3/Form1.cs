namespace HW3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] board = new Button[3, 3];
        int[,] state = new int[3, 3];
        bool start = false;
        bool computer = true;
        int count;

        //���s�t�m - �G���}�C
        private void Form1_Load(object sender, EventArgs e)
        {
            board[0, 0] = button1;
            board[0, 1] = button2;
            board[0, 2] = button3;
            board[1, 0] = button4;
            board[1, 1] = button5;
            board[1, 2] = button6;
            board[2, 0] = button7;
            board[2, 1] = button8;
            board[2, 2] = button9;
        }

        //�u�X����
        void showBoard()
        {
            int i, j;
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (state[i, j] == 0) board[i, j].Text = "";
                    if (state[i, j] == 1) board[i, j].Text = "O";
                    if (state[i, j] == 10) board[i, j].Text = "X";
                }
            }

            if (computer) textBox1.Text = "�q��";
            else textBox1.Text = "���a";

            //�q��
            //�׽u
            if (state[0, 0] + state[1, 1] + state[2, 2] == 3 || state[0, 2] + state[1, 1] + state[2, 0] == 3)
            {
                MessageBox.Show("�q�����", "�C������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = false;
                return;
            }
            //���u
            for (i = 0; i < 3; i++)
            {
                if (state[i, 0] + state[i, 1] + state[i, 2] == 3 || state[0, i] + state[1, i] + state[2, i] == 3)
                {
                    MessageBox.Show("�q�����", "�C������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    start = false;
                    return;
                }
            }

            //���a
            //�׽u
            if (state[0, 0] + state[1, 1] + state[2, 2] == 30 || state[0, 2] + state[1, 1] + state[2, 0] == 30)
            {
                MessageBox.Show("���a���", "�C������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = false;
                return;
            }
            //���u
            for (i = 0; i < 3; i++)
            {
                if (state[i, 0] + state[i, 1] + state[i, 2] == 30 || state[0, i] + state[1, i] + state[2, i] == 30)
                {
                    MessageBox.Show("���a���", "�C������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    start = false;
                    return;
                }
            }

            if (count == 9)
            {
                MessageBox.Show("���襭��", "�C������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                start = false;
            }
        }

        //�}�l���s
        private void button10_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    state[i, j] = 0;
                }
            }
            count = 0;
            showBoard();
            start = true;
            if (radioButton2.Checked == true)
            {
                computer = false;
                textBox1.Text = "���a";
            }
            else
            {
                computer = false;
                textBox1.Text = "�q��";
                play();
            }
        }

        //�q���C��
        void play()
        {
            if (start == false) return;

            int i, j;
            //�e�B�z
            int[] player_row_count = new int[3];
            int[] player_col_count = new int[3];
            int[] player_slash_count = new int[2];
            int[] computer_row_count = new int[3];
            int[] computer_col_count = new int[3];
            int[] computer_slash_count = new int[2];
            for(i = 0; i < 3; i++)
            {
                for(j = 0; j < 3; j++)
                {
                    if (state[i, j] == 1)
                    {
                        computer_row_count[i]++;
                        computer_col_count[j]++;
                        if ((i + j) % 2 == 0)
                        {
                            if(i == j) computer_slash_count[0]++;
                            if(i + j == 2) computer_slash_count[1]++;
                        }
                    }
                    else if (state[i, j] == 10)
                    {
                        player_row_count[i]++;
                        player_col_count[j]++;
                        if ((i + j) % 2 == 0)
                        {
                            if (i == j) player_slash_count[0]++;
                            if (i + j == 2) player_slash_count[1]++;
                        }

                    }
                }
            }

            //1. �q���t�@�ӳs�u
            //�׽u
            if (computer_slash_count[0] == 2 && player_slash_count[0] == 0)
            {
                for(i = 0; i < 3; i++)
                {
                    if(state[i, i] == 0)
                    {
                        state[i, i] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            }
            if (computer_slash_count[1] == 2 && player_slash_count[1] == 0)
            {
                for (i = 0; i < 3; i++)
                {
                    if (state[i, 3-1-i] == 0)
                    {
                        state[i, 3-1-i] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            }
            //���u
            for (i = 0; i < 3; i++)
            {
                if (computer_row_count[i] == 2 && player_row_count[i] == 0)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (state[i, j] == 0)
                        {
                            state[i, j] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
                if (computer_col_count[i] == 2 && player_col_count[i] == 0)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (state[j, i] == 0)
                        {
                            state[j, i] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
            }

            //2. ���a�t�@�ӳs�u
            //�׽u
            if (player_slash_count[0] == 2 && computer_slash_count[0] == 0)
            {
                for (i = 0; i < 3; i++)
                {
                    if (state[i, i] == 0)
                    {
                        state[i, i] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            }
            if (player_slash_count[1] == 2 && computer_slash_count[1] == 0)
            {
                for (i = 0; i < 3; i++)
                {
                    if (state[i, 3 - 1 - i] == 0)
                    {
                        state[i, 3 - 1 - i] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            }
            //���u
            for (i = 0; i < 3; i++)
            {
                if (player_row_count[i] == 2 && computer_row_count[i] == 0)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (state[i, j] == 0)
                        {
                            state[i, j] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
                if (player_col_count[i] == 2 && computer_col_count[i] == 0)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (state[j, i] == 0)
                        {
                            state[j, i] = 1;
                            count++;
                            computer = false;
                            showBoard();
                            return;
                        }
                    }
                }
            }

            //3. �q�������i�H�y������uť�P
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (state[i, j] != 0) continue;

                    int cnt = 0;
                    if (computer_row_count[i] == 1 && player_row_count[i] == 0) cnt++;
                    if (computer_col_count[j] == 1 && player_col_count[j] == 0) cnt++;
                    if ((i + j) % 2 == 0)
                    {
                        if (i == j && computer_slash_count[0] == 1 && player_slash_count[0] == 0) cnt++;
                        if (i + j == 2 && computer_slash_count[1] == 1 && player_slash_count[1] == 0) cnt++;
                    }

                    if (cnt >= 2)
                    {
                        state[i, j] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            }

            //4. ���a�����i�H�y������uť�P
            int ni = -1, nj = -1, special = 0; // �S����
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (state[i, j] != 0) continue;

                    int cnt = 0;
                    if (player_row_count[i] == 1 && computer_row_count[i] == 0) cnt++;
                    if (player_col_count[j] == 1 && computer_col_count[j] == 0) cnt++;
                    if ((i + j) % 2 == 0)
                    {
                        if (i == j && player_slash_count[0] == 1 && computer_slash_count[0] == 0) cnt++;
                        if (i + j == 2 && player_slash_count[1] == 1 && computer_slash_count[1] == 0) cnt++;
                    }

                    if (cnt >= 2)
                    {
                        ni = i; nj = j;
                        special++;
                    }
                }
            }
            if(ni != -1 && nj != -1)
            {
                if (special < 2)
                {
                    state[ni, nj] = 1;
                    count++;
                    computer = false;
                    showBoard();
                    return;
                }
                else // �i���}
                {
                    for (i = 0; i < 3; i++)
                    {
                        for (j = 0; j < 3; j++)
                        {
                            if ((i + j) % 2 != 0 && state[i, j] == 0)
                            {
                                state[i, j] = 1;
                                count++;
                                computer = false;
                                showBoard();
                                return;
                            }
                        }
                    }
                }
            }

            //5. ���勵����
            if (state[1, 1] == 0)
            {
                state[1, 1] = 1;
                count++;
                computer = false;
                showBoard();
                return;
            }

            //6. �A�﨤��
            for(i = 0; i < 3; i++)
            {
                for(j = 0; j < 3; j++)
                {
                    if((i + j) % 2 == 0 && state[i, j] == 0)
                    {
                        state[i, j] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            }

            //7. �̫����u
            for (i = 0; i < 3; i++)
            {
                for(j = 0; j < 3; j++)
                {
                    if (state[i, j] == 0)
                    {
                        state[i, j] = 1;
                        count++;
                        computer = false;
                        showBoard();
                        return;
                    }
                }
            }
        }

        //���s�Q���U
        private void button1_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[0, 0] == 0)
            {
                state[0, 0] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[0, 1] == 0)
            {
                state[0, 1] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[0, 2] == 0)
            {
                state[0, 2] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[1, 0] == 0)
            {
                state[1, 0] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[1, 1] == 0)
            {
                state[1, 1] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[1, 2] == 0)
            {
                state[1, 2] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[2, 0] == 0)
            {
                state[2, 0] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[2, 1] == 0)
            {
                state[2, 1] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (start && !computer && state[2, 2] == 0)
            {
                state[2, 2] = 10;
                count++;
                computer = true;
                showBoard();
                play();
            }
        }
    }
}
