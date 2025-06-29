namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客表
/// </summary>
/// <typeparam name="TKey">主键类型</typeparam>
public class BlogPost<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 主键
    /// </summary>
    public virtual required TKey Id { get; set; }

    /// <summary>
    /// 博客标题
    /// </summary>
    public virtual string? Title { get; set; }

    /// <summary>
    /// 博客内容
    /// </summary>
    public virtual required string Content { get; set; }

    /// <summary>
    /// 发表这篇博客的用户主键
    /// </summary>
    public virtual required TKey UserId { get; set; }

    /// <summary>
    /// 博客的类型
    /// </summary>
    public virtual BlogPostType Type { get; set; }

    /// <summary>
    /// 博客的状态
    /// </summary>
    public virtual BlogPostStatus Status { get; set; }

    /// <summary>
    /// 博客的创建时间
    /// </summary>
    public virtual DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// 博客的最后更新时间
    /// </summary>
    public virtual DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    /// 博客的发布时间
    /// </summary>
    public virtual DateTimeOffset? PublishedAt { get; set; }
}






