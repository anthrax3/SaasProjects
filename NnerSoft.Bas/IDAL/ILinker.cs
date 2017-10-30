using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NnerSoft.Bas.Model;
using NnerSoft.Bas.Model.Linker;
namespace NnerSoft.Bas.IDAL
{
    /// <summary>
    /// 客户接口
    /// </summary>
    public interface ILinker
    {
        Result Insert(LinkerModel model);
        Result Update(LinkerModel model);
        Result Delete(LinkerDeleteParams model);
    }
}
