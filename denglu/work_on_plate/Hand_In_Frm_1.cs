using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WmsCommon;
using WmsModel;

namespace denglu.work_on_plate
{
    public partial class Hand_In_Frm_1 : Form
    {
        public Hand_In_Frm_1()
        {
            InitializeComponent();
        }

        private void Hand_In_Frm_1_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            ConnServer();
            
        }
        // 入库
        IMsg msg = null;
        private void button1_Click(object sender, EventArgs e)
        {

            msg = WmsCommon.UdpClient.Ins.SendOutDb("A12345", "X1111");
           // textBox1.Text += "\r\n 出库信息：" + msg.strFrm;


            //if (textBox1.Text == "")
            //{
            //    MessageBox.Show("sorry,料号输入为空导致系统未找到胶盘，出库失败！","WMS Message");
            //}
            //else
            //{//发送
            //    try
            //    {
            //        ConnServer();
            //        label3.Visible = true;
            //        DialogResult ds = MessageBox.Show("入库指令发送成功，等待出盘...", "WMS Message");
            //        if (ds == DialogResult.OK)
            //        {
            //            this.Visible=false;
            //            Hand_In_Frm_2 in_Frm_2 = new Hand_In_Frm_2();

            //            in_Frm_2.ShowDialog();

            //        }

            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }

            //}

        }

   
        private void ConnServer()
        {
            //Client端  >>  服务端
            //WmsCommon.UdpClient.Ins = new WmsCommon.UdpClient("192.168.0.220", 6100, "192.168.0.90", 6000, 2, Ins_E_ModForm, null);
            //WmsCommon.UdpClient.Ins.SendThr();

            WmsCommon.UdpClient.Ins = new WmsCommon.UdpClient("127.0.0.1", 6100, "127.0.0.1", 6000, 2, Ins_E_ModForm, null);
            WmsCommon.UdpClient.Ins.SendThr();
            //UdpServer.Ins = new UdpServer[1];
            //UdpServer.Ins[0] = new UdpServer(0, "192.168.0.90", 6000, "192.168.0.90", 6100, Form1_E_ModForm);
            //UdpServer.Ins[0].SendThr();

        }
      
        private void Ins_E_ModForm(IMsg obj)
        {
            if (textBox2.InvokeRequired)
            {
                tBox2.Invoke(new Action<IMsg>(Ins_E_ModForm), obj);
                return;
            }
            tBox2.Text += "\r\n" + DateTime.Now.ToString() + "--" + obj.DaType + "--" + obj.strFrm;
        }


        //test
        private void button3_Click(object sender, EventArgs e)
        {
            string pn = this.textBox2.Text.Trim();
            if (pn != "")
            {
                //小胶盘
                //SqlHelper sqlHelper = new SqlHelper();
                //String sql = " select * from Sys_small where pn= '" + pn + "' ";
                //SqlDataReader sdr = sqlHelper.reder(sql);
                //if (sdr.HasRows)
                //{
                //    sdr.Read();
                //    string pN = (string)sdr["pn"];
                //    int sets = (int)sdr["sets"];
                //    int type = (int)sdr["type"];
                //    int mtr_num = (int)sdr["mtr_num"];
                //    test t = new test();
                //    t.label8.Text = pN;
                //    t.label1.Text = mtr_num.ToString();
                //    t.label3.Text = sets.ToString();
                //    t.label5.Text = type.ToString();
                //    t.ShowDialog();
                //}
                //else
                //{
                //    MessageBox.Show("sorry,此胶盘编号不存在，请检查输入是否有误", "WMS Message");
                //}

                //大胶盘
                SqlHelper sqlHelper = new SqlHelper();
                String sql = " select * from [Sys_big] where pn= '" + pn + "' ";
                SqlDataReader sdr = sqlHelper.reder(sql);
                if (sdr.HasRows)
                {
                    sdr.Read();
                    string pN = (string)sdr["pn"];
                    int mtr_num = (int)sdr["mtr_num"];
                    int type = Convert.ToInt32(sdr["type_five"]);
                    int state = Convert.ToInt32(sdr["state"]);
                    test2 t = new test2();
                    t.label8.Text = pN;
                    t.label35.Text = mtr_num.ToString();
                    if (state == 1)
                    {
                        t.label57.Text = "满盘";
                    }
                    t.label60.Text = type.ToString();
                    t.ShowDialog();
                }
                else
                {
                    MessageBox.Show("sorry,此胶盘编号不存在，请检查输入是否有误", "WMS Message");
                }
            }
        }
    }
}
