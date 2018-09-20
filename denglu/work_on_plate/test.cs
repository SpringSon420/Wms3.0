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
using WmsCommon;

namespace denglu.work_on_plate
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

     

        private void test_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

           int mtr_num= Convert.ToInt32(this.label1.Text);//物料种类
           int sets = Convert.ToInt32(this.label3.Text);//set
           Label[] pList = new Label[24];
            pList[0] = lb1; pList[1] = lb2; pList[2] = lb3; pList[3] = lb4;
            pList[4] = lb5; pList[5] = lb6; pList[6] = lb7; pList[7] = lb8;
            pList[8] = lb9; pList[9] = lb10; pList[10] = lb11; pList[11] = lb12;
            pList[12] = lb13; pList[13] = lb14; pList[14] = lb15; pList[15] = lb16;
            pList[16] = lb17; pList[17] = lb18; pList[18] = lb19; pList[19] = lb20;
            pList[20] = lb21;

            List<String> li = Find_Mtr_Num();//查找物料号
            //label
            for (int i = 0; i < mtr_num; i++)
            {
                if (pList[i].Visible == false)
                {
                    pList[i].Visible = true;
                    pList[i].Text = li[i]+":数量";
                }
            }
            //for (int i = 0; i < li.Count(); i++)
            //{

            //}

            //combox
            ComboBox[] combox = new ComboBox[24];
            combox[0] =comboBox1 ; combox[1] = comboBox2; combox[2] = comboBox3; combox[3] = comboBox4;
            combox[4] = comboBox5; combox[5] = comboBox6; combox[6] = comboBox7; combox[7] = comboBox8;
            combox[8] = comboBox9; combox[9] = comboBox10; combox[10] = comboBox11; combox[11] = comboBox12;
            combox[12] = comboBox13; combox[13] = comboBox14; combox[14] = comboBox15; combox[15] = comboBox16;
            combox[16] = comboBox17; combox[17] = comboBox18; combox[18] = comboBox19; combox[19] = comboBox20;
            combox[20] = comboBox21;
            foreach (Control ctl in Controls)
            {
                if (ctl is ComboBox)
                {
                    ComboBox con = ctl as ComboBox;
                    con.Text = label3.Text.Trim();
                    for (int i = sets; i > 0; i--)
                    {
                        con.Items.Add(i);
                    }
                }
            }
            for (int i = 0; i < mtr_num; i++)
            {
                combox[i].Visible = true;
            }


            

        }
        //接收扫描
        private void button1_Click(object sender, EventArgs e)
        {
            this.label25.Text = "已扫描";
            this.label25.ForeColor = SystemColors.ActiveCaption;
        }

        //查询物料编号
        private List<string> Find_Mtr_Num()
        {
            int type = Convert.ToInt32(this.label5.Text);//type
            SqlHelper sqlHelper = new SqlHelper();
            String sql = " select mtr_pn from Sys_small_type where type= " + type;
            DataSet ds = sqlHelper.DataSetSearch(sql);
            List<String> li = new List<string>();
            //遍历一个表多行一列
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                li.Add(row[0].ToString());
            }
            return li;
        }

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
            //string position = "1";//实际从主窗体 提取
            //string plate_pn = label8.Text.Trim();//实际从方法外提取 
            //string run_num = position + DateTime.Now.ToLongTimeString().ToString().Replace(":", "");
            //IPEndPoint udpPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10002);//client
            //UdpClient udpClient = new UdpClient(udpPoint);
            //string sendMsg = SendCmd_BC(position, plate_pn, run_num);
            //textBox1.Text = sendMsg;
            //byte[] sendData = Encoding.Default.GetBytes(sendMsg);
            //IPEndPoint targetPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10001);//server
            //udpClient.Send(sendData, sendData.Length, targetPoint);
            //udpClient.Close();
        }
        //摆盘入库
        private string SendCmd_BC(string position, string plate_pn, string run_num)
        {
            string cmd = "HEAD" + 10 + "BC" + position + plate_pn + run_num + "END";
            return cmd;
        }

        private void manCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (this.manCbx.Checked)
            {
                manCbx.Checked = true;
                feimanCbx.Checked = false;
            }
        }

        private void feimanCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (feimanCbx.Checked)
            {
                feimanCbx.Checked = true;
                manCbx.Checked = false;
            }
        }
    }
}
