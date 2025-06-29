namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客文章附件存储接口
/// </summary>
/// <typeparam name="TPost">博客文章实体类型</typeparam>
/// <typeparam name="TKey">主键类型，必须实现 <see cref="IEquatable{TKey}"/> 接口</typeparam>
/// <remarks>
/// 此接口定义了博客文章与附件的关联关系管理操作，
/// 支持单个和批量添加/移除附件，以及完全覆盖附件集合。
/// </remarks>
public interface IPostAttachmentStore<TPost, TKey> :
    IPostStore<TPost, TKey>
    where TPost : class
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 将文章关联到单个指定附件
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="attachmentId">要关联的附件ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// 此方法会添加文章与单个附件的关联关系，不影响文章原有的其他附件
    /// </remarks>
    Task AddAttachmentAsync(
        TPost post,
        TKey attachmentId,
        CancellationToken cancellationToken);

    /// <summary>
    /// 将文章关联到多个指定附件
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="attachmentIds">要关联的附件ID集合</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会批量添加文章与多个附件的关联关系，
    /// 不影响文章原有的其他附件
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.AddAttachmentAsync(post, new[] { imageId, docId });
    /// </code>
    /// </para>
    /// </remarks>
    Task AddAttachmentAsync(
        TPost post,
        IEnumerable<TKey> attachmentIds,
        CancellationToken cancellationToken);

    /// <summary>
    /// 将文章从单个指定附件中解除关联
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="attachmentId">要解除关联的附件ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// 此方法仅解除指定的单个附件关联，不影响文章的其他附件
    /// </remarks>
    Task RemoveAttachmentAsync(
        TPost post,
        TKey attachmentId,
        CancellationToken cancellationToken);

    /// <summary>
    /// 将文章从多个指定附件中解除关联
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="attachmentIds">要解除关联的附件ID集合</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会批量解除文章与多个附件的关联关系，
    /// 不影响文章的其他附件
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.RemoveAttachmentAsync(post, new[] { oldAttachmentId });
    /// </code>
    /// </para>
    /// </remarks>
    Task RemoveAttachmentAsync(
        TPost post,
        IEnumerable<TKey> attachmentIds,
        CancellationToken cancellationToken);

    /// <summary>
    /// 批量设置文章的附件（完全覆盖原有附件）
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="attachmentIds">新的附件ID集合</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会执行原子操作：
    /// 1. 清除文章原有的所有附件关联
    /// 2. 添加新的附件关联集合
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.SetAttachmentsAsync(post, new[] { imageId, videoId });
    /// </code>
    /// </para>
    /// <para>
    /// 注意：此操作会完全替换原有附件关联，请谨慎使用
    /// </para>
    /// </remarks>
    Task SetAttachmentsAsync(
        TPost post,
        IEnumerable<TKey> attachmentIds,
        CancellationToken cancellationToken);
}