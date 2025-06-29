namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 博客文章摘要信息（包含核心内容及互动统计）
/// </summary>
/// <typeparam name="TPost">博客文章实体类型</typeparam>
/// <typeparam name="TCategory">文章分类类型</typeparam>
/// <typeparam name="TTag">文章标签类型</typeparam>
/// <typeparam name="TAttachment">文章附件类型</typeparam>
/// <param name="Post">博客文章主体</param>
/// <param name="Categories">关联的分类列表</param>
/// <param name="Tags">关联的标签列表</param>
/// <param name="Attachments">关联的附件列表</param>
/// <param name="Statistics">文章互动统计数据</param>
public record BlogPostSummary<TPost, TCategory, TTag, TAttachment>(
    TPost Post,
    IReadOnlyList<TCategory> Categories,
    IReadOnlyList<TTag> Tags,
    IReadOnlyList<TAttachment> Attachments,
    PostStatistics Statistics
);

/// <summary>
/// 博客文章互动统计数据
/// </summary>
/// <param name="ViewCount">浏览👁次数</param>
/// <param name="LikeCount">点赞👍次数</param>
/// <param name="CommentCount">评论次数</param>
/// <param name="FavoriteCount">收藏⭐次数</param>
/// <param name="ShareCount">分享次数</param>
public record PostStatistics(
    int ViewCount = 0,
    int LikeCount = 0,
    int CommentCount = 0,
    int FavoriteCount = 0,
    int ShareCount = 0
)
{
    /// <summary>
    /// 总互动量（点赞+收藏+分享）
    /// </summary>
    public int TotalInteractions => LikeCount + CommentCount + FavoriteCount + ShareCount;

    /// <summary>
    /// 互动率 = 互动量/浏览量
    /// </summary>
    public double EngagementRate =>
        TotalInteractions / Math.Max(1, (double)ViewCount);
}

