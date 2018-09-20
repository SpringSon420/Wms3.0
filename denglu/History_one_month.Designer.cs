namespace denglu
{
    partial class History_one_month
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History_one_month));
            this.timeDp = new System.Windows.Forms.DateTimePicker();
            this.resetBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Btn3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Btn2 = new System.Windows.Forms.Button();
            this.endbtn = new System.Windows.Forms.Button();
            this.Btn = new System.Windows.Forms.Button();
            this.nextbtn = new System.Windows.Forms.Button();
            this.cbx = new System.Windows.Forms.ComboBox();
            this.lastbtn = new System.Windows.Forms.Button();
            this.pnTbx = new System.Windows.Forms.TextBox();
            this.Firstbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblSept = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // timeDp
            // 
            this.timeDp.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeDp.CustomFormat = "yyyy-MM-dd ";
            this.timeDp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeDp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeDp.Location = new System.Drawing.Point(791, 30);
            this.timeDp.Name = "timeDp";
            this.timeDp.Size = new System.Drawing.Size(111, 23);
            this.timeDp.TabIndex = 271;
            // 
            // resetBtn
            // 
            this.resetBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.resetBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetBtn.FlatAppearance.BorderSize = 0;
            this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetBtn.Location = new System.Drawing.Point(981, 30);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(48, 23);
            this.resetBtn.TabIndex = 267;
            this.resetBtn.Text = "重置";
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(27, 83);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 30;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1016, 486);
            this.dataGridView2.TabIndex = 272;
            // 
            // Btn3
            // 
            this.Btn3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Btn3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn3.FlatAppearance.BorderSize = 0;
            this.Btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn3.Location = new System.Drawing.Point(917, 30);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(52, 23);
            this.Btn3.TabIndex = 268;
            this.Btn3.Text = "筛选";
            this.Btn3.UseVisualStyleBackColor = false;
            this.Btn3.Click += new System.EventHandler(this.Btn3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(163, 595);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 281;
            this.label7.Text = "总记录数:";
            // 
            // Btn2
            // 
            this.Btn2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Btn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn2.FlatAppearance.BorderSize = 0;
            this.Btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn2.Location = new System.Drawing.Point(626, 29);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(52, 23);
            this.Btn2.TabIndex = 269;
            this.Btn2.Text = "筛选";
            this.Btn2.UseVisualStyleBackColor = false;
            this.Btn2.Click += new System.EventHandler(this.Btn2_Click);
            // 
            // endbtn
            // 
            this.endbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.endbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endbtn.ForeColor = System.Drawing.Color.Blue;
            this.endbtn.Location = new System.Drawing.Point(965, 590);
            this.endbtn.Name = "endbtn";
            this.endbtn.Size = new System.Drawing.Size(50, 25);
            this.endbtn.TabIndex = 280;
            this.endbtn.Text = "尾页";
            this.endbtn.UseVisualStyleBackColor = true;
            this.endbtn.Click += new System.EventHandler(this.endbtn_Click);
            // 
            // Btn
            // 
            this.Btn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn.FlatAppearance.BorderSize = 0;
            this.Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn.Location = new System.Drawing.Point(286, 30);
            this.Btn.Name = "Btn";
            this.Btn.Size = new System.Drawing.Size(52, 23);
            this.Btn.TabIndex = 270;
            this.Btn.Text = "筛选";
            this.Btn.UseVisualStyleBackColor = false;
            this.Btn.Click += new System.EventHandler(this.Btn_Click);
            // 
            // nextbtn
            // 
            this.nextbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextbtn.ForeColor = System.Drawing.Color.Blue;
            this.nextbtn.Location = new System.Drawing.Point(897, 590);
            this.nextbtn.Name = "nextbtn";
            this.nextbtn.Size = new System.Drawing.Size(62, 25);
            this.nextbtn.TabIndex = 278;
            this.nextbtn.Text = "下一页";
            this.nextbtn.UseVisualStyleBackColor = true;
            this.nextbtn.Click += new System.EventHandler(this.nextbtn_Click);
            // 
            // cbx
            // 
            this.cbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx.FormattingEnabled = true;
            this.cbx.ItemHeight = 14;
            this.cbx.Items.AddRange(new object[] {
            "入库记录",
            "小胶盘入库",
            "大胶盘入库",
            "出库记录",
            "小胶盘出库",
            "大胶盘出库"});
            this.cbx.Location = new System.Drawing.Point(481, 29);
            this.cbx.Name = "cbx";
            this.cbx.Size = new System.Drawing.Size(139, 22);
            this.cbx.TabIndex = 266;
            // 
            // lastbtn
            // 
            this.lastbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lastbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastbtn.ForeColor = System.Drawing.Color.Blue;
            this.lastbtn.Location = new System.Drawing.Point(829, 590);
            this.lastbtn.Name = "lastbtn";
            this.lastbtn.Size = new System.Drawing.Size(62, 25);
            this.lastbtn.TabIndex = 277;
            this.lastbtn.Text = "上一页";
            this.lastbtn.UseVisualStyleBackColor = true;
            this.lastbtn.Click += new System.EventHandler(this.lastbtn_Click);
            // 
            // pnTbx
            // 
            this.pnTbx.BackColor = System.Drawing.SystemColors.Window;
            this.pnTbx.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnTbx.Location = new System.Drawing.Point(112, 30);
            this.pnTbx.Name = "pnTbx";
            this.pnTbx.Size = new System.Drawing.Size(168, 23);
            this.pnTbx.TabIndex = 265;
            // 
            // Firstbtn
            // 
            this.Firstbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Firstbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Firstbtn.ForeColor = System.Drawing.Color.Blue;
            this.Firstbtn.Location = new System.Drawing.Point(773, 590);
            this.Firstbtn.Name = "Firstbtn";
            this.Firstbtn.Size = new System.Drawing.Size(50, 25);
            this.Firstbtn.TabIndex = 279;
            this.Firstbtn.Text = "首页";
            this.Firstbtn.UseVisualStyleBackColor = true;
            this.Firstbtn.Click += new System.EventHandler(this.Firstbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(746, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 264;
            this.label4.Text = "时间：";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentPage.Location = new System.Drawing.Point(52, 598);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(35, 12);
            this.lblCurrentPage.TabIndex = 273;
            this.lblCurrentPage.Text = "0";
            this.lblCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(398, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 263;
            this.label3.Text = "查询条件：";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCount.Location = new System.Drawing.Point(227, 598);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(11, 12);
            this.lblTotalCount.TabIndex = 274;
            this.lblTotalCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 262;
            this.label1.Text = "胶盘编号：";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Location = new System.Drawing.Point(108, 598);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(11, 12);
            this.lblPageCount.TabIndex = 276;
            this.lblPageCount.Text = "0";
            // 
            // lblSept
            // 
            this.lblSept.AutoSize = true;
            this.lblSept.Location = new System.Drawing.Point(93, 598);
            this.lblSept.Name = "lblSept";
            this.lblSept.Size = new System.Drawing.Size(11, 12);
            this.lblSept.TabIndex = 275;
            this.lblSept.Text = "/";
            // 
            // History_one_month
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 645);
            this.Controls.Add(this.timeDp);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.Btn3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.endbtn);
            this.Controls.Add(this.Btn);
            this.Controls.Add(this.nextbtn);
            this.Controls.Add(this.cbx);
            this.Controls.Add(this.lastbtn);
            this.Controls.Add(this.pnTbx);
            this.Controls.Add(this.Firstbtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCurrentPage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPageCount);
            this.Controls.Add(this.lblSept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "History_one_month";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History_this_month";
            this.Load += new System.EventHandler(this.History_one_month_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker timeDp;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button Btn3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button endbtn;
        private System.Windows.Forms.Button Btn;
        private System.Windows.Forms.Button nextbtn;
        private System.Windows.Forms.ComboBox cbx;
        private System.Windows.Forms.Button lastbtn;
        private System.Windows.Forms.TextBox pnTbx;
        private System.Windows.Forms.Button Firstbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Label lblSept;
    }
}