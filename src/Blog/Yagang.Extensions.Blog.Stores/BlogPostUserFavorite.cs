namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 表示博客表与收藏⭐该博客的用户之间的关联。
/// </summary>
/// <typeparam name="TKey"></typeparam>
public class BlogPostUserFavorite<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 获取或设置与用户收藏关联的博客的主键。
    /// </summary>
    public virtual required TKey BlogId { get; set; }

    /// <summary>
    /// 获取或设置与博客关联的用户收藏的主键。
    /// </summary>
    public virtual required TKey UserId { get; set; }

    /// <summary>
    /// 关联的创建时间
    /// </summary>
    public virtual DateTimeOffset CreatedAt { get; set; }
}
