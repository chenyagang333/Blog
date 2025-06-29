namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客文章用户浏览记录存储接口
/// </summary>
/// <typeparam name="TPost">博客文章实体类型</typeparam>
/// <typeparam name="TKey">主键类型，必须实现 <see cref="IEquatable{TKey}"/> 接口</typeparam>
/// <remarks>
/// <para>
/// 此接口定义了用户对文章的浏览记录管理功能，
/// 支持记录用户浏览行为和查询浏览历史。
/// </para>
/// <para>
/// 继承自 <see cref="IPostStore{TPost, TKey}"/> 接口，
/// 扩展了文章存储的用户浏览记录功能。
/// </para>
/// </remarks>
public interface IPostUserViewStore<TPost, TKey> :
    IPostStore<TPost, TKey>
    where TPost : class
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 记录用户浏览文章的行为
    /// </summary>
    /// <param name="postId">被浏览的文章ID</param>
    /// <param name="userId">浏览文章的用户ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会记录用户浏览文章的行为，通常包含以下信息：
    /// - 浏览时间（自动记录为当前时间）
    /// - 用户ID
    /// - 文章ID
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.RecordViewAsync(postId, userId);
    /// </code>
    /// </para>
    /// </remarks>
    Task RecordViewAsync(
        TKey postId,
        TKey userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 分页获取用户浏览的文章ID列表
    /// </summary>
    /// <param name="queryParams">用户文章浏览查询参数</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>用户浏览的文章ID分页结果</returns>
    /// <remarks>
    /// <para>
    /// 返回的文章ID列表按浏览时间倒序排列（最近浏览的在前）
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// var query = new BlogPostsByUserQueryParams
    /// {
    ///     UserId = userId,
    ///     PageIndex = 1,
    ///     PageSize = 10
    /// };
    /// 
    /// var result = await store.GetViewedPostIdsAsync(query);
    /// </code>
    /// </para>
    /// </remarks>
    Task<PaginatedResult<TKey>> GetViewedPostIdsAsync(
        BlogPostsByUserQueryParams<TKey> queryParams,
        CancellationToken cancellationToken = default);
}