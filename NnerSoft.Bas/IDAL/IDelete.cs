using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NnerSoft.Bas.Model.Results;
namespace NnerSoft.Bas.IDAL
{
    /// <summary>
    /// 删除接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDelete<T,TResult>
    {
        TResult Delete(T model);
    }
}
