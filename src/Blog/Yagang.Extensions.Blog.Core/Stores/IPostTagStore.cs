namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客文章标签存储接口
/// </summary>
/// <typeparam name="TPost">博客文章实体类型</typeparam>
/// <typeparam name="TKey">主键类型，必须实现 <see cref="IEquatable{TKey}"/> 接口</typeparam>
/// <remarks>
/// 此接口定义了博客文章与标签的关联关系管理操作，
/// 支持单个和批量添加/移除标签，以及完全覆盖标签集合。
/// </remarks>
public interface IPostTagStore<TPost, TKey> :
    IPostStore<TPost, TKey>
    where TPost : class
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 将文章添加到单个指定标签
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="tagId">要添加的标签ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// 此方法会添加文章与单个标签的关联关系，不影响文章原有的其他标签
    /// </remarks>
    Task AddToTagAsync(
        TPost post,
        TKey tagId,
        CancellationToken cancellationToken);

    /// <summary>
    /// 将文章添加到多个指定标签
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="tagIds">要添加的标签ID集合</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会批量添加文章与多个标签的关联关系，
    /// 不影响文章原有的其他标签
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.AddToTagAsync(post, new[] { techId, programmingId });
    /// </code>
    /// </para>
    /// </remarks>
    Task AddToTagAsync(
        TPost post,
        IEnumerable<TKey> tagIds,
        CancellationToken cancellationToken);

    /// <summary>
    /// 将文章从单个指定标签中移除
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="tagId">要移除的标签ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// 此方法仅移除指定的单个标签关联，不影响文章的其他标签
    /// </remarks>
    Task RemoveFromTagAsync(
        TPost post,
        TKey tagId,
        CancellationToken cancellationToken);

    /// <summary>
    /// 将文章从多个指定标签中移除
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="tagIds">要移除的标签ID集合</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会批量移除文章与多个标签的关联关系，
    /// 不影响文章的其他标签
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.RemoveFromTagAsync(post, new[] { oldTagId });
    /// </code>
    /// </para>
    /// </remarks>
    Task RemoveFromTagAsync(
        TPost post,
        IEnumerable<TKey> tagIds,
        CancellationToken cancellationToken);

    /// <summary>
    /// 批量设置文章的标签（完全覆盖原有标签）
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="tagIds">新的标签ID集合</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会执行原子操作：
    /// 1. 清除文章原有的所有标签关联
    /// 2. 添加新的标签关联集合
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.SetTagsAsync(post, new[] { techId, dotnetId });
    /// </code>
    /// </para>
    /// <para>
    /// 注意：此操作会完全替换原有标签，请谨慎使用
    /// </para>
    /// </remarks>
    Task SetTagsAsync(
        TPost post,
        IEnumerable<TKey> tagIds,
        CancellationToken cancellationToken);
}