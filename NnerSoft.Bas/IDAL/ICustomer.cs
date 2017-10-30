using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NnerSoft.Bas.Model;
using NnerSoft.Bas.Model.Customers;
namespace NnerSoft.Bas.IDAL
{
    /// <summary>
    /// 联系人接口
    /// </summary>
    public interface ICustomer
    {
        Result Insert(CustomerModel model);
        Result Update(CustomerModel model);
        Result Delete(CustomerDeleteParams model);
    }
}
