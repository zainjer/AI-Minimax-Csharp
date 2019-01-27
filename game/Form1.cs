using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        
        Car p1 = new Car();
        Car p2 = new Car();


        public Form1()
        {
            InitializeComponent();

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            comboBox2.SelectedIndex = 0;
            informationPanel.Hide();
            TurnPanel.Hide();
            Exitbtn.Hide();
            restartbtn.Hide();

        }
        float x=200, y=550;
        float x1 = 450,y1=550;
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.FillRectangle(Brushes.White, x, y, 15, 70);
            e.Graphics.FillRectangle(Brushes.White, x, y, 32, 32);
            e.Graphics.FillRectangle(Brushes.White, x1, y1, 32, 32);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dragger(object sender, MouseEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startpanel.Hide();
            informationPanel.Show();
            restartbtn.Show();
            Exitbtn.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RULES");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string playername = textBox1.Text;
            string color = comboBox2.SelectedItem.ToString();
            p1 = Car.CreateCar(playername, color);
            p2 = Car.CreateCar("Computer", "Black");
            informationPanel.Hide();
            TurnPanel.Show();
            //Weight: { 0}\nAgility: { 1}\nGrip: { 2}\nOwner: { 3}\nColor: { 4}\nStep Power: { 5}\nStatus: { 6}\nDestroyed: { 7}
            //", obj.weight, obj.agility, obj.grip, obj.owner, obj.color, obj.step_power, obj.status, obj.destroyed
            StatusBox.Text = "Car Owner: \t"+p1.owner+"\nColor: \t\t"+p1.color+"\nWeight: "+p1.weight+"\nAgility: "+p1.agility+"\nGrip: "+p1.grip+"\nStatus:";
            StepPowerlbl.Text = "Step Power: "+p1.step_power;
        }

        private void TurnPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void StepPowerlbl_Click(object sender, EventArgs e)
        {

        }
        private void button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
           
        }

        private void play(bool player,float stepPower)
        {
            for (int i = 0; i <= 9; i++)
            {
                if (player)
                {
                    y -= stepPower;
                    player = false;
                }
                else
                {
                    y1 -= stepPower;
                    player = true;
                }
            }
            this.Refresh();
        }

        private void Weight_Click(object sender, EventArgs e)
        {

            turn(1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            turn(2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            turn(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
             //   y -= 30;
            
            this.Refresh();
            Application.DoEvents();
        }
        void turn(int ch)
        {
            Car.TakeTurn(p1, ch);
            play(true,p1.step_power);
            StepPowerlbl.Text = "Step Power: "+p1.step_power;
            Node start = Car.GenerateTree(5, p2);
            String cpuRes = Node.minimax(start);
            
            if (cpuRes == "W")
            {
                Car.TakeTurn(p2, 1);
                play(false, p2.step_power);

            }
            else if (cpuRes == "A")
            {
                Car.TakeTurn(p2, 2);
                play(false, p2.step_power);
            }
            else
            {
                Car.TakeTurn(p2, 3);
                play(false, p2.step_power);
            }
            if (y <= 0 && y1 <= 0)
                MessageBox.Show("Draw", "Game Draw");
            else
            { 
                if (y <= 0)
                    MessageBox.Show("You Won", "Goal Reached");
           
                if(y1 <= 0)
                    MessageBox.Show("Cpu Won", "Goal Not Reached");
            }
        }

        
}}
