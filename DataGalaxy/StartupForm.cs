using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGalaxy
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
            timer1.Start();
        }
        private int _sec;


        private void timer1_Tick(object sender, EventArgs e)
        {
            _sec++;
            if (_sec == 4)
            {
                timer1.Stop();
                new Form1().Show();
                Hide();
            }
        }
    }
}
