namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客文章排序方式
/// </summary>
public enum BlogPostSortOrder
{
    /// <summary>
    /// 最新优先（按发布时间降序）
    /// <para>默认排序方式，优先展示最新发布的内容</para>
    /// </summary>
    Newest,

    /// <summary>
    /// 最热优先（按综合热度降序）
    /// <para>热度 = (点赞数 × 2) + 收藏数 + 评论数 + (浏览量 × 0.1)</para>
    /// </summary>
    MostPopular,

    /// <summary>
    /// 最多评论（按评论数降序）
    /// <para>优先展示讨论度最高的文章</para>
    /// </summary>
    MostCommented,

    /// <summary>
    /// 最多浏览（按浏览量降序）
    /// <para>优先展示阅读量最高的文章</para>
    /// </summary>
    MostViewed,

    /// <summary>
    /// 最多收藏（按收藏数降序）
    /// <para>优先展示被用户收藏最多的文章</para>
    /// </summary>
    MostFavorited
}