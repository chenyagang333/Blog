namespace Yagang.Extensions.Blog.Stores;

public abstract class PostStoreBase<TPost,TKey>

    where TPost : BlogPost<TKey>
    where TKey : IEquatable<TKey>
{

}
