namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客状态枚举
/// </summary>
public enum BlogPostStatus : byte
{
    /// <summary>
    /// 草稿状态，未发布
    /// </summary>
    Draft,
    /// <summary>
    /// 已发布状态，博客已经公开可见
    /// </summary>
    Published,
    /// <summary>
    /// 已删除状态，博客已经被删除
    /// </summary>
    Deleted
}