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
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;// (要)参照に追加

namespace iwm_commandliner2
{
	public partial class Form1 : Form
	{
		//-----------
		// 大域定数
		//-----------
		private const string VERSION =
			"Ver.20190913_1305 'A-29'" + CRLF +
			"(C)2018-2019 iwm-iwama" + CRLF
		;

		private const string CRLF = "\r\n";
		private const string LN = "----------------------------------------------------------------------" + CRLF;

		//-----------
		// 大域変数
		//-----------
		// CurDir
		private string CurDir = "";

		// 編集用コマンド
		private readonly string[,] ACmd = {
			{ "#grep",     "検索       (例) #grep \"2018\"" },
			{ "#except",   "不一致検索 (例) #except \"2018\"" },
			{ "#replace",  "置換       (例) #replace \"2018/\" \"18/\"" },
			{ "#split",    "分割       (例) #split \"\\t\" \"[0],[1]\"" },
			{ "#toUpper",  "大文字に変換" },
			{ "#toLower",  "小文字に変換" },
			{ "#toWide",   "全角に変換" },
			{ "#toNarrow", "半角に変換" },
			{ "#erase",    "消去 \"開始位置\" \"終了位置\" (例) #erase \"0\" \"5\"" },
			{ "#sort",     "ソート" },
			{ "#uniq",     "ソート後、重複行を消去" },
			{ "#x1",       "空白行削除" },
			{ "#x2",       "行番号付与" },
			{ "#x3",       "行数カウント" },
			{ "#version",  "バージョン" }
		};

		// コマンド／出力結果履歴
		private readonly List<string> LCmdHistory = new List<string>() { "" };// [0] = ""
		private int LCmdHistoryPos = 0;

		private readonly List<string> LResultHistory = new List<string>() { "" };// [0] = ""
		private int LResultHistoryPos = 0;

		// SendMessage関係
		[DllImport("User32.dll")]
		private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

		private delegate void MyEventHandler(object sender, DataReceivedEventArgs e);
		private event MyEventHandler MyEvent = null;

		public Process P1 { get; set; } = null;

		private const int EM_REPLACESEL = 0x00C2;

		// 文字列
		private readonly StringBuilder SB = new StringBuilder();

		//--------
		// Form1
		//--------
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//
			SubDgvCmdLoad();

			TbCmd_Enter(sender, e);

			// CurDir表示
			CurDir = TbCurDir.Text = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(CurDir);

			// 例示
			TbCmd.Text = "dir";

			//
			BtnCmdUndo.Enabled = false;
			BtnCmdRedo.Enabled = false;

			BtnResultUndo.Enabled = false;
			BtnResultRedo.Enabled = false;

			// DgvEdit 表示
			for (int _i1 = 0; _i1 < ACmd.GetLength(0); _i1++)
			{
				_ = DgvEdit.Rows.Add(ACmd[_i1, 0], ACmd[_i1, 1]);
			}

			// LblResult
			TbResult_MouseUp(sender, null);

			// フォントサイズ
			NumericUpDown1.Value = (int)Math.Round(TbResult.Font.Size);

			// 初フォーカス
			SubTbCmdFocus();
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
		}

		private void TbCurDir_MouseHover(object sender, EventArgs e)
		{
			ToolTip1.SetToolTip(TbCurDir, TbCurDir.Text);
		}

		//--------
		// TbCmd
		//--------
		private void TbCmd_Enter(object sender, EventArgs e)
		{
			CbDgvEdit.Checked = false;
			CbDgvEdit_Click(sender, e);

			CbDgvCmd.Checked = false;
			CbDgvCmd_Click(sender, e);

			SubTbCmdFocus();

			try
			{
				TbResult.Enabled = true;
			}
			catch
			{
			}
		}

