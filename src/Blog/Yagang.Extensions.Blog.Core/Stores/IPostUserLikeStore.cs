namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客文章用户点赞存储接口
/// </summary>
/// <typeparam name="TPost">博客文章实体类型</typeparam>
/// <typeparam name="TKey">主键类型，必须实现 <see cref="IEquatable{TKey}"/> 接口</typeparam>
/// <remarks>
/// <para>
/// 此接口定义了用户对文章的点赞操作管理，
/// 支持点赞和取消点赞功能。
/// </para>
/// <para>
/// 继承自 <see cref="IPostStore{TPost, TKey}"/> 接口，
/// 扩展了文章存储的用户点赞功能。
/// </para>
/// </remarks>
public interface IPostUserLikeStore<TPost, TKey> :
    IPostStore<TPost, TKey>
    where TPost : class
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 用户点赞指定文章
    /// </summary>
    /// <param name="postId">要点赞的文章ID</param>
    /// <param name="userId">执行点赞操作的用户ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会添加用户与文章的点赞关联关系。
    /// 如果用户已点赞该文章，则忽略操作。
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.LikePostAsync(postId, userId);
    /// </code>
    /// </para>
    /// </remarks>
    Task LikePostAsync(
        TKey postId,
        TKey userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 用户取消点赞指定文章
    /// </summary>
    /// <param name="postId">要取消点赞的文章ID</param>
    /// <param name="userId">执行取消点赞操作的用户ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会移除用户与文章的点赞关联关系。
    /// 如果用户未点赞该文章，则忽略操作。
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.UnlikePostAsync(postId, userId);
    /// </code>
    /// </para>
    /// </remarks>
    Task UnlikePostAsync(
        TKey postId,
        TKey userId,
        CancellationToken cancellationToken = default);
}