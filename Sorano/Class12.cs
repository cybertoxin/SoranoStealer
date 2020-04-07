using System;
using System.Reflection;

// Token: 0x02000018 RID: 24
internal class Class12
{
	// Token: 0x06000063 RID: 99 RVA: 0x00006820 File Offset: 0x00004A20
	internal static void dELv2R66tPZZi(int typemdt)
	{
		Type type = Class12.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class12.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	// Token: 0x06000064 RID: 100 RVA: 0x0000224C File Offset: 0x0000044C
	public Class12()
	{
		Class13.Cyiv2R6zubiV2();
		base..ctor();
	}

	// Token: 0x06000065 RID: 101 RVA: 0x000023CD File Offset: 0x000005CD
	// Note: this type is marked as 'beforefieldinit'.
	static Class12()
	{
		Class13.Cyiv2R6zubiV2();
		Class12.module_0 = typeof(Class12).Assembly.ManifestModule;
	}

	// Token: 0x0400003F RID: 63
	internal static Module module_0;

	// Token: 0x02000019 RID: 25
	// (Invoke) Token: 0x06000067 RID: 103
	internal delegate void Delegate0(object o);
}
