using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.AppCore
{
    public static class QueryableExtensions
    {
        private static int Count = 1000;

        /// <summary>
        /// TODO implement paging with PageInfo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="order"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async static Task<T[]> ToPageAsync<T>(this IQueryable<T> query, Expression<Func<T, object>> order, CancellationToken token = default)
        {
            return await query.OrderBy(order).Skip(0).Take(Count).ToArrayAsync(token);
        }
    }
}
