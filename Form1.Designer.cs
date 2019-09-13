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
			this.CmsResult_L2 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsResult_全クリア = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_全選択 = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_L3 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsResult_切り取り = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_コピー = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_貼り付け = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_L4 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsResult_名前を付けて保存 = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_名前を付けて保存_ShiftJIS = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_名前を付けて保存_UTF8N = new System.Windows.Forms.ToolStripMenuItem();
			this.TbCmd = new System.Windows.Forms.TextBox();
			this.CmsCmd = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CmsCmd_全クリア = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmd_全選択 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsCmd_切り取り = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmd_コピー = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmd_貼り付け = new System.Windows.Forms.ToolStripMenuItem();
			this.TbCurDir = new System.Windows.Forms.TextBox();
			this.CmsNull = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.BtnTbResultWrite = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
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
			((System.ComponentModel.ISupportInitialize)(this.DgvEdit)).BeginInit();
			this.CmsResult.SuspendLayout();
			this.CmsCmd.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DgvCmd)).BeginInit();
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
			this.BtnCmdStop.Location = new System.Drawing.Point(433, 80);
			this.BtnCmdStop.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdStop.Name = "BtnCmdStop";
			this.BtnCmdStop.Size = new System.Drawing.Size(22, 22);
			this.BtnCmdStop.TabIndex = 8;
			this.BtnCmdStop.TabStop = false;
			this.BtnCmdStop.Text = "✖";
			this.ToolTip1.SetToolTip(this.BtnCmdStop, "中断");
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
			this.DgvEdit.Location = new System.Drawing.Point(82, 80);
			this.DgvEdit.Margin = new System.Windows.Forms.Padding(0);
			this.DgvEdit.MultiSelect = false;
			this.DgvEdit.Name = "DgvEdit";
			this.DgvEdit.ReadOnly = true;
			this.DgvEdit.RowHeadersVisible = false;
			this.DgvEdit.RowTemplate.Height = 21;
			this.DgvEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.DgvEdit.Size = new System.Drawing.Size(68, 24);
			this.DgvEdit.StandardTab = true;
			this.DgvEdit.TabIndex = 4;
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
			this.Dgv_Tbc21.HeaderText = "編集";
			this.Dgv_Tbc21.MinimumWidth = 60;
			this.Dgv_Tbc21.Name = "Dgv_Tbc21";
			this.Dgv_Tbc21.ReadOnly = true;
			this.Dgv_Tbc21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Dgv_Tbc21.Width = 70;
			// 
			// Dgv_Tbc22
			// 
			this.Dgv_Tbc22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Dgv_Tbc22.FillWeight = 150F;
			this.Dgv_Tbc22.HeaderText = "";
			this.Dgv_Tbc22.MinimumWidth = 80;
			this.Dgv_Tbc22.Name = "Dgv_Tbc22";
			this.Dgv_Tbc22.ReadOnly = true;
			this.Dgv_Tbc22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Dgv_Tbc22.Width = 300;
			// 
			// CmsResult
			// 
			this.CmsResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsResult_上へ,
            this.CmsResult_下へ,
            this.CmsResult_L2,
            this.CmsResult_全クリア,
            this.CmsResult_全選択,
            this.CmsResult_L3,
            this.CmsResult_切り取り,
            this.CmsResult_コピー,
            this.CmsResult_貼り付け,
            this.CmsResult_L4,
            this.CmsResult_名前を付けて保存});
			this.CmsResult.Name = "CmsResult";
			this.CmsResult.Size = new System.Drawing.Size(173, 198);
			// 
			// CmsResult_上へ
			// 
			this.CmsResult_上へ.ForeColor = System.Drawing.Color.OrangeRed;
			this.CmsResult_上へ.Name = "CmsResult_上へ";
			this.CmsResult_上へ.Size = new System.Drawing.Size(172, 22);
			this.CmsResult_上へ.Text = "▲";
			this.CmsResult_上へ.Click += new System.EventHandler(this.CmsResult_上へ_Click);
			// 
			// CmsResult_下へ
			// 
			this.CmsResult_下へ.ForeColor = System.Drawing.Color.OrangeRed;
			this.CmsResult_下へ.Name = "CmsResult_下へ";
			this.CmsResult_下へ.Size = new System.Drawing.Size(172, 22);
			this.CmsResult_下へ.Text = "▼";
			this.CmsResult_下へ.Click += new System.EventHandler(this.CmsResult_下へ_Click);
			// 
			// CmsResult_L2
			// 
			this.CmsResult_L2.Name = "CmsResult_L2";
			this.CmsResult_L2.Size = new System.Drawing.Size(169, 6);
			// 
			// CmsResult_全クリア
			// 
			this.CmsResult_全クリア.Name = "CmsResult_全クリア";
			this.CmsResult_全クリア.Size = new System.Drawing.Size(172, 22);
			this.CmsResult_全クリア.Text = "全クリア";
			this.CmsResult_全クリア.Click += new System.EventHandler(this.CmsResult_全クリア_Click);
			// 
			// CmsResult_全選択
			// 
			this.CmsResult_全選択.Name = "CmsResult_全選択";
			this.CmsResult_全選択.Size = new System.Drawing.Size(172, 22);
			this.CmsResult_全選択.Text = "全選択";
			this.CmsResult_全選択.Click += new System.EventHandler(this.CmsResult_全選択_Click);
			// 
			// CmsResult_L3
			// 
			this.CmsResult_L3.Name = "CmsResult_L3";
			this.CmsResult_L3.Size = new System.Drawing.Size(169, 6);
			// 
			// CmsResult_切り取り
			// 
			this.CmsResult_切り取り.Name = "CmsResult_切り取り";
			this.CmsResult_切り取り.Size = new System.Drawing.Size(172, 22);
			this.CmsResult_切り取り.Text = "切り取り";
			this.CmsResult_切り取り.Click += new System.EventHandler(this.CmsResult_切り取り_Click);
			// 
			// CmsResult_コピー
			// 
			this.CmsResult_コピー.Name = "CmsResult_コピー";
			this.CmsResult_コピー.Size = new System.Drawing.Size(172, 22);
			this.CmsResult_コピー.Text = "コピー";
			this.CmsResult_コピー.Click += new System.EventHandler(this.CmsResult_コピー_Click);
			// 
			// CmsResult_貼り付け
			// 
			this.CmsResult_貼り付け.Name = "CmsResult_貼り付け";
			this.CmsResult_貼り付け.Size = new System.Drawing.Size(172, 22);
			this.CmsResult_貼り付け.Text = "貼り付け";
			this.CmsResult_貼り付け.Click += new System.EventHandler(this.CmsResult_貼り付け_Click);
			// 
			// CmsResult_L4
			// 
			this.CmsResult_L4.Name = "CmsResult_L4";
			this.CmsResult_L4.Size = new System.Drawing.Size(169, 6);
			// 
			// CmsResult_名前を付けて保存
			// 
			this.CmsResult_名前を付けて保存.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsResult_名前を付けて保存_ShiftJIS,
            this.CmsResult_名前を付けて保存_UTF8N});
			this.CmsResult_名前を付けて保存.Name = "CmsResult_名前を付けて保存";
			this.CmsResult_名前を付けて保存.Size = new System.Drawing.Size(172, 22);
			this.CmsResult_名前を付けて保存.Text = "名前を付けて保存";
			// 
			// CmsResult_名前を付けて保存_ShiftJIS
			// 
			this.CmsResult_名前を付けて保存_ShiftJIS.Name = "CmsResult_名前を付けて保存_ShiftJIS";
			this.CmsResult_名前を付けて保存_ShiftJIS.Size = new System.Drawing.Size(128, 22);
			this.CmsResult_名前を付けて保存_ShiftJIS.Text = "Shift_JIS";
			this.CmsResult_名前を付けて保存_ShiftJIS.Click += new System.EventHandler(this.CmsResult_名前を付けて保存_ShiftJIS_Click);
			// 
			// CmsResult_名前を付けて保存_UTF8N
			// 
			this.CmsResult_名前を付けて保存_UTF8N.Name = "CmsResult_名前を付けて保存_UTF8N";
			this.CmsResult_名前を付けて保存_UTF8N.Size = new System.Drawing.Size(128, 22);
			this.CmsResult_名前を付けて保存_UTF8N.Text = "UTF-8N";
			this.CmsResult_名前を付けて保存_UTF8N.Click += new System.EventHandler(this.CmsResult_名前を付けて保存_UTF8N_Click);
			// 
			// TbCmd
			// 
			this.TbCmd.AllowDrop = true;
			this.TbCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TbCmd.BackColor = System.Drawing.Color.White;
			this.TbCmd.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TbCmd.ContextMenuStrip = this.CmsCmd;
			this.TbCmd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbCmd.Location = new System.Drawing.Point(11, 25);
			this.TbCmd.Margin = new System.Windows.Forms.Padding(0);
			this.TbCmd.Multiline = true;
			this.TbCmd.Name = "TbCmd";
			this.TbCmd.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.TbCmd.Size = new System.Drawing.Size(445, 50);
			this.TbCmd.TabIndex = 1;
			this.TbCmd.WordWrap = false;
			this.TbCmd.DragDrop += new System.Windows.Forms.DragEventHandler(this.TbCmd_DragDrop);
			this.TbCmd.DragEnter += new System.Windows.Forms.DragEventHandler(this.TbCmd_DragEnter);
			this.TbCmd.Enter += new System.EventHandler(this.TbCmd_Enter);
			this.TbCmd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbCmd_KeyUp);
			this.TbCmd.MouseHover += new System.EventHandler(this.TbCmd_MouseHover);
			// 
			// CmsCmd
			// 
			this.CmsCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsCmd_全クリア,
            this.CmsCmd_全選択,
            this.toolStripSeparator1,
            this.CmsCmd_切り取り,
            this.CmsCmd_コピー,
            this.CmsCmd_貼り付け});
			this.CmsCmd.Name = "CmsResult";
			this.CmsCmd.Size = new System.Drawing.Size(125, 120);
			// 
			// CmsCmd_全クリア
			// 
			this.CmsCmd_全クリア.Name = "CmsCmd_全クリア";
			this.CmsCmd_全クリア.Size = new System.Drawing.Size(124, 22);
			this.CmsCmd_全クリア.Text = "全クリア";
			this.CmsCmd_全クリア.Click += new System.EventHandler(this.CmsCmd_全クリア_Click);
			// 
			// CmsCmd_全選択
			// 
			this.CmsCmd_全選択.Name = "CmsCmd_全選択";
			this.CmsCmd_全選択.Size = new System.Drawing.Size(124, 22);
			this.CmsCmd_全選択.Text = "全選択";
			this.CmsCmd_全選択.Click += new System.EventHandler(this.CmsCmd_全選択_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
			// 
			// CmsCmd_切り取り
			// 
			this.CmsCmd_切り取り.Name = "CmsCmd_切り取り";
			this.CmsCmd_切り取り.Size = new System.Drawing.Size(124, 22);
			this.CmsCmd_切り取り.Text = "切り取り";
			this.CmsCmd_切り取り.Click += new System.EventHandler(this.CmsCmd_切り取り_Click);
			// 
			// CmsCmd_コピー
			// 
			this.CmsCmd_コピー.Name = "CmsCmd_コピー";
			this.CmsCmd_コピー.Size = new System.Drawing.Size(124, 22);
			this.CmsCmd_コピー.Text = "コピー";
			this.CmsCmd_コピー.Click += new System.EventHandler(this.CmsCmd_コピー_Click);
			// 
			// CmsCmd_貼り付け
			// 
			this.CmsCmd_貼り付け.Name = "CmsCmd_貼り付け";
			this.CmsCmd_貼り付け.Size = new System.Drawing.Size(124, 22);
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
			this.TbCurDir.ForeColor = System.Drawing.Color.Snow;
			this.TbCurDir.Location = new System.Drawing.Point(12, 8);
			this.TbCurDir.Margin = new System.Windows.Forms.Padding(0);
			this.TbCurDir.Name = "TbCurDir";
			this.TbCurDir.Size = new System.Drawing.Size(443, 13);
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
			this.BtnTbResultWrite.Location = new System.Drawing.Point(433, 405);
			this.BtnTbResultWrite.Margin = new System.Windows.Forms.Padding(0);
			this.BtnTbResultWrite.Name = "BtnTbResultWrite";
			this.BtnTbResultWrite.Size = new System.Drawing.Size(22, 22);
			this.BtnTbResultWrite.TabIndex = 15;
			this.BtnTbResultWrite.TabStop = false;
			this.BtnTbResultWrite.Text = "★";
			this.ToolTip1.SetToolTip(this.BtnTbResultWrite, "画面ロック解除");
			this.BtnTbResultWrite.UseVisualStyleBackColor = false;
			this.BtnTbResultWrite.Click += new System.EventHandler(this.BtnTbResultWrite_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.BackColor = System.Drawing.Color.DimGray;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(400, 80);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(22, 22);
			this.button1.TabIndex = 7;
			this.button1.TabStop = false;
			this.button1.Text = "●";
			this.ToolTip1.SetToolTip(this.button1, "実行");
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.BtnCmdExec_Click);
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
			this.NumericUpDown1.Location = new System.Drawing.Point(360, 406);
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
			this.NumericUpDown1.TabIndex = 13;
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
			this.Lbl2.ForeColor = System.Drawing.Color.Snow;
			this.Lbl2.Location = new System.Drawing.Point(405, 407);
			this.Lbl2.Margin = new System.Windows.Forms.Padding(0);
			this.Lbl2.Name = "Lbl2";
			this.Lbl2.Size = new System.Drawing.Size(20, 15);
			this.Lbl2.TabIndex = 14;
			this.Lbl2.Text = "pt";
			this.Lbl2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// BtnCmdRedo
			// 
			this.BtnCmdRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdRedo.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdRedo.ForeColor = System.Drawing.Color.White;
			this.BtnCmdRedo.Location = new System.Drawing.Point(40, 80);
			this.BtnCmdRedo.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdRedo.Name = "BtnCmdRedo";
			this.BtnCmdRedo.Size = new System.Drawing.Size(25, 24);
			this.BtnCmdRedo.TabIndex = 3;
			this.BtnCmdRedo.TabStop = false;
			this.BtnCmdRedo.Text = "▶";
			this.BtnCmdRedo.UseVisualStyleBackColor = true;
			this.BtnCmdRedo.Click += new System.EventHandler(this.BtnCmdRedo_Click);
			// 
			// BtnCmdUndo
			// 
			this.BtnCmdUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdUndo.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdUndo.ForeColor = System.Drawing.Color.White;
			this.BtnCmdUndo.Location = new System.Drawing.Point(10, 80);
			this.BtnCmdUndo.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdUndo.Name = "BtnCmdUndo";
			this.BtnCmdUndo.Size = new System.Drawing.Size(25, 24);
			this.BtnCmdUndo.TabIndex = 2;
			this.BtnCmdUndo.TabStop = false;
			this.BtnCmdUndo.Text = "◀";
			this.BtnCmdUndo.UseVisualStyleBackColor = true;
			this.BtnCmdUndo.Click += new System.EventHandler(this.BtnCmdUndo_Click);
			// 
			// TbDgvCmdSearch
			// 
			this.TbDgvCmdSearch.BackColor = System.Drawing.Color.WhiteSmoke;
			this.TbDgvCmdSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TbDgvCmdSearch.ContextMenuStrip = this.CmsNull;
			this.TbDgvCmdSearch.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbDgvCmdSearch.Location = new System.Drawing.Point(230, 81);
			this.TbDgvCmdSearch.Name = "TbDgvCmdSearch";
			this.TbDgvCmdSearch.Size = new System.Drawing.Size(80, 20);
			this.TbDgvCmdSearch.TabIndex = 6;
			this.TbDgvCmdSearch.WordWrap = false;
			this.TbDgvCmdSearch.TextChanged += new System.EventHandler(this.TbDgvCmdSearch_TextChanged);
			this.TbDgvCmdSearch.Enter += new System.EventHandler(this.TbDgvCmdSearch_Enter);
			this.TbDgvCmdSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbDgvCmdSearch_KeyUp);
			this.TbDgvCmdSearch.Leave += new System.EventHandler(this.TbDgvCmdSearch_Leave);
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
			this.DgvCmd.Location = new System.Drawing.Point(165, 80);
			this.DgvCmd.Margin = new System.Windows.Forms.Padding(0);
			this.DgvCmd.MultiSelect = false;
			this.DgvCmd.Name = "DgvCmd";
			this.DgvCmd.ReadOnly = true;
			this.DgvCmd.RowHeadersVisible = false;
			this.DgvCmd.RowTemplate.Height = 21;
			this.DgvCmd.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.DgvCmd.Size = new System.Drawing.Size(68, 24);
			this.DgvCmd.TabIndex = 5;
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
			this.TbResult.Location = new System.Drawing.Point(10, 115);
			this.TbResult.Margin = new System.Windows.Forms.Padding(0);
			this.TbResult.MaxLength = 2147483647;
			this.TbResult.Multiline = true;
			this.TbResult.Name = "TbResult";
			this.TbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TbResult.Size = new System.Drawing.Size(445, 285);
			this.TbResult.TabIndex = 9;
			this.TbResult.TabStop = false;
			this.TbResult.WordWrap = false;
			this.TbResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbResult_KeyUp);
			this.TbResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TbResult_MouseUp);
			// 
			// CbDgvEdit
			// 
			this.CbDgvEdit.AutoSize = true;
			this.CbDgvEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CbDgvEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CbDgvEdit.Location = new System.Drawing.Point(72, 85);
			this.CbDgvEdit.Margin = new System.Windows.Forms.Padding(0);
			this.CbDgvEdit.Name = "CbDgvEdit";
			this.CbDgvEdit.Size = new System.Drawing.Size(12, 11);
			this.CbDgvEdit.TabIndex = 4;
			this.CbDgvEdit.UseVisualStyleBackColor = true;
			this.CbDgvEdit.Click += new System.EventHandler(this.CbDgvEdit_Click);
			// 
			// CbDgvCmd
			// 
			this.CbDgvCmd.AutoSize = true;
			this.CbDgvCmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CbDgvCmd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CbDgvCmd.Location = new System.Drawing.Point(155, 85);
			this.CbDgvCmd.Margin = new System.Windows.Forms.Padding(0);
			this.CbDgvCmd.Name = "CbDgvCmd";
			this.CbDgvCmd.Size = new System.Drawing.Size(12, 11);
			this.CbDgvCmd.TabIndex = 5;
			this.CbDgvCmd.UseVisualStyleBackColor = true;
			this.CbDgvCmd.Click += new System.EventHandler(this.CbDgvCmd_Click);
			// 
			// BtnResultRedo
			// 
			this.BtnResultRedo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnResultRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnResultRedo.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnResultRedo.ForeColor = System.Drawing.Color.White;
			this.BtnResultRedo.Location = new System.Drawing.Point(40, 405);
			this.BtnResultRedo.Margin = new System.Windows.Forms.Padding(0);
			this.BtnResultRedo.Name = "BtnResultRedo";
			this.BtnResultRedo.Size = new System.Drawing.Size(25, 24);
			this.BtnResultRedo.TabIndex = 11;
			this.BtnResultRedo.TabStop = false;
			this.BtnResultRedo.Text = "▶";
			this.BtnResultRedo.UseVisualStyleBackColor = true;
			this.BtnResultRedo.Click += new System.EventHandler(this.BtnResultRedo_Click);
			// 
			// BtnResultUndo
			// 
			this.BtnResultUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnResultUndo.BackColor = System.Drawing.Color.DimGray;
			this.BtnResultUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnResultUndo.Font = new System.Drawing.Font("Yu Gothic UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnResultUndo.ForeColor = System.Drawing.Color.White;
			this.BtnResultUndo.Location = new System.Drawing.Point(10, 405);
			this.BtnResultUndo.Margin = new System.Windows.Forms.Padding(0);
			this.BtnResultUndo.Name = "BtnResultUndo";
			this.BtnResultUndo.Size = new System.Drawing.Size(25, 24);
			this.BtnResultUndo.TabIndex = 10;
			this.BtnResultUndo.TabStop = false;
			this.BtnResultUndo.Text = "◀";
			this.BtnResultUndo.UseVisualStyleBackColor = false;
			this.BtnResultUndo.Click += new System.EventHandler(this.BtnResultUndo_Click);
			// 
			// LblResult
			// 
			this.LblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblResult.AutoSize = true;
			this.LblResult.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LblResult.ForeColor = System.Drawing.Color.Snow;
			this.LblResult.Location = new System.Drawing.Point(150, 408);
			this.LblResult.Margin = new System.Windows.Forms.Padding(0);
			this.LblResult.Name = "LblResult";
			this.LblResult.Size = new System.Drawing.Size(70, 13);
			this.LblResult.TabIndex = 12;
			this.LblResult.Text = "LblResult";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(464, 441);
			this.Controls.Add(this.CbDgvEdit);
			this.Controls.Add(this.DgvEdit);
			this.Controls.Add(this.CbDgvCmd);
			this.Controls.Add(this.TbDgvCmdSearch);
			this.Controls.Add(this.DgvCmd);
			this.Controls.Add(this.button1);
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
		private System.Windows.Forms.ToolStripMenuItem CmsResult_全選択;
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
		private System.Windows.Forms.ToolStripMenuItem CmsCmd_全選択;
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
		private System.Windows.Forms.DataGridViewTextBoxColumn Dgv_Tbc21;
		private System.Windows.Forms.DataGridViewTextBoxColumn Dgv_Tbc22;
		private System.Windows.Forms.DataGridViewTextBoxColumn DgvCmd01;
		private System.Windows.Forms.Label LblResult;
		private System.Windows.Forms.Button button1;
	}
}

