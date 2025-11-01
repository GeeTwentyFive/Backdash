using System.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;
using Backdash.Serialization;

namespace Backdash.Tests.Specs.Unit.Serialization;

public class SubState
{
    public short Sub1;
    public long Sub2;
}

public record struct MyVector2(float X, float Y);

public enum EnumState : uint { None, Foo, Bar }

public class GameState
{
    public int Value1;
    public long Value2;
    public bool Value3;

    public Vector2 Value4;
    public SubState Value5 = new();

    public int[] Value6 = new int[5];

    public MyVector2[] Value7 = new MyVector2[3];
    public EnumState Value9;
    public EnumState[] Value10 = new EnumState[2];

    public GameState()
    {
        for (int i = 0; i < Value7.Length; i++)
        {
            Value7[i] = new();
        }
    }
}

[BinarySerializer<MyVector2>]
public partial class MyVector2Serializer;

[BinarySerializer<SubState>]
public partial class SubStateSerializer;

[BinarySerializer<GameState>]
public partial class GameStateSerializer;

public class GeneratorTests
{
    //
}
