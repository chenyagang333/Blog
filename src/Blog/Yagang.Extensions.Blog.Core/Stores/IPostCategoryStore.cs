namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客文章分类存储接口
/// </summary>
/// <typeparam name="TPost">博客文章实体类型</typeparam>
/// <typeparam name="TKey">主键类型，必须实现 <see cref="IEquatable{TKey}"/> 接口</typeparam>
/// <remarks>
/// 此接口定义了博客文章与分类的关联关系管理操作，
/// 支持单个和批量添加/移除分类，以及完全覆盖分类集合。
/// </remarks>
public interface IPostCategoryStore<TPost, TKey> :
    IPostStore<TPost, TKey>
    where TPost : class
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 将文章添加到单个指定分类
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="categoryId">要添加的分类ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// 此方法会添加文章与单个分类的关联关系，不影响文章原有的其他分类
    /// </remarks>
    Task AddToCategoryAsync(
        TPost post,
        TKey categoryId,
        CancellationToken cancellationToken);

    /// <summary>
    /// 将文章添加到多个指定分类
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="categoryIds">要添加的分类ID集合</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会批量添加文章与多个分类的关联关系，
    /// 不影响文章原有的其他分类
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.AddToCategoryAsync(post, new[] { techId, programmingId });
    /// </code>
    /// </para>
    /// </remarks>
    Task AddToCategoryAsync(
        TPost post,
        IEnumerable<TKey> categoryIds,
        CancellationToken cancellationToken);

    /// <summary>
    /// 将文章从单个指定分类中移除
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="categoryId">要移除的分类ID</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// 此方法仅移除指定的单个分类关联，不影响文章的其他分类
    /// </remarks>
    Task RemoveFromCategoryAsync(
        TPost post,
        TKey categoryId,
        CancellationToken cancellationToken);

    /// <summary>
    /// 将文章从多个指定分类中移除
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="categoryIds">要移除的分类ID集合</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会批量移除文章与多个分类的关联关系，
    /// 不影响文章的其他分类
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.RemoveFromCategoryAsync(post, new[] { oldCategoryId });
    /// </code>
    /// </para>
    /// </remarks>
    Task RemoveFromCategoryAsync(
        TPost post,
        IEnumerable<TKey> categoryIds,
        CancellationToken cancellationToken);

    /// <summary>
    /// 批量设置文章的分类（完全覆盖原有分类）
    /// </summary>
    /// <param name="post">要操作的博客文章</param>
    /// <param name="categoryIds">新的分类ID集合</param>
    /// <param name="cancellationToken">取消操作令牌</param>
    /// <returns>表示异步操作的任务</returns>
    /// <remarks>
    /// <para>
    /// 此方法会执行原子操作：
    /// 1. 清除文章原有的所有分类关联
    /// 2. 添加新的分类关联集合
    /// </para>
    /// <para>
    /// 示例：
    /// <code>
    /// await store.SetCategoriesAsync(post, new[] { techId, dotnetId });
    /// </code>
    /// </para>
    /// <para>
    /// 注意：此操作会完全替换原有分类，请谨慎使用
    /// </para>
    /// </remarks>
    Task SetCategoriesAsync(
        TPost post,
        IEnumerable<TKey> categoryIds,
        CancellationToken cancellationToken);
}