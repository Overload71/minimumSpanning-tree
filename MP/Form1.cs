using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP
{
    public partial class Form1 : Form
    {
        Nodes n;
        int V;
        int[,] graph = new int[10, 10];
        List<int> l = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            panel2.Refresh();
            l.Clear();
            n = new Nodes(panel1,panel2);
           // textBox1.Text = "5";
            V = Convert.ToInt32(textBox1.Text);
            n.draw(Convert.ToInt32(textBox1.Text));
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == comboBox2.Text || textBox2.Text == "")
            {
                MessageBox.Show("Error");
            }
            else
            {

                n.Draw_edge(Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox2.Text), textBox2.Text);
                graph[Convert.ToInt32(comboBox1.Text), Convert.ToInt32(comboBox2.Text)] = Convert.ToInt32(textBox2.Text);
                graph[Convert.ToInt32(comboBox2.Text), Convert.ToInt32(comboBox1.Text)] = Convert.ToInt32(textBox2.Text);
            
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            primMST(graph);
        }
        int min_node_value(int[] node_value, bool[] visited)
        {
            // Initialize min value
            int min = Int32.MaxValue;
            int min_index=-1;

            for (int v = 0; v < V; v++)
                if (visited[v] == false && node_value[v] < min)
                {
                    min = node_value[v];
                    min_index = v;
                }

            return min_index;
        }
       
        void primMST(int [,]graph)
        {
            int[] parent = new int[V]; // Array to store constructed MST
            int[] node_value = new int[V];   // node_value values used to pick minimum weight edge
            bool[] visited = new bool[V];  

           
            for (int i = 0; i < V; i++)
            {
                node_value[i] = Int32.MaxValue;
                visited[i] = false;
            }
            node_value[0] = 0;     //first index
            parent[0] = -1; //first node is root

            
            for (int count = 0; count < V ; count++)
            {
                int u = min_node_value(node_value, visited);
                visited[u] = true;
                l.Add(u);
                for (int v = 0; v < V; v++)
                    if (graph[u, v] != 0 && visited[v] == false && graph[u, v] < node_value[v])
                    {
                        parent[v] = u; 
                        node_value[v] = graph[u, v];  
                    }
            }
            int total_cost=0;
           for ( int i = 1; i < V; i++)
           {
               string s = "";
               total_cost+=graph[i,parent[i]];
               n.draw_sol(parent[i],i,graph[i,parent[i]]);
           }
           textBox3.Text = total_cost.ToString();
           textBox4.Text = string.Join(" , ",l.ToArray());
        }
    }
}
