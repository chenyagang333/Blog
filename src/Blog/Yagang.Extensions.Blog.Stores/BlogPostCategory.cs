namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 表示博客表与分类表之间的关联。
/// </summary>
public class BlogPostCategory<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 获取或设置与分类关联的博客的主键。
    /// </summary>
    public virtual required TKey BlogId { get; set; }

    /// <summary>
    /// 获取或设置与博客关联的分类的主键。
    /// </summary>
    public virtual required TKey CategoryId { get; set; }
}