		private void TbCmd_KeyUp(object sender, KeyEventArgs e)
		{
			// Fontを戻す
			TbCmd.Font = new Font(TbCmd.Font.Name, TbCmd.Font.Size);

			// [Ctrl+V] のとき
			if (e.KeyData == (Keys.Control | Keys.V))
			{
				TbCmd.Text = TbCmd.Text.Replace(CRLF, " ").Trim();
			}

			int iLen = TbCmd.TextLength;
			int i1;

			switch (e.KeyCode)
			{
				case Keys.Enter:
					SubTbCmdExec(sender, null);
					SubTbCmdFocus();
					break;

				case Keys.Up:
					TbCmd.Select(0, 0);
					break;

				case Keys.Down:
					TbCmd.Select(iLen, 0);
					break;

				case Keys.Right:
					if (iLen == TbCmd.SelectionStart)
					{
						TbCmd.Text += " ";
						TbCmd.Select(TbCmd.TextLength, 0);
						// 後段で補完
					}
					break;

				case Keys.PageUp:
					i1 = TbCmd.SelectionStart - 10;
					if (i1 < 0)
					{
						i1 = 0;
					}
					TbCmd.Select(i1, 0);
					break;

				case Keys.PageDown:
					i1 = TbCmd.SelectionStart + 10;
					if (i1 > iLen)
					{
						i1 = iLen;
					}
					TbCmd.Select(i1, 0);
					break;

				default:
					break;
			}

			TbCmd.ScrollToCaret();

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

		private void TbCmd_MouseHover(object sender, EventArgs e)
		{
			ToolTip1.SetToolTip(TbCmd, Regex.Replace(TbCmd.Text, @"(?<=\G.{80})(?!$)", Environment.NewLine));
		}

		private void TbCmd_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
		}

		private void TbCmd_DragDrop(object sender, DragEventArgs e)
		{
			int i1 = TbCmd.SelectionStart;
			string s1 = "";

			string[] a1 = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			foreach (string _s1 in a1)
			{
				s1 += " " + _s1;
			}

			TbCmd.Text = TbCmd.Text.Substring(0, i1).Trim() + s1 + " " + TbCmd.Text.Substring(i1).Trim();
		}

		//---------
		// CmsCmd
		//---------
		private void CmsCmd_全クリア_Click(object sender, EventArgs e)
		{
			TbCmd.Text = "";
		}

		private void CmsCmd_全選択_Click(object sender, EventArgs e)
		{
			TbCmd.SelectAll();
		}

		private void CmsCmd_切り取り_Click(object sender, EventArgs e)
		{
			TbCmd.Cut();
		}

		private void CmsCmd_コピー_Click(object sender, EventArgs e)
		{
			TbCmd.Copy();
		}

		private void CmsCmd_貼り付け_Click(object sender, EventArgs e)
		{
			IDataObject data = Clipboard.GetDataObject();
			if (data != null && data.GetDataPresent(DataFormats.Text) == true)
			{
				TbCmd.Paste();
				TbCmd.Text = TbCmd.Text.Replace(CRLF, " ").Trim();
			}
		}

		//----------
		// DgvEdit
		//----------
		private void CbDgvEdit_Click(object sender, EventArgs e)
		{
			if (CbDgvEdit.Checked == true)
			{
				DgvEdit.Enabled = true;
				DgvEdit.ScrollBars = ScrollBars.Vertical;
				DgvEdit.Width = 374;
				DgvEdit.Height = 340;
			}
			else
			{
				DgvEdit.Enabled = false;
				DgvEdit.ScrollBars = ScrollBars.None;
				DgvEdit.Width = 68;
				DgvEdit.Height = 24;
			}
		}

		private void DgvEdit_MouseHover(object sender, EventArgs e)
		{
			_ = DgvEdit.Focus();
		}

		private void DgvEdit_Click(object sender, EventArgs e)
		{
			TbCmd.Text = DgvEdit[0, DgvEdit.CurrentRow.Index].Value.ToString();
			CbDgvEdit.Checked = false;
			CbDgvEdit_Click(sender, e);
			SubTbCmdFocus();
		}

