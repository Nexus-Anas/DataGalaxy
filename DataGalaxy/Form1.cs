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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        //////////////////////////////////////////////////////////////////////////////////////////
        private const int cGrip = 16;
        private const int cCaption = 40;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                var pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);

                if (pos.Y <= cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }

                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }

                if (pos.X <= cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)16;
                    return;
                }

                if (pos.X <= cGrip)
                {
                    m.Result = (IntPtr)10;
                    return;
                }

                if (pos.X >= ClientSize.Width - cGrip)
                {
                    m.Result = (IntPtr)11;
                    return;
                }

                if (pos.Y <= cGrip)
                {
                    m.Result = (IntPtr)12;
                    return;
                }

                if (pos.Y >= ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)15;
                    return;
                }
            }
            base.WndProc(ref m);
        }






        private bool _mouseDown;
        private Point _startPoint = new Point(0, 0);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true; _startPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                var point = PointToScreen(e.Location);
                Location = new Point(point.X - _startPoint.X, point.Y - _startPoint.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e) => _mouseDown = false;

        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void btnAbout_Click(object sender, EventArgs e) => MessageBox.Show("Hi there!\nPlease support me on:\nhttps://github.com/The-Vigilante\nContact me on:\nanas.vigilante@gmail.com", "Message from Creator", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);








        //Python.
        private void btnPy_Click(object sender, EventArgs e) => Multipage.SetPage("tabPage2");
        private async Task initializePy() => await webViewPy.EnsureCoreWebView2Async(null);
        public async void InitPy()
        {
            await initializePy();
            webViewPy.CoreWebView2.Navigate("https://replit.com/");
        }

        private void btnExcel_Click(object sender, EventArgs e) => Multipage.SetPage("tabPage3");
        private async Task initializeExcel() => await webViewExcel.EnsureCoreWebView2Async(null);
        public async void InitExcel()
        {
            await initializeExcel();
            webViewExcel.CoreWebView2.Navigate("https://login.microsoftonline.com/common/oauth2/v2.0/authorize?client_id=4765445b-32c6-49b0-83e6-1d93765276ca&redirect_uri=https%3A%2F%2Fwww.office.com%2Flandingv2&response_type=code%20id_token&scope=openid%20profile%20https%3A%2F%2Fwww.office.com%2Fv2%2FOfficeHome.All&response_mode=form_post&nonce=638100180074965464.NmMwYTMyNWQtZjZiNS00NTkxLWE1N2MtODM2OWZlZjgyNjFmMDY4N2JmYWYtZTM4MS00YjAwLWExZTYtNWQ2NjRlYWEyM2Iy&ui_locales=en-US&mkt=en-US&state=dTK5lw5ewGdy3hwKEvqQ_RbzKt5OaXbpBYocjSF8drDAxv0mM8Kf6z3ZbUGGhKqnJ86roPmLpDKUVttkba5QVPXDTdb7LizHo8qF46V7_vhQHT_76xZDZThkr3CuSZ0Qv9fdYyfU3NBaVoi-o4N20jN0kM4QBRKOyEJN0L01-8wXF_VQ8yfF4YHQhjlvxrbbIUJ-KEF3UqUXjVZ0-GbB1z69fGUpyjuSqDnVdVRQOJlWNb4wDK_-cPfqfSmFlG8s8z9gF7pKbDU3O3buyaIPnPy3_2OB3r4l67peZFDqUlqJX6h3qLR1pXZI7OUW0TQV&x-client-SKU=ID_NETSTANDARD2_0&x-client-ver=6.16.0.0");
        }

        private void btnJup_Click(object sender, EventArgs e) => Multipage.SetPage("tabPage4");
        private async Task initializeJup() => await webViewJup.EnsureCoreWebView2Async(null);
        public async void InitJup()
        {
            await initializeJup();
            webViewJup.CoreWebView2.Navigate("https://jupyter.org/");
        }

        private void btnR_Click(object sender, EventArgs e) => Multipage.SetPage("tabPage5");
        private async Task initializeR() => await webViewR.EnsureCoreWebView2Async(null);
        public async void InitR()
        {
            await initializeR();
            webViewR.CoreWebView2.Navigate("https://posit.co/");
        }

        private void btnHigh_Click(object sender, EventArgs e) => Multipage.SetPage("tabPage6");
        private async Task initializeHigh() => await webViewHigh.EnsureCoreWebView2Async(null);
        public async void InitHigh()
        {
            await initializeHigh();
            webViewHigh.CoreWebView2.Navigate("https://www.highcharts.com/");
        }

        private void btnData_Click(object sender, EventArgs e) => Multipage.SetPage("tabPage7");
        private async Task initializeData() => await webViewData.EnsureCoreWebView2Async(null);
        public async void InitData()
        {
            await initializeData();
            webViewData.CoreWebView2.Navigate("https://www.datapine.com/");
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            if (btnPower.Text == "OFF")
            {
                InitPy(); InitExcel(); InitR(); InitJup(); InitHigh(); InitData();
                btnPy.Enabled = true; btnExcel.Enabled = true; btnR.Enabled = true;
                btnJup.Enabled = true; btnHigh.Enabled = true; btnData.Enabled = true;
                btnPower.BorderColor = Color.MediumSeaGreen;
                btnPower.Text = "ON";
            }
            else
            {
                btnPy.Enabled = false; btnExcel.Enabled = false; btnR.Enabled = false;
                btnJup.Enabled = false; btnHigh.Enabled = false; btnData.Enabled = false;
                btnPower.BorderColor = Color.Crimson;
                btnPower.Text = "OFF";
                Multipage.SetPage("tabPage1");
            }
        }
    }
}
