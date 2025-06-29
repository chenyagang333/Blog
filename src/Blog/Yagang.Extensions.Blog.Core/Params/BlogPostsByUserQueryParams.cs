namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 按用户查询博客文章的参数
/// </summary>
/// <typeparam name="TKey">主键类型</typeparam>
public class BlogPostsByUserQueryParams<TKey> : PaginationParams
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public required TKey UserId { get; set; }
}