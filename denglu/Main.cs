using denglu;
using denglu.work_on_plate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelPhiUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void testBuJu_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            //获取当前时间  
            this.timer2.Interval = 1000;
            label12.Text = DateTime.Now.ToString();
            this.timer2.Start();
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            label14.Text = week;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToString();
        }
       
        private void systemAbout_Click(object sender, EventArgs e)
        {
            AboutSystemForm aboutSystemForm = new AboutSystemForm();
            aboutSystemForm.ShowDialog();
        }

        private void instructions_Click(object sender, EventArgs e)
        {
            OpenWendang("Helper.docx");
        }
        //打开word文档
        private void OpenWendang(string strname)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            string str = System.Windows.Forms.Application.StartupPath + "\\wendang\\" + strname;
            string strs = System.IO.Path.GetFullPath(str);
            string strhzm = System.IO.Path.GetExtension(str);
            if (strhzm.ToLower() == ".doc" || strhzm.ToLower() == ".docx")
            {
                //startInfo.FileName = "WINWORD.EXE"; 
                startInfo.FileName = "WPS.EXE";
                startInfo.Arguments = strs;
            }
            try
            {
                Process.Start(startInfo);
            }
            catch
            {
                MessageBox.Show("您电脑没有安装office软件，无法打开文件请安装再试谢谢！","提示:");
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SmallPlateForm smallPlateForm = new SmallPlateForm();
            smallPlateForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigPlateForm bigPlateForm = new BigPlateForm();
            bigPlateForm.ShowDialog();
;        }
        
        private void login_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(this);
            loginForm.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Cancel == MessageBox.Show("您点击了 '退出'按钮!,如果您真的要退出请点击'确定'。", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk))
            {
                e.Cancel = true;
            }
        }

        private void 手动入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hand_In_Frm_1 hand_In_Frm = new Hand_In_Frm_1();
            hand_In_Frm.ShowDialog();
        }

        private void 手动出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hand_Out_Frm_2 out_Frm_2 = new Hand_Out_Frm_2();
            out_Frm_2.ShowDialog();
        }

        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //权限判定
            if (LoginForm.login_pro == "0")
            {
                History history = new History();
                history.ShowDialog();
            }
            else
            {
                MessageBox.Show("sorry,您的权限不足，请尝试'管理员'身份登录。", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void 出库到现场ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hand_Out_Frm hand_Out_Frm = new Hand_Out_Frm();
            hand_Out_Frm.ShowDialog();
        }
        //本月内出入库记录
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            History_one_month history_One_Month = new History_one_month();
            history_One_Month.ShowDialog();
        }
    }
}
