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
using System.Runtime.Loader;
using System.Resources;

using System.Runtime.InteropServices;
using System.Diagnostics;

//using System.Net.WebSockets;
using System.Threading;

using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;

//using System;
//using System.Collections.Generic;
using System.Security.Cryptography;
//using System.Text;
using WebSocketSharp;
using Newtonsoft.Json.Linq;
//using System.Threading.Tasks;
//using OBSWebsocketDotNet.Types;
using Newtonsoft.Json;
using System.Collections.Concurrent;
//using System.Diagnostics;


namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        List<Button> btn_list;
        List<List<Custom_Panel>> panel_list;
        int layout_prev_selected;
        int layout;

        public OBSWebsocket obs;
        //protected OBSWebsocket obs;
        //WebSocket client;

        //[DllImport("kernel32.dll")]
        public Form1()
        {
            InitializeComponent();
            //AssemblyLoadContext.Default.LoadFromAssemblyPath(@"H:\Projet_Streamlabs\dotNET_CORE\WindowsFormsApp1\WindowsFormsApp1\dlls\Dll1.dll");
            
            panel_list = new List<List<Custom_Panel>>();
            panel_list.Add(new List<Custom_Panel>());
            panel_list.Add(new List<Custom_Panel>());
            layout_prev_selected = -1;
            layout = 0;

            obs = new OBSWebsocket();

            obs.Connected += onConnect;
            obs.Disconnected += onDisconnect;
        }

        private void Fill_panel_layout()
        {
            int i;
            int j;

            i = 0;
            j = 0;

            Size panel_size;
            List<Point> panel_locs;

            panel_size = new Size();
            panel_locs = new List<Point>();

            //TextBox_tab_name.Text = Convert.ToString(layout);

            if (layout == 15)
            {
                panel_size.Height = (tabPage1.Size.Height / 3) - 75;
                panel_size.Width = (tabPage1.Size.Width / 5) - 75;

                while (i < 15)
                {
                    
                    panel_locs.Add(new Point());
                    ++i;
                }
                i = 0;
                /*while(i < panel_list.Count)
                {
                    while(j < 15)
                    {

                    }
                }*/


                panel_locs[0] = new Point((panel_size.Width * 0) + (50 * 1), (panel_size.Height * 0) + 50);
                panel_locs[1] = new Point((panel_size.Width * 1) + (50 * 2), (panel_size.Height * 0) + 50);
                panel_locs[2] = new Point((panel_size.Width * 2) + (50 * 3), (panel_size.Height * 0) + 50);
                panel_locs[3] = new Point((panel_size.Width * 3) + (50 * 4), (panel_size.Height * 0) + 50);
                panel_locs[4] = new Point((panel_size.Width * 4) + (50 * 5), (panel_size.Height * 0) + 50);
                panel_locs[5] = new Point((panel_size.Width * 0) + (50 * 1), (panel_size.Height * 1) + 100);
                panel_locs[6] = new Point((panel_size.Width * 1) + (50 * 2), (panel_size.Height * 1) + 100);
                panel_locs[7] = new Point((panel_size.Width * 2) + (50 * 3), (panel_size.Height * 1) + 100);
                panel_locs[8] = new Point((panel_size.Width * 3) + (50 * 4), (panel_size.Height * 1) + 100);
                panel_locs[9] = new Point((panel_size.Width * 4) + (50 * 5), (panel_size.Height * 1) + 100);
                panel_locs[10] = new Point((panel_size.Width * 0) + (50 * 1), (panel_size.Height * 2) + 150);
                panel_locs[11] = new Point((panel_size.Width * 1) + (50 * 2), (panel_size.Height * 2) + 150);
                panel_locs[12] = new Point((panel_size.Width * 2) + (50 * 3), (panel_size.Height * 2) + 150);
                panel_locs[13] = new Point((panel_size.Width * 3) + (50 * 4), (panel_size.Height * 2) + 150);
                panel_locs[14] = new Point((panel_size.Width * 4) + (50 * 5), (panel_size.Height * 2) + 150);
                //panel_locs[0].Y = 50;
            }
            else if (layout == 32)
            {
                panel_size.Height = (tabPage1.Size.Height / 4) - 60;
                panel_size.Width = (tabPage1.Size.Width / 8) - 60;

                while (i < 32)
                {
                    panel_locs.Add(new Point());
                    ++i;
                }
                panel_locs[0] = new Point((panel_size.Width * 0) + (40 * 1), (panel_size.Height * 0) + 40);
                panel_locs[1] = new Point((panel_size.Width * 1) + (40 * 2), (panel_size.Height * 0) + 40);
                panel_locs[2] = new Point((panel_size.Width * 2) + (40 * 3), (panel_size.Height * 0) + 40);
                panel_locs[3] = new Point((panel_size.Width * 3) + (40 * 4), (panel_size.Height * 0) + 40);
                panel_locs[4] = new Point((panel_size.Width * 4) + (40 * 5), (panel_size.Height * 0) + 40);
                panel_locs[5] = new Point((panel_size.Width * 5) + (40 * 6), (panel_size.Height * 0) + 40);
                panel_locs[6] = new Point((panel_size.Width * 6) + (40 * 7), (panel_size.Height * 0) + 40);
                panel_locs[7] = new Point((panel_size.Width * 7) + (40 * 8), (panel_size.Height * 0) + 40);
                panel_locs[8] = new Point((panel_size.Width * 0) + (40 * 1), (panel_size.Height * 1) + 80);
                panel_locs[9] = new Point((panel_size.Width * 1) + (40 * 2), (panel_size.Height * 1) + 80);
                panel_locs[10] = new Point((panel_size.Width * 2) + (40 * 3), (panel_size.Height * 1) + 80);
                panel_locs[11] = new Point((panel_size.Width * 3) + (40 * 4), (panel_size.Height * 1) + 80);
                panel_locs[12] = new Point((panel_size.Width * 4) + (40 * 5), (panel_size.Height * 1) + 80);
                panel_locs[13] = new Point((panel_size.Width * 5) + (40 * 6), (panel_size.Height * 1) + 80);
                panel_locs[14] = new Point((panel_size.Width * 6) + (40 * 7), (panel_size.Height * 1) + 80);
                panel_locs[15] = new Point((panel_size.Width * 7) + (40 * 8), (panel_size.Height * 1) + 80);
                panel_locs[16] = new Point((panel_size.Width * 0) + (40 * 1), (panel_size.Height * 2) + 120);
                panel_locs[17] = new Point((panel_size.Width * 1) + (40 * 2), (panel_size.Height * 2) + 120);
                panel_locs[18] = new Point((panel_size.Width * 2) + (40 * 3), (panel_size.Height * 2) + 120);
                panel_locs[19] = new Point((panel_size.Width * 3) + (40 * 4), (panel_size.Height * 2) + 120);
                panel_locs[20] = new Point((panel_size.Width * 4) + (40 * 5), (panel_size.Height * 2) + 120);
                panel_locs[21] = new Point((panel_size.Width * 5) + (40 * 6), (panel_size.Height * 2) + 120);
                panel_locs[22] = new Point((panel_size.Width * 6) + (40 * 7), (panel_size.Height * 2) + 120);
                panel_locs[23] = new Point((panel_size.Width * 7) + (40 * 8), (panel_size.Height * 2) + 120);
                panel_locs[24] = new Point((panel_size.Width * 0) + (40 * 1), (panel_size.Height * 3) + 160);
                panel_locs[25] = new Point((panel_size.Width * 1) + (40 * 2), (panel_size.Height * 3) + 160);
                panel_locs[26] = new Point((panel_size.Width * 2) + (40 * 3), (panel_size.Height * 3) + 160);
                panel_locs[27] = new Point((panel_size.Width * 3) + (40 * 4), (panel_size.Height * 3) + 160);
                panel_locs[28] = new Point((panel_size.Width * 4) + (40 * 5), (panel_size.Height * 3) + 160);
                panel_locs[29] = new Point((panel_size.Width * 5) + (40 * 6), (panel_size.Height * 3) + 160);
                panel_locs[30] = new Point((panel_size.Width * 6) + (40 * 7), (panel_size.Height * 3) + 160);
                panel_locs[31] = new Point((panel_size.Width * 7) + (40 * 8), (panel_size.Height * 3) + 160);

                //panel_locs[0].Y = 40;
            }

            i = 0;

            //TODO change ça pour garder les panels qui ont déjà été "validés"

            while (i < tabControl_Editor.TabPages.Count)
            {
                tabControl_Editor.TabPages[i].Controls.Clear();
                ++i;
            }

            i = 0;

            while (i < panel_list.Count)
            {
                while (j < layout)
                {
                    panel_list[i].Add(new Custom_Panel(this));
                    panel_list[i][j].BackColor = Color.DarkGray;
                    panel_list[i][j].BackgroundImage = (Image) Properties.Resources.ResourceManager.GetObject("_158");
                    panel_list[i][j].BackgroundImageLayout = ImageLayout.Center;
                    panel_list[i][j].BorderStyle = BorderStyle.FixedSingle;
                    panel_list[i][j].Location = panel_locs[j]; // A revoir
                    panel_list[i][j].Size = panel_size; // A revoir
                    //panel_list[i][j].Self_Panel = panel_list[i][j];
                    panel_list[i][j].Click += Add_Panel_Command;
                    tabControl_Editor.TabPages[i].Controls.Add(panel_list[i][j]);
                    ++j;
                }
                j = 0;
                ++i;
            }
        }

        private void Add_Panel_Command(object sender, EventArgs e)
        {
            //listBox1.Items.Add("clicked");
            Form2 Cmd_btn_chooser = new Form2(this, (Custom_Panel)sender);
            Cmd_btn_chooser.StartPosition = FormStartPosition.CenterParent;
            Cmd_btn_chooser.Show();
            //Cmd_btn_chooser.TopLevel;
            //Cmd_btn_chooser.Parent = this;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;


            if (comboBox1.SelectedIndex == 0 && layout_prev_selected != comboBox1.SelectedIndex)
            {
                layout = 15;
                /*
                layout_prev_selected = comboBox1.SelectedIndex;
               
                if (btn_list.Count == 0)
                {
                    i = 0;
                    while (i < 15)
                    {
                        btn_list.Add(new Button());
                        ++i;
                    }
                    splitContainer1.Panel2.Controls.Add();
                }
                */
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                layout = 32;
            }
            Fill_panel_layout();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //TODO ajouter ou enlever des tabs en fonction de la valeur choisi **(value -1)**
        }

        private void btn_img_Click(object sender, EventArgs e)
        {

        }

        private void btn_color_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox_tab_name.Text = tabControl_Editor.SelectedTab.Text;
        }

        private void TextBox_tab_name_TextChanged(object sender, EventArgs e)
        {
            tabControl_Editor.SelectedTab.Text = TextBox_tab_name.Text;
        }

        private void Panel_list_0_Click(object sender, EventArgs e)
        {

        }

        private void btn_publish_Click(object sender, EventArgs e)
        {
            Form streamdeck_fs = new Form() 
            { 
                FormBorderStyle = FormBorderStyle.None, 
                WindowState = FormWindowState.Maximized,
                StartPosition=FormStartPosition.Manual, 
                Location= Screen.AllScreens[2].Bounds.Location 
            };

            foreach(Screen scr in Screen.AllScreens)
            {
                listBox1.Items.Add(scr.Bounds.Width.ToString() + " " + scr.Bounds.Height.ToString());
            }

            /*streamdeck_fs.FormBorderStyle = FormBorderStyle.None;
            streamdeck_fs.WindowState = FormWindowState.Maximized;

            streamdeck_fs.StartPosition = FormStartPosition.Manual;
            streamdeck_fs.Location = Screen.AllScreens[1].Bounds.Location;*/

            TabControl tabControl_view = new TabControl();
            //TabControl tabControl_view = tabControl_Editor;

            copy_tabControl(tabControl_Editor, tabControl_view);

            /*
            streamdeck_fs.FormBorderStyle = FormBorderStyle.None;
            streamdeck_fs.WindowState = FormWindowState.Maximized;

            streamdeck_fs.StartPosition = FormStartPosition.Manual;
            streamdeck_fs.Location = Screen.AllScreens[1].Bounds.Location;*/

            streamdeck_fs.Controls.Add(tabControl_view);

            streamdeck_fs.Show();
        }

        private void copy_tabControl(TabControl TC_src, TabControl TC_dest)
        {
            int i = 0;
            int j = 0;

            
            while (i < TC_src.TabCount)
            {
                TC_dest.TabPages.Add(TC_src.TabPages[i].Text);
                ++i;
            }
            i = 0;
            while (i < TC_dest.TabCount)
            {
                while (j < TC_src.TabPages[i].Controls.Count)
                {
                    
                    if (panel_list[i][j].Activated)
                    {
                        Custom_Panel panel = new Custom_Panel(this);
                        panel.BackColor = panel_list[i][j].BackColor;
                        panel.BackgroundImage = panel_list[i][j].BackgroundImage;
                        panel.BackgroundImageLayout = ImageLayout.Stretch;
                        panel.BorderStyle = BorderStyle.FixedSingle;
                        panel.Location = panel_list[i][j].Location; // A revoir
                        panel.Size = panel_list[i][j].Size; // A revoir
                        panel.Click += panel_list[i][j].Futur_Click;
                        panel.Set_Label(panel_list[i][j].Text.Text);
                        TC_dest.TabPages[i].Controls.Add(panel);
                    }
                    //TC_dest.TabPages[i].Controls[j].Click += panel.Futur_Click;
                    //TC_dest.TabPages[i].Controls[j]
                    ++j;
                    
                }
                j = 0;
                ++i;
            }

            TC_dest.Location = new Point(TC_src.Location.X, TC_src.Location.Y);
            TC_dest.Size = new Size(TC_src.Size.Width, TC_src.Size.Height);

            

            /*
            using (ResXResourceWriter resx = new ResXResourceWriter(@".\custom_panel.resx"))
            {
                resx.AddResource("TC_dest", TC_src);
            }

            using (ResXResourceSet resr = new ResXResourceSet(@";\custom_panel.resx"))
            {
                TC_dest = (TabControl) resr.GetObject("TC_dest");
            }

            using (ResXResourceSet resr = new ResXResourceSet(@";\custom_panel.resx"))
            {
                resr.Dispose();
                //TC_dest = (TabControl)resr.GetObject("TC_dest");
            }*/
            /*
                foreach (TabPage tab in TC_src.TabPages)
                {
                    TC_dest.TabPages.Add(tab.Text);
                    foreach (Control ctrl in TC_src.Controls)
                    {
                        Control ctrl_tmp = new Control();
                        ctrl_tmp = ctrl;

                        TC_dest.Controls.Add(ctrl_tmp);
                    }
                }*/
            // foreach custom_panel.click += custom_panel.futur_click;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            string procName = "toto";
            int procPID = 0;
            int ProcIndex = 0;
            ProcessModuleCollection proc_modules;
            Process[] Procs = Process.GetProcesses();

            while (i < Procs.Length)
            {
                //Label labete = new Label();
                //labete.Text = Procs[i].ProcessName;
                //listBox1.Items.Add(Procs[i].ProcessName);
                //listBox1.Items.Add(labete);
                if (Procs[i].ProcessName == "obs64")
                {
                    procName = Procs[i].ProcessName;
                    procPID = Procs[i].Id;
                    ProcIndex = i;
                    break;
                }
                ++i;
            }

            i = 0;

            //Commands obs = new Commands();





            //_obs.Connect("wss://127.0.0.1:4444", "");

            if (!obs.IsConnected)
            {
                obs.Connect("ws://192.168.1.22:4444", "");
                //obs.Connect("ws://127.0.0.1:4444", "");
                //List<SourceInfo> sources = obs.GetSourcesList();
                //obs.SetMute(sources.Where(s => s.Name == "Mic/Aux").FirstOrDefault().Name, true);
                /*while (i < sources.Count)
                {
                    listBox1.Items.Add(sources[i].Name);
                    ++i;
                    //if (sources[i].Name == "")
                }*/
                //obs.SetMute();
            }
            else
            {
                obs.Disconnect();
            }

            //Uri localhost = new Uri("wss://localhost:4444");

            //ClientWebSocket client = new ClientWebSocket();

            //WebSocket client = new WebSocket("wss://localhost:4444") { WaitTime = new TimeSpan(10)};
            //client.Connect();

            //client.ConnectAsync();

            //Uri localhost = new Uri("https://127.0.0.1:4444");

            //webso
            //client = new WebSocket("wss://localhost:4444");
            //client.OnMessage += websocket_message_handler;
            //client.Connect();
            //if (client.IsAlive)
            //{
            //    listBox1.Items.Add("connected");
            //}

            //CancellationTokenSource cts = new CancellationTokenSource();
            //CancellationToken ct = cts.Token;
            //listBox1.Items.Add(client.ConnectAsync(localhost, ct).Status.ToString());
            //client.SendAsync(, WebSocketMessageType.Text, );
            /*
            proc_modules = Process.GetProcessById(procPID).Modules;

            while (i < proc_modules.Count)
            {
                listBox1.Items.Add(proc_modules[i].ModuleName);
            }*/
            //button1.Text = name;//Convert.ToString(Procs[0].ProcessName);
        }

        

        private void onConnect(object sender, EventArgs e)
        {
            listBox1.Items.Add("Connected");
        }

        private void onDisconnect(object sender, EventArgs e)
        {
            listBox1.Items.Add("Disconnected");
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
