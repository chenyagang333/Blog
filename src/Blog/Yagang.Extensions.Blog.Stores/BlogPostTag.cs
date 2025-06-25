namespace Yagang.Extensions.Blog.Stores;

/// <summary>
/// 表示博客表与 标签/话题 表之间的关联。
/// </summary>
public class BlogPostTag<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 获取或设置与 标签/话题 关联的博客的主键。
    /// </summary>
    public virtual required TKey BlogId { get; set; }

    /// <summary>
    /// 获取或设置与博客关联的 标签/话题 的主键。
    /// </summary>
    public virtual required TKey TagId { get; set; }
}