		private int DgvEditRow = 0;

		private void DgvEdit_KeyDown(object sender, KeyEventArgs e)
		{
			DgvEditRow = DgvEdit.CurrentRow.Index;

			switch (e.KeyCode)
			{
				case Keys.Enter:
					try
					{
						TbCmd.Text = DgvEdit[0, DgvEditRow].Value.ToString();
					}
					catch
					{
						TbCmd.Text = "";
					}
					break;

				default:
					break;
			}
		}

		private void DgvEdit_KeyUp(object sender, KeyEventArgs e)
		{
			int i1 = DgvEdit.RowCount - 1;

			switch (e.KeyCode)
			{
				case Keys.Enter:
					SubTbCmdFocus();
					break;

				case Keys.Up:
					if (--DgvEditRow < 0)
					{
						DgvEditRow = i1;
					}
					break;

				case Keys.Down:
					if (++DgvEditRow > i1)
					{
						DgvEditRow = 0;
					}
					break;

				case Keys.Left:
					if (DgvEditRow == 0)
					{
						DgvEditRow = i1;
						break;
					}

					if ((DgvEditRow -= 3) < 0)
					{
						DgvEditRow = 0;
					}

					break;

				case Keys.Right:
					if (DgvEditRow == i1)
					{
						DgvEditRow = 0;
						break;
					}

					if ((DgvEditRow += 3) > i1)
					{
						DgvEditRow = i1;
					}

					break;

				case Keys.PageUp:
					DgvEditRow = DgvEditRow == 0 ? i1 : DgvEdit.CurrentRow.Index;
					break;

				case Keys.PageDown:
					DgvEditRow = DgvEditRow == i1 ? 0 : DgvEdit.CurrentRow.Index;
					break;

				default:
					break;
			}

			DgvEdit.CurrentCell = DgvEdit[0, DgvEditRow];
		}

		//---------
		// DgvCmd
		//---------
		private void CbDgvCmd_Click(object sender, EventArgs e)
		{
			if (CbDgvCmd.Checked == true)
			{
				DgvCmd.Enabled = true;
				DgvCmd.ScrollBars = ScrollBars.Both;
				DgvCmd.Width = 291;
				DgvCmd.Height = 340;
				TbDgvCmdSearch.Visible = true;
			}
			else
			{
				DgvCmd.Enabled = false;
				DgvCmd.ScrollBars = ScrollBars.None;
				DgvCmd.Width = 68;
				DgvCmd.Height = 24;
				TbDgvCmdSearch.Visible = false;
			}
		}

		private void DgvCmd_MouseHover(object sender, EventArgs e)
		{
			_ = DgvCmd.Focus();
		}

		private void DgvCmd_Click(object sender, EventArgs e)
		{
			TbCmd.Text = DgvCmd[0, DgvCmd.CurrentCell.RowIndex].Value.ToString();

			CbDgvCmd.Checked = false;
			CbDgvCmd_Click(sender, e);

			SubTbCmdFocus();
		}

		private int DgvCmdCurrentRow = 0;

		private void DgvCmd_KeyDown(object sender, KeyEventArgs e)
		{
			DgvCmdCurrentRow = DgvCmd.CurrentRow.Index;

			switch (e.KeyCode)
			{
				case Keys.Enter:
					TbCmd.Text = DgvCmd[0, DgvCmd.CurrentCell.RowIndex].Value.ToString();

					try
					{
						DgvCmd.CurrentCell = DgvCmd[0, DgvCmdCurrentRow - 1];
					}
					catch
					{
						DgvCmd.CurrentCell = DgvCmd[0, 0];
					}

					break;

				default:
					break;
			}
		}

