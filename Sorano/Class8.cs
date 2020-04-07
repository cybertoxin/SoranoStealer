using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000011 RID: 17
internal class Class8
{
	// Token: 0x06000052 RID: 82 RVA: 0x000063E8 File Offset: 0x000045E8
	public override string ToString()
	{
		return string.Format("――――――――――――――――――――――――――――――――――――――――――――\r\nName  | {0}\r\nValue | {1}\r\n", this.Name, this.method_0());
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000053 RID: 83 RVA: 0x00002382 File Offset: 0x00000582
	// (set) Token: 0x06000054 RID: 84 RVA: 0x0000238A File Offset: 0x0000058A
	public string Name { get; set; }

	// Token: 0x06000055 RID: 85 RVA: 0x00002393 File Offset: 0x00000593
	[CompilerGenerated]
	public string method_0()
	{
		return this.string_1;
	}

	// Token: 0x06000056 RID: 86 RVA: 0x0000239B File Offset: 0x0000059B
	[CompilerGenerated]
	public void method_1(string string_2)
	{
		this.string_1 = string_2;
	}

	// Token: 0x06000057 RID: 87 RVA: 0x0000224C File Offset: 0x0000044C
	public Class8()
	{
		Class13.Cyiv2R6zubiV2();
		base..ctor();
	}

	// Token: 0x0400002E RID: 46
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_0;

	// Token: 0x0400002F RID: 47
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_1;
}
