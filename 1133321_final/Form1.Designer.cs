namespace _1133321_final
{
    partial class hotel
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpRooms = new System.Windows.Forms.TableLayoutPanel();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.lblRoomNumTitle = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblNotesTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblRoomNum = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.grpEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRooms
            // 
            this.tlpRooms.ColumnCount = 3;
            this.tlpRooms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.13187F));
            this.tlpRooms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.86813F));
            this.tlpRooms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223F));
            this.tlpRooms.Location = new System.Drawing.Point(12, 12);
            this.tlpRooms.Name = "tlpRooms";
            this.tlpRooms.RowCount = 2;
            this.tlpRooms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.45631F));
            this.tlpRooms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.54369F));
            this.tlpRooms.Size = new System.Drawing.Size(679, 206);
            this.tlpRooms.TabIndex = 0;
            // 
            // grpEdit
            // 
            this.grpEdit.Controls.Add(this.cmbService);
            this.grpEdit.Controls.Add(this.lblService);
            this.grpEdit.Controls.Add(this.lblCheckOut);
            this.grpEdit.Controls.Add(this.dtpCheckOut);
            this.grpEdit.Controls.Add(this.lblRoomNum);
            this.grpEdit.Controls.Add(this.btnCancel);
            this.grpEdit.Controls.Add(this.lblNotesTitle);
            this.grpEdit.Controls.Add(this.lblStatusTitle);
            this.grpEdit.Controls.Add(this.btnSave);
            this.grpEdit.Controls.Add(this.txtNotes);
            this.grpEdit.Controls.Add(this.cmbStatus);
            this.grpEdit.Controls.Add(this.lblRoomNumTitle);
            this.grpEdit.Enabled = false;
            this.grpEdit.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpEdit.Location = new System.Drawing.Point(12, 224);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(679, 253);
            this.grpEdit.TabIndex = 1;
            this.grpEdit.TabStop = false;
            // 
            // lblRoomNumTitle
            // 
            this.lblRoomNumTitle.AutoSize = true;
            this.lblRoomNumTitle.Location = new System.Drawing.Point(42, 19);
            this.lblRoomNumTitle.Name = "lblRoomNumTitle";
            this.lblRoomNumTitle.Size = new System.Drawing.Size(98, 13);
            this.lblRoomNumTitle.TabIndex = 0;
            this.lblRoomNumTitle.Text = "目前選取房號：";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "入住中",
            "待清潔",
            "維修中",
            "空房"});
            this.cmbStatus.Location = new System.Drawing.Point(536, 48);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(128, 21);
            this.cmbStatus.TabIndex = 1;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(139, 45);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(288, 202);
            this.txtNotes.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(499, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.AutoSize = true;
            this.lblStatusTitle.Location = new System.Drawing.Point(461, 51);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(72, 13);
            this.lblStatusTitle.TabIndex = 4;
            this.lblStatusTitle.Text = "房況狀態：";
            // 
            // lblNotesTitle
            // 
            this.lblNotesTitle.AutoSize = true;
            this.lblNotesTitle.Location = new System.Drawing.Point(7, 48);
            this.lblNotesTitle.Name = "lblNotesTitle";
            this.lblNotesTitle.Size = new System.Drawing.Size(133, 13);
            this.lblNotesTitle.TabIndex = 5;
            this.lblNotesTitle.Text = "客房備註 / 交接事項：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(589, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblRoomNum
            // 
            this.lblRoomNum.AutoSize = true;
            this.lblRoomNum.Location = new System.Drawing.Point(138, 19);
            this.lblRoomNum.Name = "lblRoomNum";
            this.lblRoomNum.Size = new System.Drawing.Size(11, 13);
            this.lblRoomNum.TabIndex = 7;
            this.lblRoomNum.Text = "-";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Location = new System.Drawing.Point(536, 76);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(128, 23);
            this.dtpCheckOut.TabIndex = 2;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Location = new System.Drawing.Point(435, 83);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(98, 13);
            this.lblCheckOut.TabIndex = 8;
            this.lblCheckOut.Text = "預計退房日期：";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(435, 112);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(98, 13);
            this.lblService.TabIndex = 9;
            this.lblService.Text = "客房服務指示：";
            // 
            // cmbService
            // 
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Items.AddRange(new object[] {
            "無指示(正常)",
            "請勿打擾 (DND)",
            "請即打掃 (MUR)"});
            this.cmbService.Location = new System.Drawing.Point(536, 109);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(128, 21);
            this.cmbService.TabIndex = 10;
            // 
            // hotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 489);
            this.Controls.Add(this.grpEdit);
            this.Controls.Add(this.tlpRooms);
            this.Name = "hotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "hotel";
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRooms;
        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblRoomNumTitle;
        private System.Windows.Forms.Label lblNotesTitle;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblRoomNum;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblCheckOut;
    }
}

