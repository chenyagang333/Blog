namespace Yagang.Extensions.Blog.Stores;

/// <summary>
/// 博客附件表
/// </summary>
/// <typeparam name="TKey"></typeparam>
public class BlogAttachment<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// 博客附件表主键
    /// </summary>
    public virtual required TKey Id { get; set; }

    /// <summary>
    /// 用户上传的原始文件名（没有路径）
    /// </summary>
    public virtual required string Name { get; set; }

    /// <summary>
    /// 附件大小（尺寸为字节）
    /// </summary>
    public virtual required string SizeInBytes { get; set; }

    /// <summary>
    /// 附件内容的散列值（SHA256）
    /// </summary>
    /// <remarks>
    /// 两个文件的大小和散列值（SHA256）都相同的概率非常小。
    /// 因此只要文件大小和SHA256相同，则认为是相同的文件。
    /// SHA256的碰撞概率比MD5小很多
    /// </remarks>
    public virtual required string SHA256Hash { get; set; }

    /// <summary>
    /// 附件的相对存储路径
    /// </summary>
    public virtual required Uri RelativeUri { get; set; }

    /// <summary>
    /// 附件的创建时间
    /// </summary>
    public virtual DateTimeOffset CreatedAt { get; set; }
}
