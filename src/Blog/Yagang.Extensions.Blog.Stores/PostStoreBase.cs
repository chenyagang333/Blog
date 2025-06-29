namespace Yagang.AspNetCore.Blog;

public abstract class PostStoreBase<TPost,TKey>
    where TPost : BlogPost<TKey>
    where TKey : IEquatable<TKey>
{

}
