namespace SpiderRock.SpiderStream.Mbus.Layouts;

internal interface IKeyLayoutEquatable<TKeyLayout> where TKeyLayout : struct
{
    bool Equals(ref TKeyLayout other);
}
