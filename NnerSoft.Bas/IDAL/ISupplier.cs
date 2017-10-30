using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NnerSoft.Bas.Model;
using NnerSoft.Bas.Model.Supplier;
namespace NnerSoft.Bas.IDAL
{
    /// <summary>
    /// 供应商接口
    /// </summary>
    public interface ISupplier : IInsert<SupplierEntity,Result>,IUpdate<SupplierEntity,Result>,IDelete<DeleteParams,Result>
    {

    }
}
