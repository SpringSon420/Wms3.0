
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denglu
{
    public partial class BigPlateForm : Form
    {
        public BigPlateForm()
        {
            InitializeComponent();
        }

        private void quitPbx_Click(object sender, EventArgs e)
        {
       
        }


        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (this.renwuCbx.Checked == false)
            {
                MessageBox.Show("Sorry，提交前未确定任务已完成,提交失败！", "提示");
                return;
            }
            if (this.manCbx.Checked == false && this.feimanCbx.Checked == false)
            {
                MessageBox.Show("Sorry，提交前未确认当前是否满盘,提交失败！", "提示");
                return;
            }
            if (this.manCbx.Checked == true && this.feimanCbx.Checked == true)
            {
                MessageBox.Show("Sorry，'满盘'和'非满'只能指定一种状态！", "提示");
                return;
            }
            DialogResult ds = MessageBox.Show("提交成功,当前任务已提交,等待入库。", "提示");
            if (ds == DialogResult.OK)
            {
                this.Close();
            }
        }

    

       
        //现阶段通过按钮点击 模拟物料每扫描一次 出现一条信息
        private void testBtn_Click(object sender, EventArgs e)
        {
            //法二
            Panel[] pList = new Panel[48];
            pList[0] = p1; pList[1] = p2; pList[2] = p3; pList[3] = p4;
            pList[4] = p5; pList[5] = p6; pList[6] = p7; pList[7] = p8;
            pList[8] = p9; pList[9] = p10; pList[10] = p11; pList[11] = p12;
            pList[12] = p13; pList[13] = p14; pList[14] = p15; pList[15] = p16;
            pList[16] = p17; pList[17] = p18; pList[18] = p19; pList[19] = p20;
            pList[20] = p21; pList[21] = p22; pList[22] = p23; pList[23] = p24;
            pList[24] = p25; pList[25] = p26; pList[26] = p27; pList[27] = p28;
            pList[28] = p29; pList[29] = p30; pList[30] = p31; pList[31] = p32;
            pList[32] = p33; pList[33] = p34; pList[34] = p35; pList[35] = p36;
            pList[36] = p37; pList[37] = p38; pList[38] = p39; pList[39] = p40;
            pList[40] = p41; pList[41] = p42; pList[42] = p43; pList[43] = p44;
            pList[44] = p45; pList[45] = p46; pList[46] = p47; pList[47] = p48;
            for (int i = 0; i < 48; i++)
            {
                if (pList[i].Visible == false)
                {
                    pList[i].Visible = true;
                    return;
                }
            }
            if (pList[47].Visible == true)
            {
                MessageBox.Show("Sorry!物料扫描次数已达上限, 请先入库！", "提示");
            }

        }

        private void BigPlateForm_Load(object sender, EventArgs e)
        {

  


        }

      
     

        private void p0_Paint(object sender, PaintEventArgs e)
        {
                //使用虚线绘制边框
                Pen pen1 = new Pen(Color.Green, 1);
                pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                pen1.DashPattern = new float[] { 4f, 2f };
                e.Graphics.DrawRectangle(pen1, 0, 0, this.p0.Width - 1, this.p0.Height - 1);

         
        }

        private void BigPlateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("当前摆盘任务还没有完成,确定要强行关闭吗！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }
    }
}
