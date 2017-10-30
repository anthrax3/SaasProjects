using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NnerSoft.Bas.IDAL;

namespace NnerSoft.Bas.DALFactory
{
    public class DAFBas : DataAccessBase
    {
        public static ISupplier CreateSupplier()
        {
            string classNamespace = DataAccessBase.AssemblyPath + ".Supplier";
            object obj = DataAccessBase.CreateObject(DataAccessBase.AssemblyPath, classNamespace);
            return (ISupplier)obj;
        }

        public static ICustomer CreateCustomer()
        {
            string classNamespace = DataAccessBase.AssemblyPath + ".Customer";
            object obj = DataAccessBase.CreateObject(DataAccessBase.AssemblyPath, classNamespace);
            return (ICustomer)obj;
        }

        public static ILinker CreateLinker()
        {
            string classNamespace = DataAccessBase.AssemblyPath + ".Linker";
            object obj = DataAccessBase.CreateObject(DataAccessBase.AssemblyPath, classNamespace);
            return (ILinker)obj;
        }
    }
}
