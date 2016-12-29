using System;
using System.Fabric;
using System.Fabric.Description;
using System.Runtime.InteropServices;
using System.Security;

namespace ServiceFabricConfigDecryptionHelper
{
	public static class ServiceFabricExtensions
	{
		/// <summary>
		/// Get the value of the given configuration value from the Configuration Package
		/// </summary>
		public static string GetConfigurationValue(this ServiceContext context, string section, string parameter)
		{
			return context.CodePackageActivationContext.GetConfigurationPackageObject("Config").Settings.Sections[section].Parameters[parameter].GetValue();
		}

		/// <summary>
		/// Get the value of this property whether it is encrypted or not
		/// </summary>
		public static string GetValue(this ConfigurationProperty prop)
		{
			if (!prop.IsEncrypted)
				return prop.Value;

			var secure = prop.DecryptValue();
			return secure.GetString();
		}

		private static string GetString(this SecureString value)
		{
			//http://stackoverflow.com/questions/818704/how-to-convert-securestring-to-system-string
			IntPtr valuePtr = IntPtr.Zero;
			try
			{
				valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
				return Marshal.PtrToStringUni(valuePtr);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
			}
		}
	}
}
