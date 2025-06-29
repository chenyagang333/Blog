namespace Yagang.AspNetCore.Blog;

/// <summary>
/// 分页查询参数基类
/// </summary>
/// <remarks>
/// 包含所有分页相关的通用参数
/// </remarks>
public class PaginationParams
{
    /// <summary>
    /// 页码（从1开始）
    /// </summary>
    public int PageIndex { get; set; } = 1;

    /// <summary>
    /// 每页记录数
    /// </summary>
    public int PageSize { get; set; } = 20;

    /// <summary>
    /// 是否降序排列（默认：true）
    /// </summary>
    public bool IsDescending { get; set; } = true;
}