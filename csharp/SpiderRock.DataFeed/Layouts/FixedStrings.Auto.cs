// ------------------------------------------------------------------------------------------------------------------------------
//
// Machine generated.  Do not edit directly.
//
// Copyright 2014, SpiderRock Technology
//
// ------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpiderRock.DataFeed.Layouts
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	internal unsafe struct FixedString16Layout : IEquatable<FixedString16Layout>, IComparable<FixedString16Layout>, IEquatable<string>
	{
		public fixed byte chars[16];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return Value;
		}
		
		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					{
						for (int i = 0; i < 16; i++) 
						{
							if (charsPtr[i] == 0) return i;
						}
						return 16;
					}
				}
			}
		}
		
		public int MaxLength { get { return 16; } }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
        }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(FixedString16Layout other)
		{
			fixed (FixedString16Layout* pfself = &this)
			{
				/* -------------- compare as ints ------------ */
				var pIntSelf = (int*) pfself;
				var pIntOther = (int*) &other;
				for (int i = 0; i < 4; i++)
				{
					if (*(pIntSelf++) == *(pIntOther++)) continue;
					return false;
				}
 				return true;

			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(string value)
		{
			unchecked
			{
				fixed (byte* charsPtr = chars)
				fixed (char* valuePtr = value)
				{
					int i = 0;
					while (i < 16) 
					{
						byte mine = charsPtr[i]; 
						byte theirs = (byte) valuePtr[i];
						if (mine != theirs) return false;
						if (mine == 0 || theirs == 0) break;
						++i;
					}
					return i == value.Length;
				}
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(FixedString16Layout other)
        {
			unchecked
			{
				fixed (byte* pfchars = chars)
				{
					var pother = (byte*) &other;
					for (int i = 0; i < 16; i++)
					{
						int result = *(pfchars + i) - *(pother + i);
						if (result == 0) continue;
						return result;
					}
					return 0;
				}
			}
        }

	    public string Value
	    {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
	        get
			{
				fixed (byte* charsPtr = chars)
				{
					int length = Length;
					return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
				}
			}
			
	        [MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					fixed (char* valuePtr = value)
					{
						char* pstr = valuePtr;
						byte* pchars = charsPtr;
						
						if (value.Length >= 16)
						{
							for (int i = 0; i < 16; i++) { *(pchars++) = (byte) *(pstr++); }
						}
						else
						{
							while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
							*pchars = 0;
						}
					}
				}
			}
	    }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void TrimEnd()
		{
			unchecked
			{
				fixed (byte* begPtr = chars)
				{
					byte* endPtr = begPtr + 15;
					
					for (int i = 0; i < 16; i++)
					{
						if (*endPtr == 32)
						{
							*(endPtr--) = 0;
							continue;
						}
						break;
					}
				}
			}
		}
		
		public override int GetHashCode()
		{
			fixed (FixedString16Layout* pfself = &this)
			{
				int hashCode = 37;
				/* -------------- hash as ints ------------ */
				var pIntSelf = (int*) pfself;
				for (int i = 0; i < 4; i++)
				{
					hashCode = (hashCode*397) ^ *(pIntSelf++);
				}

				return hashCode;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator string(FixedString16Layout value)
		{
			return value.Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator FixedString16Layout(string value)
		{
			var r = new FixedString16Layout();
			if (string.IsNullOrEmpty(value)) return r;
			r.Value = value;
			return r;
		}
	}
 	
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	internal unsafe struct FixedString256Layout : IEquatable<FixedString256Layout>, IComparable<FixedString256Layout>, IEquatable<string>
	{
		public fixed byte chars[256];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return Value;
		}
		
		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					{
						for (int i = 0; i < 256; i++) 
						{
							if (charsPtr[i] == 0) return i;
						}
						return 256;
					}
				}
			}
		}
		
		public int MaxLength { get { return 256; } }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
        }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(FixedString256Layout other)
		{
			fixed (FixedString256Layout* pfself = &this)
			{
				/* -------------- compare as ints ------------ */
				var pIntSelf = (int*) pfself;
				var pIntOther = (int*) &other;
				for (int i = 0; i < 64; i++)
				{
					if (*(pIntSelf++) == *(pIntOther++)) continue;
					return false;
				}
 				return true;

			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(string value)
		{
			unchecked
			{
				fixed (byte* charsPtr = chars)
				fixed (char* valuePtr = value)
				{
					int i = 0;
					while (i < 256) 
					{
						byte mine = charsPtr[i]; 
						byte theirs = (byte) valuePtr[i];
						if (mine != theirs) return false;
						if (mine == 0 || theirs == 0) break;
						++i;
					}
					return i == value.Length;
				}
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(FixedString256Layout other)
        {
			unchecked
			{
				fixed (byte* pfchars = chars)
				{
					var pother = (byte*) &other;
					for (int i = 0; i < 256; i++)
					{
						int result = *(pfchars + i) - *(pother + i);
						if (result == 0) continue;
						return result;
					}
					return 0;
				}
			}
        }

	    public string Value
	    {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
	        get
			{
				fixed (byte* charsPtr = chars)
				{
					int length = Length;
					return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
				}
			}
			
	        [MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					fixed (char* valuePtr = value)
					{
						char* pstr = valuePtr;
						byte* pchars = charsPtr;
						
						if (value.Length >= 256)
						{
							for (int i = 0; i < 256; i++) { *(pchars++) = (byte) *(pstr++); }
						}
						else
						{
							while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
							*pchars = 0;
						}
					}
				}
			}
	    }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void TrimEnd()
		{
			unchecked
			{
				fixed (byte* begPtr = chars)
				{
					byte* endPtr = begPtr + 255;
					
					for (int i = 0; i < 256; i++)
					{
						if (*endPtr == 32)
						{
							*(endPtr--) = 0;
							continue;
						}
						break;
					}
				}
			}
		}
		
		public override int GetHashCode()
		{
			fixed (FixedString256Layout* pfself = &this)
			{
				int hashCode = 37;
				/* -------------- hash as ints ------------ */
				var pIntSelf = (int*) pfself;
				for (int i = 0; i < 64; i++)
				{
					hashCode = (hashCode*397) ^ *(pIntSelf++);
				}

				return hashCode;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator string(FixedString256Layout value)
		{
			return value.Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator FixedString256Layout(string value)
		{
			var r = new FixedString256Layout();
			if (string.IsNullOrEmpty(value)) return r;
			r.Value = value;
			return r;
		}
	}
 	
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	internal unsafe struct FixedString32Layout : IEquatable<FixedString32Layout>, IComparable<FixedString32Layout>, IEquatable<string>
	{
		public fixed byte chars[32];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return Value;
		}
		
		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					{
						for (int i = 0; i < 32; i++) 
						{
							if (charsPtr[i] == 0) return i;
						}
						return 32;
					}
				}
			}
		}
		
		public int MaxLength { get { return 32; } }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
        }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(FixedString32Layout other)
		{
			fixed (FixedString32Layout* pfself = &this)
			{
				/* -------------- compare as ints ------------ */
				var pIntSelf = (int*) pfself;
				var pIntOther = (int*) &other;
				for (int i = 0; i < 8; i++)
				{
					if (*(pIntSelf++) == *(pIntOther++)) continue;
					return false;
				}
 				return true;

			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(string value)
		{
			unchecked
			{
				fixed (byte* charsPtr = chars)
				fixed (char* valuePtr = value)
				{
					int i = 0;
					while (i < 32) 
					{
						byte mine = charsPtr[i]; 
						byte theirs = (byte) valuePtr[i];
						if (mine != theirs) return false;
						if (mine == 0 || theirs == 0) break;
						++i;
					}
					return i == value.Length;
				}
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(FixedString32Layout other)
        {
			unchecked
			{
				fixed (byte* pfchars = chars)
				{
					var pother = (byte*) &other;
					for (int i = 0; i < 32; i++)
					{
						int result = *(pfchars + i) - *(pother + i);
						if (result == 0) continue;
						return result;
					}
					return 0;
				}
			}
        }

	    public string Value
	    {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
	        get
			{
				fixed (byte* charsPtr = chars)
				{
					int length = Length;
					return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
				}
			}
			
	        [MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					fixed (char* valuePtr = value)
					{
						char* pstr = valuePtr;
						byte* pchars = charsPtr;
						
						if (value.Length >= 32)
						{
							for (int i = 0; i < 32; i++) { *(pchars++) = (byte) *(pstr++); }
						}
						else
						{
							while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
							*pchars = 0;
						}
					}
				}
			}
	    }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void TrimEnd()
		{
			unchecked
			{
				fixed (byte* begPtr = chars)
				{
					byte* endPtr = begPtr + 31;
					
					for (int i = 0; i < 32; i++)
					{
						if (*endPtr == 32)
						{
							*(endPtr--) = 0;
							continue;
						}
						break;
					}
				}
			}
		}
		
		public override int GetHashCode()
		{
			fixed (FixedString32Layout* pfself = &this)
			{
				int hashCode = 37;
				/* -------------- hash as ints ------------ */
				var pIntSelf = (int*) pfself;
				for (int i = 0; i < 8; i++)
				{
					hashCode = (hashCode*397) ^ *(pIntSelf++);
				}

				return hashCode;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator string(FixedString32Layout value)
		{
			return value.Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator FixedString32Layout(string value)
		{
			var r = new FixedString32Layout();
			if (string.IsNullOrEmpty(value)) return r;
			r.Value = value;
			return r;
		}
	}
 	
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	internal unsafe struct FixedString48Layout : IEquatable<FixedString48Layout>, IComparable<FixedString48Layout>, IEquatable<string>
	{
		public fixed byte chars[48];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return Value;
		}
		
		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					{
						for (int i = 0; i < 48; i++) 
						{
							if (charsPtr[i] == 0) return i;
						}
						return 48;
					}
				}
			}
		}
		
		public int MaxLength { get { return 48; } }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
        }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(FixedString48Layout other)
		{
			fixed (FixedString48Layout* pfself = &this)
			{
				/* -------------- compare as ints ------------ */
				var pIntSelf = (int*) pfself;
				var pIntOther = (int*) &other;
				for (int i = 0; i < 12; i++)
				{
					if (*(pIntSelf++) == *(pIntOther++)) continue;
					return false;
				}
 				return true;

			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(string value)
		{
			unchecked
			{
				fixed (byte* charsPtr = chars)
				fixed (char* valuePtr = value)
				{
					int i = 0;
					while (i < 48) 
					{
						byte mine = charsPtr[i]; 
						byte theirs = (byte) valuePtr[i];
						if (mine != theirs) return false;
						if (mine == 0 || theirs == 0) break;
						++i;
					}
					return i == value.Length;
				}
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(FixedString48Layout other)
        {
			unchecked
			{
				fixed (byte* pfchars = chars)
				{
					var pother = (byte*) &other;
					for (int i = 0; i < 48; i++)
					{
						int result = *(pfchars + i) - *(pother + i);
						if (result == 0) continue;
						return result;
					}
					return 0;
				}
			}
        }

	    public string Value
	    {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
	        get
			{
				fixed (byte* charsPtr = chars)
				{
					int length = Length;
					return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
				}
			}
			
	        [MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					fixed (char* valuePtr = value)
					{
						char* pstr = valuePtr;
						byte* pchars = charsPtr;
						
						if (value.Length >= 48)
						{
							for (int i = 0; i < 48; i++) { *(pchars++) = (byte) *(pstr++); }
						}
						else
						{
							while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
							*pchars = 0;
						}
					}
				}
			}
	    }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void TrimEnd()
		{
			unchecked
			{
				fixed (byte* begPtr = chars)
				{
					byte* endPtr = begPtr + 47;
					
					for (int i = 0; i < 48; i++)
					{
						if (*endPtr == 32)
						{
							*(endPtr--) = 0;
							continue;
						}
						break;
					}
				}
			}
		}
		
		public override int GetHashCode()
		{
			fixed (FixedString48Layout* pfself = &this)
			{
				int hashCode = 37;
				/* -------------- hash as ints ------------ */
				var pIntSelf = (int*) pfself;
				for (int i = 0; i < 12; i++)
				{
					hashCode = (hashCode*397) ^ *(pIntSelf++);
				}

				return hashCode;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator string(FixedString48Layout value)
		{
			return value.Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator FixedString48Layout(string value)
		{
			var r = new FixedString48Layout();
			if (string.IsNullOrEmpty(value)) return r;
			r.Value = value;
			return r;
		}
	}
 	
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	internal unsafe struct FixedString6Layout : IEquatable<FixedString6Layout>, IComparable<FixedString6Layout>, IEquatable<string>
	{
		public fixed byte chars[6];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return Value;
		}
		
		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					{
						for (int i = 0; i < 6; i++) 
						{
							if (charsPtr[i] == 0) return i;
						}
						return 6;
					}
				}
			}
		}
		
		public int MaxLength { get { return 6; } }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
        }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(FixedString6Layout other)
		{
			fixed (FixedString6Layout* pfself = &this)
			{
				/* -------------- compare as ints ------------ */
				var pIntSelf = (int*) pfself;
				var pIntOther = (int*) &other;
				for (int i = 0; i < 1; i++)
				{
					if (*(pIntSelf++) == *(pIntOther++)) continue;
					return false;
				}
 				/* -------------- compare as bytes ------------ */
				var pByteSelf = (byte*) pIntSelf;
				var pByteOther = (byte*) pIntOther;
 		
				for (int i = 0; i < 2; i++)
				{
					if (*(pByteSelf++) == *(pByteOther++)) continue;
					return false;
				}
 				return true;

			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(string value)
		{
			unchecked
			{
				fixed (byte* charsPtr = chars)
				fixed (char* valuePtr = value)
				{
					int i = 0;
					while (i < 6) 
					{
						byte mine = charsPtr[i]; 
						byte theirs = (byte) valuePtr[i];
						if (mine != theirs) return false;
						if (mine == 0 || theirs == 0) break;
						++i;
					}
					return i == value.Length;
				}
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(FixedString6Layout other)
        {
			unchecked
			{
				fixed (byte* pfchars = chars)
				{
					var pother = (byte*) &other;
					for (int i = 0; i < 6; i++)
					{
						int result = *(pfchars + i) - *(pother + i);
						if (result == 0) continue;
						return result;
					}
					return 0;
				}
			}
        }

	    public string Value
	    {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
	        get
			{
				fixed (byte* charsPtr = chars)
				{
					int length = Length;
					return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
				}
			}
			
	        [MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					fixed (char* valuePtr = value)
					{
						char* pstr = valuePtr;
						byte* pchars = charsPtr;
						
						if (value.Length >= 6)
						{
							for (int i = 0; i < 6; i++) { *(pchars++) = (byte) *(pstr++); }
						}
						else
						{
							while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
							*pchars = 0;
						}
					}
				}
			}
	    }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void TrimEnd()
		{
			unchecked
			{
				fixed (byte* begPtr = chars)
				{
					byte* endPtr = begPtr + 5;
					
					for (int i = 0; i < 6; i++)
					{
						if (*endPtr == 32)
						{
							*(endPtr--) = 0;
							continue;
						}
						break;
					}
				}
			}
		}
		
		public override int GetHashCode()
		{
			fixed (FixedString6Layout* pfself = &this)
			{
				int hashCode = 37;
				/* -------------- hash as ints ------------ */
				var pIntSelf = (int*) pfself;
				for (int i = 0; i < 1; i++)
				{
					hashCode = (hashCode*397) ^ *(pIntSelf++);
				}
 				/* -------------- hash as bytes ------------ */
				var pByteSelf = (byte*) pIntSelf;
 		
				for (int i = 0; i < 2; i++)
				{
					hashCode = (hashCode*397) ^ *(pByteSelf++);
				}

				return hashCode;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator string(FixedString6Layout value)
		{
			return value.Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator FixedString6Layout(string value)
		{
			var r = new FixedString6Layout();
			if (string.IsNullOrEmpty(value)) return r;
			r.Value = value;
			return r;
		}
	}
 	
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
	internal unsafe struct FixedString8Layout : IEquatable<FixedString8Layout>, IComparable<FixedString8Layout>, IEquatable<string>
	{
		public fixed byte chars[8];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return Value;
		}
		
		public int Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					{
						for (int i = 0; i < 8; i++) 
						{
							if (charsPtr[i] == 0) return i;
						}
						return 8;
					}
				}
			}
		}
		
		public int MaxLength { get { return 8; } }

        public bool IsEmpty
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (byte* pfchars = chars) return *pfchars == 0; }
        }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(FixedString8Layout other)
		{
			fixed (FixedString8Layout* pfself = &this)
			{
				/* -------------- compare as ints ------------ */
				var pIntSelf = (int*) pfself;
				var pIntOther = (int*) &other;
				for (int i = 0; i < 2; i++)
				{
					if (*(pIntSelf++) == *(pIntOther++)) continue;
					return false;
				}
 				return true;

			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(string value)
		{
			unchecked
			{
				fixed (byte* charsPtr = chars)
				fixed (char* valuePtr = value)
				{
					int i = 0;
					while (i < 8) 
					{
						byte mine = charsPtr[i]; 
						byte theirs = (byte) valuePtr[i];
						if (mine != theirs) return false;
						if (mine == 0 || theirs == 0) break;
						++i;
					}
					return i == value.Length;
				}
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(FixedString8Layout other)
        {
			unchecked
			{
				fixed (byte* pfchars = chars)
				{
					var pother = (byte*) &other;
					for (int i = 0; i < 8; i++)
					{
						int result = *(pfchars + i) - *(pother + i);
						if (result == 0) continue;
						return result;
					}
					return 0;
				}
			}
        }

	    public string Value
	    {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
	        get
			{
				fixed (byte* charsPtr = chars)
				{
					int length = Length;
					return length == 0 ? string.Empty : new string((sbyte*) charsPtr, 0, Length, System.Text.Encoding.ASCII);
				}
			}
			
	        [MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				unchecked
				{
					fixed (byte* charsPtr = chars)
					fixed (char* valuePtr = value)
					{
						char* pstr = valuePtr;
						byte* pchars = charsPtr;
						
						if (value.Length >= 8)
						{
							for (int i = 0; i < 8; i++) { *(pchars++) = (byte) *(pstr++); }
						}
						else
						{
							while (*pstr != 0) { *(pchars++) = (byte) *(pstr++); }
							*pchars = 0;
						}
					}
				}
			}
	    }
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void TrimEnd()
		{
			unchecked
			{
				fixed (byte* begPtr = chars)
				{
					byte* endPtr = begPtr + 7;
					
					for (int i = 0; i < 8; i++)
					{
						if (*endPtr == 32)
						{
							*(endPtr--) = 0;
							continue;
						}
						break;
					}
				}
			}
		}
		
		public override int GetHashCode()
		{
			fixed (FixedString8Layout* pfself = &this)
			{
				int hashCode = 37;
				/* -------------- hash as ints ------------ */
				var pIntSelf = (int*) pfself;
				for (int i = 0; i < 2; i++)
				{
					hashCode = (hashCode*397) ^ *(pIntSelf++);
				}

				return hashCode;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator string(FixedString8Layout value)
		{
			return value.Value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator FixedString8Layout(string value)
		{
			var r = new FixedString8Layout();
			if (string.IsNullOrEmpty(value)) return r;
			r.Value = value;
			return r;
		}
	}

}