		private void DgvCmd_KeyUp(object sender, KeyEventArgs e)
		{
			int i1 = DgvCmd.RowCount - 1;

			switch (e.KeyCode)
			{
				case Keys.Enter:
					SubTbCmdFocus();
					break;

				case Keys.Up:
					if (--DgvCmdCurrentRow < 0)
					{
						DgvCmdCurrentRow = i1;
					}
					break;

				case Keys.Down:
					if (++DgvCmdCurrentRow > i1)
					{
						DgvCmdCurrentRow = 0;
					}
					break;

				case Keys.Left:
					DgvCmdCurrentRow = DgvCmdCurrentRow == 0 ? i1 : 0;
					break;

				case Keys.Right:
					DgvCmdCurrentRow = DgvCmdCurrentRow == i1 ? 0 : i1;
					break;

				case Keys.PageUp:
					DgvCmdCurrentRow = DgvCmdCurrentRow == 0 ? i1 : DgvCmd.CurrentRow.Index;
					break;

				case Keys.PageDown:
					DgvCmdCurrentRow = DgvCmdCurrentRow == i1 ? 0 : DgvCmd.CurrentRow.Index;
					break;

				case Keys.Tab:
					_ = TbDgvCmdSearch.Focus();
					break;

				default:
					break;
			}

			DgvCmd.CurrentCell = DgvCmd[0, DgvCmdCurrentRow];
		}

		IEnumerable<string> IeFile = null;

		private void SubDgvCmdLoad()
		{
			List<string> l1 = new List<string>();

			foreach (string _s1 in Environment.GetEnvironmentVariable("Path").ToLower().Replace("/", "\\").Split(';'))
			{
				string _s2 = _s1.TrimEnd('\\');
				if (_s2.Length > 0)
				{
					l1.Add(_s2);
				}
			}

			l1.Sort();
			IEnumerable<string> ie1 = l1.Distinct(StringComparer.InvariantCultureIgnoreCase);

			List<string> l2 = new List<string>();

			foreach (string _s1 in ie1)
			{
				DirectoryInfo DI = new DirectoryInfo(_s1);

				if (DI.Exists)
				{
					foreach (FileInfo _fi1 in DI.GetFiles("*", SearchOption.TopDirectoryOnly))
					{
						if (Regex.IsMatch(_fi1.FullName, @"\.(exe|bat|cmd)$", RegexOptions.IgnoreCase))
						{
							l2.Add(Path.GetFileName(_fi1.FullName));
						}
					}
				}
			}

			l2.Sort();
			IeFile = l2.Distinct(StringComparer.InvariantCultureIgnoreCase);

			foreach (string _s1 in IeFile)
			{
				_ = DgvCmd.Rows.Add(_s1);
			}
		}

		private void TbDgvCmdSearch_MouseHover(object sender, EventArgs e)
		{
			_ = TbDgvCmdSearch.Focus();
		}

		private void TbDgvCmdSearch_Enter(object sender, EventArgs e)
		{
			TbDgvCmdSearch.BackColor = Color.WhiteSmoke;
		}

		private void TbDgvCmdSearch_Leave(object sender, EventArgs e)
		{
			TbDgvCmdSearch.BackColor = Color.LightGray;
		}

		private void TbDgvCmdSearch_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
				case Keys.Down:
					_ = DgvCmd.Focus();
					break;

