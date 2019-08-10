using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
//using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;// (要)参照に追加

namespace iwm_commandliner
{
	public partial class Form1 : Form
	{
		//-----------
		// 大域定数
		//-----------
		private const string VERSION =
			"Ver.20190810 'A-4'" + CRLF +
			"(C)2018-2019 iwm-iwama" + CRLF
		;

		private const string CRLF = "\r\n";
		private const string LN = "----------------------------------------------------------------------" + CRLF;

		private const string HELP =
			"[ESC]  TextBox間をカーソル移動" + CRLF +
			CRLF +
			"[F1]  履歴 ON/OFF" + CRLF +
			"[F2]  編集 ON/OFF" + CRLF +
			"[F3]  Dir 選択" + CRLF +
			"[F4]  File 選択" + CRLF +
			CRLF +
			"[F5]  コマンドをクリア" + CRLF +
			"[F6]  結果をクリア" + CRLF +
			"[F7]  プロセス停止" + CRLF +
			"[F8]  実行" + CRLF +
			CRLF +
			"[F9]  記憶した結果に戻す" + CRLF +
			"[F10]  結果を記憶" + CRLF +
			"[F11]  ヘルプ" + CRLF +
			"[F12]  Window 最大化／最小化" + CRLF
		;

		//-----------
		// 大域変数
		//-----------
		// CurDir
		private string CurDir = "";

		// [停止]ボタンが押されたか？
		private bool BoolStopEvent = false;

		// [Enter] 抑制
		private bool BoolEnterLock = false;

		// アクティブな textBox の番号
		private int ActiveTBNum = 0;

		// dataGridView Width/Height
		private int Dgv1Width = 0;
		private int Dgv1Height = 0;
		private int Dgv2Width = 0;
		private int Dgv2Height = 0;

		// 編集用コマンド
		private readonly string[,] ACmd = {
			{ "#",         "ヘルプ" },
			{ "#grep",     "検索(正規表現)       (例) #grep \"2018\"" },
			{ "#except",   "不一致検索(正規表現) (例) #except \"2018\"" },
			{ "#replace",  "置換(正規表現)       (例) #replace \"2018/\" \"18/\"" },
			{ "#split",    "分割(正規表現)       (例) #split \"\\t\" \"[0],[1]\"" },
			{ "#sort",     "ソート" },
			{ "#uniq",     "ソート後、重複行を消去" },
			{ "#toUpper",  "大文字に変換" },
			{ "#toLower",  "小文字に変換" },
			{ "#toWide",   "全角に変換" },
			{ "#toNarrow", "半角に変換" },
			{ "#x1",       "空白行削除" },
			{ "#x2",       "行番号付与" },
			{ "#x3",       "行数カウント" },
			{ "#q",        "終了" }
		};

		// 変数
		private readonly StringBuilder SB = new StringBuilder();

		//---------------
		// コマンド履歴
		//---------------
		private List<string> LCmdHistory = new List<string>();

		//-----------
		// 出力履歴
		//-----------
		private string TbResultCache = "";
		private const int EM_REPLACESEL = 0x00C2;

		[DllImport("User32.dll")]
		private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

		private delegate void MyEventHandler(object sender, DataReceivedEventArgs e);
		private event MyEventHandler MyEvent = null;
		private Process P = null;

		//--------
		// Form1
		//--------
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// CurDir表示
			CurDir = TbCurDir.Text = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(CurDir);

			// [ESC] [F1] 等を処理
			KeyPreview = true;

			// 例示
			TbCmd.Text = "dir";
			SubTbCmdFocus();

			// 記録バー
			LblCashOn.Visible = false;

			// dataGridView Width/Height
			Dgv1Width = Dgv1.Width;
			Dgv1Height = Dgv1.Height;

			Dgv2Width = Dgv2.Width;
			Dgv2Height = Dgv2.Height;

			// Dgv2 表示
			for (int _i1 = 0; _i1 < ACmd.GetLength(0); _i1++)
			{
				_ = Dgv2.Rows.Add(ACmd[_i1, 0], ACmd[_i1, 1]);
			}

			// フォントサイズ
			NumericUpDown1.Value = (int)Math.Round(TbResult.Font.Size);
		}

