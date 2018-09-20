using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denglu
{
    public partial class SmallPlateForm : Form
    {
        public SmallPlateForm()
        {
            InitializeComponent();
        }

      

        private void quitPbx_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry!当前摆盘任务还没有完成,窗体不能关闭！", "提示");
        }
        
   
       

     

      

        private void SmallPlateForm_Load(object sender, EventArgs e)
        {
            //遍历每一个combox;
            foreach (Control c in this.Controls)
            {
                ComboBox cb = c as ComboBox;
                if (cb != null)
                {
                    for (int i = 5; i > 0; i--)
                    {
                        cb.Items.Add(i);
                    }
                    cb.SelectedIndex = 0;
                }
            }
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

        private void SmallPlateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("当前摆盘任务还没有完成,确定要强行关闭吗！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }
    }
}
