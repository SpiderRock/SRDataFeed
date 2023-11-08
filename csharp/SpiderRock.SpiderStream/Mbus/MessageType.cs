using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.SpiderStream.Mbus;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly partial struct MessageType : IEquatable<MessageType>
{
    private class _Attributes
    {
        public ushort Type { get; set; }

        public bool IsCore { get; set; }

        public string Name { get; set; }

        public long SchemaHash { get; set; }
    }

    private static readonly _Attributes[] attributes = CreateSizedArray<_Attributes>();
    private static readonly Dictionary<string, MessageType> nameMap = new();

    static MessageType()
    {
        Initialize();

        foreach (var attr in attributes.Where(_ => _ is not null))
        {
            nameMap[attr.Name.ToLowerInvariant()] = attr.Type;
        }
    }

    private readonly ushort value;

    public MessageType(ushort value)
    {
        this.value = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Equals(MessageType other) => value == other.value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly bool Equals(object obj) => obj is MessageType messageType && Equals(messageType);

    public override readonly int GetHashCode() => value.GetHashCode();

    public static IEnumerable<MessageType> Core => attributes.Where(info => info?.IsCore ?? false).Select(info => (MessageType)info.Type);

    public static MessageType FromName(string value) => nameMap.TryGetValue(value.ToLowerInvariant(), out var messageType) ? messageType : default;

    internal static T[] CreateSizedArray<T>(Func<MessageType, T> factory = null)
    {
        var arr = new T[Max + 1];
        if (factory == null) return arr;
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = factory(i);
        }
        return arr;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static _Attributes GetAttributes(ushort value)
    {
        try
        {
            return attributes[value];
        }
        catch
        {
            return null;
        }
    }

    public readonly bool IsAdmin => !(GetAttributes(value)?.IsCore) ?? false;

    public readonly bool IsCore => GetAttributes(value)?.IsCore ?? false;

    public readonly long? SchemaHash => GetAttributes(value)?.SchemaHash ?? null;

    public override readonly string ToString() => $"{GetAttributes(value)?.Name ?? "Unknown"}({value})";

    public static bool operator ==(MessageType left, MessageType right) => left.Equals(right);

    public static bool operator !=(MessageType left, MessageType right) => !left.Equals(right);

    public static implicit operator int(MessageType messageType) => messageType.value;

    public static implicit operator ushort(MessageType messageType) => messageType.value;

    public static implicit operator MessageType(int value) => new((ushort)value);

    public static implicit operator MessageType(ushort value) => new(value);
}
