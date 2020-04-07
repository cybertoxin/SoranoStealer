using System;
using System.IO;
using System.Text;

// Token: 0x0200000D RID: 13
internal class Class7
{
	// Token: 0x06000048 RID: 72 RVA: 0x0000546C File Offset: 0x0000366C
	public Class7(string string_1)
	{
		Class13.Cyiv2R6zubiV2();
		this.byte_1 = new byte[]
		{
			0,
			1,
			2,
			3,
			4,
			6,
			8,
			8,
			0,
			0
		};
		base..ctor();
		this.byte_0 = File.ReadAllBytes(string_1);
		this.ulong_1 = this.method_0(16, 2);
		this.ulong_0 = this.method_0(56, 4);
		this.method_5(100L);
	}

	// Token: 0x06000049 RID: 73 RVA: 0x000054D8 File Offset: 0x000036D8
	private ulong method_0(int int_0, int int_1)
	{
		ulong result;
		try
		{
			if (int_1 > 8 | int_1 == 0)
			{
				result = 0UL;
			}
			else
			{
				ulong num = 0UL;
				for (int i = 0; i <= int_1 - 1; i++)
				{
					num = (num << 8 | (ulong)this.byte_0[int_0 + i]);
				}
				result = num;
			}
		}
		catch
		{
			result = 0UL;
		}
		return result;
	}

	// Token: 0x0600004A RID: 74 RVA: 0x0000554C File Offset: 0x0000374C
	private long method_1(int int_0, int int_1)
	{
		long result;
		try
		{
			int_1++;
			byte[] array = new byte[8];
			int num = int_1 - int_0;
			bool flag = false;
			if (num == 0 | num > 9)
			{
				result = 0L;
			}
			else if (num == 1)
			{
				array[0] = (this.byte_0[int_0] & 127);
				result = BitConverter.ToInt64(array, 0);
			}
			else
			{
				if (num == 9)
				{
					flag = true;
				}
				int num2 = 1;
				int num3 = 7;
				int num4 = 0;
				if (flag)
				{
					array[0] = this.byte_0[int_1 - 1];
					int_1--;
					num4 = 1;
				}
				for (int i = int_1 - 1; i >= int_0; i += -1)
				{
					if (i - 1 >= int_0)
					{
						array[num4] = (byte)((this.byte_0[i] >> num2 - 1 & 255 >> num2) | (int)this.byte_0[i - 1] << num3);
						num2++;
						num4++;
						num3--;
					}
					else if (!flag)
					{
						array[num4] = (byte)(this.byte_0[i] >> num2 - 1 & 255 >> num2);
					}
				}
				result = BitConverter.ToInt64(array, 0);
			}
		}
		catch
		{
			result = 0L;
		}
		return result;
	}

