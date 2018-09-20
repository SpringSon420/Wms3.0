using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denglu
{
    public partial class test2 : Form
    {

        //主要功能 测试 抓取界面文字信息写入到 指定路径文件下 loginUser.config中（不写入重复数据）
        // 并且 当页面再次 加载时 将配置文件中的用户名 逐条读取显示
        public test2()
        {
            InitializeComponent();
        }

        string path = System.Environment.CurrentDirectory + @"\loginUser.config";
        private void button1_Click(object sender, EventArgs e)
        {
            string name= this.comboBox1.Text.ToString();
            if ( name== "abc"||name=="123")
            {
                //先读取 判断文件中有无 该name 有则不写 没有再写入 防止重复
               string rs= Read(path);
                if (rs.Contains(name))
                {
                    //什么也不做 登录
                    MessageBox.Show("name已经存在");
                }
                else  //写入
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(path, true);//加true 则逐行追加 否则会替换原来的数据 只保存一行
                        sw.WriteLine(name);
                        sw.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("未找到文件或文件被占用");
                    }

                }

            }
           
        }

        private void test2_Load(object sender, EventArgs e)
        {
            #region 读配置文件中用户数据 提前加载至combox容器
            StreamReader rd = new StreamReader(path, Encoding.Default);
            string strReadline;
            while ((strReadline = rd.ReadLine()) != null)
            {
                comboBox1.Items.Add(strReadline);//添加item
               
            }    
            rd.Close();
            #endregion
        }



        private string Read(string path) {
            StreamReader rd = new StreamReader(path, Encoding.Default);
            string strReadline;
            string result="";
            while ((strReadline = rd.ReadLine()) != null)
            {
                result+= strReadline;
            }
            rd.Close();
            return result;
        }
    }
}
