using STPL.Common.Model;
using STPL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Core.Util
{
    public static class FilterUtil
    {
        public static async Task<ResultData<T>> FilterGrid<T>(this IQueryable<T> query, PageInfo page)
        {
            if (!string.IsNullOrEmpty(page.SearchValue))
            {
                query = ApplySearchFilter(query, page.SearchValue);
            }
            int totalCount = query.Count();

            if (!string.IsNullOrEmpty(page.OrderColumn))
            {
                query = ApplyOrdering(query, page.OrderColumn, page.IsOrderDescending ?? false);
            }
            page.PageIndex -= 1;
            int skip = page.PageIndex * page.PageSize;

            query = query.Skip(skip).Take(page.PageSize);

            return new ResultData<T>
            {
                TotalCount = totalCount,
                Data = query.ToList(),
            };
        }

        private static IQueryable<T> ApplyOrdering<T>(IQueryable<T> query, string orderByColumn, bool isDescending)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, orderByColumn);
            var lambda = Expression.Lambda(property, parameter);
            var methodName = isDescending ? "OrderByDescending" : "OrderBy";
            var methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                new Type[] { typeof(T), property.Type },
                query.Expression, Expression.Quote(lambda));
            return query.Provider.CreateQuery<T>(methodCallExpression);
        }
        private static IQueryable<T> ApplySearchFilter<T>(IQueryable<T> query, string searchKey)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var predicate = GetSearchPredicate<T>(searchKey, parameter);
            return query.Where(predicate);
        }

        private static Expression<Func<T, bool>> GetSearchPredicate<T>(string searchKey, ParameterExpression parameter)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Expression finalExpression = Expression.Constant(false);

            foreach (var property in properties)
            {
                if (!typeof(IEnumerable<object>).IsAssignableFrom(property.PropertyType))
                {
                    Expression propertyAccess = Expression.Property(parameter, property);
                    Expression searchExpression = Expression.Call(propertyAccess, "ToString", null);
                    searchExpression = Expression.Call(searchExpression, "Contains", null, Expression.Constant(searchKey));

                    finalExpression = Expression.OrElse(finalExpression, searchExpression);
                }
            }

            return Expression.Lambda<Func<T, bool>>(finalExpression, parameter);
        }

        private static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}
