using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;

// Token: 0x02000014 RID: 20
internal class Class11
{
	// Token: 0x0600005B RID: 91 RVA: 0x00006490 File Offset: 0x00004690
	public static long smethod_0(string string_0)
	{
		long result;
		if (!Regex.IsMatch(string_0, "^STEAM_0:[0-1]:([0-9]{1,10})$"))
		{
			result = (long)Class11.int_0;
		}
		else
		{
			result = Class11.long_0 + Convert.ToInt64(string_0.Substring(10)) * 2L + Convert.ToInt64(string_0.Substring(8, 1));
		}
		return result;
	}

	// Token: 0x0600005C RID: 92 RVA: 0x000064E4 File Offset: 0x000046E4
	public static long smethod_1(long long_2)
	{
		long result;
		if (long_2 < 1L || !Regex.IsMatch("U:1:" + long_2.ToString(CultureInfo.InvariantCulture), "^U:1:([0-9]{1,10})$"))
		{
			result = (long)Class11.int_0;
		}
		else
		{
			result = long_2 + Class11.long_0;
		}
		return result;
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00006538 File Offset: 0x00004738
	public static long smethod_2(long long_2)
	{
		long result;
		if (long_2 < Class11.long_1 || !Regex.IsMatch(long_2.ToString(CultureInfo.InvariantCulture), "^7656119([0-9]{10})$"))
		{
			result = (long)Class11.int_0;
		}
		else
		{
			result = long_2 - Class11.long_0;
		}
		return result;
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00006580 File Offset: 0x00004780
	public static string smethod_3(long long_2)
	{
		string result;
		if (long_2 < Class11.long_1 || !Regex.IsMatch(long_2.ToString(CultureInfo.InvariantCulture), "^7656119([0-9]{10})$"))
		{
			result = string.Empty;
		}
		else
		{
			long_2 -= Class11.long_0;
			long_2 -= long_2 % 2L;
			string text = string.Format("{0}{1}:{2}", "STEAM_0:", long_2 % 2L, long_2 / 2L);
			if (!Regex.IsMatch(text, "^STEAM_0:[0-1]:([0-9]{1,10})$"))
			{
				result = string.Empty;
			}
			else
			{
				result = text;
			}
		}
		return result;
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00006620 File Offset: 0x00004820
	public static string smethod_4()
	{
		string path = Path.Combine(Class11.smethod_5("InstallPath", "SourceModInstallPath"), "config\\loginusers.vdf");
		StringBuilder stringBuilder = new StringBuilder();
		string result;
		try
		{
			if (!File.Exists(path))
			{
				result = null;
			}
			else
			{
				string text = File.ReadAllLines(path)[2].Split(new char[]
				{
					'"'
				})[1];
				if (Regex.IsMatch(text, "^7656119([0-9]{10})$"))
				{
					string str = Class11.smethod_3(Convert.ToInt64(text));
					string str2 = "U:1:" + Class11.smethod_2(Convert.ToInt64(text)).ToString(CultureInfo.InvariantCulture);
					stringBuilder.AppendLine("Steam2 ID         | " + str);
					stringBuilder.AppendLine("Steam3 ID x32     | " + str2);
					stringBuilder.AppendLine("Steam3 ID x64     | " + text);
					stringBuilder.AppendLine("Ссылка на аккаунт | https://steamcommunity.com/profiles/" + text);
					result = stringBuilder.ToString();
				}
				else
				{
					result = null;
				}
			}
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000060 RID: 96 RVA: 0x0000672C File Offset: 0x0000492C
	public static string smethod_5(string string_0 = "InstallPath", string string_1 = "SourceModInstallPath")
	{
		string name = "SOFTWARE\\Wow6432Node\\Valve\\Steam";
		string name2 = "Software\\Valve\\Steam";
		bool flag = true;
		bool flag2 = false;
		string result;
		using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32))
		{
			using (RegistryKey registryKey2 = registryKey.OpenSubKey(name, Environment.Is64BitOperatingSystem ? flag : flag2))
			{
				using (RegistryKey registryKey3 = registryKey.OpenSubKey(name2, Environment.Is64BitOperatingSystem ? flag : flag2))
				{
					string text;
					if (registryKey2 != null)
					{
						object value = registryKey2.GetValue(string_0);
						if (value != null)
						{
							if ((text = value.ToString()) != null)
							{
								goto IL_93;
							}
						}
					}
					if (registryKey3 == null)
					{
						text = null;
					}
					else
					{
						object value2 = registryKey3.GetValue(string_1);
						text = ((value2 != null) ? value2.ToString() : null);
					}
					IL_93:
					result = text;
				}
			}
		}
		return result;
	}

	// Token: 0x06000061 RID: 97 RVA: 0x0000224C File Offset: 0x0000044C
	public Class11()
	{
		Class13.Cyiv2R6zubiV2();
		base..ctor();
	}

	// Token: 0x06000062 RID: 98 RVA: 0x000023A4 File Offset: 0x000005A4
	// Note: this type is marked as 'beforefieldinit'.
	static Class11()
	{
		Class13.Cyiv2R6zubiV2();
		Class11.long_0 = 76561197960265728L;
		Class11.long_1 = 76561197960265729L;
		Class11.int_0 = 0;
	}

	// Token: 0x0400003B RID: 59
	private static readonly long long_0;

	// Token: 0x0400003C RID: 60
	private static readonly long long_1;

	// Token: 0x0400003D RID: 61
	private static readonly int int_0;
}
