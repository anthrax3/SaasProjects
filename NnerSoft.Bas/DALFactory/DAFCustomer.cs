using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NnerSoft.Bas.IDAL;

namespace NnerSoft.Bas.DALFactory
{
    /// <summary>
    /// 客户
    /// </summary>
    /// 
    public class DAFCustomer : DataAccessBase
    {
        public static ICustomer CreateCustomer()
        {
            string classNamespace = DataAccessBase.AssemblyPath + ".Customer";
            object obj = DataAccessBase.CreateObject(DataAccessBase.AssemblyPath, classNamespace);
            return (ICustomer)obj;
        }
    }
}
