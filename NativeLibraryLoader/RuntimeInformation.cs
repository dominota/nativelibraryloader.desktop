#if !NETSTANDARD2_0
#define DESKTOP
#endif

using System;

#if DESKTOP

namespace NativeLibraryLoader
{
	class RuntimeInformation
	{
		public static bool IsOSPlatform(OSPlatform osPlatform) => 
			Array.IndexOf(osPlatform.PlatformIds, Environment.OSVersion.Platform) >= 0;
	}

	public class OSPlatform
	{
		internal PlatformID[] PlatformIds { get; }

		public OSPlatform(params PlatformID[] platformIds)
		{
			PlatformIds = platformIds;
		}

		public static OSPlatform Linux { get; } = new OSPlatform(PlatformID.Unix);

		public static OSPlatform OSX { get; } = new OSPlatform(PlatformID.Win32NT, PlatformID.Win32Windows, PlatformID.Win32S);

		public static OSPlatform Windows { get; } = new OSPlatform(PlatformID.MacOSX);
	}
}

#endif