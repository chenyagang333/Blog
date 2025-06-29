namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 分页查询结果
/// </summary>
/// <typeparam name="T">数据项类型</typeparam>
/// <remarks>
/// 包含分页元数据和实际数据集合
/// </remarks>
public class PaginatedResult<T>
{
    /// <summary>
    /// 当前页码
    /// </summary>
    public int PageIndex { get; }

    /// <summary>
    /// 每页记录数
    /// </summary>
    public int PageSize { get; }

    /// <summary>
    /// 总记录数
    /// </summary>
    public long TotalCount { get; }

    /// <summary>
    /// 总页数
    /// </summary>
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    /// <summary>
    /// 当前页数据集合
    /// </summary>
    public IReadOnlyList<T> Items { get; }

    /// <summary>
    /// 是否有上一页
    /// </summary>
    public bool HasPreviousPage => PageIndex > 1;

    /// <summary>
    /// 是否有下一页
    /// </summary>
    public bool HasNextPage => PageIndex < TotalPages;

    public PaginatedResult(
        IReadOnlyList<T> items,
        long totalCount,
        int pageIndex,
        int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalCount = totalCount;
        Items = items;
    }
}