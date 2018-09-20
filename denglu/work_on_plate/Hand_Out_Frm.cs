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

namespace denglu.work_on_plate
{
    public partial class Hand_Out_Frm : Form
    {
        public Hand_Out_Frm()
        {
            InitializeComponent();
        }
        //出库
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Hand_Out_Frm_Load(object sender, EventArgs e)
        {
            //
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.stationCbx.Focus();
            for (int i = 20; i > 0; i--)
            {
                this.stationCbx.Items.Add(i);
            }
        }

        private void stationCbx_Leave(object sender, EventArgs e)
        {
            try
            {
                //清空 carrier 数据
                this.carrierCbx.Items.Clear();
                if (this.stationCbx.Text != "")
                {
                    int station=Convert.ToInt32(this.stationCbx.Text);
                    SqlHelper sqlHelper = new SqlHelper();
                    String sql = " select carrier from [Sys_station_carrier] where station= "+station;
                    SqlConnection cn = sqlHelper.GetConn();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, cn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);//填充数据到dt
                    foreach (DataRow row in dt.Rows)
                    {
                        this.carrierCbx.Items.Add(row["carrier"].ToString());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
           
        }
    }
}