	// Token: 0x0600004B RID: 75 RVA: 0x000056A0 File Offset: 0x000038A0
	public int method_2()
	{
		return this.struct4_0.Length;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x000056B8 File Offset: 0x000038B8
	public string method_3(int int_0, int int_1)
	{
		string result;
		try
		{
			if (int_0 >= this.struct4_0.Length)
			{
				result = null;
			}
			else
			{
				result = ((int_1 >= this.struct4_0[int_0].string_0.Length) ? null : this.struct4_0[int_0].string_0[int_1]);
			}
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00005720 File Offset: 0x00003920
	private int method_4(int int_0)
	{
		int result;
		try
		{
			if (int_0 > this.byte_0.Length)
			{
				return 0;
			}
			for (int i = int_0; i <= int_0 + 8; i++)
			{
				if (i > this.byte_0.Length - 1)
				{
					return 0;
				}
				if ((this.byte_0[i] & 128) != 128)
				{
					result = i;
					goto IL_61;
				}
			}
			return int_0 + 8;
		}
		catch
		{
			result = 0;
		}
		IL_61:
		return result;
	}

	// Token: 0x0600004E RID: 78 RVA: 0x0000236A File Offset: 0x0000056A
	private static bool smethod_0(long long_0)
	{
		return (long_0 & 1L) == 1L;
	}

	// Token: 0x0600004F RID: 79 RVA: 0x000057A4 File Offset: 0x000039A4
	private void method_5(long long_0)
	{
		try
		{
			byte b = this.byte_0[(int)((IntPtr)long_0)];
			if (b != 5)
			{
				if (b == 13)
				{
					ulong num = this.method_0((int)long_0 + 3, 2) - 1UL;
					int num2 = 0;
					if (this.struct3_0 != null)
					{
						num2 = this.struct3_0.Length;
						Array.Resize<Class7.Struct3>(ref this.struct3_0, this.struct3_0.Length + (int)num + 1);
					}
					else
					{
						this.struct3_0 = new Class7.Struct3[num + 1UL];
					}
					for (ulong num3 = 0UL; num3 <= num; num3 += 1UL)
					{
						ulong num4 = this.method_0((int)long_0 + 8 + (int)num3 * 2, 2);
						if (long_0 != 100L)
						{
							num4 += (ulong)long_0;
						}
						int num5 = this.method_4((int)num4);
						this.method_1((int)num4, num5);
						int num6 = this.method_4((int)(num4 + ((double)num5 - num4) + 1.0));
						this.method_1((int)(num4 + ((double)num5 - num4) + 1.0), num6);
						ulong num7 = (ulong)(num4 + ((double)num6 - num4 + 1.0));
						int num8 = this.method_4((int)num7);
						int num9 = num8;
						long num10 = this.method_1((int)num7, num8);
						long[] array = new long[5];
						for (int i = 0; i <= 4; i++)
						{
							int int_ = num9 + 1;
							num9 = this.method_4(int_);
							array[i] = this.method_1(int_, num9);
							array[i] = (long)((array[i] <= 9L) ? ((ulong)this.byte_1[(int)((IntPtr)array[i])]) : ((ulong)((!Class7.smethod_0(array[i])) ? ((array[i] - 12L) / 2L) : ((array[i] - 13L) / 2L))));
						}
						if (this.ulong_0 == 1UL)
						{
						}
						if (this.ulong_0 == 1UL)
						{
							this.struct3_0[num2 + (int)num3].string_0 = Encoding.Default.GetString(this.byte_0, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
						}
						else if (this.ulong_0 == 2UL)
						{
							this.struct3_0[num2 + (int)num3].string_0 = Encoding.Unicode.GetString(this.byte_0, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
						}
						else if (this.ulong_0 == 3UL)
						{
							this.struct3_0[num2 + (int)num3].string_0 = Encoding.BigEndianUnicode.GetString(this.byte_0, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
						}
						this.struct3_0[num2 + (int)num3].long_0 = (long)this.method_0((int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2]), (int)array[3]);
						if (this.ulong_0 == 1UL)
						{
							this.struct3_0[num2 + (int)num3].TxQjzxiwTb = Encoding.Default.GetString(this.byte_0, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
						}
						else if (this.ulong_0 == 2UL)
						{
							this.struct3_0[num2 + (int)num3].TxQjzxiwTb = Encoding.Unicode.GetString(this.byte_0, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
						}
						else if (this.ulong_0 == 3UL)
						{
							this.struct3_0[num2 + (int)num3].TxQjzxiwTb = Encoding.BigEndianUnicode.GetString(this.byte_0, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
						}
					}
				}
			}
			else
			{
				ushort num11 = (ushort)(this.method_0((int)long_0 + 3, 2) - 1UL);
				for (int j = 0; j <= (int)num11; j++)
				{
					ushort num12 = (ushort)this.method_0((int)long_0 + 12 + j * 2, 2);
					if (long_0 == 100L)
					{
						this.method_5((long)((this.method_0((int)num12, 4) - 1UL) * this.ulong_1));
					}
					else
					{
						this.method_5((long)((this.method_0((int)(long_0 + (long)((ulong)num12)), 4) - 1UL) * this.ulong_1));
					}
				}
				this.method_5((long)((this.method_0((int)long_0 + 8, 4) - 1UL) * this.ulong_1));
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00005CE0 File Offset: 0x00003EE0
	public bool method_6(string string_1)
	{
		bool result;
		try
		{
			int num = -1;
			int i = 0;
			while (i <= this.struct3_0.Length)
			{
				if (string.Compare(this.struct3_0[i].string_0.ToLower(), string_1.ToLower(), StringComparison.Ordinal) != 0)
				{
					i++;
				}
				else
				{
					num = i;
					IL_46:
					if (num == -1)
					{
						return false;
					}
					char[] separator = new char[]
					{
						','
					};
					string[] array = this.struct3_0[num].TxQjzxiwTb.Substring(this.struct3_0[num].TxQjzxiwTb.IndexOf("(", StringComparison.Ordinal) + 1).Split(separator);
					for (int j = 0; j <= array.Length - 1; j++)
					{
						array[j] = array[j].TrimStart(new char[0]);
						int num2 = array[j].IndexOf(' ');
						if (num2 > 0)
						{
							array[j] = array[j].Substring(0, num2);
						}
						if (array[j].IndexOf("UNIQUE", StringComparison.Ordinal) != 0)
						{
							Array.Resize<string>(ref this.string_0, j + 1);
							this.string_0[j] = array[j];
						}
					}
					return this.method_7((ulong)((this.struct3_0[num].long_0 - 1L) * (long)this.ulong_1));
				}
			}
			goto IL_46;
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00005E60 File Offset: 0x00004060
	private bool method_7(ulong ulong_2)
	{
		bool result;
		try
		{
			if (this.byte_0[(int)((IntPtr)((long)ulong_2))] == 13)
			{
				ushort num = (ushort)(this.method_0((int)ulong_2 + 3, 2) - 1UL);
				int num2 = 0;
				if (this.struct4_0 != null)
				{
					num2 = this.struct4_0.Length;
					Array.Resize<Class7.Struct4>(ref this.struct4_0, this.struct4_0.Length + (int)num + 1);
				}
				else
				{
					this.struct4_0 = new Class7.Struct4[(int)(num + 1)];
				}
				ushort num3 = num;
				ushort num4 = 0;
				for (ushort num5 = 0; num5 <= num; num5 += 1)
				{
					if (num3 == num)
					{
						num4 += 1;
					}
					if (num4 > 100)
					{
						return false;
					}
					ulong num6 = this.method_0((int)ulong_2 + 8 + (int)(num5 * 2), 2);
					if (ulong_2 != 100UL)
					{
						num6 += ulong_2;
					}
					int num7 = this.method_4((int)num6);
					this.method_1((int)num6, num7);
					int num8 = this.method_4((int)(num6 + ((double)num7 - num6) + 1.0));
					this.method_1((int)(num6 + ((double)num7 - num6) + 1.0), num8);
					ulong num9 = (ulong)(num6 + ((double)num8 - num6 + 1.0));
					int num10 = this.method_4((int)num9);
					int num11 = num10;
					long num12 = this.method_1((int)num9, num10);
					Class7.Struct2[] array = null;
					long num13 = (long)(num9 - (ulong)((long)num10) + 1UL);
					int num14 = 0;
					while (num13 < num12)
					{
						Array.Resize<Class7.Struct2>(ref array, num14 + 1);
						int num15 = num11 + 1;
						num11 = this.method_4(num15);
						array[num14].long_1 = this.method_1(num15, num11);
						array[num14].long_0 = (long)((array[num14].long_1 <= 9L) ? ((ulong)this.byte_1[(int)((IntPtr)array[num14].long_1)]) : ((ulong)((!Class7.smethod_0(array[num14].long_1)) ? ((array[num14].long_1 - 12L) / 2L) : ((array[num14].long_1 - 13L) / 2L))));
						num13 = num13 + (long)(num11 - num15) + 1L;
						num14++;
					}
					if (array != null)
					{
						this.struct4_0[num2 + (int)num5].string_0 = new string[array.Length];
						int num16 = 0;
						for (int i = 0; i <= array.Length - 1; i++)
						{
							if (array[i].long_1 > 9L)
							{
								if (!Class7.smethod_0(array[i].long_1))
								{
									if (this.ulong_0 == 1UL)
									{
										this.struct4_0[num2 + (int)num5].string_0[i] = Encoding.Default.GetString(this.byte_0, (int)(num9 + (ulong)num12) + num16, (int)array[i].long_0);
									}
									else if (this.ulong_0 == 2UL)
									{
										this.struct4_0[num2 + (int)num5].string_0[i] = Encoding.Unicode.GetString(this.byte_0, (int)(num9 + (ulong)num12) + num16, (int)array[i].long_0);
									}
									else if (this.ulong_0 == 3UL)
									{
										this.struct4_0[num2 + (int)num5].string_0[i] = Encoding.BigEndianUnicode.GetString(this.byte_0, (int)(num9 + (ulong)num12) + num16, (int)array[i].long_0);
									}
								}
								else
								{
									this.struct4_0[num2 + (int)num5].string_0[i] = Encoding.Default.GetString(this.byte_0, (int)(num9 + (ulong)num12) + num16, (int)array[i].long_0);
								}
							}
							else
							{
								this.struct4_0[num2 + (int)num5].string_0[i] = Convert.ToString(this.method_0((int)(num9 + (ulong)num12) + num16, (int)array[i].long_0));
							}
							num16 += (int)array[i].long_0;
						}
					}
				}
			}
			else if (this.byte_0[(int)((IntPtr)((long)ulong_2))] == 5)
			{
				ushort num17 = (ushort)(this.method_0((int)(ulong_2 + 3UL), 2) - 1UL);
				for (ushort num18 = 0; num18 <= num17; num18 += 1)
				{
					ushort num19 = (ushort)this.method_0((int)ulong_2 + 12 + (int)(num18 * 2), 2);
					this.method_7((this.method_0((int)(ulong_2 + (ulong)num19), 4) - 1UL) * this.ulong_1);
				}
				this.method_7((this.method_0((int)(ulong_2 + 8UL), 4) - 1UL) * this.ulong_1);
			}
			result = true;
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x04000021 RID: 33
	private readonly ulong ulong_0;

	// Token: 0x04000022 RID: 34
	private string[] string_0;

	// Token: 0x04000023 RID: 35
	private readonly byte[] byte_0;

	// Token: 0x04000024 RID: 36
	private Class7.Struct3[] struct3_0;

	// Token: 0x04000025 RID: 37
	private readonly ulong ulong_1;

	// Token: 0x04000026 RID: 38
	private readonly byte[] byte_1;

	// Token: 0x04000027 RID: 39
	private Class7.Struct4[] struct4_0;

	// Token: 0x0200000E RID: 14
	private struct Struct2
	{
		// Token: 0x04000028 RID: 40
		public long long_0;

		// Token: 0x04000029 RID: 41
		public long long_1;
	}

	// Token: 0x0200000F RID: 15
	private struct Struct3
	{
		// Token: 0x0400002A RID: 42
		public string string_0;

		// Token: 0x0400002B RID: 43
		public long long_0;

		// Token: 0x0400002C RID: 44
		public string TxQjzxiwTb;
	}

	// Token: 0x02000010 RID: 16
	private struct Struct4
	{
		// Token: 0x0400002D RID: 45
		public string[] string_0;
	}
}