		private void Form1_SizeChanged(object sender, EventArgs e)
		{
			switch (ActiveTBNum)
			{
				case 1:
					TbResult_MouseClick(sender, null);
					break;

				case 2:
					TbCmd_MouseClick(sender, null);
					break;

				default:
					break;
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			///Console.WriteLine("e.KeyCode:" + e.KeyCode);
			switch (e.KeyCode)
			{
				case Keys.Escape:
					switch (ActiveTBNum)
					{
						case 1:
							ActiveTBNum = 2;
							break;

						case 2:
							ActiveTBNum = 1;
							break;

						default:
							break;
					}
					Form1_SizeChanged(sender, e);
					break;

				case Keys.F1:
					if (Dgv1.Focused)
					{
						SubTbCmdFocus();
					}
					else
					{
						_ = Dgv1.Focus();
					}
					break;

				case Keys.F2:
					if (Dgv2.Focused)
					{
						SubTbCmdFocus();
					}
					else
					{
						_ = Dgv2.Focus();
					}
					break;

				case Keys.F3:
					BtnCmdSelectDir_Click(sender, e);
					break;

				case Keys.F4:
					BtnCmdSelectFile_Click(sender, e);
					break;

				case Keys.F5:
					BtnCmdClear_Click(sender, e);
					break;

				case Keys.F6:
					BtnResultClear_Click(sender, e);
					break;

				case Keys.F7:
					BtnCmdStop_Click(sender, null);
					break;

				case Keys.F8:
					SubTbCmdFocus();
					BtnCmdExec_Click(sender, null);
					break;

				case Keys.F9:
					BtnResultUndo_Click(sender, e);
					break;

				case Keys.F10:
					BtnResultCash_Click(sender, e);
					SendKeys.Send("{TAB}");// 最終コントロール => 一発入れないとフォーカスが不明になる
					break;

				case Keys.F11:
					BoolEnterLock = true;
					_ = MessageBox.Show(VERSION + CRLF + HELP);
					break;

				case Keys.F12:
					switch (WindowState)
					{
						case FormWindowState.Normal:
							WindowState = FormWindowState.Maximized;
							break;

						case FormWindowState.Maximized:
							WindowState = FormWindowState.Normal;
							break;

						default:
							break;
					}
					break;

				default:
					break;
			}
		}

		//-----------
		// TbCurDir
		//-----------
		private void TbCurDir_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog fbd = new FolderBrowserDialog
			{
				Description = "フォルダを指定してください。",
				SelectedPath = Environment.CurrentDirectory,
				ShowNewFolderButton = false
			})
			{
				if (fbd.ShowDialog(this) == DialogResult.OK)
				{
					CurDir = TbCurDir.Text = fbd.SelectedPath;
					Directory.SetCurrentDirectory(CurDir);
				}
			}
			TbCurDir.SelectAll();

