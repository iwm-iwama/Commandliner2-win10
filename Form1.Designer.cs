namespace iwm_commandliner2
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.BtnCmdStop = new System.Windows.Forms.Button();
			this.DgvEdit = new System.Windows.Forms.DataGridView();
			this.Dgv_Tbc21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Dgv_Tbc22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CmsResult = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CmsResult_上へ = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_下へ = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsResult_選択文字列を実行 = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_L2 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsResult_全選択 = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_全クリア = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_全コピー = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_L3 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsResult_コピー = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_切り取り = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_貼り付け = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_ファイル名を貼り付け = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_L4 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsResult_名前を付けて保存 = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_名前を付けて保存_ShiftJIS = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_名前を付けて保存_UTF8N = new System.Windows.Forms.ToolStripMenuItem();
			this.TbCmd = new System.Windows.Forms.TextBox();
			this.CmsCmd = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CmsCmd_実行 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsCmd_全クリア = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmd_全コピー = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsCmd_コピー = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmd_切り取り = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmd_貼り付け = new System.Windows.Forms.ToolStripMenuItem();
			this.TbCurDir = new System.Windows.Forms.TextBox();
			this.CmsNull = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.BtnTbResultWrite = new System.Windows.Forms.Button();
			this.BtnCmdExec = new System.Windows.Forms.Button();
			this.BtnResultMem = new System.Windows.Forms.Button();
			this.CbTextCode = new System.Windows.Forms.ComboBox();
			this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.Lbl2 = new System.Windows.Forms.Label();
			this.BtnCmdRedo = new System.Windows.Forms.Button();
			this.BtnCmdUndo = new System.Windows.Forms.Button();
			this.TbDgvCmdSearch = new System.Windows.Forms.TextBox();
			this.DgvCmd = new System.Windows.Forms.DataGridView();
			this.DgvCmd01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TbResult = new System.Windows.Forms.TextBox();
			this.CbDgvEdit = new System.Windows.Forms.CheckBox();
			this.CbDgvCmd = new System.Windows.Forms.CheckBox();
			this.BtnResultRedo = new System.Windows.Forms.Button();
			this.BtnResultUndo = new System.Windows.Forms.Button();
			this.LblResult = new System.Windows.Forms.Label();
			this.TbCmdSub = new System.Windows.Forms.TextBox();
			this.CmsCmdSub = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CmsCmdSub_全クリア = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmdSub_全コピー = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsCmdSub_コピー = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmdSub_切り取り = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmdSub_貼り付け = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.DgvEdit)).BeginInit();
			this.CmsResult.SuspendLayout();
			this.CmsCmd.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DgvCmd)).BeginInit();
			this.CmsCmdSub.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnCmdStop
			// 
			this.BtnCmdStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCmdStop.BackColor = System.Drawing.Color.Crimson;
			this.BtnCmdStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.BtnCmdStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdStop.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdStop.ForeColor = System.Drawing.Color.White;
			this.BtnCmdStop.Location = new System.Drawing.Point(433, 97);
			this.BtnCmdStop.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdStop.Name = "BtnCmdStop";
			this.BtnCmdStop.Size = new System.Drawing.Size(22, 22);
			this.BtnCmdStop.TabIndex = 12;
			this.BtnCmdStop.TabStop = false;
			this.BtnCmdStop.Text = "✖";
			this.ToolTip1.SetToolTip(this.BtnCmdStop, "停止");
			this.BtnCmdStop.UseVisualStyleBackColor = false;
			this.BtnCmdStop.Click += new System.EventHandler(this.BtnCmdStop_Click);
			// 
			// DgvEdit
			// 
			this.DgvEdit.AllowUserToAddRows = false;
			this.DgvEdit.AllowUserToDeleteRows = false;
			this.DgvEdit.AllowUserToResizeColumns = false;
			this.DgvEdit.AllowUserToResizeRows = false;
			this.DgvEdit.BackgroundColor = System.Drawing.Color.LightGray;
			this.DgvEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgvEdit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dgv_Tbc21,
            this.Dgv_Tbc22});
			this.DgvEdit.GridColor = System.Drawing.Color.LightGray;
			this.DgvEdit.Location = new System.Drawing.Point(82, 97);
			this.DgvEdit.Margin = new System.Windows.Forms.Padding(0);
			this.DgvEdit.MultiSelect = false;
			this.DgvEdit.Name = "DgvEdit";
			this.DgvEdit.ReadOnly = true;
			this.DgvEdit.RowHeadersVisible = false;
			this.DgvEdit.RowTemplate.Height = 21;
			this.DgvEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.DgvEdit.Size = new System.Drawing.Size(68, 24);
			this.DgvEdit.StandardTab = true;
			this.DgvEdit.TabIndex = 6;
			this.DgvEdit.TabStop = false;
			this.DgvEdit.Click += new System.EventHandler(this.DgvEdit_Click);
			this.DgvEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvEdit_KeyDown);
			this.DgvEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DgvEdit_KeyUp);
			this.DgvEdit.MouseHover += new System.EventHandler(this.DgvEdit_MouseHover);
			// 
			// Dgv_Tbc21
			// 
			this.Dgv_Tbc21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Dgv_Tbc21.FillWeight = 150F;
			this.Dgv_Tbc21.HeaderText = "マクロ";
			this.Dgv_Tbc21.MinimumWidth = 75;
			this.Dgv_Tbc21.Name = "Dgv_Tbc21";
			this.Dgv_Tbc21.ReadOnly = true;
			this.Dgv_Tbc21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Dgv_Tbc21.Width = 75;
			// 
			// Dgv_Tbc22
			// 
			this.Dgv_Tbc22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Dgv_Tbc22.FillWeight = 150F;
			this.Dgv_Tbc22.HeaderText = "説明";
			this.Dgv_Tbc22.MinimumWidth = 275;
			this.Dgv_Tbc22.Name = "Dgv_Tbc22";
			this.Dgv_Tbc22.ReadOnly = true;
			this.Dgv_Tbc22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Dgv_Tbc22.Width = 275;
			// 
			// CmsResult
			// 
			this.CmsResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsResult_上へ,
            this.CmsResult_下へ,
            this.toolStripMenuItem1,
            this.CmsResult_選択文字列を実行,
            this.CmsResult_L2,
            this.CmsResult_全選択,
            this.CmsResult_全クリア,
            this.CmsResult_全コピー,
            this.CmsResult_L3,
            this.CmsResult_コピー,
            this.CmsResult_切り取り,
            this.CmsResult_貼り付け,
            this.CmsResult_ファイル名を貼り付け,
            this.CmsResult_L4,
            this.CmsResult_名前を付けて保存});
			this.CmsResult.Name = "CmsResult";
			this.CmsResult.Size = new System.Drawing.Size(171, 270);
			// 
			// CmsResult_上へ
			// 
			this.CmsResult_上へ.ForeColor = System.Drawing.Color.OrangeRed;
			this.CmsResult_上へ.Name = "CmsResult_上へ";
			this.CmsResult_上へ.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_上へ.Text = "▲";
			this.CmsResult_上へ.Click += new System.EventHandler(this.CmsResult_上へ_Click);
			// 
			// CmsResult_下へ
			// 
			this.CmsResult_下へ.ForeColor = System.Drawing.Color.OrangeRed;
			this.CmsResult_下へ.Name = "CmsResult_下へ";
			this.CmsResult_下へ.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_下へ.Text = "▼";
			this.CmsResult_下へ.Click += new System.EventHandler(this.CmsResult_下へ_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 6);
			// 
			// CmsResult_選択文字列を実行
			// 
			this.CmsResult_選択文字列を実行.BackColor = System.Drawing.SystemColors.Control;
			this.CmsResult_選択文字列を実行.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CmsResult_選択文字列を実行.Name = "CmsResult_選択文字列を実行";
			this.CmsResult_選択文字列を実行.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_選択文字列を実行.Text = "選択文字列を実行";
			this.CmsResult_選択文字列を実行.Click += new System.EventHandler(this.CmsResult_選択文字列を実行_Click);
			// 
			// CmsResult_L2
			// 
			this.CmsResult_L2.Name = "CmsResult_L2";
			this.CmsResult_L2.Size = new System.Drawing.Size(167, 6);
			// 
			// CmsResult_全選択
			// 
			this.CmsResult_全選択.Name = "CmsResult_全選択";
			this.CmsResult_全選択.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_全選択.Text = "全選択";
			this.CmsResult_全選択.Click += new System.EventHandler(this.CmsResult_全選択_Click);
			// 
			// CmsResult_全クリア
			// 
			this.CmsResult_全クリア.Name = "CmsResult_全クリア";
			this.CmsResult_全クリア.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_全クリア.Text = "全クリア";
			this.CmsResult_全クリア.Click += new System.EventHandler(this.CmsResult_全クリア_Click);
			// 
			// CmsResult_全コピー
			// 
			this.CmsResult_全コピー.Name = "CmsResult_全コピー";
			this.CmsResult_全コピー.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_全コピー.Text = "全コピー";
			this.CmsResult_全コピー.Click += new System.EventHandler(this.CmsResult_全コピー_Click);
			// 
			// CmsResult_L3
			// 
			this.CmsResult_L3.Name = "CmsResult_L3";
			this.CmsResult_L3.Size = new System.Drawing.Size(167, 6);
			// 
			// CmsResult_コピー
			// 
			this.CmsResult_コピー.Name = "CmsResult_コピー";
			this.CmsResult_コピー.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_コピー.Text = "コピー";
			this.CmsResult_コピー.Click += new System.EventHandler(this.CmsResult_コピー_Click);
			// 
			// CmsResult_切り取り
			// 
			this.CmsResult_切り取り.Name = "CmsResult_切り取り";
			this.CmsResult_切り取り.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_切り取り.Text = "切り取り";
			this.CmsResult_切り取り.Click += new System.EventHandler(this.CmsResult_切り取り_Click);
			// 
			// CmsResult_貼り付け
			// 
			this.CmsResult_貼り付け.Name = "CmsResult_貼り付け";
			this.CmsResult_貼り付け.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_貼り付け.Text = "貼り付け";
			this.CmsResult_貼り付け.Click += new System.EventHandler(this.CmsResult_貼り付け_Click);
			// 
			// CmsResult_ファイル名を貼り付け
			// 
			this.CmsResult_ファイル名を貼り付け.Name = "CmsResult_ファイル名を貼り付け";
			this.CmsResult_ファイル名を貼り付け.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_ファイル名を貼り付け.Text = "ファイル名を貼り付け";
			this.CmsResult_ファイル名を貼り付け.Click += new System.EventHandler(this.CmsResult_ファイル名を貼り付け_Click);
			// 
			// CmsResult_L4
			// 
			this.CmsResult_L4.Name = "CmsResult_L4";
			this.CmsResult_L4.Size = new System.Drawing.Size(167, 6);
			// 
			// CmsResult_名前を付けて保存
			// 
			this.CmsResult_名前を付けて保存.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsResult_名前を付けて保存_ShiftJIS,
            this.CmsResult_名前を付けて保存_UTF8N});
			this.CmsResult_名前を付けて保存.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CmsResult_名前を付けて保存.Name = "CmsResult_名前を付けて保存";
			this.CmsResult_名前を付けて保存.Size = new System.Drawing.Size(170, 22);
			this.CmsResult_名前を付けて保存.Text = "名前を付けて保存";
			// 
			// CmsResult_名前を付けて保存_ShiftJIS
			// 
			this.CmsResult_名前を付けて保存_ShiftJIS.Name = "CmsResult_名前を付けて保存_ShiftJIS";
			this.CmsResult_名前を付けて保存_ShiftJIS.Size = new System.Drawing.Size(116, 22);
			this.CmsResult_名前を付けて保存_ShiftJIS.Text = "Shift_JIS";
			this.CmsResult_名前を付けて保存_ShiftJIS.Click += new System.EventHandler(this.CmsResult_名前を付けて保存_ShiftJIS_Click);
			// 
			// CmsResult_名前を付けて保存_UTF8N
			// 
			this.CmsResult_名前を付けて保存_UTF8N.Name = "CmsResult_名前を付けて保存_UTF8N";
			this.CmsResult_名前を付けて保存_UTF8N.Size = new System.Drawing.Size(116, 22);
			this.CmsResult_名前を付けて保存_UTF8N.Text = "UTF-8N";
			this.CmsResult_名前を付けて保存_UTF8N.Click += new System.EventHandler(this.CmsResult_名前を付けて保存_UTF8N_Click);
			// 
			// TbCmd
			// 
			this.TbCmd.AllowDrop = true;
			this.TbCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TbCmd.BackColor = System.Drawing.Color.White;
			this.TbCmd.ContextMenuStrip = this.CmsCmd;
			this.TbCmd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbCmd.ForeColor = System.Drawing.Color.Black;
			this.TbCmd.Location = new System.Drawing.Point(10, 26);
			this.TbCmd.Margin = new System.Windows.Forms.Padding(0);
			this.TbCmd.Multiline = true;
			this.TbCmd.Name = "TbCmd";
			this.TbCmd.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.TbCmd.Size = new System.Drawing.Size(446, 40);
			this.TbCmd.TabIndex = 1;
			this.TbCmd.WordWrap = false;
			this.TbCmd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TbCmd_MouseClick);
			this.TbCmd.DragDrop += new System.Windows.Forms.DragEventHandler(this.TbCmd_DragDrop);
			this.TbCmd.DragEnter += new System.Windows.Forms.DragEventHandler(this.TbCmd_DragEnter);
			this.TbCmd.Enter += new System.EventHandler(this.TbCmd_Enter);
			this.TbCmd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbCmd_KeyUp);
			this.TbCmd.MouseHover += new System.EventHandler(this.TbCmd_MouseHover);
			// 
			// CmsCmd
			// 
			this.CmsCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsCmd_実行,
            this.toolStripMenuItem2,
            this.CmsCmd_全クリア,
            this.CmsCmd_全コピー,
            this.toolStripSeparator1,
            this.CmsCmd_コピー,
            this.CmsCmd_切り取り,
            this.CmsCmd_貼り付け});
			this.CmsCmd.Name = "CmsResult";
			this.CmsCmd.Size = new System.Drawing.Size(116, 148);
			// 
			// CmsCmd_実行
			// 
			this.CmsCmd_実行.Name = "CmsCmd_実行";
			this.CmsCmd_実行.Size = new System.Drawing.Size(115, 22);
			this.CmsCmd_実行.Text = "実行";
			this.CmsCmd_実行.Click += new System.EventHandler(this.CmsCmd_実行_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(112, 6);
			// 
			// CmsCmd_全クリア
			// 
			this.CmsCmd_全クリア.Name = "CmsCmd_全クリア";
			this.CmsCmd_全クリア.Size = new System.Drawing.Size(115, 22);
			this.CmsCmd_全クリア.Text = "全クリア";
			this.CmsCmd_全クリア.Click += new System.EventHandler(this.CmsCmd_全クリア_Click);
			// 
			// CmsCmd_全コピー
			// 
			this.CmsCmd_全コピー.Name = "CmsCmd_全コピー";
			this.CmsCmd_全コピー.Size = new System.Drawing.Size(115, 22);
			this.CmsCmd_全コピー.Text = "全コピー";
			this.CmsCmd_全コピー.Click += new System.EventHandler(this.CmsCmd_全コピー_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(112, 6);
			// 
			// CmsCmd_コピー
			// 
			this.CmsCmd_コピー.Name = "CmsCmd_コピー";
			this.CmsCmd_コピー.Size = new System.Drawing.Size(115, 22);
			this.CmsCmd_コピー.Text = "コピー";
			this.CmsCmd_コピー.Click += new System.EventHandler(this.CmsCmd_コピー_Click);
			// 
			// CmsCmd_切り取り
			// 
			this.CmsCmd_切り取り.Name = "CmsCmd_切り取り";
			this.CmsCmd_切り取り.Size = new System.Drawing.Size(115, 22);
			this.CmsCmd_切り取り.Text = "切り取り";
			this.CmsCmd_切り取り.Click += new System.EventHandler(this.CmsCmd_切り取り_Click);
			// 
			// CmsCmd_貼り付け
			// 
			this.CmsCmd_貼り付け.Name = "CmsCmd_貼り付け";
			this.CmsCmd_貼り付け.Size = new System.Drawing.Size(115, 22);
			this.CmsCmd_貼り付け.Text = "貼り付け";
			this.CmsCmd_貼り付け.Click += new System.EventHandler(this.CmsCmd_貼り付け_Click);
			// 
			// TbCurDir
			// 
			this.TbCurDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TbCurDir.BackColor = System.Drawing.Color.DimGray;
			this.TbCurDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TbCurDir.ContextMenuStrip = this.CmsNull;
			this.TbCurDir.Cursor = System.Windows.Forms.Cursors.Default;
			this.TbCurDir.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbCurDir.ForeColor = System.Drawing.Color.White;
			this.TbCurDir.Location = new System.Drawing.Point(10, 5);
			this.TbCurDir.Margin = new System.Windows.Forms.Padding(0);
			this.TbCurDir.Name = "TbCurDir";
			this.TbCurDir.Size = new System.Drawing.Size(444, 13);
			this.TbCurDir.TabIndex = 0;
			this.TbCurDir.TabStop = false;
			this.TbCurDir.Text = "TbCurDir";
			this.TbCurDir.WordWrap = false;
			this.TbCurDir.Click += new System.EventHandler(this.TbCurDir_Click);
			this.TbCurDir.MouseHover += new System.EventHandler(this.TbCurDir_MouseHover);
			// 
			// CmsNull
			// 
			this.CmsNull.Name = "contextMenuStrip0";
			this.CmsNull.Size = new System.Drawing.Size(61, 4);
			// 
			// ToolTip1
			// 
			this.ToolTip1.AutoPopDelay = 6000;
			this.ToolTip1.BackColor = System.Drawing.Color.Ivory;
			this.ToolTip1.ForeColor = System.Drawing.Color.Black;
			this.ToolTip1.InitialDelay = 500;
			this.ToolTip1.ReshowDelay = 100;
			// 
			// BtnTbResultWrite
			// 
			this.BtnTbResultWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnTbResultWrite.BackColor = System.Drawing.Color.DarkOrange;
			this.BtnTbResultWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.BtnTbResultWrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnTbResultWrite.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnTbResultWrite.ForeColor = System.Drawing.Color.White;
			this.BtnTbResultWrite.Location = new System.Drawing.Point(433, 408);
			this.BtnTbResultWrite.Margin = new System.Windows.Forms.Padding(0);
			this.BtnTbResultWrite.Name = "BtnTbResultWrite";
			this.BtnTbResultWrite.Size = new System.Drawing.Size(22, 22);
			this.BtnTbResultWrite.TabIndex = 19;
			this.BtnTbResultWrite.TabStop = false;
			this.BtnTbResultWrite.Text = "★";
			this.ToolTip1.SetToolTip(this.BtnTbResultWrite, "画面ロック解除");
			this.BtnTbResultWrite.UseVisualStyleBackColor = false;
			this.BtnTbResultWrite.Click += new System.EventHandler(this.BtnTbResultWrite_Click);
			// 
			// BtnCmdExec
			// 
			this.BtnCmdExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCmdExec.BackColor = System.Drawing.Color.RoyalBlue;
			this.BtnCmdExec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.BtnCmdExec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdExec.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdExec.ForeColor = System.Drawing.Color.White;
			this.BtnCmdExec.Location = new System.Drawing.Point(404, 97);
			this.BtnCmdExec.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdExec.Name = "BtnCmdExec";
			this.BtnCmdExec.Size = new System.Drawing.Size(22, 22);
			this.BtnCmdExec.TabIndex = 11;
			this.BtnCmdExec.TabStop = false;
			this.BtnCmdExec.Text = "▶";
			this.ToolTip1.SetToolTip(this.BtnCmdExec, "実行");
			this.BtnCmdExec.UseVisualStyleBackColor = false;
			this.BtnCmdExec.Click += new System.EventHandler(this.BtnCmdExec_Click);
			// 
			// BtnResultMem
			// 
			this.BtnResultMem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnResultMem.BackColor = System.Drawing.Color.Crimson;
			this.BtnResultMem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnResultMem.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnResultMem.ForeColor = System.Drawing.Color.White;
			this.BtnResultMem.Location = new System.Drawing.Point(72, 408);
			this.BtnResultMem.Margin = new System.Windows.Forms.Padding(0);
			this.BtnResultMem.Name = "BtnResultMem";
			this.BtnResultMem.Size = new System.Drawing.Size(25, 24);
			this.BtnResultMem.TabIndex = 16;
			this.BtnResultMem.TabStop = false;
			this.BtnResultMem.Text = "●";
			this.ToolTip1.SetToolTip(this.BtnResultMem, "出力を記憶");
			this.BtnResultMem.UseVisualStyleBackColor = false;
			this.BtnResultMem.Click += new System.EventHandler(this.BtnResultMem_Click);
			// 
			// CbTextCode
			// 
			this.CbTextCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CbTextCode.BackColor = System.Drawing.Color.DimGray;
			this.CbTextCode.ContextMenuStrip = this.CmsNull;
			this.CbTextCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbTextCode.DropDownWidth = 72;
			this.CbTextCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CbTextCode.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CbTextCode.ForeColor = System.Drawing.Color.White;
			this.CbTextCode.FormattingEnabled = true;
			this.CbTextCode.Location = new System.Drawing.Point(320, 98);
			this.CbTextCode.Margin = new System.Windows.Forms.Padding(0);
			this.CbTextCode.Name = "CbTextCode";
			this.CbTextCode.Size = new System.Drawing.Size(72, 20);
			this.CbTextCode.TabIndex = 10;
			this.CbTextCode.TabStop = false;
			this.ToolTip1.SetToolTip(this.CbTextCode, "出力される文字コード");
			// 
			// NumericUpDown1
			// 
			this.NumericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.NumericUpDown1.BackColor = System.Drawing.Color.DimGray;
			this.NumericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NumericUpDown1.ContextMenuStrip = this.CmsNull;
			this.NumericUpDown1.Cursor = System.Windows.Forms.Cursors.Default;
			this.NumericUpDown1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.NumericUpDown1.ForeColor = System.Drawing.Color.White;
			this.NumericUpDown1.Location = new System.Drawing.Point(365, 410);
			this.NumericUpDown1.Margin = new System.Windows.Forms.Padding(0);
			this.NumericUpDown1.Maximum = new decimal(new int[] {
            288,
            0,
            0,
            0});
			this.NumericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NumericUpDown1.Name = "NumericUpDown1";
			this.NumericUpDown1.Size = new System.Drawing.Size(45, 20);
			this.NumericUpDown1.TabIndex = 18;
			this.NumericUpDown1.TabStop = false;
			this.NumericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NumericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
			// 
			// Lbl2
			// 
			this.Lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Lbl2.AutoSize = true;
			this.Lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Lbl2.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Lbl2.ForeColor = System.Drawing.Color.White;
			this.Lbl2.Location = new System.Drawing.Point(409, 411);
			this.Lbl2.Margin = new System.Windows.Forms.Padding(0);
			this.Lbl2.Name = "Lbl2";
			this.Lbl2.Size = new System.Drawing.Size(20, 15);
			this.Lbl2.TabIndex = 17;
			this.Lbl2.Text = "pt";
			this.Lbl2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// BtnCmdRedo
			// 
			this.BtnCmdRedo.BackColor = System.Drawing.Color.DimGray;
			this.BtnCmdRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdRedo.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdRedo.ForeColor = System.Drawing.Color.White;
			this.BtnCmdRedo.Location = new System.Drawing.Point(40, 97);
			this.BtnCmdRedo.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdRedo.Name = "BtnCmdRedo";
			this.BtnCmdRedo.Size = new System.Drawing.Size(25, 24);
			this.BtnCmdRedo.TabIndex = 4;
			this.BtnCmdRedo.TabStop = false;
			this.BtnCmdRedo.Text = "▶";
			this.BtnCmdRedo.UseVisualStyleBackColor = false;
			this.BtnCmdRedo.Click += new System.EventHandler(this.BtnCmdRedo_Click);
			// 
			// BtnCmdUndo
			// 
			this.BtnCmdUndo.BackColor = System.Drawing.Color.DimGray;
			this.BtnCmdUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdUndo.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdUndo.ForeColor = System.Drawing.Color.White;
			this.BtnCmdUndo.Location = new System.Drawing.Point(10, 97);
			this.BtnCmdUndo.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdUndo.Name = "BtnCmdUndo";
			this.BtnCmdUndo.Size = new System.Drawing.Size(25, 24);
			this.BtnCmdUndo.TabIndex = 3;
			this.BtnCmdUndo.TabStop = false;
			this.BtnCmdUndo.Text = "◀";
			this.BtnCmdUndo.UseVisualStyleBackColor = false;
			this.BtnCmdUndo.Click += new System.EventHandler(this.BtnCmdUndo_Click);
			// 
			// TbDgvCmdSearch
			// 
			this.TbDgvCmdSearch.BackColor = System.Drawing.Color.LightYellow;
			this.TbDgvCmdSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TbDgvCmdSearch.ContextMenuStrip = this.CmsNull;
			this.TbDgvCmdSearch.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbDgvCmdSearch.ForeColor = System.Drawing.Color.Black;
			this.TbDgvCmdSearch.Location = new System.Drawing.Point(230, 98);
			this.TbDgvCmdSearch.Name = "TbDgvCmdSearch";
			this.TbDgvCmdSearch.Size = new System.Drawing.Size(80, 20);
			this.TbDgvCmdSearch.TabIndex = 9;
			this.TbDgvCmdSearch.TabStop = false;
			this.TbDgvCmdSearch.WordWrap = false;
			this.TbDgvCmdSearch.TextChanged += new System.EventHandler(this.TbDgvCmdSearch_TextChanged);
			this.TbDgvCmdSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbDgvCmdSearch_KeyUp);
			this.TbDgvCmdSearch.MouseHover += new System.EventHandler(this.TbDgvCmdSearch_MouseHover);
			// 
			// DgvCmd
			// 
			this.DgvCmd.AllowUserToAddRows = false;
			this.DgvCmd.AllowUserToDeleteRows = false;
			this.DgvCmd.AllowUserToResizeColumns = false;
			this.DgvCmd.AllowUserToResizeRows = false;
			this.DgvCmd.BackgroundColor = System.Drawing.Color.LightGray;
			this.DgvCmd.ColumnHeadersHeight = 20;
			this.DgvCmd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.DgvCmd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvCmd01});
			this.DgvCmd.GridColor = System.Drawing.Color.LightGray;
			this.DgvCmd.Location = new System.Drawing.Point(165, 97);
			this.DgvCmd.Margin = new System.Windows.Forms.Padding(0);
			this.DgvCmd.MultiSelect = false;
			this.DgvCmd.Name = "DgvCmd";
			this.DgvCmd.ReadOnly = true;
			this.DgvCmd.RowHeadersVisible = false;
			this.DgvCmd.RowTemplate.Height = 21;
			this.DgvCmd.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.DgvCmd.Size = new System.Drawing.Size(68, 24);
			this.DgvCmd.TabIndex = 8;
			this.DgvCmd.TabStop = false;
			this.DgvCmd.Click += new System.EventHandler(this.DgvCmd_Click);
			this.DgvCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvCmd_KeyDown);
			this.DgvCmd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DgvCmd_KeyUp);
			this.DgvCmd.MouseHover += new System.EventHandler(this.DgvCmd_MouseHover);
			// 
			// DgvCmd01
			// 
			this.DgvCmd01.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.DgvCmd01.HeaderText = "コマンド";
			this.DgvCmd01.MinimumWidth = 50;
			this.DgvCmd01.Name = "DgvCmd01";
			this.DgvCmd01.ReadOnly = true;
			this.DgvCmd01.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.DgvCmd01.Width = 265;
			// 
			// TbResult
			// 
			this.TbResult.AcceptsTab = true;
			this.TbResult.AllowDrop = true;
			this.TbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TbResult.BackColor = System.Drawing.Color.Black;
			this.TbResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TbResult.ContextMenuStrip = this.CmsResult;
			this.TbResult.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbResult.ForeColor = System.Drawing.Color.Lime;
			this.TbResult.Location = new System.Drawing.Point(10, 126);
			this.TbResult.Margin = new System.Windows.Forms.Padding(0);
			this.TbResult.MaxLength = 2147483647;
			this.TbResult.Multiline = true;
			this.TbResult.Name = "TbResult";
			this.TbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TbResult.Size = new System.Drawing.Size(445, 277);
			this.TbResult.TabIndex = 13;
			this.TbResult.TabStop = false;
			this.TbResult.WordWrap = false;
			this.TbResult.DragDrop += new System.Windows.Forms.DragEventHandler(this.TbResult_DragDrop);
			this.TbResult.DragEnter += new System.Windows.Forms.DragEventHandler(this.TbResult_DragEnter);
			this.TbResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbResult_KeyUp);
			this.TbResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TbResult_MouseUp);
			// 
			// CbDgvEdit
			// 
			this.CbDgvEdit.AutoSize = true;
			this.CbDgvEdit.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CbDgvEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CbDgvEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CbDgvEdit.Location = new System.Drawing.Point(72, 102);
			this.CbDgvEdit.Margin = new System.Windows.Forms.Padding(0);
			this.CbDgvEdit.Name = "CbDgvEdit";
			this.CbDgvEdit.Size = new System.Drawing.Size(12, 11);
			this.CbDgvEdit.TabIndex = 5;
			this.CbDgvEdit.TabStop = false;
			this.CbDgvEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CbDgvEdit.UseVisualStyleBackColor = true;
			this.CbDgvEdit.Click += new System.EventHandler(this.CbDgvEdit_Click);
			// 
			// CbDgvCmd
			// 
			this.CbDgvCmd.AutoSize = true;
			this.CbDgvCmd.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CbDgvCmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CbDgvCmd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CbDgvCmd.Location = new System.Drawing.Point(155, 102);
			this.CbDgvCmd.Margin = new System.Windows.Forms.Padding(0);
			this.CbDgvCmd.Name = "CbDgvCmd";
			this.CbDgvCmd.Size = new System.Drawing.Size(12, 11);
			this.CbDgvCmd.TabIndex = 7;
			this.CbDgvCmd.TabStop = false;
			this.CbDgvCmd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CbDgvCmd.UseVisualStyleBackColor = true;
			this.CbDgvCmd.Click += new System.EventHandler(this.CbDgvCmd_Click);
			// 
			// BtnResultRedo
			// 
			this.BtnResultRedo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnResultRedo.BackColor = System.Drawing.Color.DimGray;
			this.BtnResultRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnResultRedo.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnResultRedo.ForeColor = System.Drawing.Color.White;
			this.BtnResultRedo.Location = new System.Drawing.Point(40, 408);
			this.BtnResultRedo.Margin = new System.Windows.Forms.Padding(0);
			this.BtnResultRedo.Name = "BtnResultRedo";
			this.BtnResultRedo.Size = new System.Drawing.Size(25, 24);
			this.BtnResultRedo.TabIndex = 15;
			this.BtnResultRedo.TabStop = false;
			this.BtnResultRedo.Text = "▶";
			this.BtnResultRedo.UseVisualStyleBackColor = false;
			this.BtnResultRedo.Click += new System.EventHandler(this.BtnResultRedo_Click);
			// 
			// BtnResultUndo
			// 
			this.BtnResultUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnResultUndo.BackColor = System.Drawing.Color.DimGray;
			this.BtnResultUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnResultUndo.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnResultUndo.ForeColor = System.Drawing.Color.White;
			this.BtnResultUndo.Location = new System.Drawing.Point(10, 408);
			this.BtnResultUndo.Margin = new System.Windows.Forms.Padding(0);
			this.BtnResultUndo.Name = "BtnResultUndo";
			this.BtnResultUndo.Size = new System.Drawing.Size(25, 24);
			this.BtnResultUndo.TabIndex = 14;
			this.BtnResultUndo.TabStop = false;
			this.BtnResultUndo.Text = "◀";
			this.BtnResultUndo.UseVisualStyleBackColor = false;
			this.BtnResultUndo.Click += new System.EventHandler(this.BtnResultUndo_Click);
			// 
			// LblResult
			// 
			this.LblResult.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.LblResult.AutoSize = true;
			this.LblResult.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LblResult.ForeColor = System.Drawing.Color.White;
			this.LblResult.Location = new System.Drawing.Point(150, 411);
			this.LblResult.Margin = new System.Windows.Forms.Padding(0);
			this.LblResult.Name = "LblResult";
			this.LblResult.Size = new System.Drawing.Size(59, 12);
			this.LblResult.TabIndex = 17;
			this.LblResult.Text = "LblResult";
			this.LblResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// TbCmdSub
			// 
			this.TbCmdSub.AllowDrop = true;
			this.TbCmdSub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TbCmdSub.BackColor = System.Drawing.Color.Black;
			this.TbCmdSub.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TbCmdSub.ContextMenuStrip = this.CmsCmdSub;
			this.TbCmdSub.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbCmdSub.ForeColor = System.Drawing.Color.Yellow;
			this.TbCmdSub.Location = new System.Drawing.Point(10, 66);
			this.TbCmdSub.Margin = new System.Windows.Forms.Padding(0);
			this.TbCmdSub.Multiline = true;
			this.TbCmdSub.Name = "TbCmdSub";
			this.TbCmdSub.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TbCmdSub.Size = new System.Drawing.Size(445, 26);
			this.TbCmdSub.TabIndex = 2;
			this.TbCmdSub.WordWrap = false;
			this.TbCmdSub.Enter += new System.EventHandler(this.TbCmdSub_Enter);
			this.TbCmdSub.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbCmdSub_KeyUp);
			// 
			// CmsCmdSub
			// 
			this.CmsCmdSub.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsCmdSub_全クリア,
            this.CmsCmdSub_全コピー,
            this.toolStripSeparator2,
            this.CmsCmdSub_コピー,
            this.CmsCmdSub_切り取り,
            this.CmsCmdSub_貼り付け});
			this.CmsCmdSub.Name = "CmsResult";
			this.CmsCmdSub.Size = new System.Drawing.Size(116, 120);
			// 
			// CmsCmdSub_全クリア
			// 
			this.CmsCmdSub_全クリア.Name = "CmsCmdSub_全クリア";
			this.CmsCmdSub_全クリア.Size = new System.Drawing.Size(115, 22);
			this.CmsCmdSub_全クリア.Text = "全クリア";
			this.CmsCmdSub_全クリア.Click += new System.EventHandler(this.CmsCmdSub_全クリア_Click);
			// 
			// CmsCmdSub_全コピー
			// 
			this.CmsCmdSub_全コピー.Name = "CmsCmdSub_全コピー";
			this.CmsCmdSub_全コピー.Size = new System.Drawing.Size(115, 22);
			this.CmsCmdSub_全コピー.Text = "全コピー";
			this.CmsCmdSub_全コピー.Click += new System.EventHandler(this.CmsCmdSub_全コピー_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(112, 6);
			// 
			// CmsCmdSub_コピー
			// 
			this.CmsCmdSub_コピー.Name = "CmsCmdSub_コピー";
			this.CmsCmdSub_コピー.Size = new System.Drawing.Size(115, 22);
			this.CmsCmdSub_コピー.Text = "コピー";
			this.CmsCmdSub_コピー.Click += new System.EventHandler(this.CmsCmdSub_コピー_Click);
			// 
			// CmsCmdSub_切り取り
			// 
			this.CmsCmdSub_切り取り.Name = "CmsCmdSub_切り取り";
			this.CmsCmdSub_切り取り.Size = new System.Drawing.Size(115, 22);
			this.CmsCmdSub_切り取り.Text = "切り取り";
			this.CmsCmdSub_切り取り.Click += new System.EventHandler(this.CmsCmdSub_切り取り_Click);
			// 
			// CmsCmdSub_貼り付け
			// 
			this.CmsCmdSub_貼り付け.Name = "CmsCmdSub_貼り付け";
			this.CmsCmdSub_貼り付け.Size = new System.Drawing.Size(115, 22);
			this.CmsCmdSub_貼り付け.Text = "貼り付け";
			this.CmsCmdSub_貼り付け.Click += new System.EventHandler(this.CmsCmdSub_貼り付け_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(464, 441);
			this.Controls.Add(this.DgvEdit);
			this.Controls.Add(this.TbDgvCmdSearch);
			this.Controls.Add(this.DgvCmd);
			this.Controls.Add(this.BtnResultMem);
			this.Controls.Add(this.CbDgvEdit);
			this.Controls.Add(this.CbDgvCmd);
			this.Controls.Add(this.BtnCmdExec);
			this.Controls.Add(this.BtnCmdStop);
			this.Controls.Add(this.LblResult);
			this.Controls.Add(this.NumericUpDown1);
			this.Controls.Add(this.Lbl2);
			this.Controls.Add(this.BtnTbResultWrite);
			this.Controls.Add(this.BtnResultRedo);
			this.Controls.Add(this.BtnResultUndo);
			this.Controls.Add(this.BtnCmdUndo);
			this.Controls.Add(this.BtnCmdRedo);
			this.Controls.Add(this.TbResult);
			this.Controls.Add(this.TbCmd);
			this.Controls.Add(this.TbCurDir);
			this.Controls.Add(this.CbTextCode);
			this.Controls.Add(this.TbCmdSub);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(480, 480);
			this.Name = "Form1";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "iwm_commandliner2";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.DgvEdit)).EndInit();
			this.CmsResult.ResumeLayout(false);
			this.CmsCmd.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DgvCmd)).EndInit();
			this.CmsCmdSub.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button BtnCmdStop;
		private System.Windows.Forms.DataGridView DgvEdit;
		private System.Windows.Forms.ContextMenuStrip CmsResult;
		private System.Windows.Forms.ToolStripSeparator CmsResult_L2;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_切り取り;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_コピー;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_貼り付け;
		private System.Windows.Forms.TextBox TbCmd;
		private System.Windows.Forms.ToolStripSeparator CmsResult_L3;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_全コピー;
		private System.Windows.Forms.TextBox TbCurDir;
		private System.Windows.Forms.ToolStripSeparator CmsResult_L4;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_名前を付けて保存;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_名前を付けて保存_ShiftJIS;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_名前を付けて保存_UTF8N;
		private System.Windows.Forms.ContextMenuStrip CmsCmd;
		private System.Windows.Forms.ToolStripMenuItem CmsCmd_貼り付け;
		private System.Windows.Forms.ToolTip ToolTip1;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_上へ;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_下へ;
		private System.Windows.Forms.ContextMenuStrip CmsNull;
		private System.Windows.Forms.NumericUpDown NumericUpDown1;
		private System.Windows.Forms.Label Lbl2;
		private System.Windows.Forms.ToolStripMenuItem CmsCmd_全コピー;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem CmsCmd_切り取り;
		private System.Windows.Forms.ToolStripMenuItem CmsCmd_コピー;
		private System.Windows.Forms.ToolStripMenuItem CmsCmd_全クリア;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_全クリア;
		private System.Windows.Forms.Button BtnCmdRedo;
		private System.Windows.Forms.Button BtnCmdUndo;
		private System.Windows.Forms.TextBox TbDgvCmdSearch;
		private System.Windows.Forms.DataGridView DgvCmd;
		private System.Windows.Forms.TextBox TbResult;
		private System.Windows.Forms.CheckBox CbDgvEdit;
		private System.Windows.Forms.CheckBox CbDgvCmd;
		private System.Windows.Forms.Button BtnResultRedo;
		private System.Windows.Forms.Button BtnResultUndo;
		private System.Windows.Forms.Button BtnTbResultWrite;
		private System.Windows.Forms.Label LblResult;
		private System.Windows.Forms.Button BtnCmdExec;
		private System.Windows.Forms.Button BtnResultMem;
		private System.Windows.Forms.TextBox TbCmdSub;
		private System.Windows.Forms.ContextMenuStrip CmsCmdSub;
		private System.Windows.Forms.ToolStripMenuItem CmsCmdSub_全クリア;
		private System.Windows.Forms.ToolStripMenuItem CmsCmdSub_全コピー;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem CmsCmdSub_切り取り;
		private System.Windows.Forms.ToolStripMenuItem CmsCmdSub_コピー;
		private System.Windows.Forms.ToolStripMenuItem CmsCmdSub_貼り付け;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_選択文字列を実行;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ComboBox CbTextCode;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_ファイル名を貼り付け;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_全選択;
		private System.Windows.Forms.DataGridViewTextBoxColumn DgvCmd01;
		private System.Windows.Forms.ToolStripMenuItem CmsCmd_実行;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Dgv_Tbc21;
		private System.Windows.Forms.DataGridViewTextBoxColumn Dgv_Tbc22;
	}
}

