using System;
using System.Reflection;
using NnerSoft.Commom;
namespace NnerSoft.Bas.DALFactory
{
    public class DataAccessBase
    {        
        protected static readonly string AssemblyPath ="NnerSoft.Bas."+ConfigHelper.GetConfigString("DAL");
        protected static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            object result;
            try
            {
                object obj = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                result = obj;
            }
            catch
            {
                result = null;
            }
            return result;
        }
        protected static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object obj = DataCache.GetCache(classNamespace);
            if (obj == null)
            {
                try
                {
                    obj = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, obj);
                }
                catch
                {
                }
            }
            return obj;
        }
    }
}
