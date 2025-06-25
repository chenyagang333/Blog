namespace Yagang.Extensions.Blog.Stores;

/// <summary>
/// 博客分类表
/// </summary>
/// <typeparam name="TKey"></typeparam>
public class BlogCategory<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 主键
    /// </summary>
    public virtual required TKey Id { get; set; }

    /// <summary>
    /// 分类名称
    /// </summary>
    public virtual required string Name { get; set; }

    /// <summary>
    /// 分类的创建时间
    /// </summary>
    public virtual DateTimeOffset CreatedAt { get; set; }
}
