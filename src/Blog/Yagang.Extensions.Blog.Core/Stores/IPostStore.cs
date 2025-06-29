namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客文章存储接口
/// </summary>
/// <typeparam name="TPost">博客文章实体类型</typeparam>
/// <typeparam name="TKey">主键类型，必须实现 <see cref="IEquatable{T}"/> 接口</typeparam>
/// <remarks>
/// <para>
/// 此接口定义了博客文章的核心数据访问操作，
/// 支持完整的CRUD和局部更新操作。
/// </para>
/// </remarks>
public interface IPostStore<TPost, TKey> :
    IDisposable
    where TPost : class
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 创建新的博客文章
    /// </summary>
    /// <param name="post">要创建的博客文章实体</param>
    /// <param name="cancellationToken">用于传播应取消操作的通知</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法将新文章添加到存储中，通常对应数据库的INSERT操作。
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.CreateAsync(newPost);
    /// </code>
    /// </para>
    /// </remarks>
    Task CreateAsync(TPost post, CancellationToken cancellationToken);

    /// <summary>
    /// 更新整个博客文章实体
    /// </summary>
    /// <param name="post">要更新的博客文章实体</param>
    /// <param name="cancellationToken">用于传播应取消操作的通知</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法将更新实体的所有字段，适用于完整替换场景。
    /// </para>
    /// <para>
    /// 注意：此操作会覆盖所有字段，请确保传入完整的实体数据。
    /// </para>
    /// </remarks>
    Task UpdateAsync(TPost post, CancellationToken cancellationToken);

    /// <summary>
    /// 根据主键删除单个博客文章
    /// </summary>
    /// <param name="postId">要删除的文章主键</param>
    /// <param name="cancellationToken">用于传播应取消操作的通知</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法仅需文章ID即可执行删除操作，无需加载完整实体。
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.DeleteAsync(postId);
    /// </code>
    /// </para>
    /// </remarks>
    Task DeleteAsync(TKey postId, CancellationToken cancellationToken);

    /// <summary>
    /// 批量删除多个博客文章
    /// </summary>
    /// <param name="postIds">要删除的文章主键集合</param>
    /// <param name="cancellationToken">用于传播应取消操作的通知</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法通过主键集合批量删除文章，适用于高效删除多个文章的场景。
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.DeleteAsync([id1, id2, id3]);
    /// </code>
    /// </para>
    /// <para>
    /// 实现时应使用事务确保操作的原子性。
    /// </para>
    /// </remarks>
    Task DeleteAsync(IEnumerable<TKey> postIds, CancellationToken cancellationToken);

    /// <summary>
    /// 根据主键查询单个博客文章
    /// </summary>
    /// <param name="postId">要查询的文章主键</param>
    /// <param name="cancellationToken">用于传播应取消操作的通知</param>
    /// <returns>找到的博客文章实体，如果未找到则返回 null</returns>
    /// <remarks>
    /// <para>
    /// 此方法对应数据库的SELECT操作，用于按主键检索单个文章。
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// var post = await store.FindByIdAsync(postId);
    /// </code>
    /// </para>
    /// </remarks>
    Task<TPost?> FindByIdAsync(TKey postId, CancellationToken cancellationToken);

    /// <summary>
    /// 更新博客文章的标题
    /// </summary>
    /// <param name="id">要更新的文章主键</param>
    /// <param name="title">新的文章标题</param>
    /// <param name="cancellationToken">用于传播应取消操作的通知</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法仅更新标题字段，适用于局部更新场景。
    /// </para>
    /// <para>
    /// 实现时应同时更新修改时间字段（UpdatedAt）。
    /// </para>
    /// </remarks>
    Task UpdateTitleAsync(TKey id, string title, CancellationToken cancellationToken);

    /// <summary>
    /// 更新博客文章的内容
    /// </summary>
    /// <param name="id">要更新的文章主键</param>
    /// <param name="content">新的文章内容</param>
    /// <param name="cancellationToken">用于传播应取消操作的通知</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法仅更新内容字段，适用于局部更新场景。
    /// </para>
    /// <para>
    /// 内容更新通常需要同时更新修改时间字段（UpdatedAt）。
    /// </para>
    /// </remarks>
    Task UpdateContentAsync(TKey id, string content, CancellationToken cancellationToken);

    /// <summary>
    /// 更新博客文章的状态
    /// </summary>
    /// <param name="id">要更新的文章主键</param>
    /// <param name="status">新的文章状态</param>
    /// <param name="cancellationToken">用于传播应取消操作的通知</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 状态变更可能触发其他操作：
    /// - 发布时自动设置发布时间（PublishedAt）
    /// - 删除时设置删除时间（DeletedAt）
    /// - 撤回发布时清除发布时间
    /// </para>
    /// <para>
    /// 状态定义参考：<see cref="BlogPostStatus"/>
    /// </para>
    /// </remarks>
    Task UpdateStatusAsync(TKey id, BlogPostStatus status, CancellationToken cancellationToken);

    /// <summary>
    /// 更新博客文章的类型
    /// </summary>
    /// <param name="id">要更新的文章主键</param>
    /// <param name="type">新的文章类型</param>
    /// <param name="cancellationToken">用于传播应取消操作的通知</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 类型变更可能影响内容展示方式：
    /// - 文章（Article）：标准博客文章
    /// - 视频（Video）：视频内容
    /// - 音频（Audio）：音频内容
    /// - 朋友圈（Moment）：短内容
    /// </para>
    /// <para>
    /// 类型定义参考：<see cref="BlogPostType"/>
    /// </para>
    /// </remarks>
    Task UpdateTypeAsync(TKey id, BlogPostType type, CancellationToken cancellationToken);
}