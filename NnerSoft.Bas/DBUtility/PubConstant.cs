using System;
using System.Configuration;
using System.Web;
using System.Web.Caching;
namespace NnerSoft.Bas.DBUtility
{
	public class PubConstant
	{
		protected const string KEY_CONNECTION = "ConnectionString";
		protected const string KEY_ENCRYPT = "ConStringEncrypt";
        private const string SQLSERVERDAL = "SQLServerDAL";
        public static bool IsSQLServer = PubConstant.GetConfigString("DAL") == "SQLServerDAL";
		public static string ConnectionString
		{
			get
			{
				ConfigurationManager.RefreshSection("appSettings");
				string text = ConfigurationManager.AppSettings["ConnectionString"];
				string a = ConfigurationManager.AppSettings["ConStringEncrypt"];
				if (a == "true")
				{
					text = DESEncrypt.Decrypt(text);
				}
				return text;
			}
		}
		public static string GetConnectionString(string configName)
		{
			ConfigurationManager.RefreshSection("appSettings");
			string text = ConfigurationManager.AppSettings[configName];
			string a = ConfigurationManager.AppSettings["ConStringEncrypt"];
			if (a == "true")
			{
				text = DESEncrypt.Decrypt(text);
			}
			return text;
		}
		public static string GetConfigString(string key)
		{
			string cacheKey = "AppSettings-" + key;
			object obj = PubConstant.GetCache(cacheKey);
			if (obj == null)
			{
				try
				{
					obj = ConfigurationManager.AppSettings[key];
					if (obj != null)
					{
						int num = 30;
						PubConstant.SetCache(cacheKey, obj, System.DateTime.Now.AddMinutes((double)num), System.TimeSpan.Zero);
					}
				}
				catch
				{
				}
			}
			return obj.ToString();
		}
		public static object GetCache(string CacheKey)
		{
			Cache cache = HttpRuntime.Cache;
			return cache[CacheKey];
		}
		public static void SetCache(string CacheKey, object objObject, System.DateTime absoluteExpiration, System.TimeSpan slidingExpiration)
		{
			Cache cache = HttpRuntime.Cache;
			cache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
		}
	}
}
