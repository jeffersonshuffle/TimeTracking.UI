using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
