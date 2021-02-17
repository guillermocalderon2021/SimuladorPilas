using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorPilas
{
    public partial class Form1 : Form
    {
        Stack<int> pila = new Stack<int>();
        Stack<Label> pilaLabel = new Stack<Label>();
        int x = 0;
        int y = 75;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(nudValor.Value);
            pila.Push(valor);
            Label miLabel = new Label();
            miLabel.Text = valor.ToString();
            miLabel.Width = 50;
            miLabel.Height = 50;
            miLabel.BackColor = Color.White;
            miLabel.TextAlign =  ContentAlignment.MiddleCenter;
            miLabel.BorderStyle = BorderStyle.FixedSingle;
            miLabel.Location = new Point(0,0);
            //x += 50;
            panel1.Controls.Add(miLabel);
            pilaLabel.Push(miLabel);
            timer1.Start();
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            pila.Pop();
            timer2.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Label miLabel = pilaLabel.Peek();//Recuperando el ultimo label
            miLabel.BackColor = Color.Blue;
            if (miLabel.Location.X < x)
            {
                miLabel.Location = new Point(miLabel.Location.X + 5, 0);
                return;
            }
            if (miLabel.Location.Y < y)
            {
                miLabel.Location = new Point(miLabel.Location.X, miLabel.Location.Y+5);
                return;
            }

            x += 50;
            miLabel.BackColor = Color.White;
            timer1.Stop();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Label miLabel = pilaLabel.Peek();
            miLabel.BackColor = Color.Red;
            if (miLabel.Location.Y > 0)
            {
                miLabel.Location = new Point(miLabel.Location.X, miLabel.Location.Y - 5);
                return;
            }
            if (miLabel.Location.X > 0)
            {
                miLabel.Location = new Point(miLabel.Location.X - 5, 0);
                return;
            }
            pilaLabel.Pop();
            panel1.Controls.Remove(miLabel);
            x -= 50;
            timer2.Stop();
        }
    }
}
