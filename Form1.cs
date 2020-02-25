using System;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
//using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; // プロジェクト～参照の追加

namespace iwm_commandliner2
{
	public partial class Form1 : Form
	{
		//-----------
		// 大域定数
		//-----------
		private const string VERSION = "Ver.20200225_1922 'A-29' (C)2018-2020 iwm-iwama";

		private const string NL = "\r\n";
		private readonly string[] SPLITS = { NL };

		private readonly string[] GblASTextCode = { "Shift_JIS", "UTF-8" };

		private readonly object[,] GblAOCmd = {
			// [コマンド]   [説明]                                              [引数]
			{ "#clear",     "入出力クリア",                                       0 },
			{ "#grep",      "検索        #grep \"2018\"",                         1 },
			{ "#except",    "不一致検索  #except \"2018\"",                       1 },
			{ "#replace",   "置換        #replace \"2018/\" \"18/\"",             2 },
			{ "#split",     "分割        #split \"\\t\" \"[0],[1]\"",             2 },
			{ "#toUpper",   "大文字に変換",                                       0 },
			{ "#toLower",   "小文字に変換",                                       0 },
			{ "#toWide",    "全角に変換",                                         0 },
			{ "#toZenNum",  "全角に変換(数字のみ)",                               0 },
			{ "#toZenKana", "全角に変換(カナのみ)",                               0 },
			{ "#toNarrow",  "半角に変換",                                         0 },
			{ "#toHanNum",  "半角に変換(数字のみ)",                               0 },
			{ "#toHanKana", "半角に変換(カナのみ)",                               0 },
			{ "#erase",     "消去 \"開始位置\" \"文字長\"  #erase \"0\" \"5\"",   2 },
			{ "#sort",      "ソート",                                             0 },
			{ "#uniq",      "ソート後、重複行を消去",                             0 },
			{ "#rmBlankLn", "空白行削除",                                         0 },
			{ "#addLnNum",  "行番号付与",                                         0 },
			{ "#wget",      "ファイル取得  #wget \"http://.../index.html\"",      1 },
			{ "#calc",      "計算機        #calc \"45 * pi / 180\"",              1 },
			{ "#now",       "現在日時",                                           0 },
			{ "#version",   "バージョン",                                         0 }
		};

		//-----------
		// 大域変数
		//-----------
		// CurDir
		private string CurDir = "";

		// 文字列
		private readonly StringBuilder SB = new StringBuilder();

		// コマンド／出力履歴
		private readonly List<string> LCmdHistory = new List<string>() { "" }; // 初期値 ""
		private int LCmdHistoryPos = 0;

		private readonly List<string> LResultHistory = new List<string>() { "" }; // 初期値 ""
		private int LResultHistoryPos = 0;

		private delegate void MyEventHandler(object sender, DataReceivedEventArgs e);
		private event MyEventHandler MyEvent = null;

		public Process P1 { get; set; } = null;

		internal static class NativeMethods
		{
			[DllImport("User32.dll", CharSet = CharSet.Unicode)]
			internal static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
		}

		private const int EM_REPLACESEL = 0x00C2;

		//-------
		// Form
		//-------
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
			for (int _i1 = 0; _i1 < GblAOCmd.GetLength(0); _i1++)
			{
				_ = DgvEdit.Rows.Add(GblAOCmd[_i1, 0], GblAOCmd[_i1, 1]);
			}

			// Encode
			foreach (string _s1 in GblASTextCode)
			{
				_ = CbTextCode.Items.Add(_s1);
			}
			CbTextCode.Text = GblASTextCode[0];

			// LblResult
			TbResult_MouseUp(sender, null);

			// フォントサイズ
			NumericUpDown1.Value = (int)Math.Round(TbResult.Font.Size);

			// 初フォーカス
			SubTbCmdFocus(TbCmd.TextLength);
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

			TbResult.Enabled = true;
		}

		private void TbCmd_KeyPress(object sender, KeyPressEventArgs e)
		{
			switch (e.KeyChar)
			{
				// IME入力対策
				case (char)Keys.Enter:
					SubTbCmdExec(sender, null);
					break;
			}
		}

