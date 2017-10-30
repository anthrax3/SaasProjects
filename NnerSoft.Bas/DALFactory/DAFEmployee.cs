using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NnerSoft.Bas.IDAL;

namespace NnerSoft.Bas.DALFactory
{
    /// <summary>
    /// 员工
    /// </summary>
    /// 
    public class DAFEmployee : DataAccessBase
    {
        public static IEmployee CreateEmployee()
        {
            string classNamespace = DataAccessBase.AssemblyPath + ".Employee";
            object obj = DataAccessBase.CreateObject(DataAccessBase.AssemblyPath, classNamespace);
            return (IEmployee)obj;
        }
    }
}
