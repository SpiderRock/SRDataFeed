using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct MessageType : IEquatable<MessageType>
    {
		private static readonly bool[] isAdmin;
		private static readonly bool[] isCore;
        private static readonly bool[] isKnown;
		private static readonly string[] names;

        private static IEnumerable<MessageType> FilterMessageTypes(bool[] filter)
        {
            for (MessageType i = Lowest; i <= Highest; i++)
            {
                if (filter[i]) yield return i;
            }
        }

		static MessageType()
		{
			isCore = CreateIsCoreTestVector();
			isAdmin = CreateIsAdminTestVector();

		    var core = FilterMessageTypes(isCore).ToArray();
			var admin = FilterMessageTypes(isAdmin).ToArray();

		    isKnown = CreateSizedArray<bool>();
            foreach (var messageType in core.Union(admin))
		    {
		        isKnown[messageType] = true;
		    }

		    names = CreateNamesVector();
		}		

        private readonly ushort value;

        public MessageType(ushort value)
        {
            this.value = value;
        }

        #region dictionary friendliness

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(MessageType other)
        {
            return value == other.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is MessageType && Equals((MessageType) obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
		
		#endregion

        public static T[] CreateSizedArray<T>(Func<MessageType, T> factory = null)
        {
            var arr = new T[Max + 1];
            if (factory == null) return arr;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = factory(i);
            }
            return arr;
        }

        public bool IsAdmin
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return value < isAdmin.Length && isAdmin[value];
            }
        }

        public bool IsCore
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return value < isCore.Length && isCore[value];
            }
        }

        public bool IsKnown
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return value < isKnown.Length && isKnown[value];
            }
        }       

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return IsKnown ? names[value] : "Unknown";
        }

		#region overloaded comparison operators
	
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(MessageType left, MessageType right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(MessageType left, MessageType right)
        {
            return !left.Equals(right);
        }

        #endregion

		#region overloaded relational operators
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >(MessageType left, MessageType right)
        {
            return left.value.CompareTo(right.value) > 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >=(MessageType left, MessageType right)
        {
            return left.value.CompareTo(right.value) >= 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <(MessageType left, MessageType right)
        {
            return left.value.CompareTo(right.value) < 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <=(MessageType left, MessageType right)
        {
            return left.value.CompareTo(right.value) <= 0;
        }
		
		#endregion

		#region overloaded arithmetic operators
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MessageType operator ++(MessageType messageType)
        {
            return messageType.value + 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MessageType operator --(MessageType messageType)
        {
            return messageType.value - 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MessageType operator +(MessageType left, MessageType right)
        {
            return left.value + right.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MessageType operator -(MessageType left, MessageType right)
        {
            return left.value - right.value;
        }       
		
		#endregion
		
		#region overloaded cast operators
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(MessageType value)
        {
            return value.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort(MessageType messageType)
        {
            return messageType.value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator MessageType(int value)
        {
            return new MessageType((ushort)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator MessageType(ushort value)
        {
            return new MessageType(value);
        }
		
		#endregion
    }
} // namespace
