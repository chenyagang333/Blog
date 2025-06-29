namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 表示博客表与分享该博客的用户之间的关联。
/// </summary>
/// <typeparam name="TKey"></typeparam>
public class BlogPostUserShare<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 获取或设置与分享该博客的用户关联的博客的主键。
    /// </summary>
    public virtual required TKey BlogId { get; set; }

    /// <summary>
    /// 获取或设置与博客关联的分享该博客的用户主键。
    /// </summary>
    public virtual required TKey UserId { get; set; }

    /// <summary>
    /// 关联的创建时间
    /// </summary>
    public virtual DateTimeOffset CreatedAt { get; set; }
}
