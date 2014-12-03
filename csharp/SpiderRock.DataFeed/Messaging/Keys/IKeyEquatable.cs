namespace SpiderRock.DataFeed.Messaging.Keys
{
    internal interface IKeyEquatable<TKey> where TKey : struct 
    {
        bool Equals(ref TKey other);
    }
}