namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客类型枚举
/// </summary>
public enum BlogPostType : byte
{
    /// <summary>
    /// 文章博客
    /// </summary>
    Article = 1,
    /// <summary>
    /// 视频博客
    /// </summary>
    Video,
    /// <summary>
    /// 音频博客
    /// </summary>
    Audio,
    /// <summary>
    /// 类似于 微信朋友圈/QQ空间/微博
    /// </summary>
    Moment
}