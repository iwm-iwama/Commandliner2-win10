namespace iwm_commandliner
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
			this.BtnCmdExec = new System.Windows.Forms.Button();
			this.BtnCmdStop = new System.Windows.Forms.Button();
			this.BtnCmdSelectFile = new System.Windows.Forms.Button();
			this.Dgv2 = new System.Windows.Forms.DataGridView();
			this.Dgv_Tbc21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Dgv_Tbc22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BtnCmdSelectDir = new System.Windows.Forms.Button();
			this.LblCashOn = new System.Windows.Forms.Label();
			this.Dgv1 = new System.Windows.Forms.DataGridView();
			this.Dgv_Tbc11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TbResult = new System.Windows.Forms.TextBox();
			this.CmsResult = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CmsResult_上へ = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_下へ = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_L1 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsResult_カーソルより前をクリア = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_カーソルより後をクリア = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsResult_L2 = new System.Windows.Forms.ToolStripSeparator();
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
			this.CmsCmd_カーソルより前をクリア = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmd_カーソルより後をクリア = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsCmd_L1 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsCmd_貼り付け = new System.Windows.Forms.ToolStripMenuItem();
			this.BtnResultFont = new System.Windows.Forms.Button();
			this.BtnResultUndo = new System.Windows.Forms.Button();
			this.BtnResultCash = new System.Windows.Forms.Button();
			this.BtnCmdClear = new System.Windows.Forms.Button();
			this.BtnResultClear = new System.Windows.Forms.Button();
			this.TbCurDir = new System.Windows.Forms.TextBox();
			this.BtnResultBgColor = new System.Windows.Forms.Button();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.LblCurTb = new System.Windows.Forms.Label();
			this.CmsNull = new System.Windows.Forms.ContextMenuStrip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.Dgv2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
			this.CmsResult.SuspendLayout();
			this.CmsCmd.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnCmdExec
			// 
			this.BtnCmdExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCmdExec.BackColor = System.Drawing.Color.OrangeRed;
			this.BtnCmdExec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdExec.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdExec.ForeColor = System.Drawing.Color.White;
			this.BtnCmdExec.Location = new System.Drawing.Point(495, 74);
			this.BtnCmdExec.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdExec.Name = "BtnCmdExec";
			this.BtnCmdExec.Size = new System.Drawing.Size(80, 24);
			this.BtnCmdExec.TabIndex = 8;
			this.BtnCmdExec.TabStop = false;
			this.BtnCmdExec.Text = "実行 [F8]";
			this.BtnCmdExec.UseVisualStyleBackColor = false;
			this.BtnCmdExec.Click += new System.EventHandler(this.BtnCmdExec_Click);
			// 
			// BtnCmdStop
			// 
			this.BtnCmdStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCmdStop.BackColor = System.Drawing.Color.DimGray;
			this.BtnCmdStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdStop.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdStop.ForeColor = System.Drawing.Color.White;
			this.BtnCmdStop.Location = new System.Drawing.Point(414, 74);
			this.BtnCmdStop.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdStop.Name = "BtnCmdStop";
			this.BtnCmdStop.Size = new System.Drawing.Size(80, 24);
			this.BtnCmdStop.TabIndex = 7;
			this.BtnCmdStop.TabStop = false;
			this.BtnCmdStop.Text = "停止 [F7]";
			this.BtnCmdStop.UseVisualStyleBackColor = false;
			this.BtnCmdStop.Click += new System.EventHandler(this.BtnCmdStop_Click);
			// 
			// BtnCmdSelectFile
			// 
			this.BtnCmdSelectFile.BackColor = System.Drawing.Color.DimGray;
			this.BtnCmdSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdSelectFile.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdSelectFile.ForeColor = System.Drawing.Color.White;
			this.BtnCmdSelectFile.Location = new System.Drawing.Point(248, 74);
			this.BtnCmdSelectFile.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdSelectFile.Name = "BtnCmdSelectFile";
			this.BtnCmdSelectFile.Size = new System.Drawing.Size(70, 24);
			this.BtnCmdSelectFile.TabIndex = 5;
			this.BtnCmdSelectFile.TabStop = false;
			this.BtnCmdSelectFile.Text = "File [F4]";
			this.BtnCmdSelectFile.UseVisualStyleBackColor = false;
			this.BtnCmdSelectFile.Click += new System.EventHandler(this.BtnCmdSelectFile_Click);
			// 
			// Dgv2
			// 
			this.Dgv2.AllowUserToAddRows = false;
			this.Dgv2.AllowUserToDeleteRows = false;
			this.Dgv2.BackgroundColor = System.Drawing.Color.Gray;
			this.Dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dgv_Tbc21,
            this.Dgv_Tbc22});
			this.Dgv2.GridColor = System.Drawing.Color.Gray;
			this.Dgv2.Location = new System.Drawing.Point(94, 74);
			this.Dgv2.Margin = new System.Windows.Forms.Padding(0);
			this.Dgv2.MultiSelect = false;
			this.Dgv2.Name = "Dgv2";
			this.Dgv2.ReadOnly = true;
			this.Dgv2.RowHeadersVisible = false;
			this.Dgv2.RowTemplate.Height = 21;
			this.Dgv2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Dgv2.Size = new System.Drawing.Size(80, 24);
			this.Dgv2.StandardTab = true;
			this.Dgv2.TabIndex = 3;
			this.Dgv2.TabStop = false;
			this.Dgv2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv2_CellClick);
			this.Dgv2.Enter += new System.EventHandler(this.Dgv2_Enter);
			this.Dgv2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dgv2_KeyDown);
			this.Dgv2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Dgv2_KeyUp);
			this.Dgv2.Leave += new System.EventHandler(this.Dgv2_Leave);
			this.Dgv2.MouseEnter += new System.EventHandler(this.Dgv2_MouseEnter);
			this.Dgv2.MouseLeave += new System.EventHandler(this.Dgv2_MouseLeave);
			// 
			// Dgv_Tbc21
			// 
			this.Dgv_Tbc21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Dgv_Tbc21.FillWeight = 150F;
			this.Dgv_Tbc21.HeaderText = "編集 [F2]";
			this.Dgv_Tbc21.MinimumWidth = 80;
			this.Dgv_Tbc21.Name = "Dgv_Tbc21";
			this.Dgv_Tbc21.ReadOnly = true;
			this.Dgv_Tbc21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Dgv_Tbc21.Width = 80;
			// 
			// Dgv_Tbc22
			// 
			this.Dgv_Tbc22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Dgv_Tbc22.FillWeight = 150F;
			this.Dgv_Tbc22.HeaderText = "説明";
			this.Dgv_Tbc22.MinimumWidth = 320;
			this.Dgv_Tbc22.Name = "Dgv_Tbc22";
			this.Dgv_Tbc22.ReadOnly = true;
			this.Dgv_Tbc22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Dgv_Tbc22.Width = 320;
			// 
			// BtnCmdSelectDir
			// 
			this.BtnCmdSelectDir.BackColor = System.Drawing.Color.DimGray;
			this.BtnCmdSelectDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdSelectDir.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdSelectDir.ForeColor = System.Drawing.Color.White;
			this.BtnCmdSelectDir.Location = new System.Drawing.Point(182, 74);
			this.BtnCmdSelectDir.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdSelectDir.Name = "BtnCmdSelectDir";
			this.BtnCmdSelectDir.Size = new System.Drawing.Size(65, 24);
			this.BtnCmdSelectDir.TabIndex = 5;
			this.BtnCmdSelectDir.TabStop = false;
			this.BtnCmdSelectDir.Text = "Dir [F3]";
			this.BtnCmdSelectDir.UseVisualStyleBackColor = false;
			this.BtnCmdSelectDir.Click += new System.EventHandler(this.BtnCmdSelectDir_Click);
			// 
			// LblCashOn
			// 
			this.LblCashOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LblCashOn.BackColor = System.Drawing.Color.DimGray;
			this.LblCashOn.Cursor = System.Windows.Forms.Cursors.Default;
			this.LblCashOn.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LblCashOn.ForeColor = System.Drawing.Color.Red;
			this.LblCashOn.Location = new System.Drawing.Point(530, 395);
			this.LblCashOn.Margin = new System.Windows.Forms.Padding(0);
			this.LblCashOn.Name = "LblCashOn";
			this.LblCashOn.Size = new System.Drawing.Size(10, 10);
			this.LblCashOn.TabIndex = 17;
			this.LblCashOn.Text = "●";
			this.LblCashOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LblCashOn.Visible = false;
			// 
			// Dgv1
			// 
			this.Dgv1.AllowUserToAddRows = false;
			this.Dgv1.AllowUserToDeleteRows = false;
			this.Dgv1.BackgroundColor = System.Drawing.Color.Gray;
			this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dgv_Tbc11});
			this.Dgv1.GridColor = System.Drawing.Color.Gray;
			this.Dgv1.Location = new System.Drawing.Point(10, 74);
			this.Dgv1.Margin = new System.Windows.Forms.Padding(0);
			this.Dgv1.MultiSelect = false;
			this.Dgv1.Name = "Dgv1";
			this.Dgv1.ReadOnly = true;
			this.Dgv1.RowHeadersVisible = false;
			this.Dgv1.RowTemplate.Height = 21;
			this.Dgv1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.Dgv1.Size = new System.Drawing.Size(80, 24);
			this.Dgv1.StandardTab = true;
			this.Dgv1.TabIndex = 2;
			this.Dgv1.TabStop = false;
			this.Dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv1_CellClick);
			this.Dgv1.Enter += new System.EventHandler(this.Dgv1_Enter);
			this.Dgv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dgv1_KeyDown);
			this.Dgv1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Dgv1_KeyUp);
			this.Dgv1.Leave += new System.EventHandler(this.Dgv1_Leave);
			this.Dgv1.MouseEnter += new System.EventHandler(this.Dgv1_MouseEnter);
			this.Dgv1.MouseLeave += new System.EventHandler(this.Dgv1_MouseLeave);
			// 
			// Dgv_Tbc11
			// 
			this.Dgv_Tbc11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Dgv_Tbc11.FillWeight = 170F;
			this.Dgv_Tbc11.HeaderText = "履歴 [F1]";
			this.Dgv_Tbc11.MinimumWidth = 80;
			this.Dgv_Tbc11.Name = "Dgv_Tbc11";
			this.Dgv_Tbc11.ReadOnly = true;
			this.Dgv_Tbc11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Dgv_Tbc11.Width = 80;
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
			this.TbResult.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbResult.ForeColor = System.Drawing.Color.Lime;
			this.TbResult.Location = new System.Drawing.Point(10, 107);
			this.TbResult.Margin = new System.Windows.Forms.Padding(0);
			this.TbResult.MaxLength = 2147483647;
			this.TbResult.Multiline = true;
			this.TbResult.Name = "TbResult";
			this.TbResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TbResult.Size = new System.Drawing.Size(565, 288);
			this.TbResult.TabIndex = 9;
			this.TbResult.TabStop = false;
			this.TbResult.WordWrap = false;
			this.TbResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TbResult_MouseClick);
			this.TbResult.DragDrop += new System.Windows.Forms.DragEventHandler(this.TbResult_DragDrop);
			this.TbResult.DragEnter += new System.Windows.Forms.DragEventHandler(this.TbResult_DragEnter);
			this.TbResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbResult_KeyUp);
			// 
			// CmsResult
			// 
			this.CmsResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsResult_上へ,
            this.CmsResult_下へ,
            this.CmsResult_L1,
            this.CmsResult_カーソルより前をクリア,
            this.CmsResult_カーソルより後をクリア,
            this.CmsResult_L2,
            this.CmsResult_全選択,
            this.CmsResult_L3,
            this.CmsResult_切り取り,
            this.CmsResult_コピー,
            this.CmsResult_貼り付け,
            this.CmsResult_L4,
            this.CmsResult_名前を付けて保存});
			this.CmsResult.Name = "CmsResult";
			this.CmsResult.Size = new System.Drawing.Size(175, 226);
			// 
			// CmsResult_上へ
			// 
			this.CmsResult_上へ.ForeColor = System.Drawing.Color.OrangeRed;
			this.CmsResult_上へ.Name = "CmsResult_上へ";
			this.CmsResult_上へ.Size = new System.Drawing.Size(174, 22);
			this.CmsResult_上へ.Text = "▲";
			this.CmsResult_上へ.Click += new System.EventHandler(this.CmsResult_上へ_Click);
			// 
			// CmsResult_下へ
			// 
			this.CmsResult_下へ.ForeColor = System.Drawing.Color.OrangeRed;
			this.CmsResult_下へ.Name = "CmsResult_下へ";
			this.CmsResult_下へ.Size = new System.Drawing.Size(174, 22);
			this.CmsResult_下へ.Text = "▼";
			this.CmsResult_下へ.Click += new System.EventHandler(this.CmsResult_下へ_Click);
			// 
			// CmsResult_L1
			// 
			this.CmsResult_L1.Name = "CmsResult_L1";
			this.CmsResult_L1.Size = new System.Drawing.Size(171, 6);
			// 
			// CmsResult_カーソルより前をクリア
			// 
			this.CmsResult_カーソルより前をクリア.Name = "CmsResult_カーソルより前をクリア";
			this.CmsResult_カーソルより前をクリア.Size = new System.Drawing.Size(174, 22);
			this.CmsResult_カーソルより前をクリア.Text = "カーソルより前をクリア";
			this.CmsResult_カーソルより前をクリア.Click += new System.EventHandler(this.CmsResult_カーソルより前をクリア_Click);
			// 
			// CmsResult_カーソルより後をクリア
			// 
			this.CmsResult_カーソルより後をクリア.Name = "CmsResult_カーソルより後をクリア";
			this.CmsResult_カーソルより後をクリア.Size = new System.Drawing.Size(174, 22);
			this.CmsResult_カーソルより後をクリア.Text = "カーソルより後をクリア";
			this.CmsResult_カーソルより後をクリア.Click += new System.EventHandler(this.CmsResult_カーソルより後をクリア_Click);
			// 
			// CmsResult_L2
			// 
			this.CmsResult_L2.Name = "CmsResult_L2";
			this.CmsResult_L2.Size = new System.Drawing.Size(171, 6);
			// 
			// CmsResult_全選択
			// 
			this.CmsResult_全選択.Name = "CmsResult_全選択";
			this.CmsResult_全選択.Size = new System.Drawing.Size(174, 22);
			this.CmsResult_全選択.Text = "全選択";
			this.CmsResult_全選択.Click += new System.EventHandler(this.CmsResult_全選択_Click);
			// 
			// CmsResult_L3
			// 
			this.CmsResult_L3.Name = "CmsResult_L3";
			this.CmsResult_L3.Size = new System.Drawing.Size(171, 6);
			// 
			// CmsResult_切り取り
			// 
			this.CmsResult_切り取り.Name = "CmsResult_切り取り";
			this.CmsResult_切り取り.Size = new System.Drawing.Size(174, 22);
			this.CmsResult_切り取り.Text = "切り取り";
			this.CmsResult_切り取り.Click += new System.EventHandler(this.CmsResult_切り取り_Click);
			// 
			// CmsResult_コピー
			// 
			this.CmsResult_コピー.Name = "CmsResult_コピー";
			this.CmsResult_コピー.Size = new System.Drawing.Size(174, 22);
			this.CmsResult_コピー.Text = "コピー";
			this.CmsResult_コピー.Click += new System.EventHandler(this.CmsResult_コピー_Click);
			// 
			// CmsResult_貼り付け
			// 
			this.CmsResult_貼り付け.Name = "CmsResult_貼り付け";
			this.CmsResult_貼り付け.Size = new System.Drawing.Size(174, 22);
			this.CmsResult_貼り付け.Text = "貼り付け";
			this.CmsResult_貼り付け.Click += new System.EventHandler(this.CmsResult_貼り付け_Click);
			// 
			// CmsResult_L4
			// 
			this.CmsResult_L4.Name = "CmsResult_L4";
			this.CmsResult_L4.Size = new System.Drawing.Size(171, 6);
			// 
			// CmsResult_名前を付けて保存
			// 
			this.CmsResult_名前を付けて保存.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsResult_名前を付けて保存_ShiftJIS,
            this.CmsResult_名前を付けて保存_UTF8N});
			this.CmsResult_名前を付けて保存.Name = "CmsResult_名前を付けて保存";
			this.CmsResult_名前を付けて保存.Size = new System.Drawing.Size(174, 22);
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
			this.TbCmd.BackColor = System.Drawing.Color.GhostWhite;
			this.TbCmd.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TbCmd.ContextMenuStrip = this.CmsCmd;
			this.TbCmd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbCmd.Location = new System.Drawing.Point(10, 25);
			this.TbCmd.Margin = new System.Windows.Forms.Padding(0);
			this.TbCmd.Multiline = true;
			this.TbCmd.Name = "TbCmd";
			this.TbCmd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TbCmd.Size = new System.Drawing.Size(565, 40);
			this.TbCmd.TabIndex = 1;
			this.TbCmd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TbCmd_MouseClick);
			this.TbCmd.DragEnter += new System.Windows.Forms.DragEventHandler(this.TbCmd_DragEnter);
			this.TbCmd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbCmd_KeyUp);
			this.TbCmd.MouseEnter += new System.EventHandler(this.TbCmd_MouseEnter);
			// 
			// CmsCmd
			// 
			this.CmsCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsCmd_カーソルより前をクリア,
            this.CmsCmd_カーソルより後をクリア,
            this.CmsCmd_L1,
            this.CmsCmd_貼り付け});
			this.CmsCmd.Name = "CmsResult";
			this.CmsCmd.Size = new System.Drawing.Size(175, 76);
			// 
			// CmsCmd_カーソルより前をクリア
			// 
			this.CmsCmd_カーソルより前をクリア.Name = "CmsCmd_カーソルより前をクリア";
			this.CmsCmd_カーソルより前をクリア.Size = new System.Drawing.Size(174, 22);
			this.CmsCmd_カーソルより前をクリア.Text = "カーソルより前をクリア";
			this.CmsCmd_カーソルより前をクリア.Click += new System.EventHandler(this.CmsCmd_カーソルより前をクリア_Click);
			// 
			// CmsCmd_カーソルより後をクリア
			// 
			this.CmsCmd_カーソルより後をクリア.Name = "CmsCmd_カーソルより後をクリア";
			this.CmsCmd_カーソルより後をクリア.Size = new System.Drawing.Size(174, 22);
			this.CmsCmd_カーソルより後をクリア.Text = "カーソルより後をクリア";
			this.CmsCmd_カーソルより後をクリア.Click += new System.EventHandler(this.CmsCmd_カーソルより後をクリア_Click);
			// 
			// CmsCmd_L1
			// 
			this.CmsCmd_L1.Name = "CmsCmd_L1";
			this.CmsCmd_L1.Size = new System.Drawing.Size(171, 6);
			// 
			// CmsCmd_貼り付け
			// 
			this.CmsCmd_貼り付け.Name = "CmsCmd_貼り付け";
			this.CmsCmd_貼り付け.Size = new System.Drawing.Size(174, 22);
			this.CmsCmd_貼り付け.Text = "貼り付け";
			this.CmsCmd_貼り付け.Click += new System.EventHandler(this.CmsCmd_貼り付け_Click);
			// 
			// BtnResultFont
			// 
			this.BtnResultFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnResultFont.BackColor = System.Drawing.Color.DimGray;
			this.BtnResultFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnResultFont.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnResultFont.ForeColor = System.Drawing.Color.White;
			this.BtnResultFont.Location = new System.Drawing.Point(10, 405);
			this.BtnResultFont.Margin = new System.Windows.Forms.Padding(0);
			this.BtnResultFont.Name = "BtnResultFont";
			this.BtnResultFont.Size = new System.Drawing.Size(65, 24);
			this.BtnResultFont.TabIndex = 10;
			this.BtnResultFont.TabStop = false;
			this.BtnResultFont.Text = "フォント";
			this.BtnResultFont.UseVisualStyleBackColor = false;
			this.BtnResultFont.Click += new System.EventHandler(this.BtnResultFont_Click);
			// 
			// BtnResultUndo
			// 
			this.BtnResultUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnResultUndo.BackColor = System.Drawing.Color.DimGray;
			this.BtnResultUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnResultUndo.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnResultUndo.ForeColor = System.Drawing.Color.White;
			this.BtnResultUndo.Location = new System.Drawing.Point(414, 405);
			this.BtnResultUndo.Margin = new System.Windows.Forms.Padding(0);
			this.BtnResultUndo.Name = "BtnResultUndo";
			this.BtnResultUndo.Size = new System.Drawing.Size(80, 24);
			this.BtnResultUndo.TabIndex = 13;
			this.BtnResultUndo.TabStop = false;
			this.BtnResultUndo.Text = "戻す [F9]";
			this.BtnResultUndo.UseVisualStyleBackColor = false;
			this.BtnResultUndo.Click += new System.EventHandler(this.BtnResultUndo_Click);
			this.BtnResultUndo.MouseEnter += new System.EventHandler(this.BtnResultUndo_MouseEnter);
			// 
			// BtnResultCash
			// 
			this.BtnResultCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnResultCash.BackColor = System.Drawing.Color.RoyalBlue;
			this.BtnResultCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnResultCash.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnResultCash.ForeColor = System.Drawing.Color.White;
			this.BtnResultCash.Location = new System.Drawing.Point(495, 405);
			this.BtnResultCash.Margin = new System.Windows.Forms.Padding(0);
			this.BtnResultCash.Name = "BtnResultCash";
			this.BtnResultCash.Size = new System.Drawing.Size(80, 24);
			this.BtnResultCash.TabIndex = 14;
			this.BtnResultCash.TabStop = false;
			this.BtnResultCash.Text = "記憶 [F10]";
			this.BtnResultCash.UseVisualStyleBackColor = false;
			this.BtnResultCash.Click += new System.EventHandler(this.BtnResultCash_Click);
			this.BtnResultCash.MouseEnter += new System.EventHandler(this.BtnResultCash_MouseEnter);
			// 
			// BtnCmdClear
			// 
			this.BtnCmdClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCmdClear.BackColor = System.Drawing.Color.Firebrick;
			this.BtnCmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCmdClear.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnCmdClear.ForeColor = System.Drawing.Color.White;
			this.BtnCmdClear.Location = new System.Drawing.Point(326, 74);
			this.BtnCmdClear.Margin = new System.Windows.Forms.Padding(0);
			this.BtnCmdClear.Name = "BtnCmdClear";
			this.BtnCmdClear.Size = new System.Drawing.Size(80, 24);
			this.BtnCmdClear.TabIndex = 6;
			this.BtnCmdClear.TabStop = false;
			this.BtnCmdClear.Text = "クリア [F5]";
			this.BtnCmdClear.UseVisualStyleBackColor = false;
			this.BtnCmdClear.Click += new System.EventHandler(this.BtnCmdClear_Click);
			// 
			// BtnResultClear
			// 
			this.BtnResultClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnResultClear.BackColor = System.Drawing.Color.Firebrick;
			this.BtnResultClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnResultClear.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnResultClear.ForeColor = System.Drawing.Color.White;
			this.BtnResultClear.Location = new System.Drawing.Point(326, 405);
			this.BtnResultClear.Margin = new System.Windows.Forms.Padding(0);
			this.BtnResultClear.Name = "BtnResultClear";
			this.BtnResultClear.Size = new System.Drawing.Size(80, 24);
			this.BtnResultClear.TabIndex = 12;
			this.BtnResultClear.TabStop = false;
			this.BtnResultClear.Text = "クリア [F6]";
			this.BtnResultClear.UseVisualStyleBackColor = false;
			this.BtnResultClear.Click += new System.EventHandler(this.BtnResultClear_Click);
			// 
			// TbCurDir
			// 
			this.TbCurDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TbCurDir.BackColor = System.Drawing.Color.DimGray;
			this.TbCurDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TbCurDir.ContextMenuStrip = this.CmsNull;
			this.TbCurDir.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbCurDir.ForeColor = System.Drawing.Color.Snow;
			this.TbCurDir.Location = new System.Drawing.Point(10, 8);
			this.TbCurDir.Margin = new System.Windows.Forms.Padding(0);
			this.TbCurDir.Name = "TbCurDir";
			this.TbCurDir.Size = new System.Drawing.Size(565, 13);
			this.TbCurDir.TabIndex = 0;
			this.TbCurDir.TabStop = false;
			this.TbCurDir.WordWrap = false;
			this.TbCurDir.Click += new System.EventHandler(this.TbCurDir_Click);
			// 
			// BtnResultBgColor
			// 
			this.BtnResultBgColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnResultBgColor.BackColor = System.Drawing.Color.GhostWhite;
			this.BtnResultBgColor.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BtnResultBgColor.ForeColor = System.Drawing.Color.Black;
			this.BtnResultBgColor.Location = new System.Drawing.Point(80, 405);
			this.BtnResultBgColor.Margin = new System.Windows.Forms.Padding(0);
			this.BtnResultBgColor.Name = "BtnResultBgColor";
			this.BtnResultBgColor.Size = new System.Drawing.Size(24, 24);
			this.BtnResultBgColor.TabIndex = 11;
			this.BtnResultBgColor.TabStop = false;
			this.BtnResultBgColor.UseVisualStyleBackColor = false;
			this.BtnResultBgColor.Click += new System.EventHandler(this.BtnResultBgColor_Click);
			// 
			// ToolTip1
			// 
			this.ToolTip1.AutoPopDelay = 6000;
			this.ToolTip1.BackColor = System.Drawing.Color.Ivory;
			this.ToolTip1.ForeColor = System.Drawing.Color.Black;
			this.ToolTip1.InitialDelay = 500;
			this.ToolTip1.ReshowDelay = 100;
			// 
			// LblCurTb
			// 
			this.LblCurTb.AutoSize = true;
			this.LblCurTb.BackColor = System.Drawing.Color.DimGray;
			this.LblCurTb.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LblCurTb.ForeColor = System.Drawing.Color.Red;
			this.LblCurTb.Location = new System.Drawing.Point(-1, 40);
			this.LblCurTb.Margin = new System.Windows.Forms.Padding(0);
			this.LblCurTb.Name = "LblCurTb";
			this.LblCurTb.Size = new System.Drawing.Size(13, 8);
			this.LblCurTb.TabIndex = 16;
			this.LblCurTb.Text = "●";
			this.LblCurTb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CmsNull
			// 
			this.CmsNull.Name = "contextMenuStrip0";
			this.CmsNull.Size = new System.Drawing.Size(61, 4);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(584, 441);
			this.Controls.Add(this.Dgv1);
			this.Controls.Add(this.Dgv2);
			this.Controls.Add(this.TbResult);
			this.Controls.Add(this.BtnResultUndo);
			this.Controls.Add(this.BtnResultCash);
			this.Controls.Add(this.BtnResultClear);
			this.Controls.Add(this.BtnResultBgColor);
			this.Controls.Add(this.BtnResultFont);
			this.Controls.Add(this.TbCurDir);
			this.Controls.Add(this.TbCmd);
			this.Controls.Add(this.BtnCmdSelectFile);
			this.Controls.Add(this.BtnCmdSelectDir);
			this.Controls.Add(this.BtnCmdClear);
			this.Controls.Add(this.BtnCmdExec);
			this.Controls.Add(this.BtnCmdStop);
			this.Controls.Add(this.LblCashOn);
			this.Controls.Add(this.LblCurTb);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(600, 480);
			this.Name = "Form1";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "iwm_commandliner";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.Dgv2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
			this.CmsResult.ResumeLayout(false);
			this.CmsCmd.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button BtnCmdExec;
		private System.Windows.Forms.Button BtnCmdStop;
		private System.Windows.Forms.Button BtnCmdSelectFile;
		private System.Windows.Forms.DataGridView Dgv2;
		private System.Windows.Forms.Button BtnCmdSelectDir;
		private System.Windows.Forms.Label LblCashOn;
		private System.Windows.Forms.DataGridView Dgv1;
		private System.Windows.Forms.TextBox TbResult;
		private System.Windows.Forms.ContextMenuStrip CmsResult;
		private System.Windows.Forms.ToolStripSeparator CmsResult_L2;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_切り取り;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_コピー;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_貼り付け;
		private System.Windows.Forms.TextBox TbCmd;
		private System.Windows.Forms.Button BtnResultFont;
		private System.Windows.Forms.Button BtnResultUndo;
		private System.Windows.Forms.Button BtnResultCash;
		private System.Windows.Forms.Button BtnCmdClear;
		private System.Windows.Forms.Button BtnResultClear;
		private System.Windows.Forms.ToolStripSeparator CmsResult_L3;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_全選択;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_カーソルより前をクリア;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_カーソルより後をクリア;
		private System.Windows.Forms.TextBox TbCurDir;
		private System.Windows.Forms.Button BtnResultBgColor;
		private System.Windows.Forms.ToolStripSeparator CmsResult_L4;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_名前を付けて保存;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_名前を付けて保存_ShiftJIS;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_名前を付けて保存_UTF8N;
		private System.Windows.Forms.ContextMenuStrip CmsCmd;
		private System.Windows.Forms.ToolStripMenuItem CmsCmd_カーソルより前をクリア;
		private System.Windows.Forms.ToolStripMenuItem CmsCmd_カーソルより後をクリア;
		private System.Windows.Forms.ToolStripSeparator CmsCmd_L1;
		private System.Windows.Forms.ToolStripMenuItem CmsCmd_貼り付け;
		private System.Windows.Forms.ToolTip ToolTip1;
		private System.Windows.Forms.Label LblCurTb;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_上へ;
		private System.Windows.Forms.ToolStripMenuItem CmsResult_下へ;
		private System.Windows.Forms.ToolStripSeparator CmsResult_L1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Dgv_Tbc11;
		private System.Windows.Forms.DataGridViewTextBoxColumn Dgv_Tbc21;
		private System.Windows.Forms.DataGridViewTextBoxColumn Dgv_Tbc22;
		private System.Windows.Forms.ContextMenuStrip CmsNull;
	}
}

