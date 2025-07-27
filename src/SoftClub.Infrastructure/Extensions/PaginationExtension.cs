using Microsoft.EntityFrameworkCore;
using SoftClub.Domain.Common.Pagination;

namespace SoftClub.Infrastructure.Extensions;

public static class PaginationExtension
{
    public static async Task<List<TEntity>> ToPaginateAsync<TEntity>(
        this IQueryable<TEntity> src,
        Pagination pagination,
        CancellationToken cancellationToken = default
        )
    {
        src = src
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize);

        return await src.ToListAsync(cancellationToken);
    }

    public static IQueryable<TEntity> ToPaginate<TEntity>(this IQueryable<TEntity> src, Pagination pagination)
    {
        src = src
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize);

        return src;
    }
}
