﻿#if !UNITY
using System;
using System.Reflection;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{
    // Layout: [fixedElementSize]
    // Layout: [hasValue:1][fixedElementSize]


    [Preserve(AllMembers = true)]
    internal class Int16EnumFormatter<T> : Formatter<T>
    {
        static Int16 Identity(Int16 x) { return x; }

        readonly Func<Int16, T> deserializeCast;
        readonly Func<T, Int16> serializeCast;

        [Preserve]
        public Int16EnumFormatter()
        {
            Func<Int16, Int16> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, Int16>)) as Func<T, Int16>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<Int16, T>)) as Func<Int16, T>;
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteInt16(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            return deserializeCast(BinaryUtil.ReadInt16(ref bytes, offset));
        }
    }

    [Preserve(AllMembers = true)]
    internal class NullableInt16EnumFormatter<T> : Formatter<T?>
        where T : struct
    {
        static Int16 Identity(Int16 x) { return x; }

        readonly Func<Int16, T> deserializeCast;
        readonly Func<T, Int16> serializeCast;

        [Preserve]
        public NullableInt16EnumFormatter()
        {
            Func<Int16, Int16> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, Int16>)) as Func<T, Int16>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<Int16, T>)) as Func<Int16, T>;
        }

        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, T? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt16(ref bytes, offset + 1, serializeCast(value.Value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 3);
            }

            return 3;
        }

        public override T? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 3;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return deserializeCast(BinaryUtil.ReadInt16(ref bytes, offset + 1));
        }
    }


    [Preserve(AllMembers = true)]
    internal class Int32EnumFormatter<T> : Formatter<T>
    {
        static Int32 Identity(Int32 x) { return x; }

        readonly Func<Int32, T> deserializeCast;
        readonly Func<T, Int32> serializeCast;

        [Preserve]
        public Int32EnumFormatter()
        {
            Func<Int32, Int32> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, Int32>)) as Func<T, Int32>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<Int32, T>)) as Func<Int32, T>;
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return deserializeCast(BinaryUtil.ReadInt32(ref bytes, offset));
        }
    }

    [Preserve(AllMembers = true)]
    internal class NullableInt32EnumFormatter<T> : Formatter<T?>
        where T : struct
    {
        static Int32 Identity(Int32 x) { return x; }

        readonly Func<Int32, T> deserializeCast;
        readonly Func<T, Int32> serializeCast;

        [Preserve]
        public NullableInt32EnumFormatter()
        {
            Func<Int32, Int32> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, Int32>)) as Func<T, Int32>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<Int32, T>)) as Func<Int32, T>;
        }

        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, T? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, serializeCast(value.Value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override T? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return deserializeCast(BinaryUtil.ReadInt32(ref bytes, offset + 1));
        }
    }


    [Preserve(AllMembers = true)]
    internal class Int64EnumFormatter<T> : Formatter<T>
    {
        static Int64 Identity(Int64 x) { return x; }

        readonly Func<Int64, T> deserializeCast;
        readonly Func<T, Int64> serializeCast;

        [Preserve]
        public Int64EnumFormatter()
        {
            Func<Int64, Int64> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, Int64>)) as Func<T, Int64>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<Int64, T>)) as Func<Int64, T>;
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteInt64(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 8;
            return deserializeCast(BinaryUtil.ReadInt64(ref bytes, offset));
        }
    }

    [Preserve(AllMembers = true)]
    internal class NullableInt64EnumFormatter<T> : Formatter<T?>
        where T : struct
    {
        static Int64 Identity(Int64 x) { return x; }

        readonly Func<Int64, T> deserializeCast;
        readonly Func<T, Int64> serializeCast;

        [Preserve]
        public NullableInt64EnumFormatter()
        {
            Func<Int64, Int64> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, Int64>)) as Func<T, Int64>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<Int64, T>)) as Func<Int64, T>;
        }

        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, T? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt64(ref bytes, offset + 1, serializeCast(value.Value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 9);
            }

            return 9;
        }

        public override T? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 9;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return deserializeCast(BinaryUtil.ReadInt64(ref bytes, offset + 1));
        }
    }


    [Preserve(AllMembers = true)]
    internal class UInt16EnumFormatter<T> : Formatter<T>
    {
        static UInt16 Identity(UInt16 x) { return x; }

        readonly Func<UInt16, T> deserializeCast;
        readonly Func<T, UInt16> serializeCast;

        [Preserve]
        public UInt16EnumFormatter()
        {
            Func<UInt16, UInt16> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, UInt16>)) as Func<T, UInt16>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<UInt16, T>)) as Func<UInt16, T>;
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteUInt16(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            return deserializeCast(BinaryUtil.ReadUInt16(ref bytes, offset));
        }
    }

    [Preserve(AllMembers = true)]
    internal class NullableUInt16EnumFormatter<T> : Formatter<T?>
        where T : struct
    {
        static UInt16 Identity(UInt16 x) { return x; }

        readonly Func<UInt16, T> deserializeCast;
        readonly Func<T, UInt16> serializeCast;

        [Preserve]
        public NullableUInt16EnumFormatter()
        {
            Func<UInt16, UInt16> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, UInt16>)) as Func<T, UInt16>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<UInt16, T>)) as Func<UInt16, T>;
        }

        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, T? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteUInt16(ref bytes, offset + 1, serializeCast(value.Value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 3);
            }

            return 3;
        }

        public override T? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 3;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return deserializeCast(BinaryUtil.ReadUInt16(ref bytes, offset + 1));
        }
    }


    [Preserve(AllMembers = true)]
    internal class UInt32EnumFormatter<T> : Formatter<T>
    {
        static UInt32 Identity(UInt32 x) { return x; }

        readonly Func<UInt32, T> deserializeCast;
        readonly Func<T, UInt32> serializeCast;

        [Preserve]
        public UInt32EnumFormatter()
        {
            Func<UInt32, UInt32> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, UInt32>)) as Func<T, UInt32>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<UInt32, T>)) as Func<UInt32, T>;
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteUInt32(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return deserializeCast(BinaryUtil.ReadUInt32(ref bytes, offset));
        }
    }

    [Preserve(AllMembers = true)]
    internal class NullableUInt32EnumFormatter<T> : Formatter<T?>
        where T : struct
    {
        static UInt32 Identity(UInt32 x) { return x; }

        readonly Func<UInt32, T> deserializeCast;
        readonly Func<T, UInt32> serializeCast;

        [Preserve]
        public NullableUInt32EnumFormatter()
        {
            Func<UInt32, UInt32> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, UInt32>)) as Func<T, UInt32>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<UInt32, T>)) as Func<UInt32, T>;
        }

        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, T? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteUInt32(ref bytes, offset + 1, serializeCast(value.Value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override T? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return deserializeCast(BinaryUtil.ReadUInt32(ref bytes, offset + 1));
        }
    }


    [Preserve(AllMembers = true)]
    internal class UInt64EnumFormatter<T> : Formatter<T>
    {
        static UInt64 Identity(UInt64 x) { return x; }

        readonly Func<UInt64, T> deserializeCast;
        readonly Func<T, UInt64> serializeCast;

        [Preserve]
        public UInt64EnumFormatter()
        {
            Func<UInt64, UInt64> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, UInt64>)) as Func<T, UInt64>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<UInt64, T>)) as Func<UInt64, T>;
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteUInt64(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 8;
            return deserializeCast(BinaryUtil.ReadUInt64(ref bytes, offset));
        }
    }

    [Preserve(AllMembers = true)]
    internal class NullableUInt64EnumFormatter<T> : Formatter<T?>
        where T : struct
    {
        static UInt64 Identity(UInt64 x) { return x; }

        readonly Func<UInt64, T> deserializeCast;
        readonly Func<T, UInt64> serializeCast;

        [Preserve]
        public NullableUInt64EnumFormatter()
        {
            Func<UInt64, UInt64> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, UInt64>)) as Func<T, UInt64>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<UInt64, T>)) as Func<UInt64, T>;
        }

        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, T? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteUInt64(ref bytes, offset + 1, serializeCast(value.Value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 9);
            }

            return 9;
        }

        public override T? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 9;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return deserializeCast(BinaryUtil.ReadUInt64(ref bytes, offset + 1));
        }
    }


    [Preserve(AllMembers = true)]
    internal class ByteEnumFormatter<T> : Formatter<T>
    {
        static Byte Identity(Byte x) { return x; }

        readonly Func<Byte, T> deserializeCast;
        readonly Func<T, Byte> serializeCast;

        [Preserve]
        public ByteEnumFormatter()
        {
            Func<Byte, Byte> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, Byte>)) as Func<T, Byte>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<Byte, T>)) as Func<Byte, T>;
        }

        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return deserializeCast(BinaryUtil.ReadByte(ref bytes, offset));
        }
    }

    [Preserve(AllMembers = true)]
    internal class NullableByteEnumFormatter<T> : Formatter<T?>
        where T : struct
    {
        static Byte Identity(Byte x) { return x; }

        readonly Func<Byte, T> deserializeCast;
        readonly Func<T, Byte> serializeCast;

        [Preserve]
        public NullableByteEnumFormatter()
        {
            Func<Byte, Byte> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, Byte>)) as Func<T, Byte>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<Byte, T>)) as Func<Byte, T>;
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, T? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, serializeCast(value.Value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override T? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return deserializeCast(BinaryUtil.ReadByte(ref bytes, offset + 1));
        }
    }


    [Preserve(AllMembers = true)]
    internal class SByteEnumFormatter<T> : Formatter<T>
    {
        static SByte Identity(SByte x) { return x; }

        readonly Func<SByte, T> deserializeCast;
        readonly Func<T, SByte> serializeCast;

        [Preserve]
        public SByteEnumFormatter()
        {
            Func<SByte, SByte> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, SByte>)) as Func<T, SByte>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<SByte, T>)) as Func<SByte, T>;
        }

        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, T value)
        {
            return BinaryUtil.WriteSByte(ref bytes, offset, serializeCast(value));
        }

        public override T Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return deserializeCast(BinaryUtil.ReadSByte(ref bytes, offset));
        }
    }

    [Preserve(AllMembers = true)]
    internal class NullableSByteEnumFormatter<T> : Formatter<T?>
        where T : struct
    {
        static SByte Identity(SByte x) { return x; }

        readonly Func<SByte, T> deserializeCast;
        readonly Func<T, SByte> serializeCast;

        [Preserve]
        public NullableSByteEnumFormatter()
        {
            Func<SByte, SByte> identity = Identity;
            this.serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, SByte>)) as Func<T, SByte>;
            this.deserializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<SByte, T>)) as Func<SByte, T>;
        }

        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, T? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteSByte(ref bytes, offset + 1, serializeCast(value.Value));
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override T? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return deserializeCast(BinaryUtil.ReadSByte(ref bytes, offset + 1));
        }
    }


}

#endif