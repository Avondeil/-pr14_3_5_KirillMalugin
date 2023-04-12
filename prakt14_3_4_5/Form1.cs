using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Security.Policy;

namespace prakt14_3_4_5
{
    public partial class Form1 : Form
    {
        Queue<int> queue = new Queue<int>();
        Queue<string> people = new Queue<string>();
        Queue<string> peoplesortage = new Queue<string>();
        public Form1()
        {
            InitializeComponent();

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            queue.Clear();
            int save = (int)numericUpDown1.Value;
            for (int i = 1; i <= save; i++)
            {
                queue.Enqueue(i);
            }
            MessageBox.Show("Очередь успешно заполнена!", "Сообщение", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (queue.Count == 0)
            {
                MessageBox.Show("Очередь не найдена!", "Сообщение", MessageBoxButtons.OK);
            }
            else
            {
                foreach (int num in queue)
                {
                    listBox1.Items.Add(num);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            listBox2.Items.Clear();
            people.Clear();
            StreamReader st = new StreamReader("p.txt");
            string str;
            while (!st.EndOfStream)
            {
                str = st.ReadLine();
                string[] spl = str.Split(' ');
                int age = Convert.ToInt32(spl[3]);
                if (age < 40)
                {
                    people.Enqueue(str);
                }
            }
            st.Close();
            foreach (string lines in people)
            {
                listBox2.Items.Add(lines);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string[] st = File.ReadAllLines("p.txt");
            string[] split=new string[st.Length]; string[] split1=new string[st.Length];
            for (int i = 0; i < st.Length-1; i++)
            {
                for (int j = i+1; j < st.Length; j++)
                {
                    split = st[i].Split(' ');
                    split1 = st[j].Split(' ');
                    if (Convert.ToInt32(split[3]) > Convert.ToInt32(split1[3]))
                    {
                        string save = st[i];
                        st[i] = st[j];
                        st[j] = save;
                    }
                }
            }
            for (int i = 0; i < st.Length; i++) 
            {
                peoplesortage.Enqueue(st[i]);
            }
            foreach (string lines in peoplesortage)
            {
                listBox2.Items.Add(lines);
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            button3.Visible = true;
            button4.Visible=false;
            panel1.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            button4.Visible = true;
            button3.Visible = false;
            panel1.Visible = false;
        }
    }
    }

