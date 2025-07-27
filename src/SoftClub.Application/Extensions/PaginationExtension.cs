using SoftClub.Domain.Common.Pagination;

namespace SoftClub.Application.Extensions;

public static class PaginationExtension
{
    public static IEnumerable<TEntity> ToPaginate<TEntity>(this IQueryable<TEntity> src, Pagination pagination)
    {
        src = src
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize);

        return src.ToList();
    }
}