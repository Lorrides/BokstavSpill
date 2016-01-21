using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BokstavSpill2
{
    public partial class Form1 : Form
    {


        Random random = new Random();
        Stats stats = new Stats();

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Legger til en random nøkkel til listBoxen
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if (listBox1.Items.Count > 7 )
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game over");
                timer1.Stop();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //If the uesr pressed a key that's in the ListBox, remove it
            //and then make the game alittle faster
            if ( listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                if (timer1.Interval > 400)
                    timer1.Interval -= 10;
                if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                if (timer1.Interval > 100)
                    timer1.Interval -= 2;
                difficultyProgressBar.Value = 800 - timer1.Interval;

                //The user pressd a correct key, so update the stats object
                //by calling its update() method with the argument true
                stats.Update(true);
                }
            else
            {
                //the user prossed an incorrect key, so update the Stas object
                //by calling its Update() method with tha argument false
                stats.Update(false);
            }
            //uppdate the labels on the StatusStrip
            correctLabel.Text = "Correct: " + stats.Correct;
            missedLabel.Text = "Missed: " + stats.Missed;
            totalLabel.Text = "Total: " + stats.Total;
            accuracyLabel.Text = "Accuracy: " + stats.Accuracy +"%";

        }
    }
}
