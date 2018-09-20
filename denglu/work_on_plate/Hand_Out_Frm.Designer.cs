namespace denglu.work_on_plate
{
    partial class Hand_Out_Frm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hand_Out_Frm));
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stationCbx = new System.Windows.Forms.ComboBox();
            this.carrierCbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(74, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "(人工输入产线位置地点，系统依据自身原则出小胶盘)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "出库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(122, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Station:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(377, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Carrier:";
            // 
            // stationCbx
            // 
            this.stationCbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stationCbx.FormattingEnabled = true;
            this.stationCbx.IntegralHeight = false;
            this.stationCbx.Location = new System.Drawing.Point(212, 148);
            this.stationCbx.Name = "stationCbx";
            this.stationCbx.Size = new System.Drawing.Size(121, 22);
            this.stationCbx.TabIndex = 8;
            this.stationCbx.Leave += new System.EventHandler(this.stationCbx_Leave);
            // 
            // carrierCbx
            // 
            this.carrierCbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.carrierCbx.FormattingEnabled = true;
            this.carrierCbx.Location = new System.Drawing.Point(464, 148);
            this.carrierCbx.Name = "carrierCbx";
            this.carrierCbx.Size = new System.Drawing.Size(121, 22);
            this.carrierCbx.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(187, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "注：手动出库的前提是产线位置必须输入正确，且server端保存有该类地址";
            // 
            // Hand_Out_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 424);
            this.Controls.Add(this.carrierCbx);
            this.Controls.Add(this.stationCbx);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Hand_Out_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hand_Out_Frm";
            this.Load += new System.EventHandler(this.Hand_Out_Frm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox stationCbx;
        private System.Windows.Forms.ComboBox carrierCbx;
        private System.Windows.Forms.Label label1;
    }
}