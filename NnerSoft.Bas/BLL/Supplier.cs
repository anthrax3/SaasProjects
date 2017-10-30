using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NnerSoft.Commom;
using NnerSoft.Bas.DALFactory;
using NnerSoft.Bas.IDAL;
using NnerSoft.Bas.Model;
using NnerSoft.Bas.Model.Supplier;
using NnerSoft.Bas.Model.Results;

namespace NnerSoft.Bas.BLL
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Supplier : ISupplier
    {
        private readonly ISupplier dal = DAFBas.CreateSupplier();

        public Model.Result Delete(DeleteParams model)
        {
            return dal.Delete(model);
        }

        public Model.Result Insert(SupplierEntity model)
        {
            return dal.Insert(model);
        }

        public Model.Result Update(SupplierEntity model)
        {
            return dal.Update(model);
        }
    }
}