			BoolEnterLock = true;
			SubTbCmdFocus();
		}

		//--------
		// TbCmd
		//--------
		private void TbCmd_MouseEnter(object sender, EventArgs e)
		{
			ToolTip1.SetToolTip(TbCmd, "[↑] 作業フォルダ変更");
		}

		private void TbCmd_MouseClick(object sender, MouseEventArgs e)
		{
			_ = TbCmd.Focus();
			ActiveTBNum = 2;

			LblCurTb.Left = -1;
			LblCurTb.Top = 43;
		}

		private void TbCmd_DragEnter(object sender, DragEventArgs e)
		{
			SubTextBoxDragEnterFn(e, TbCmd);
		}

		private void TbCmd_KeyUp(object sender, KeyEventArgs e)
		{
			// Font固定
			TbCmd.Font = new Font(TbCmd.Font.Name, TbCmd.Font.Size);

			///Console.WriteLine(e.KeyCode);
			switch (e.KeyCode)
			{
				case Keys.Enter:
					if (BoolEnterLock)
					{
						BoolEnterLock = false;
					}
					else
					{
						BtnCmdExec_Click(sender, null);
					}
					SubTbCmdFocus();
					break;

				case Keys.Up:
					_ = TbCurDir.Focus();
					TbCurDir_Click(sender, e);
					break;

				case Keys.Down:
				case Keys.Right:
					if (TbCmd.TextLength == TbCmd.SelectionStart)
					{
						TbCmd.Text += " ";
						TbCmd.Select(TbCmd.TextLength, 0);
					}
					break;

				default:
					break;
			}

			// 補完
			if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Space) && TbCmd.TextLength == TbCmd.SelectionStart && Regex.IsMatch(TbCmd.Text, @"^\s*#"))
			{
				TbCmd.ForeColor = Color.Red;
				TbCmd.Text = Regex.Replace(TbCmd.Text, @"\s$", " \"\"").Trim();
				TbCmd.Select(TbCmd.TextLength - 1, 0);
			}
			else
			{
				TbCmd.ForeColor = Color.Black;
			}
		}

		private void SubTextBoxDragEnterFn(
			DragEventArgs e,
			TextBox textbox
		)
		{
			string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			textbox.Text = fileName[0];
		}

		//---------
		// CmsCmd
		//---------
		private void CmsCmd_カーソルより前をクリア_Click(object sender, EventArgs e)
		{
			SubTextBoxTrimStart(TbCmd);
		}

		private void CmsCmd_カーソルより後をクリア_Click(object sender, EventArgs e)
		{
			SubTextBoxTrimEnd(TbCmd);
		}

		private void CmsCmd_貼り付け_Click(object sender, EventArgs e)
		{
			IDataObject data = Clipboard.GetDataObject();
			if (data != null && data.GetDataPresent(DataFormats.Text) == true)
			{
				TbCmd.Paste();
			}
		}

		//-------
		// Dgv1
		//-------
		private void Dgv1_Enter(object sender, EventArgs e)
		{
			Dgv1.Rows.Clear();

			foreach (string _s1 in LCmdHistory)
			{
				Dgv1.Rows.Add(_s1);
			}

			SubDgv1Control(true);
		}

		private void Dgv1_Leave(object sender, EventArgs e)
		{
			SubDgv1Control(false);
		}

		private void SubDgv1Control(
			bool b
		)
		{
			if (b == true)
			{
				Dgv1.ScrollBars = ScrollBars.Both;
				Dgv1.Height = 358;
				Dgv1.Width = 165;

				try
				{
					Dgv1.CurrentCell = Dgv1[0, Dgv1Row];
				}
				catch
				{
				}
			}
			else
			{
				Dgv1.ScrollBars = ScrollBars.None;
				Dgv1.Height = Dgv1Height;
				Dgv1.Width = Dgv1Width;
			}
		}

		private void Dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				TbCmd.Text = Dgv1[0, e.RowIndex].Value.ToString();
			}
			catch
			{
				TbCmd.Text = "";
			}
			SubTbCmdFocus();
		}

		int Dgv1Row = 0;

		private void Dgv1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					try
					{
						TbCmd.Text = Dgv1[0, Dgv1.SelectedCells[0].RowIndex].Value.ToString();
					}
					catch
					{
						TbCmd.Text = "";
					}
					break;

				case Keys.Up:
					Dgv1Row -= 1;
					break;

				case Keys.Down:
					Dgv1Row += 1;
					break;

				case Keys.Left:
					Dgv1Row -= 5;
					break;

				case Keys.Right:
					Dgv1Row += 5;
					break;

				default:
					break;
			}
		}

		private void Dgv1_KeyUp(object sender, KeyEventArgs e)
		{
			int i1 = Dgv1.RowCount - 1;

			switch (e.KeyCode)
			{
				case Keys.Enter:
					SubTbCmdFocus();
					break;

				case Keys.Up:
					if (Dgv1Row < 0)
					{
						Dgv1Row = i1;
					}
					break;

				case Keys.Down:
					if (Dgv1Row > i1)
					{
						Dgv1Row = 0;
					}
					break;

				case Keys.Left:
					if (Dgv1Row < 0)
					{
						Dgv1Row = 0;
					}
					break;

				case Keys.Right:
					if (Dgv1Row > i1)
					{
						Dgv1Row = i1;
					}
					break;

				case Keys.PageUp:
					Dgv1Row = 0;
					break;

				case Keys.PageDown:
					Dgv1Row = i1;
					break;

				default:
					break;
			}

			try
			{
				Dgv1.CurrentCell = Dgv1[0, Dgv1Row];
			}
			catch
			{
			}
		}

		private void Dgv1_MouseEnter(object sender, EventArgs e)
		{
			Dgv1_Enter(sender, e);
		}

		private void Dgv1_MouseLeave(object sender, EventArgs e)
		{
			Dgv1_Leave(sender, e);
		}

		//----------------
		// Dgv2
		//----------------
		private void Dgv2_Enter(object sender, EventArgs e)
		{
			SubDgv2Control(true);
		}

		private void Dgv2_Leave(object sender, EventArgs e)
		{
			SubDgv2Control(false);
		}

		private void SubDgv2Control(
			bool b
		)
		{
			if (b == true)
			{
				Dgv2.ScrollBars = ScrollBars.Vertical;
				Dgv2.Height = 358;
				Dgv2.Width = 425;

				try
				{
					Dgv2.CurrentCell = Dgv2[0, Dgv2Row];
				}
				catch
				{
				}
			}
			else
			{
				Dgv2.ScrollBars = ScrollBars.None;
				Dgv2.Height = Dgv2Height;
				Dgv2.Width = Dgv2Width;
			}
		}

		private void Dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				TbCmd.Text = Dgv2[0, e.RowIndex].Value.ToString();
			}
			catch
			{
				TbCmd.Text = "";
			}
			SubTbCmdFocus();
		}

		private int Dgv2Row = 0;

		private void Dgv2_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					try
					{
						TbCmd.Text = Dgv2[0, Dgv2.SelectedCells[0].RowIndex].Value.ToString();
					}
					catch
					{
						TbCmd.Text = "";
					}
					break;

				case Keys.Up:
					Dgv2Row -= 1;
					break;

				case Keys.Down:
					Dgv2Row += 1;
					break;

				case Keys.Left:
					Dgv2Row -= 5;
					break;

				case Keys.Right:
					Dgv2Row += 5;
					break;

				default:
					break;
			}
		}

		private void Dgv2_KeyUp(object sender, KeyEventArgs e)
		{
			int i1 = Dgv2.RowCount - 1;

			switch (e.KeyCode)
			{
				case Keys.Enter:
					SubTbCmdFocus();
					break;

				case Keys.Up:
					if (Dgv2Row < 0)
					{
						Dgv2Row = i1;
					}
					break;

				case Keys.Down:
					if (Dgv2Row > i1)
					{
						Dgv2Row = 0;
					}
					break;

				case Keys.Left:
					if (Dgv2Row < 0)
					{
						Dgv2Row = 0;
					}
					break;

				case Keys.Right:
					if (Dgv2Row > i1)
					{
						Dgv2Row = i1;
					}
					break;

				case Keys.PageUp:
					Dgv2Row = 0;
					break;

				case Keys.PageDown:
					Dgv2Row = i1;
					break;

				default:
					break;
			}

			Dgv2.CurrentCell = Dgv2[0, Dgv2Row];
		}

		private void Dgv2_MouseEnter(object sender, EventArgs e)
		{
			Dgv2_Enter(sender, e);
		}

		private void Dgv2_MouseLeave(object sender, EventArgs e)
		{
			Dgv2_Leave(sender, e);
		}

		//-----------
		// TbResult
		//-----------
		private void TbResult_MouseClick(object sender, MouseEventArgs e)
		{
			_ = TbResult.Focus();
			ActiveTBNum = 1;

			LblCurTb.Left = -1;
			LblCurTb.Top = TbResult.Location.Y - 15 + (TbResult.Size.Height / 2);
		}

		private void TbResult_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.PageUp:
					TbResult.SelectionStart = 0;
					break;

				case Keys.PageDown:
					TbResult.SelectionStart = TbResult.TextLength;
					break;

				default:
					break;
			}
		}

		private void TbResult_DragDrop(object sender, DragEventArgs e)
		{
			string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			_ = SB.Clear();
			foreach (string _s1 in File.ReadLines(fileName[0], Encoding.GetEncoding("Shift_JIS")))
			{
				_ = SB.Append(_s1.TrimEnd() + CRLF);
			}
			_ = SendMessage(TbResult.Handle, EM_REPLACESEL, 1, SB.ToString());

			SubTbResultFocus();
			TbResult_MouseClick(sender, null);
		}

		private void TbResult_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
		}

		//----------
		// Dir選択
		//----------
		private void BtnCmdSelectDir_Click(object sender, EventArgs e)
		{
			_ = BtnCmdSelectDir.Focus();

			using (FolderBrowserDialog fbd = new FolderBrowserDialog
			{
				Description = "フォルダを指定してください。",
				SelectedPath = Environment.CurrentDirectory,
				ShowNewFolderButton = true
			})
			{
				if (fbd.ShowDialog(this) == DialogResult.OK)
				{
					string s1 = TbCmd.Text;
					string s2 = fbd.SelectedPath;
					int i1 = TbCmd.SelectionStart;

					TbCmd.Text = s1.Substring(0, i1) + " " + s2 + s1.Substring(i1);

					TbCmd.Select(TbCmd.TextLength, 0);
					_ = TbCmd.Focus();
				}
			}
			BoolEnterLock = true;
		}

		//-----------
		// File選択
		//-----------
		private void BtnCmdSelectFile_Click(object sender, EventArgs e)
		{
			_ = BtnCmdSelectFile.Focus();

			using (OpenFileDialog openFileDialog1 = new OpenFileDialog
			{
				InitialDirectory = Environment.CurrentDirectory,
				Filter = "All files (*.*)|*.*",
				FilterIndex = 1,
				RestoreDirectory = true
			})
			{
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					string s1 = TbCmd.Text;
					string s2 = openFileDialog1.FileName.Replace(Directory.GetCurrentDirectory() + "\\", "");
					int i1 = TbCmd.SelectionStart;

					TbCmd.Text = s1.Substring(0, i1) + " " + s2 + s1.Substring(i1);

					TbCmd.Select(TbCmd.TextLength, 0);
					_ = TbCmd.Focus();
				}
			}
			BoolEnterLock = true;
		}

		//---------
		// クリア
		//---------
		private void BtnCmdClear_Click(object sender, EventArgs e)
		{
			TbCmd.Text = "";
		}

		private void BtnCmdExec_Click(object sender, EventArgs e)
		{
			TbCmd.Text = TbCmd.Text.Replace(CRLF, "").Trim();

			if (TbCmd.Text.Length == 0)
			{
				SubTbCmdFocus();
				return;
			}

			// 履歴を追加
			LCmdHistory.Add(TbCmd.Text);
			LCmdHistory = RtnListUniqSort(LCmdHistory);

			if (TbCmd.Text[0] == '#')
			{
				const int aOpMax = 3;
				string[] aOp = Enumerable.Repeat("", aOpMax).ToArray();

				string str = TbCmd.Text + "\n";// "\n" => 検索用フラグ

				Regex rgx = null;
				Match mth = null;
				int i1 = 0;

				// #command 取得
				rgx = new Regex("^\\s*(?<pattern>.+?)\\s", RegexOptions.None);
				mth = rgx.Match(str);
				aOp[i1] = mth.Groups["pattern"].Value;

				// option[n] 取得
				rgx = new Regex("\"(?<pattern>[\\S\\s]+?)\"[\\s\\n]", RegexOptions.None);
				for (mth = rgx.Match(str); mth.Success; mth = mth.NextMatch())
				{
					if (++i1 >= aOpMax)
					{
						break;
					}
					aOp[i1] = mth.Groups["pattern"].Value;
				}

				List<string> lTmp = new List<string>();

				// 大小区別しない
				switch (aOp[0].ToLower())
				{
					// ヘルプ
					case "#":
						BoolEnterLock = true;
						_ = MessageBox.Show(VERSION + CRLF + HELP);
						break;

					// 検索（一致）
					case "#grep":
						SubTextBoxGrep(TbResult, aOp[1], true);
						break;

					// 検索（不一致）
					case "#except":
						SubTextBoxGrep(TbResult, aOp[1], false);
						break;

					// 置換
					case "#replace":
						SubTextBoxReplace(TbResult, aOp[1], aOp[2]);
						break;

					// 分割変換（like AWK）
					case "#split":
						SubTextBoxSplitCnv(TbResult, aOp[1], aOp[2]);
						break;

					// 全角変換
					case "#towide":
						TbResult.Text = Strings.StrConv(TbResult.Text, VbStrConv.Wide, 0x411);
						SubTbResultFocus();
						break;

					// 半角変換
					case "#tonarrow":
						TbResult.Text = Strings.StrConv(TbResult.Text, VbStrConv.Narrow, 0x411);
						SubTbResultFocus();
						break;

					// 大文字変換
					case "#toupper":
						TbResult.Text = TbResult.Text.ToUpper();
						SubTbResultFocus();
						break;

					// 小文字変換
					case "#tolower":
						TbResult.Text = TbResult.Text.ToLower();
						SubTbResultFocus();
						break;

					// ソート
					case "#sort":
						SubTextBoxSort(TbResult, false);
						break;

					// ソート後、重複消除
					case "#uniq":
						SubTextBoxSort(TbResult, true);
						break;

					// 空白行削除
					case "#x1":
						bool bLines = false;// 2行目以降か？
						_ = SB.Clear();
						foreach (string _s1 in TbResult.Text.Split('\n'))
						{
							string _s2 = _s1.TrimEnd();
							if (_s2.Length > 0)
							{
								// 2行目～
								if (bLines)
								{
									_ = SB.Append(CRLF + _s2);
								}
								// 1行目
								else
								{
									_ = SB.Append(_s2);
									bLines = true;
								}
							}
						}
						TbResult.Text = SB.ToString();
						SubTbResultFocus();
						break;

					// 行番号付与
					case "#x2":
						uint cnt = 0;
						_ = SB.Clear();
						foreach (string _s1 in TbResult.Text.Split('\n'))
						{
							_ = SB.Append(string.Format("{0:D8}\t{1}{2}", ++cnt, _s1.TrimEnd(), CRLF));
						}
						TbResult.Text = SB.ToString();
						SubTbResultFocus();
						break;

					// 行数カウント
					case "#x3":
						uint cntAll = 0;
						uint cntActive = 0;
						foreach (string _s1 in TbResult.Text.Split('\n'))
						{
							++cntAll;

							if (_s1.TrimStart().Length > 0)
							{
								++cntActive;
							}
						}
						SubTbResultFocus();
						_ = SendMessage(TbResult.Handle, EM_REPLACESEL, 1, string.Format("{3}{2}全行数　 : {0}{3}有効行数 : {1}{3}{2}", cntAll, cntActive, LN, CRLF));
						break;

					// 終了
					case "#q":
						Application.Exit();
						break;

					default:
						break;
				}
			}
			else
			{
				MyEvent = new MyEventHandler(EventDataReceived);
				P = new Process();
				P.StartInfo.FileName = "cmd.exe";
				P.StartInfo.Arguments = "/C " + TbCmd.Text;
				P.StartInfo.UseShellExecute = false;
				P.StartInfo.RedirectStandardOutput = true;
				P.StartInfo.CreateNoWindow = true;
				P.OutputDataReceived += new DataReceivedEventHandler(ProcessDataReceived);
				_ = P.Start();
				P.BeginOutputReadLine();
				// 不可 P.Close() => 終了コードを返さないので書くな!!

				SubTbResultFocus();
			}

			SubTbCmdFocus();
		}

		private void EventDataReceived(object sender, DataReceivedEventArgs e)
		{
			_ = SendMessage(TbResult.Handle, EM_REPLACESEL, 1, e.Data + CRLF);
		}

		private void ProcessDataReceived(object sender, DataReceivedEventArgs e)
		{
			_ = Invoke(MyEvent, new object[2] { sender, e });
		}

		private void BtnCmdStop_Click(object sender, EventArgs e)
		{
			SubTbCmdFocus();

			BoolStopEvent = true;

			try
			{
				// 不可 P.Kill() => 子プロセスは SubKillProcessTree() で削除する
				SubKillProcessTree(P);
				P.Close();
				P.Dispose();
			}
			catch
			{
			}
		}

		//------------
		// CmsResult
		//------------
		private void CmsResult_上へ_Click(object sender, EventArgs e)
		{
			TbResult.SelectionStart = 0;
			_ = TbResult.Focus();
			TbResult.ScrollToCaret();
		}

		private void CmsResult_下へ_Click(object sender, EventArgs e)
		{
			TbResult.SelectionStart = TbResult.TextLength;
			_ = TbResult.Focus();
			TbResult.ScrollToCaret();
		}

		private void CmsResult_カーソルより前をクリア_Click(object sender, EventArgs e)
		{
			SubTextBoxTrimStart(TbResult);
		}

		private void CmsResult_カーソルより後をクリア_Click(object sender, EventArgs e)
		{
			SubTextBoxTrimEnd(TbResult);
		}

		private void CmsResult_全選択_Click(object sender, EventArgs e)
		{
			_ = TbResult.Focus();
			TbResult.SelectAll();
		}

		private void CmsResult_切り取り_Click(object sender, EventArgs e)
		{
			TbResult.Cut();
		}

		private void CmsResult_コピー_Click(object sender, EventArgs e)
		{
			TbResult.Copy();
		}

		private void CmsResult_貼り付け_Click(object sender, EventArgs e)
		{
			IDataObject data = Clipboard.GetDataObject();
			if (data != null && data.GetDataPresent(DataFormats.Text) == true)
			{
				_ = SB.Clear();
				foreach (string _s1 in Clipboard.GetText().Split('\n'))
				{
					_ = SB.Append(_s1.TrimEnd());
				}
				_ = SendMessage(TbResult.Handle, EM_REPLACESEL, 1, SB.ToString());
			}
		}

		private void CmsResult_名前を付けて保存_ShiftJIS_Click(object sender, EventArgs e)
		{
			SubTextBoxToSaveFile(TbResult, CmsResult_名前を付けて保存_ShiftJIS.Text);
		}

		private void CmsResult_名前を付けて保存_UTF8N_Click(object sender, EventArgs e)
		{
			SubTextBoxToSaveFile(TbResult, CmsResult_名前を付けて保存_UTF8N.Text);
		}

		//-----------------
		// フォントサイズ
		//-----------------
		private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			TbResult.Font = new Font(TbResult.Font.Name.ToString(), (float)NumericUpDown1.Value);
		}

		//---------
		// クリア
		//---------
		private void BtnResultClear_Click(object sender, EventArgs e)
		{
			TbResult.Text = "";
		}

		//-------------
		// 記憶／戻す
		//-------------
		private void BtnResultUndo_Click(object sender, EventArgs e)
		{
			TbResult.Text = TbResultCache;
		}

		private void BtnResultUndo_MouseEnter(object sender, EventArgs e)
		{
			SubBtnResultToolTip(BtnResultUndo);
		}

		private void BtnResultCash_Click(object sender, EventArgs e)
		{
			TbResultCache = TbResult.Text;
			LblCashOn.Visible = TbResultCache.Length > 0 ? true : false;
		}

		private void BtnResultCash_MouseEnter(object sender, EventArgs e)
		{
			SubBtnResultToolTip(BtnResultCash);
		}

		private void SubBtnResultToolTip(Button btn)
		{
			const int LENMAX = 500;
			int len = TbResultCache.Length;
			if (len > LENMAX)
			{
				len = LENMAX;
			}
			ToolTip1.SetToolTip(btn, TbResultCache.Substring(0, len));
		}

		//---------------------------
		// 子・孫プロセスを終了する
		//---------------------------
		private void SubKillProcessTree(
			Process p
		)
		{
			string taskkill = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "taskkill.exe");
			using (Process pKiller = new Process())
			{
				pKiller.StartInfo.FileName = taskkill;
				pKiller.StartInfo.Arguments = string.Format("/PID {0} /T /F", p.Id);
				pKiller.StartInfo.CreateNoWindow = true;
				pKiller.StartInfo.UseShellExecute = false;
				_ = pKiller.Start();
				pKiller.WaitForExit();
			}
		}

		//-----------------------
		// TextBox へフォーカス
		//-----------------------
		// TbCmd
		private void SubTbCmdFocus()
		{
			TbCmd.Text = TbCmd.Text.Trim();

			// カーソル位置を末尾へ移動
			TbCmd.Select(TbCmd.TextLength, 0);

			TbCmd_MouseClick(null, null);
		}

		// TbResult
		private void SubTbResultFocus()
		{
			// カーソル位置を末尾へ移動
			TbResult.Select(TbResult.TextLength, 0);
		}

		//-----------------------
		// contextMenuStrip操作
		//-----------------------
		// カーソル位置より前を削除
		private void SubTextBoxTrimStart(
			TextBox tb
		)
		{
			int iEnd = tb.SelectionStart;
			tb.Select(0, iEnd);
			tb.SelectedText = "";
		}

		// カーソル位置より後を削除
		private void SubTextBoxTrimEnd(
			TextBox tb
		)
		{
			int iBgn = tb.SelectionStart;
			tb.AppendText(" ");
			int iEnd = tb.SelectionStart;
			tb.Select(iBgn, iEnd);
			tb.SelectedText = "";
		}

		// ファイル保存
		private void SubTextBoxToSaveFile(
			TextBox tb,
			String code
		)
		{
			using (SaveFileDialog saveFileDialog1 = new SaveFileDialog
			{
				InitialDirectory = ".",
				FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt",
				Filter = "All files (*.*)|*.*",
				FilterIndex = 1
			})
			{
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					switch (code.ToUpper())
					{
						case "UTF-8N":
							UTF8Encoding utf8nEnc = new UTF8Encoding(false);
							File.WriteAllText(saveFileDialog1.FileName, tb.Text, utf8nEnc);
							break;

						default:
							File.WriteAllText(saveFileDialog1.FileName, tb.Text, Encoding.GetEncoding("Shift_JIS"));
							break;
					}
				}
			}
		}

		//---------------
		// 正規表現検索
		//---------------
		private void SubTextBoxGrep(
			TextBox tb,
			string sRegex,
			bool bMatch
		)
		{
			if (sRegex.Length == 0)
			{
				return;
			}

			Regex rgx;
			try
			{
				rgx = new Regex("(?i)" + sRegex, RegexOptions.Compiled);
			}
			catch
			{
				return;
			}

			string s1 = tb.Text;
			BoolStopEvent = false;

			_ = SB.Clear();
			foreach (string _s1 in s1.Split('\n'))
			{
				// 割込処理実行
				// [停止]ボタンが押されたか？
				Application.DoEvents();

				if (BoolStopEvent)
				{
					BoolStopEvent = false;
					break;
				}

				if (bMatch == rgx.IsMatch(_s1))
				{
					_ = SB.Append(_s1 + CRLF);
				}
			}

			tb.Text = SB.ToString();
			tb.Select(tb.TextLength, 0);
		}

		//---------------
		// 正規表現置換
		//---------------
		private void SubTextBoxReplace(
			TextBox tb,
			string sOld,
			string sNew
		)
		{
			if (sOld.Length == 0)
			{
				return;
			}

			// 特殊文字を置換
			sNew = sNew.Replace("\\n", CRLF);
			sNew = sNew.Replace("\\t", "\t");
			sNew = sNew.Replace("\\\\", "\\");
			sNew = sNew.Replace("\\\"", "\"");
			sNew = sNew.Replace("\\\'", "\'");

			Regex rgx;
			try
			{
				rgx = new Regex("(?i)" + sOld, RegexOptions.Compiled);
			}
			catch
			{
				return;
			}

			BoolStopEvent = false;

			_ = SB.Clear();
			foreach (string _s1 in tb.Text.Split('\n'))
			{
				// 割込処理実行
				// [停止]ボタンが押されたか？
				Application.DoEvents();

				if (BoolStopEvent == true)
				{
					BoolStopEvent = false;
					break;
				}
				_ = SB.Append(rgx.Replace(_s1.Trim(), sNew) + CRLF);
			}

			tb.Text = SB.ToString();
			tb.Select(tb.TextLength, 0);
		}

		//-------------
		// 分割変換
		//-------------
		private void SubTextBoxSplitCnv(
			TextBox tb,
			string sSplit,
			string sRegex
		)
		{
			if (sSplit.Length == 0 || sRegex.Length == 0)
			{
				return;
			}

			Regex rgx1, rgx2;
			try
			{
				rgx1 = new Regex(@"\[\d+\]", RegexOptions.Compiled);
				rgx2 = new Regex(sSplit, RegexOptions.Compiled);
			}
			catch
			{
				return;
			}

			string s1 = tb.Text;
			BoolStopEvent = false;

			_ = SB.Clear();
			foreach (string _s1 in s1.Split('\n'))
			{
				// 割込処理実行
				// [停止]ボタンが押されたか？
				Application.DoEvents();

				if (BoolStopEvent == true)
				{
					BoolStopEvent = false;
					break;
				}

				string[] a1 = rgx2.Split(_s1.Trim());

				if (a1[0].Length > 0)
				{
					string _s2 = sRegex;
					for (int _i1 = 0; _i1 < a1.Length; _i1++)
					{
						_s2 = _s2.Replace("[" + _i1.ToString() + "]", a1[_i1]);
					}

					// 該当なしの変換子を削除
					_ = SB.Append(rgx1.Replace(_s2, "") + CRLF);
				}
			}

			tb.Text = SB.ToString();
			tb.Select(tb.TextLength, 0);
		}

		//-------------
		// Sort／Uniq
		//-------------
		private void SubTextBoxSort(
			TextBox tb,
			bool bUniq = false
		)
		{
			List<string> l1 = new List<string>();
			foreach (string _s1 in tb.Text.Split('\n'))
			{
				string _s2 = _s1.TrimEnd();
				if (_s2.Length > 0)
				{
					l1.Add(_s2);
				}
			}

			l1.Sort();

			if (bUniq)
			{
				l1 = RtnListUniqSort(l1);
			}

			_ = SB.Clear();
			foreach (string _s1 in l1)
			{
				_ = SB.Append(_s1 + CRLF);
			}

			tb.Text = SB.ToString();
			tb.Select(tb.TextLength, 0);
		}

		//-----------------------
		// ソートして重複を除外
		//-----------------------
		private List<string> RtnListUniqSort(
			List<string> ListStr
		)
		{
			List<string> rtn = new List<string>();

			ListStr.Sort();
			string s1 = "";

			foreach (string _s1 in ListStr)
			{
				if (_s1 != s1)
				{
					rtn.Add(_s1);
					s1 = _s1;
				}
			}

			return rtn;
		}
	}
}
