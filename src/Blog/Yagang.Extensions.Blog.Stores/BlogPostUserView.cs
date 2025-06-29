namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 表示博客表与浏览该👁博客的用户之间的关联。
/// </summary>
/// <typeparam name="TKey"></typeparam>
public class BlogPostUserView<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 获取或设置与用户浏览关联的博客的主键。
    /// </summary>
    public virtual required TKey BlogId { get; set; }

    /// <summary>
    /// 获取或设置与博客关联的用户浏览的主键。
    /// </summary>
    public virtual required TKey UserId { get; set; }

    /// <summary>
    /// 关联的创建时间
    /// </summary>
    public virtual DateTimeOffset CreatedAt { get; set; }
}
