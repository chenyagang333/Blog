namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客内容聚合存储接口（管理文章及其关联数据）
/// </summary>
/// <typeparam name="TPost">博客文章实体类型</typeparam>
/// <typeparam name="TCategory">文章分类类型</typeparam>
/// <typeparam name="TTag">文章标签类型</typeparam>
/// <typeparam name="TAttachment">文章附件类型</typeparam>
/// <typeparam name="TKey">主键类型，必须实现 <see cref="IEquatable{TKey}"/> 接口</typeparam>
/// <remarks>
/// </remarks>
public interface IBlogContentAggregateStore<TPost, TCategory, TTag, TAttachment, TKey> :
    IPostStore<TPost, TKey>,
    IDisposable
    where TPost : class
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 根据文章ID获取完整内容摘要（包含关联数据）
    /// </summary>
    /// <param name="postId">文章唯一标识符</param>
    /// <param name="ct">取消操作令牌</param>
    /// <returns>博客内容摘要</returns>
    /// <remarks>
    /// 返回包含文章主体、分类、标签、附件等完整聚合数据
    /// </remarks>
    Task<BlogPostSummary<TPost, TCategory, TTag, TAttachment>> GetSummaryByIdAsync(
        TKey postId,
        CancellationToken cancellationToken);

    /// <summary>
    /// 查询内容摘要列表（使用预配置查询参数对象）
    /// </summary>
    /// <param name="queryParams">查询参数对象</param>
    /// <param name="ct">取消操作令牌</param>
    /// <returns>内容摘要列表</returns>
    /// <remarks>
    /// 支持多条件筛选、分页、排序
    /// </remarks>
    Task<PaginatedResult<BlogPostSummary<TPost, TCategory, TTag, TAttachment>>> QuerySummariesAsync(
        BlogPostQueryParams<TKey> queryParams,
        CancellationToken cancellationToken);

    /// <summary>
    /// 查询内容摘要列表（通过委托动态配置查询参数）
    /// </summary>
    /// <param name="configureQuery">查询配置委托</param>
    /// <param name="ct">取消操作令牌</param>
    /// <returns>内容摘要列表</returns>
    /// <remarks>
    /// 提供灵活的自定义查询能力，适合复杂场景
    /// 示例：
    /// <code>
    /// await store.QuerySummariesAsync(params => 
    /// {
    ///     params.Status = BlogPostStatus.Published;
    ///     params.PageSize = 10;
    ///     params.SortBy = BlogPostSortOrder.Newest;
    /// });
    /// </code>
    /// </remarks>
    Task<PaginatedResult<BlogPostSummary<TPost, TCategory, TTag, TAttachment>>> QuerySummariesAsync(
        Action<BlogPostQueryParams<TKey>> configureQuery,
        CancellationToken cancellationToken);
}