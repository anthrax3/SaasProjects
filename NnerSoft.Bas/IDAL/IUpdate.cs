using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NnerSoft.Bas.Model.Results;
namespace NnerSoft.Bas.IDAL
{
    public interface IUpdate<T,TResult>
    {
        TResult Update(T model);
    }
}
