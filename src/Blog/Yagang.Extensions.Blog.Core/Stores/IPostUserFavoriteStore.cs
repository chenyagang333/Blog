namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客文章用户收藏存储接口
/// </summary>
/// <typeparam name="TPost">博客文章实体类型</typeparam>
/// <typeparam name="TKey">主键类型，必须实现 <see cref="IEquatable{TKey}"/> 接口</typeparam>
/// <remarks>
/// <para>
/// 此接口定义了用户对文章的收藏操作管理，
/// 支持收藏和取消收藏功能。
/// </para>
/// <para>
/// 继承自 <see cref="IPostStore{TPost, TKey}"/> 接口，
/// 扩展了文章存储的用户收藏功能。
/// </para>
/// </remarks>
public interface IPostUserFavoriteStore<TPost, TKey> :
    IPostStore<TPost, TKey>
    where TPost : class
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 用户收藏指定文章
    /// </summary>
    /// <param name="postId">要收藏的文章ID</param>
    /// <param name="userId">执行收藏操作的用户ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会添加用户与文章的收藏关联关系。
    /// 如果用户已收藏该文章，则忽略操作。
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.FavoritePostAsync(postId, userId);
    /// </code>
    /// </para>
    /// </remarks>
    Task FavoritePostAsync(
        TKey postId,
        TKey userId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 用户取消收藏指定文章
    /// </summary>
    /// <param name="postId">要取消收藏的文章ID</param>
    /// <param name="userId">执行取消收藏操作的用户ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会移除用户与文章的收藏关联关系。
    /// 如果用户未收藏该文章，则忽略操作。
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.UnfavoritePostAsync(postId, userId);
    /// </code>
    /// </para>
    /// </remarks>
    Task UnfavoritePostAsync(
        TKey postId,
        TKey userId,
        CancellationToken cancellationToken = default);
}