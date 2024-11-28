using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XCubeCrm.Common.Enums;

namespace XCubeCrm.Dal.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(T entity, IEnumerable<string> fields);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);
        // biz sana T türünde bir sorgu gönderecez eğer doğru dönerse -sorgunun karşılığında bir value olduğu anlamına geliyor- o valueyi geri dönder hangi tipte geri döndüreceğini sorgu esnasında verecez T tipi
        IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector);
        int Count(Expression<Func<T, bool>> filter = null);
        string YeniKodVer(KartTuru kartTuru, Expression<Func<T, string>> filter, Expression<Func<T, bool>> where = null);


    }
}
