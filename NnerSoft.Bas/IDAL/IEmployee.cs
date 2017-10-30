using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NnerSoft.Bas.Model;
using NnerSoft.Bas.Model.Employee;
namespace NnerSoft.Bas.IDAL
{
    /// <summary>
    /// 员工接口
    /// </summary>
    public interface IEmployee
    {
        Result Insert(EmployeeEntity model);
        Result Update(EmployeeEntity model);
        Result Delete(EmployeeParams model);
    }
}
