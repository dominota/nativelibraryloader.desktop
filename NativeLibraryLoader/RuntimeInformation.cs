#if !NETSTANDARD2_0
#define DESKTOP
#endif

using System;

#if DESKTOP

namespace System.Runtime.InteropServices
{
	public enum Architecture
	{
		/// <summary>
		/// An Intel-based 32-bit processor architecture.
		/// </summary>
		X86 = 0,
		/// <summary>
		/// An Intel-based 64-bit processor architecture.
		/// </summary>
		X64 = 1,
		/// <summary>
		/// A 32-bit ARM processor architecture.
		/// </summary>
		Arm =  2,
		/// <summary>
		/// A 64-bit ARM processor architecture.
		/// </summary>
		Arm64 = 3,
	}

	public class RuntimeInformation
	{
		public static bool IsOSPlatform(OSPlatform osPlatform) => 
			Array.IndexOf(osPlatform.PlatformIds, Environment.OSVersion.Platform) >= 0;

		public static string OSDescription => string.Empty;

		
		public static Architecture OSArchitecture => GetArchitecture(Environment.Is64BitOperatingSystem);

		public static Architecture ProcessArchitecture => GetArchitecture(Environment.Is64BitProcess);

		// we don't try to support the notion of an ARM architectures
		static Architecture GetArchitecture(bool is64Bit) => is64Bit ? Architecture.X64 : Architecture.X86;
	}

	public class OSPlatform
	{
		internal PlatformID[] PlatformIds { get; }

		public OSPlatform(params PlatformID[] platformIds)
		{
			PlatformIds = platformIds;
		}

		public static OSPlatform Linux { get; } = new OSPlatform(PlatformID.Unix);

		public static OSPlatform OSX { get; } = new OSPlatform(PlatformID.MacOSX);

		public static OSPlatform Windows { get; } = new OSPlatform(PlatformID.Win32NT, PlatformID.Win32Windows, PlatformID.Win32S);
	}
}

#endif