		private void TbCmd_KeyUp(object sender, KeyEventArgs e)
		{
			TbCmd_MouseClick(sender, null);

			// Fontを戻す
			TbCmd.Font = new Font(TbCmd.Font.Name, TbCmd.Font.Size);

			// [Ctrl+V] のとき
			if (e.KeyData == (Keys.Control | Keys.V))
			{
				TbCmd.Text = TbCmd.Text.Replace(NL, " ").Trim();
			}

			int iLen = TbCmd.TextLength;
			int i1;

			switch (e.KeyCode)
			{
				case Keys.Escape:
					TbResult.Focus();
					break;

				case Keys.Enter:
					// KeyPressと連動
					TbCmd.Text = TbCmd.Text.Replace(NL, "");
					SubTbCmdFocus(TbCmd.TextLength);
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
					i1 = TbCmd.SelectionStart - 20;
					if (i1 < 0)
					{
						i1 = 0;
					}
					TbCmd.Select(i1, 0);
					break;

				case Keys.PageDown:
					i1 = TbCmd.SelectionStart + 20;
					if (i1 > iLen)
					{
						i1 = iLen;
					}
					TbCmd.Select(i1, 0);
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

		private void TbCmd_MouseClick(object sender, MouseEventArgs e)
		{
			TbResult.Enabled = true;
		}

		private void TbCmd_MouseHover(object sender, EventArgs e)
		{
			ToolTip1.SetToolTip(TbCmd, Regex.Replace(TbCmd.Text, @"(?<=\G.{80})(?!$)", NL));
		}

		private void TbCmd_DragDrop(object sender, DragEventArgs e)
		{
			string[] a1 = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			int i1 = TbCmd.SelectionStart;
			if (i1 == TbCmd.TextLength)
			{
				TbCmd.Text += " ";
				++i1;
			}

			TbCmd.Text = TbCmd.Text.Substring(0, i1) + string.Join(" ", a1) + TbCmd.Text.Substring(i1);
		}

		private void TbCmd_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
		}

		//---------
		// CmsCmd
		//---------
		private void CmsCmd_実行_Click(object sender, EventArgs e)
		{
			SubTbCmdExec(sender, e);
		}

		private void CmsCmd_全クリア_Click(object sender, EventArgs e)
		{
			TbCmd.Text = "";
		}

		private void CmsCmd_全コピー_Click(object sender, EventArgs e)
		{
			TbCmd.SelectAll();
			TbCmd.Copy();
		}

		private void CmsCmd_コピー_Click(object sender, EventArgs e)
		{
			TbCmd.Copy();
		}

		private void CmsCmd_切り取り_Click(object sender, EventArgs e)
		{
			TbCmd.Cut();
		}

		private void CmsCmd_貼り付け_Click(object sender, EventArgs e)
		{
			TbCmd.Paste();
		}

		//-----------
		// TbCmdSub
		//-----------
		private void TbCmdSub_Enter(object sender, EventArgs e)
		{
			TbResult.Enabled = true;
		}

		private void TbCmdSub_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					SubTbCmdFocus(TbCmd.TextLength);
					break;

				case Keys.Up:
					TbCmdSub.Select(0, 0);
					break;

				case Keys.Down:
					TbCmdSub.Select(TbCmdSub.TextLength, 0);
					break;
			}
		}

		private void SubCmdSubAddText(string str)
		{
			TbCmdSub.Text += str + NL;
			TbCmdSub.SelectionStart = TbCmdSub.TextLength;
			TbCmdSub.ScrollToCaret();
		}

		//------------
		// CmsCmdSub
		//------------
		private void CmsCmdSub_全クリア_Click(object sender, EventArgs e)
		{
			TbCmdSub.Text = "";
		}

		private void CmsCmdSub_全コピー_Click(object sender, EventArgs e)
		{
			TbCmdSub.SelectAll();
			TbCmdSub.Copy();
		}

		private void CmsCmdSub_コピー_Click(object sender, EventArgs e)
		{
			TbCmdSub.Copy();
		}

		private void CmsCmdSub_切り取り_Click(object sender, EventArgs e)
		{
			TbCmdSub.Cut();
		}

		private void CmsCmdSub_貼り付け_Click(object sender, EventArgs e)
		{
			TbCmdSub.Paste();
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
				DgvEdit.Height = 337;
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

			int iPos = 0;

			for (int _i1 = 0; _i1 < GblAOCmd.Length; _i1++)
			{
				if (GblAOCmd[_i1, 0].ToString() == TbCmd.Text)
				{
					int _i2 = (int)GblAOCmd[_i1, 2];
					for (int _i3 = 0; _i3 < _i2; _i3++)
					{
						TbCmd.Text += " \"\"";
					}
					iPos = _i2 - 1;
					break;
				}
			}
			SubTbCmdFocus(TbCmd.TextLength - 1 - (iPos * 3));

			CbDgvEdit.Checked = false;
			CbDgvEdit_Click(sender, e);
		}

		private int DgvEditRow = 0;

		private void DgvEdit_KeyDown(object sender, KeyEventArgs e)
		{
			DgvEditRow = DgvEdit.CurrentRow.Index;

			switch (e.KeyCode)
			{
				case Keys.Enter:
					SubCmdSubAddText("[Click]または[Space]キーで選択");
					break;
			}
		}

		private void DgvEdit_KeyUp(object sender, KeyEventArgs e)
		{
			int i1 = DgvEdit.RowCount - 1;

			switch (e.KeyCode)
			{
				case Keys.Space:
					DgvEdit_Click(sender, e);
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
					DgvEditRow = DgvEditRow == 0 ? i1 : 0;
					break;

				case Keys.Right:
					DgvEditRow = DgvEditRow == i1 ? 0 : i1;
					break;

				case Keys.PageUp:
					DgvEditRow = DgvEditRow == 0 ? i1 : DgvEdit.CurrentRow.Index;
					break;

				case Keys.PageDown:
					DgvEditRow = DgvEditRow == i1 ? 0 : DgvEdit.CurrentRow.Index;
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
				DgvCmd.Height = 337;
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

			SubTbCmdFocus(TbCmd.TextLength);
		}

		private int DgvCmdCurrentRow = 0;

		private void DgvCmd_KeyDown(object sender, KeyEventArgs e)
		{
			DgvCmdCurrentRow = DgvCmd.CurrentRow.Index;

			switch (e.KeyCode)
			{
				case Keys.Enter:
					SubCmdSubAddText("[Click]または[Space]キーで選択");
					break;
			}
		}

		private void DgvCmd_KeyUp(object sender, KeyEventArgs e)
		{
			int i1 = DgvCmd.RowCount - 1;

			switch (e.KeyCode)
			{
				case Keys.Space:
					DgvCmd_Click(sender, e);
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

		private void TbDgvCmdSearch_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
				case Keys.Down:
					_ = DgvCmd.Focus();
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

			SubTbCmdFocus(TbCmd.TextLength);
		}

		private void BtnCmdRedo_Click(object sender, EventArgs e)
		{
			int i1 = LCmdHistory.Count - 1;

			if (LCmdHistoryPos < i1)
			{
				++LCmdHistoryPos;
				TbCmd.Text = LCmdHistory[LCmdHistoryPos];
				BtnCmdUndo.Enabled = true;
			}

			if (LCmdHistoryPos == i1)
			{
				BtnCmdRedo.Enabled = false;
			}

			SubTbCmdFocus(TbCmd.TextLength);
		}

		//-------
		// 実行
		//-------
		private void SubTbCmdExec(object sender, EventArgs e)
		{
			TbResult.Enabled = false;

			TbCmd.Text = TbCmd.Text.Trim();

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

			if (TbCmd.Text[0] == '#')
			{
				const int aOpMax = 3;
				string[] aOp = Enumerable.Repeat("", aOpMax).ToArray();

				string str = TbCmd.Text + "\n"; // "\n" => 検索用フラグ

				Regex rgx = null;
				Match mth = null;
				int i1 = 0;

				// #command 取得
				rgx = new Regex("^(?<pattern>.+?)\\s", RegexOptions.None);
				mth = rgx.Match(str);
				aOp[i1] = mth.Groups["pattern"].Value;

				// option[n] 取得
				// "\"" 対応
				rgx = new Regex("\"(?<pattern>.*?)\"\\s+", RegexOptions.None);

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
					// 出力クリア
					case "#clear":
						TbCmd.Text = "";
						TbCmdSub.Text = "";
						TbResult.Text = "";
						break;

					// 検索（一致）
					case "#grep":
						TbResult.Text = RtnTextGrep(TbResult.Text, aOp[1], true);
						break;

					// 検索（不一致）
					case "#except":
						TbResult.Text = RtnTextGrep(TbResult.Text, aOp[1], false);
						break;

					// 置換
					case "#replace":
						TbResult.Text = RtnTextReplace(TbResult.Text, aOp[1], aOp[2]);
						break;

					// 分割変換（like AWK）
					case "#split":
						TbResult.Text = RtnTextSplitCnv(TbResult.Text, aOp[1], aOp[2]);
						break;

					// 全角変換
					case "#towide":
						TbResult.Text = Strings.StrConv(TbResult.Text, VbStrConv.Wide, 0x411);
						break;

					// 全角変換(数字のみ)
					case "#tozennum":
						TbResult.Text = RtnZenNum(TbResult.Text);
						break;

					// 全角変換(カナのみ)
					case "#tozenkana":
						TbResult.Text = RtnZenKana(TbResult.Text);
						break;

					// 半角変換
					case "#tonarrow":
						TbResult.Text = Strings.StrConv(TbResult.Text, VbStrConv.Narrow, 0x411);
						break;

					// 半角変換(数字のみ)
					case "#tohannum":
						TbResult.Text = RtnHanNum(TbResult.Text);
						break;

					// 半角変換(カナのみ)
					case "#tohankana":
						TbResult.Text = RtnHanKana(TbResult.Text);
						break;

					// 大文字変換
					case "#toupper":
						TbResult.Text = TbResult.Text.ToUpper();
						break;

					// 小文字変換
					case "#tolower":
						TbResult.Text = TbResult.Text.ToLower();
						break;

					// 消去
					case "#erase":
						TbResult.Text = RtnTextEraseInLine(TbResult.Text, aOp[1], aOp[2]);
						break;

					// ソート
					case "#sort":
						TbResult.Text = RtnTextSort(TbResult.Text, false);
						break;

					// ソート後、重複消除
					case "#uniq":
						TbResult.Text = RtnTextSort(TbResult.Text, true);
						break;

					// 空白行削除
					case "#rmblankln":
						_ = SB.Clear();
						foreach (string _s1 in TbResult.Text.Split(SPLITS, StringSplitOptions.None))
						{
							string _s2 = _s1.TrimEnd();
							if (_s2.Length > 0)
							{
								_ = SB.Append(_s1 + NL);
							}
						}
						TbResult.Text = SB.ToString();
						break;

					// 行番号付与
					case "#addlnnum":
						int cnt = 0;
						_ = SB.Clear();
						foreach (string _s1 in TbResult.Text.Split(SPLITS, StringSplitOptions.None))
						{
							_ = SB.Append(string.Format("{0:D8}\t{1}{2}", ++cnt, _s1, NL));
						}
						TbResult.Text = SB.ToString();
						break;

					// ファイル取得
					case "#wget":
						System.Net.WebClient wc = new System.Net.WebClient();
						try
						{
							string url = aOp[1];
							byte[] data = wc.DownloadData(url);
							if (Regex.IsMatch(url, "^(http|ftp)"))
							{
								string s1 = Encoding.GetEncoding(CbTextCode.SelectedItem.ToString()).GetString(data);
								if (Regex.IsMatch(s1, "charset.*=.*UTF-8", RegexOptions.IgnoreCase))
								{
									CbTextCode.Text = GblASTextCode[1];
								}
							}
							_ = NativeMethods.SendMessage(TbResult.Handle, EM_REPLACESEL, 1, Regex.Replace(Encoding.GetEncoding(CbTextCode.SelectedItem.ToString()).GetString(data), "\r*\n", NL));
						}
						catch
						{
						}
						wc.Dispose();
						break;

					// 計算機
					case "#calc":
						SubCmdSubAddText(RtnEvalCalc(aOp[1]));
						break;

					// 現在日時
					case "#now":
						SubCmdSubAddText(DateTime.Now.ToString("yyyy/MM/dd(ddd) HH:mm:ss"));
						break;

					// バージョン
					case "#version":
						SubCmdSubAddText(VERSION);
						break;
				}

				TbResult.Enabled = true;
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
				P1.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(CbTextCode.SelectedItem.ToString());
				P1.OutputDataReceived += new DataReceivedEventHandler(ProcessDataReceived);
				_ = P1.Start();
				P1.BeginOutputReadLine();
				// 不可 P.Close() => 終了コードを返さないので書くな!!
			}
		}

		private void EventDataReceived(object sender, DataReceivedEventArgs e)
		{
			_ = NativeMethods.SendMessage(TbResult.Handle, EM_REPLACESEL, 1, e.Data + NL);
		}

		private void ProcessDataReceived(object sender, DataReceivedEventArgs e)
		{
			_ = Invoke(MyEvent, new object[2] { sender, e });
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
			SubTbCmdFocus(TbCmd.TextLength);

			if (P1 != null)
			{
				SubKillProcessTree(P1);
			}
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
				}
				catch
				{
				}
			}
		}

		//-----------
		// TbResult
		//-----------
		private void TbResult_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					SubTbCmdFocus(TbCmd.TextLength);
					break;

				case Keys.PageUp:
					TbResult.SelectionStart = 0;
					break;

				case Keys.PageDown:
					TbResult.SelectionStart = TbResult.TextLength;
					break;

				case Keys.V:
					if (e.Control == true)
					{
						CmsResult_貼り付け_Click(sender, e);
					}
					break;

				default:
					TbResult_MouseUp(sender, null);
					break;
			}
		}

		private void TbResult_MouseUp(object sender, MouseEventArgs e)
		{
			if (TbResult.SelectionLength == 0)
			{
				LblResult.Text = "";
				return;
			}

			int iNL = 0;
			int iRow = 0;
			int iCnt = 0;

			foreach (string _s1 in TbResult.SelectedText.Split(SPLITS, StringSplitOptions.None))
			{
				++iNL;

				if (_s1.Trim().Length > 0)
				{
					++iRow;
				}

				iCnt += _s1.Length;
			}

			LblResult.Text = string.Format("{0}字(有効{1}行／全{2}行)選択", iCnt, iRow, iNL);
		}

		private void TbResult_DragDrop(object sender, DragEventArgs e)
		{
			_ = SB.Clear();

			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			foreach(string _s1 in files)
			{
				foreach (string _s2 in File.ReadLines(_s1, Encoding.GetEncoding(CbTextCode.SelectedItem.ToString())))
				{
					_ = SB.Append(_s2.TrimEnd() + NL);
				}
			}

			_ = NativeMethods.SendMessage(TbResult.Handle, EM_REPLACESEL, 1, SB.ToString());
		}

		private void TbResult_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
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

		private void CmsResult_全選択_Click(object sender, EventArgs e)
		{
			TbResult.SelectAll();
			TbResult_MouseUp(sender, null);
		}

		private void CmsResult_全クリア_Click(object sender, EventArgs e)
		{
			TbResult.Text = "";
		}

		private void CmsResult_全コピー_Click(object sender, EventArgs e)
		{
			TbResult.SelectAll();
			TbResult.Copy();
		}

		private void CmsResult_コピー_Click(object sender, EventArgs e)
		{
			TbResult.Copy();
		}

		private void CmsResult_切り取り_Click(object sender, EventArgs e)
		{
			TbResult.Cut();
		}

		private void CmsResult_貼り付け_Click(object sender, EventArgs e)
		{
			_ = NativeMethods.SendMessage(TbResult.Handle, EM_REPLACESEL, 1, Regex.Replace(Clipboard.GetText(), "\r*\n", NL));
		}

		private void CmsResult_ファイル名を貼り付け_Click(object sender, EventArgs e)
		{
			_ = SB.Clear();

			StringCollection files = Clipboard.GetFileDropList();
			foreach (string _s1 in files)
			{
				_ = SB.Append(_s1 + (Directory.Exists(_s1) ? @"\" : null) + NL);
			}

			_ = NativeMethods.SendMessage(TbResult.Handle, EM_REPLACESEL, 1, SB.ToString());
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
		private void BtnResultUndo_Click(object sender, EventArgs e)
		{
			TbResult.Enabled = true;

			BtnResultRedo.Enabled = true;

			if (LResultHistoryPos > 0)
			{
				--LResultHistoryPos;
				TbResult.Text = LResultHistory[LResultHistoryPos];
			}

			if (LResultHistoryPos == 0)
			{
				BtnResultUndo.Enabled = false;
			}
		}

		private void BtnResultRedo_Click(object sender, EventArgs e)
		{
			TbResult.Enabled = true;

			BtnResultUndo.Enabled = true;

			int i1 = LResultHistory.Count - 1;

			if (LResultHistoryPos < i1)
			{
				++LResultHistoryPos;
				TbResult.Text = LResultHistory[LResultHistoryPos];
			}

			if (LResultHistoryPos == i1)
			{
				BtnResultRedo.Enabled = false;
			}
		}

		private void BtnResultMem_Click(object sender, EventArgs e)
		{
			if (TbResult.Text.Trim().Length == 0)
			{
				return;
			}

			LResultHistory.Add(TbResult.Text);
			LResultHistoryPos = LResultHistory.Count - 1;

			BtnResultUndo.Enabled = true;
			BtnResultRedo.Enabled = false;
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
		private void SubTbCmdFocus(
			int iPos
		)
		{
			if (iPos >= 0)
			{
				TbCmd.SelectionStart = iPos;
			}
			_ = TbCmd.Focus();
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
			}
			)
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
		private string RtnTextGrep(
			string str,
			string sRegex,
			bool bMatch
		)
		{
			if (sRegex.Length == 0)
			{
				SubCmdSubAddText(@"正規表現による検索：\t \n \\ \. etc.");
				return str;
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
				return str;
			}

			_ = SB.Clear();

			foreach (string _s1 in str.Split(SPLITS, StringSplitOptions.None))
			{
				string _s2 = _s1 + NL;
				if (bMatch == rgx.IsMatch(_s2))
				{
					_ = SB.Append(_s2);
				}
			}

			return SB.ToString();
		}

		//---------------
		// 正規表現置換
		//---------------
		private string RtnTextReplace(
			string str,
			string sOld,
			string sNew
		)
		{
			if (sOld.Length == 0)
			{
				SubCmdSubAddText(@"正規表現による検索：\t \n \\ \. etc.");
				return str;
			}

			// 特殊文字を置換
			sNew = sNew.Replace("\\n", NL);
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
				return str;
			}

			_ = SB.Clear();

			foreach (string _s1 in str.Split(SPLITS, StringSplitOptions.None))
			{
				_ = SB.Append(rgx.Replace(_s1, sNew) + NL);
			}

			return SB.ToString();
		}

		//-----------
		// 分割変換
		//-----------
		private string RtnTextSplitCnv(
			string str,
			string sSplit,
			string sRegex
		)
		{
			if (sSplit.Length == 0 || sRegex.Length == 0)
			{
				SubCmdSubAddText(@"正規表現による検索：\t \n \\ \. etc.");
				return str;
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
				return str;
			}

			_ = SB.Clear();

			foreach (string _s1 in str.Split(SPLITS, StringSplitOptions.None))
			{
				if (_s1.Length > 0)
				{
					string[] a1 = rgx2.Split(_s1);
					string _s2 = sRegex;

					for (int _i1 = 0; _i1 < a1.Length; _i1++)
					{
						_s2 = _s2.Replace("[" + _i1.ToString() + "]", a1[_i1]);

						// 特殊文字を置換
						_s2 = _s2.Replace("\\n", NL);
						_s2 = _s2.Replace("\\t", "\t");
						_s2 = _s2.Replace("\\\\", "\\");
						_s2 = _s2.Replace("\\\"", "\"");
						_s2 = _s2.Replace("\\\'", "\'");
					}

					// 該当なしの変換子を削除
					_ = SB.Append(rgx1.Replace(_s2, "") + NL);
				}
			}

			return SB.ToString();
		}

		//----------------
		// 全角 <=> 半角
		//----------------
		private static string RtnZenNum(string s)
		{
			Regex rgx = new Regex(@"\d+");
			return  rgx.Replace(s, RtnReplacerWide);
		}

		private static string RtnHanNum(string s)
		{
			// 全角０-９ Unicode
			Regex rgx = new Regex(@"[\uff10-\uff19]+");
			return rgx.Replace(s, RtnReplacerNarrow);
		}

		private static string RtnZenKana(string s)
		{
			// 半角カナ Unicode
			Regex rgx = new Regex(@"[\uff61-\uFF9f]+");
			return rgx.Replace(s, RtnReplacerWide);
		}

		private static string RtnHanKana(string s)
		{
			// 全角カナ Unicode
			Regex rgx = new Regex(@"[\u30A1-\u30F6]+");
			return rgx.Replace(s, RtnReplacerNarrow);
		}

		private static string RtnReplacerWide(Match m)
		{
			return Strings.StrConv(m.Value, VbStrConv.Wide, 0x411);
		}

		private static string RtnReplacerNarrow(Match m)
		{
			return Strings.StrConv(m.Value, VbStrConv.Narrow, 0x411);
		}

		//-----------
		// 文字消去
		//-----------
		private string RtnTextEraseInLine(
			string str,
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
				return str;
			}

			int iEndPos;
			try
			{
				iEndPos = int.Parse(sEndPos);
			}
			catch
			{
				return str;
			}

			_ = SB.Clear();

			foreach (string _s1 in str.Split(SPLITS, StringSplitOptions.None))
			{
				_ = SB.Append(RtnEraseLen(_s1, ' ', iBgnPos, iEndPos) + NL);
			}

			return SB.ToString();
		}

		private string RtnEraseLen(
			string str = "",
			char cRep = ' ',
			int iBgnPos = 0,
			int iLen = 0
		)
		{
			// 範囲チェック
			if (str.Length == 0 || iBgnPos > str.Length || iLen <= 0)
			{
				return str;
			}

			int iEndPos = iBgnPos + iLen;

			// iEndPos の正位置は？
			if (iEndPos <= 0)
			{
				iEndPos += str.Length;

				if (iEndPos < 0)
				{
					return str;
				}
			}
			else if (iEndPos > str.Length)
			{
				iEndPos = str.Length;
			}

			// iBgnPos の正位置は？
			if (iBgnPos < 0)
			{
				iBgnPos += str.Length;

				if (iBgnPos < 0)
				{
					iBgnPos = 0;
				}
			}

			string rtn = "";

			// 前
			rtn += str.Substring(0, iBgnPos);

			// 中
			for (int _i1 = iBgnPos; _i1 < iEndPos; _i1++)
			{
				rtn += cRep;
			}

			// 後
			rtn += str.Substring(iEndPos, str.Length - iEndPos);

			return rtn;
		}

		//-------------
		// Sort／Uniq
		//-------------
		private string RtnTextSort(
			string str,
			bool bUniq = false
		)
		{
			List<string> l1 = new List<string>();

			foreach (string _s1 in str.Split(SPLITS, StringSplitOptions.None))
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
				_ = SB.Append(_s1 + NL);
			}

			return SB.ToString();
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

		//-----------
		// Eval計算
		//-----------
		private string RtnEvalCalc(
			string str
		)
		{
			string rtn = str.ToLower().Replace(" ", "");

			// Help
			if (rtn.Length == 0)
			{
				return "pi, e, sin(n), cos(n), tan(n), sqrt(n), pow(n,n)";
			}

			using (DataTable dt = new DataTable())
			{
				try
				{
					// 定数
					rtn = rtn.Replace("pi", Math.PI.ToString());
					rtn = rtn.Replace("e", Math.E.ToString());

					// sin(n) cos(n) tan(n) sqrt(n)
					string[] aMath = { "sin", "cos", "tan", "sqrt" };
					foreach (string _s1 in aMath)
					{
						foreach (Match _m1 in Regex.Matches(rtn, _s1 + @"\(\d+\.*\d*\)"))
						{
							string _s2 = _m1.Value;
							_s2 = _s2.Replace(_s1 + "(", "");
							_s2 = _s2.Replace(")", "");

							double _d1 = double.Parse(_s2);

							switch (_s1)
							{
								case "sin": _d1 = Math.Sin(_d1 * Math.PI / 180); break;
								case "cos": _d1 = Math.Cos(_d1 * Math.PI / 180); break;
								case "tan": _d1 = Math.Tan(_d1 * Math.PI / 180); break;
								case "sqrt": _d1 = Math.Sqrt(_d1); break;
								default: _d1 = 0; break;
							}

							rtn = rtn.Replace(_m1.Value, _d1.ToString());
						}
					}

					// pow(n,n)
					foreach (Match _m1 in Regex.Matches(rtn, @"pow\(\d+\.*\d*\,\d+\)"))
					{
						string _s2 = _m1.Value;
						_s2 = _s2.Replace("pow(", "");
						_s2 = _s2.Replace(")", "");

						string[] _a1 = _s2.Split(',');
						rtn = rtn.Replace(_m1.Value, Math.Pow(double.Parse(_a1[0]), int.Parse(_a1[1])).ToString());
					}

					rtn = dt.Compute(rtn, "").ToString();
				}
				catch
				{
					rtn = "Err";
				}
			}

			return rtn;
		}
	}
}
