namespace Yagang.Extensions.Blog.Stores;

public class OrderedEntityBase(string name, ushort sortOrder)
    : OrderedEntityBase<ushort>(name, sortOrder)
{
}

public class OrderedEntityBase<TSortOrder>(string name, TSortOrder sortOrder)
{
    public string Name { get; set; } = name;
    public TSortOrder SortOrder { get; set; } = sortOrder;
}