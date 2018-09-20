using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WmsCommon;

namespace denglu
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            //string str = "select pn as 胶盘编号,case when in_out=1 then '入库' when in_out=2 then '出库' end as 出库或入库,case when small_big=1 then '小胶盘' when small_big=2 then '大胶盘'end as 小胶盘或大胶盘,time as 时间,num as 次数 from [Sys_history]  order by id";
            //fenye(str);//分页
            //LoadPage();//加载数据





            //表头居中
           
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //设置每个单元格的格式（居中)
                foreach (DataGridViewColumn item in this.dataGridView2.Columns)
                {
                    item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                //取消点击单元格时颜色偏差 取巧
                for (int i = 0; i < 5; i++)
                {
                    dataGridView2.DefaultCellStyle.SelectionBackColor = SystemColors.Control;
                    dataGridView2.Columns[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                }

                //禁用dataGridView列排序
                for (int i = 0; i < this.dataGridView2.Columns.Count; i++)
                {
                    this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            
            
        }

     


        #region 条件筛选
        private void Btn_Click(object sender, EventArgs e)
        {
            string pn = this.pnTbx.Text;
            pnTbx.BackColor = SystemColors.ActiveCaption;
            cbx.BackColor = SystemColors.Window;
            if (pn != "")
            {
                string str = " select pn as 胶盘编号,case when in_out=1 then '入库' when in_out=2 then '出库' end as 出库或入库,case when small_big=1 then '小胶盘' when small_big=2 then '大胶盘'end as 小胶盘或大胶盘,time as 时间,num as 次数 from [Sys_history] where pn='" + pn + "' order by id ";
                fenye(str);//分页
                LoadPage();//加载数据
            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            string s = cbx.Text;
            pnTbx.BackColor = SystemColors.Window;
            cbx.BackColor = SystemColors.ActiveCaption;
            cbx.BackColor = SystemColors.ActiveCaption;

            if (s == "入库记录")// 1 12
            {
                string str = "select pn as 胶盘编号,case when in_out=1 then '入库' when in_out=2 then '出库' end as 出库或入库,case when small_big=1 then '小胶盘' when small_big=2 then '大胶盘'end as 小胶盘或大胶盘,time as 时间,num as 次数 from [Sys_history] where in_out=" + 1 + "   order by id";
                fenye(str);//分页
                LoadPage();//加载数据
            }
            if (s == "小胶盘入库")// 1 1
            {
                string str = " select pn as 胶盘编号,case when in_out=1 then '入库' when in_out=2 then '出库' end as 出库或入库,case when small_big=1 then '小胶盘' when small_big=2 then '大胶盘'end as 小胶盘或大胶盘,time as 时间,num as 次数 from [Sys_history] where in_out=" + 1 + " and small_big=" + 1 + "  order by id ";
                fenye(str);//分页
                LoadPage();//加载数据
            }
            if (s == "大胶盘入库")// 1 2 
            {
                string str = " select pn as 胶盘编号,case when in_out=1 then '入库' when in_out=2 then '出库' end as 出库或入库,case when small_big=1 then '小胶盘' when small_big=2 then '大胶盘'end as 小胶盘或大胶盘,time as 时间,num as 次数 from [Sys_history] where in_out=" + 1 + " and small_big=" + 2 + "  order by id ";
                fenye(str);//分页
                LoadPage();//加载数据
            }
            if (s == "出库记录")// 2 12
            {
                string str = " select pn as 胶盘编号,case when in_out=1 then '入库' when in_out=2 then '出库' end as 出库或入库,case when small_big=1 then '小胶盘' when small_big=2 then '大胶盘'end as 小胶盘或大胶盘,time as 时间,num as 次数 from [Sys_history] where in_out=" + 2 + "   order by id ";
                fenye(str);//分页
                LoadPage();//加载数据
            }
            if (s == "小胶盘出库")// 2 1
            {
                string str = "select pn as 胶盘编号,case when in_out=1 then '入库' when in_out=2 then '出库' end as 出库或入库,case when small_big=1 then '小胶盘' when small_big=2 then '大胶盘'end as 小胶盘或大胶盘,time as 时间,num as 次数 from [Sys_history] where in_out=" + 2 + " and small_big=" + 1 + "  order by id  ";
                fenye(str);//分页
                LoadPage();//加载数据
            }
            if (s == "大胶盘出库")// 2 2
            {
                string str = " select pn as 胶盘编号,case when in_out=1 then '入库' when in_out=2 then '出库' end as 出库或入库,case when small_big=1 then '小胶盘' when small_big=2 then '大胶盘'end as 小胶盘或大胶盘,time as 时间,num as 次数 from [Sys_history] where in_out=" + 2 + " and small_big=" + 2 + "  order by id ";
                fenye(str);//分页
                LoadPage();//加载数据
            }
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            pnTbx.BackColor = SystemColors.Window;
            cbx.BackColor = SystemColors.Window;
            string time = timeDp.Text;
            string str = "select pn as 胶盘编号,case when in_out=1 then '入库' when in_out=2 then '出库' end as 出库或入库,case when small_big=1 then '小胶盘' when small_big=2 then '大胶盘'end as 小胶盘或大胶盘,time as 时间,num as 次数 from [Sys_history] where   CONVERT(varchar(100), time, 23)='" + time + "' order by id ";
            fenye(str);//分页
            LoadPage();//加载数据
        }
        #endregion

        private void resetBtn_Click(object sender, EventArgs e)
        {
            pnTbx.BackColor = SystemColors.Window;
            cbx.BackColor = SystemColors.Window;
            this.pnTbx.Text = "";
            this.cbx.Text = "";
            string time= DateTime.Now.ToString("u").Substring(0,11);//2018-09-03
            timeDp.Value = Convert.ToDateTime(time);
            History_Load(sender,e);
        }

        #region 分页
        public int pageSize = 15;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();
        private void LoadPage()
        {
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord;
            int endRecord;
            DataTable dtTemp;
            dtTemp = dtSource.Clone();

            beginRecord = pageSize * (currentPage - 1);
            if (currentPage == 1) beginRecord = 0;
            endRecord = pageSize * currentPage;

            if (currentPage == pageCount) endRecord = recordCount;
            if(currentPage!=0&&pageCount!=0)
            for (int i = beginRecord; i < endRecord; i++)
            {
                dtTemp.ImportRow(dtSource.Rows[i]);
            }
            dataGridView2.DataSource = dtTemp;  
            lblCurrentPage.Text = currentPage.ToString();//当前页
            lblPageCount.Text = pageCount.ToString();//总页数
            lblTotalCount.Text = recordCount.ToString();//总记录数
        }

        private void fenye(string str)    //str是sql语句
        {
            SqlHelper sqlHelper = new SqlHelper();
            SqlDataAdapter sda = new SqlDataAdapter(str, sqlHelper.GetConn());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dtSource = ds.Tables[0];
            recordCount = dtSource.Rows.Count;
            pageCount = (recordCount / pageSize);
            if ((recordCount % pageSize) > 0)
            {
                pageCount++;
            }

            //默认第一页
            currentPage = 1;
            LoadPage();//调用加载数据的方法
        }

        private void Firstbtn_Click(object sender, EventArgs e)
        {
           
            if (currentPage !=1)
            {
                currentPage = 1;
            }
            else
            {
                MessageBox.Show("当前已经是第一页。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            LoadPage();
        }

        private void endbtn_Click(object sender, EventArgs e)
        {
            if (currentPage < pageCount)
            {

                currentPage = pageCount;
            }
            else
            {
                MessageBox.Show("当前已经是最后一页。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            LoadPage();
        }

        private void lastbtn_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (currentPage < 1)
            {
                MessageBox.Show("当前已经是第一页。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            LoadPage();
        }

        private void nextbtn_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (currentPage > pageCount)
            {
                MessageBox.Show("当前已经是最后一页。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            LoadPage();
        }
        #endregion

      
       
    }
}