				default:
					break;
			}
		}

		private void TbDgvCmdSearch_TextChanged(object sender, EventArgs e)
		{
			DgvCmd.Rows.Clear();

			try
			{
				foreach (string _s1 in IeFile)
				{
					if (Regex.IsMatch(_s1, TbDgvCmdSearch.Text, RegexOptions.IgnoreCase))
					{
						_ = DgvCmd.Rows.Add(_s1);
					}
				}
			}
			catch
			{
			}

			Thread.Sleep(250);
		}

		//-----------
		// TbResult
		//-----------
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
					TbResult_MouseUp(sender, null);
					break;
			}
		}

		private void TbResult_MouseUp(object sender, MouseEventArgs e)
		{
			string s1 = TbResult.SelectedText;
			string s2 = CRLF;

			int iCrlf = 0;

			int iPos = s1.IndexOf(s2);
			while (0 <= iPos && iPos < s1.Length)
			{
				++iCrlf;
				iPos = s1.IndexOf(s2, iPos + s2.Length);
			}

			int iCnt = TbResult.SelectionLength - (iCrlf * 2);
			LblResult.Text = iCnt > 0 ? iCnt.ToString() + "字(" + (iCrlf + 1).ToString() + "行)選択" : "";
		}

		//-------------
		// Undo／Redo
		//-------------
		private void BtnCmdUndo_Click(object sender, EventArgs e)
		{
			if (LCmdHistoryPos > 0)
			{
				--LCmdHistoryPos;
				TbCmd.Text = LCmdHistory[LCmdHistoryPos];
				BtnCmdRedo.Enabled = true;
			}

			if (LCmdHistoryPos == 0)
			{
				BtnCmdUndo.Enabled = false;
			}

			SubTbCmdFocus();
		}

		private void BtnCmdRedo_Click(object sender, EventArgs e)
		{
			if (LCmdHistoryPos < LCmdHistory.Count - 1)
			{
				++LCmdHistoryPos;
				TbCmd.Text = LCmdHistory[LCmdHistoryPos];
				BtnCmdUndo.Enabled = true;
			}

			if (LCmdHistoryPos == LCmdHistory.Count - 1)
			{
				BtnCmdRedo.Enabled = false;
			}

			SubTbCmdFocus();
		}

		//-------------
		// 実行／停止
		//-------------
		private void BtnCmdExec_Click(object sender, EventArgs e)
		{
			SubTbCmdExec(sender, e);
		}

		private void BtnCmdStop_Click(object sender, EventArgs e)
		{
			SubKillProcessTree(P1);
			TbCmd_Enter(sender, e);
		}

		private void SubKillProcessTree(
			Process p
		)
		{
			string taskkill = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "taskkill.exe");
			using (Process _p1 = new Process())
			{
				try
				{
					_p1.StartInfo.FileName = taskkill;
					_p1.StartInfo.Arguments = string.Format("/PID {0} /T /F", p.Id);
					_p1.StartInfo.CreateNoWindow = true;
					_p1.StartInfo.UseShellExecute = false;
					_ = _p1.Start();
					_ = _p1.WaitForExit(2500);
					_p1.Close();
					_p1.Dispose();
				}
				catch
				{
				}
			}
		}

		//-------
		// 実行
		//-------
		private void SubTbCmdExec(object sender, EventArgs e)
		{
			TbResult.Enabled = false;

			TbCmd.Text = TbCmd.Text.Replace(CRLF, null).Trim();

			if (TbCmd.Text.Length == 0)
			{
				return;
			}

			// 履歴を追加
			if (TbCmd.Text.Length > 0 && TbCmd.Text != LCmdHistory[LCmdHistory.Count - 1])
			{
				LCmdHistory.Add(TbCmd.Text);
				LCmdHistoryPos = LCmdHistory.Count - 1;

				BtnCmdUndo.Enabled = true;
				BtnCmdRedo.Enabled = false;
			}

			if (TbResult.Text.Length > 0 && TbResult.Text != LResultHistory[LResultHistory.Count - 1])
			{
				BoolResultAdd = true;

				LResultHistory.Add(TbResult.Text);
				LResultHistoryPos = LResultHistory.Count;

				BtnResultUndo.Enabled = true;
				BtnResultRedo.Enabled = false;
			}
			else
			{
				BoolResultAdd = false;
			}

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

					// 消去
					case "#erase":
						SubTextBoxEraseInLine(TbResult, aOp[1], aOp[2]);
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

					// バージョン
					case "#version":
						TbResult.Text = LN + VERSION + LN;
						break;

					default:
						break;
				}
			}
			else
			{
				MyEvent = new MyEventHandler(EventDataReceived);
				P1 = new Process();
				P1.StartInfo.FileName = "cmd.exe";
				P1.StartInfo.Arguments = "/C " + TbCmd.Text;
				P1.StartInfo.UseShellExecute = false;
				P1.StartInfo.RedirectStandardOutput = true;
				P1.StartInfo.CreateNoWindow = true;
				P1.OutputDataReceived += new DataReceivedEventHandler(ProcessDataReceived);
				_ = P1.Start();
				P1.BeginOutputReadLine();
				// 不可 P.Close() => 終了コードを返さないので書くな!!
			}
		}

		private void EventDataReceived(object sender, DataReceivedEventArgs e)
		{
			_ = SendMessage(TbResult.Handle, EM_REPLACESEL, 1, e.Data + CRLF);
		}

		private void ProcessDataReceived(object sender, DataReceivedEventArgs e)
		{
			_ = Invoke(MyEvent, new object[2] { sender, e });
		}

		//------------
		// CmsResult
		//------------
		private void CmsResult_上へ_Click(object sender, EventArgs e)
		{
			TbResult.SelectionStart = 0;
			TbResult.ScrollToCaret();
		}

		private void CmsResult_下へ_Click(object sender, EventArgs e)
		{
			TbResult.SelectionStart = TbResult.TextLength;
			TbResult.ScrollToCaret();
		}

		private void CmsResult_全クリア_Click(object sender, EventArgs e)
		{
			TbResult.Text = "";
		}

		private void CmsResult_全選択_Click(object sender, EventArgs e)
		{
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
				TbResult.Paste();
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

		//-------------
		// Undo／Redo
		//-------------
		private bool BoolResultAdd = false;

		private void BtnResultUndo_Click(object sender, EventArgs e)
		{
			if (BoolResultAdd == true && TbResult.Text.Length > 0 && TbResult.Text != LResultHistory[LResultHistory.Count - 1])
			{
				LResultHistory.Add(TbResult.Text);
				LResultHistoryPos = LResultHistory.Count - 1;
				BoolResultAdd = false;
			}

			--LResultHistoryPos;

			if (LResultHistoryPos >= 0)
			{
				TbResult.Text = LResultHistory[LResultHistoryPos];
				BtnResultRedo.Enabled = true;
			}

			if (LResultHistoryPos <= 0)
			{
				LResultHistoryPos = 0;
				BtnResultUndo.Enabled = false;
			}

			SubTbCmdFocus();
		}

		private void BtnResultRedo_Click(object sender, EventArgs e)
		{
			++LResultHistoryPos;

			if (LResultHistoryPos < LResultHistory.Count)
			{
				TbResult.Text = LResultHistory[LResultHistoryPos];
				BtnResultUndo.Enabled = true;
			}

			if (LResultHistoryPos >= LResultHistory.Count - 1)
			{
				LResultHistoryPos = LResultHistory.Count - 1;
				BtnResultRedo.Enabled = false;
			}

			SubTbCmdFocus();
		}

		//-----------------
		// フォントサイズ
		//-----------------
		private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (NumericUpDown1.Value < NumericUpDown1.Minimum)
			{
				NumericUpDown1.Value = NumericUpDown1.Minimum;
			}

			if (NumericUpDown1.Value > NumericUpDown1.Maximum)
			{
				NumericUpDown1.Value = NumericUpDown1.Maximum;
			}

			TbResult.Font = new Font(TbResult.Font.Name.ToString(), (float)NumericUpDown1.Value);
		}

		//----------------
		//	読取専用解除
		//----------------
		private void BtnTbResultWrite_Click(object sender, EventArgs e)
		{
			TbCmd_Enter(sender, e);
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
			_ = TbCmd.Focus();
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
		// ファイル保存
		private void SubTextBoxToSaveFile(
			TextBox tb,
			string code
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

			// 特殊文字を置換
			sRegex = sRegex.Replace("|", "\\|");

			Regex rgx;

			try
			{
				rgx = new Regex("(?i)" + sRegex, RegexOptions.Compiled);
			}
			catch
			{
				return;
			}

			_ = SB.Clear();

			string[] splits = { CRLF };

			foreach (string _s1 in tb.Text.Split(splits, StringSplitOptions.None))
			{
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

			_ = SB.Clear();

			string[] splits = { CRLF };

			foreach (string _s1 in tb.Text.Split(splits, StringSplitOptions.None))
			{
				_ = SB.Append(rgx.Replace(_s1, sNew) + CRLF);
			}

			tb.Text = SB.ToString();
			tb.Select(tb.TextLength, 0);
		}

		//-----------
		// 分割変換
		//-----------
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

			// 特殊文字を置換
			sSplit = sSplit.Replace("|", "\\|");

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

			_ = SB.Clear();

			string[] splits = { CRLF };

			foreach (string _s1 in tb.Text.Split(splits, StringSplitOptions.None))
			{
				if (_s1.Length > 0)
				{
					string[] a1 = rgx2.Split(_s1);
					string _s2 = sRegex;

					for (int _i1 = 0; _i1 < a1.Length; _i1++)
					{
						_s2 = _s2.Replace("[" + _i1.ToString() + "]", a1[_i1]);

						// 特殊文字を置換
						_s2 = _s2.Replace("\\n", CRLF);
						_s2 = _s2.Replace("\\t", "\t");
						_s2 = _s2.Replace("\\\\", "\\");
						_s2 = _s2.Replace("\\\"", "\"");
						_s2 = _s2.Replace("\\\'", "\'");
					}

					// 該当なしの変換子を削除
					_ = SB.Append(rgx1.Replace(_s2, "") + CRLF);
				}
			}

			tb.Text = SB.ToString();
			tb.Select(tb.TextLength, 0);
		}

		//-----------
		// 文字消去
		//-----------
		private void SubTextBoxEraseInLine(
			TextBox tb,
			string sBgnPos,
			string sEndPos
		)
		{
			int iBgnPos;
			try
			{
				iBgnPos = int.Parse(sBgnPos);
			}
			catch
			{
				iBgnPos = 0;
			}

			int iEndPos;
			try
			{
				iEndPos = int.Parse(sEndPos);
			}
			catch
			{
				iEndPos = -1;
			}

			_ = SB.Clear();

			string[] splits = { CRLF };

			foreach (string _s1 in tb.Text.Split(splits, StringSplitOptions.None))
			{
				_ = SB.Append(RtnErasePos(_s1, " ", iBgnPos, iEndPos) + CRLF);
			}

			tb.Text = SB.ToString();
			tb.Select(tb.TextLength, 0);
		}

		private string RtnErasePos(
			string sStr = "",
			string sRep = "",
			int iBgnPos = 0, // 例： 0.. 4
			int iEndPos = -1 // 例：-5..-1
		)
		{
			// iBgnPos の正位置は？
			if (iBgnPos < 0)
			{
				// マイナスのとき +1
				iBgnPos += sStr.Length + 1;
			}

			if (iBgnPos > sStr.Length)
			{
				iBgnPos = sStr.Length;
			}

			// iEndPos の正位置は？
			if (iEndPos < 0)
			{
				// マイナスのとき +1
				iEndPos += sStr.Length + 1;
			}

			// Swap
			if (iBgnPos > iEndPos)
			{
				int _i1 = iEndPos;
				iEndPos = iBgnPos;
				iBgnPos = _i1;
			}

			// 最終補正
			if (iBgnPos < 0)
			{
				iBgnPos = 0;
			}

			if (iEndPos > sStr.Length)
			{
				iEndPos = sStr.Length;
			}

			string rtn = "";

			// 前
			if (iBgnPos > 0)
			{
				rtn += sStr.Substring(0, iBgnPos);
			}

			// 中
			for (int _i1 = 0; _i1 < (iEndPos - iBgnPos); _i1++)
			{
				rtn += sRep;
			}

			// 後
			rtn += sStr.Substring(iEndPos);

			return rtn;
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
