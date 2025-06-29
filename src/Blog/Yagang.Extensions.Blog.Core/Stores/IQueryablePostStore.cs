namespace Yagang.AspNetCore.Blog;

public interface IQueryablePostStore<TPost, TKey> : 
    IPostStore<TPost,TKey> 
    where TPost : class
    where TKey : IEquatable<TKey>
{
    IQueryable<TPost> Posts { get; }
}
