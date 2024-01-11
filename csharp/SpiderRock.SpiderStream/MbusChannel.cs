using System;
using System.Collections.Generic;
using System.Net;
namespace SpiderRock.SpiderStream;

public static partial class MbusChannel
{
    static readonly Dictionary<string, RegisteredIPEndPoint> Registered = new();

    class RegisteredIPEndPoint : IPEndPoint
    {
        readonly string name;

        public static IPEndPoint Create(SysEnvironment sysEnvironment, int channelNumber, string name)
        {
            int envNumber = 20 + (int)sysEnvironment;

            IPEndPoint ep = new(
                new IPAddress(
                    sysEnvironment switch
                    {
                        SysEnvironment.Saturn => new byte[] { 233, 117, 185, (byte)channelNumber },
                        _ => new byte[] { 239, 12, (byte)envNumber, (byte)channelNumber }
                    }),
                22000 + envNumber * 250 + channelNumber);

            return new RegisteredIPEndPoint(ep, name);
        }

        public RegisteredIPEndPoint(IPEndPoint ipEndPoint, string name)
            : base(ipEndPoint.Address, ipEndPoint.Port)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            this.name = name;

            Registered[this.name.ToLowerInvariant()] = this;
        }

        public override string ToString() => $"{name}[{base.ToString()}]";
    }

    public static IPEndPoint FromName(string name) => Registered.TryGetValue(name.ToLowerInvariant(), out var ep)
        ? ep
        : throw new ArgumentException($"Unknown channel {name}");
}
