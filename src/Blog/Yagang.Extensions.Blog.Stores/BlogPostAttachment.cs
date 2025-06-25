namespace Yagang.Extensions.Blog.Stores;

/// <summary>
/// 表示博客表与附件表之间的关联。
/// </summary>
public class BlogPostAttachment<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 获取或设置与附件关联的博客的主键。
    /// </summary>
    public virtual required TKey BlogId { get; set; }

    /// <summary>
    /// 获取或设置与博客关联的附件的主键。
    /// </summary>
    public virtual required TKey AttachmentId { get; set; }
}
