namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客文章查询参数
/// </summary>
/// <typeparam name="TKey">主键类型</typeparam>
/// <remarks>
/// 继承自 <see cref="PaginationParams"/> 包含分页参数，
/// 扩展文章特有的查询过滤条件
/// </remarks>
public class BlogPostQueryParams<TKey> : PaginationParams
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 排序字段
    /// </summary>
    public BlogPostSortOrder? SortBy { get; set; }

    /// <summary>
    /// 状态过滤条件
    /// </summary>
    public BlogPostStatus Status { get; set; } = BlogPostStatus.Published;

    /// <summary>
    /// 类型过滤条件
    /// </summary>
    public BlogPostType? Type { get; set; }

    /// <summary>
    /// 关键词搜索（标题/内容）
    /// </summary>
    public string? Keyword { get; set; }

    /// <summary>
    /// 分类ID过滤
    /// </summary>
    public TKey? CategoryId { get; set; }

    /// <summary>
    /// 标签ID过滤
    /// </summary>
    public TKey? TagId { get; set; }

    /// <summary>
    /// 用户ID过滤
    /// </summary>
    public TKey? UserId { get; set; }
}