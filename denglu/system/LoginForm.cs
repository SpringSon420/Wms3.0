using WmsBLL;
using WmsCommon;
using WmsModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelPhiUI
{
    public partial class LoginForm : Form
    {
        string path = System.Environment.CurrentDirectory + @"\loginUser.config";//配置文件位置
        public static string login_pro;
        public static string login_name = "";
        private Main mainForm;
      
        public LoginForm(Main main)
        {
            mainForm = main;
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            //提示
            this.toolTip1.SetToolTip(this.comboBox1, "请输入用户名。");
            this.toolTip1.SetToolTip(this.pwdTbx, "请输入密码。");
            #region 加载配置文件中保存的用户数据
            StreamReader rd = new StreamReader(path, Encoding.Default);
            string strReadline;
            while ((strReadline = rd.ReadLine()) != null)
            {
                comboBox1.Items.Add(strReadline);//添加item
            }
            rd.Close();
            #endregion
        }

        // 传入配置文件路径 读其中数据 返回整条字符串
        private string Read(string path)
        {
            StreamReader rd = new StreamReader(path, Encoding.Default);
            string strReadline;
            string result = "";
            while ((strReadline = rd.ReadLine()) != null)
            {
                result += strReadline;
            }
            rd.Close();
            return result;
        }
       
        private void loginBtn_Click(object sender, EventArgs e)
        {
            #region 登录逻辑 
            if (string.IsNullOrEmpty(this.comboBox1.Text.Trim()))
            {
                toolTip1.Show("请输入用户名！", this.comboBox1, 1000);
                this.comboBox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.pwdTbx.Text))
            {
                toolTip1.Show("请输入密码！", this.pwdTbx, 1000);
                this.pwdTbx.Focus();
                return;
            }
            //登录
            try
            {
                bool flag = LoginManager.CheckLogin(new LoginUser(this.comboBox1.Text, this.pwdTbx.Text));
                if (flag)
                {
                    //保存登录名及密码
                    login_name = this.comboBox1.Text.Trim();
                    login_pro= LoginManager.GetPro(login_name);
                    mainForm.Enabled = true;
                    mainForm.label1.Visible = true;
                    mainForm.label13.Text = login_name;
                    mainForm.label13.Visible = true;
                    mainForm.label3.Visible = true;
                    if (login_pro == "0")
                    {
                        mainForm.pro.Visible = true;
                        mainForm.pro.Text = "管理员";
                    }
                    if (login_pro == "1")
                    {
                        mainForm.pro.Visible = true;
                        mainForm.pro.Text = "普通用户";
                    }
                    this.Hide();
                    //先读取 判断文件中有无 该name 有则不写 没有再写入 防止重复
                    string rs = Read(path);
                    if (rs.Contains(login_name))
                    {
                        //配置文件已有该name 不再写入 登录即可
                    }
                    else  
                    {
                        //写入
                        try
                        {
                            StreamWriter sw = new StreamWriter(path, true);//加true 则逐行追加 否则会替换原来的数据 只保存一行
                            sw.WriteLine(login_name);
                            sw.Dispose();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("未找到配置文件或文件被占用");
                        }

                    }
                }
                else
                {
                    MessageBox.Show(" Sorry! 用户名或密码输入错误。", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("数据库异常：" + ex.Message);
            }
            #endregion
        }
        
    }
}
