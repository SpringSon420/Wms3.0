using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denglu.work_on_plate
{
    public partial class Hand_In_Frm_2 : Form
    {
        public Hand_In_Frm_2()
        {
            InitializeComponent();
        }

        private void Hand_In_Frm_2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            try
            {
                int set = Convert.ToInt32(label3.Text.Trim());

                foreach (Control ctl in Controls)
                {
                    if (ctl is ComboBox)
                    {
                        ComboBox con = ctl as ComboBox;
                        con.Text = label3.Text.Trim();
                        for (int i = set; i > 0; i--)
                        {
                            con.Items.Add(i);
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        //
        private void BianLi()
        {

            int set = Convert.ToInt32(label3.Text.Trim());

            foreach (Control ctl in Controls)
            {
                if (ctl is ComboBox)
                {
                    ComboBox con = ctl as ComboBox;
                    for (int i = set; i > 0; i++)
                    {
                        con.Items.Add(i);
                    }
                }

            }
        }
        //接受扫描 实际对应接收扫描枪扫描胶盘信号
        private void button1_Click(object sender, EventArgs e)
        {
            this.label25.Text = "已扫描";
            this.label25.ForeColor = SystemColors.ActiveCaption;
        }
        //提交入库
        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (label25.Text != "已扫描")
            {
                MessageBox.Show("sorry,胶盘未完成扫描，拒绝提交入库！", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (renwuCbx.Checked == false)
            {
                MessageBox.Show("sorry,未指定任务已完成，拒绝提交入库！", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (manCbx.Checked == false && feimanCbx.Checked == false)
            {
                MessageBox.Show("sorry,未指定胶盘状态'满盘'或'非满'，拒绝提交入库！", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    ConnServer();
                }
                catch (Exception)
                {

                    throw;
                }
               // MessageBox.Show("提交成功", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);

            }
        }

        private void ConnServer()
        {
            string position = "1";//实际从主窗体 提取
            string plate_pn = label8.Text.Trim();//实际从方法外提取 
            string run_num = position + DateTime.Now.ToLongTimeString().ToString().Replace(":", "");
            IPEndPoint udpPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10002);//client
            UdpClient udpClient = new UdpClient(udpPoint);
            string sendMsg = SendCmd_BC(position, plate_pn, run_num);
            textBox1.Text = sendMsg;
            byte[] sendData = Encoding.Default.GetBytes(sendMsg);
            IPEndPoint targetPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10001);//server
            udpClient.Send(sendData, sendData.Length, targetPoint);
            udpClient.Close();
        }
        //摆盘入库
        private string SendCmd_BC(string position,  string plate_pn, string run_num)
        {
            string cmd = "HEAD" + 10 + "BC" + position  + plate_pn + run_num + "END";
            return cmd;
        }
    }
}
