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
            StreamReader st = new StreamReader("people.txt");
            string str;
            while (!st.EndOfStream)
            {
                str = st.ReadLine();
                string[] spl = str.Split(' ');
                int age = Convert.ToInt32(spl[3]);
                if (age < 40)
                {
                    listBox2.Items.Add(str);
                }
                else people.Enqueue(str);
            }
            st.Close();
            foreach (string lines in people)
            {
                listBox2.Items.Add(lines);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
    }

