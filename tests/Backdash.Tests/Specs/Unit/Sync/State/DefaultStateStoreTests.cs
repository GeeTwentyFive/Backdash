using System.Numerics;
using Backdash.Serialization;
using Backdash.Synchronizing.State;
using Backdash.Tests.TestUtils;

namespace Backdash.Tests.Specs.Unit.Sync.State;

public class DefaultStateStoreTests
{
    //
}

public record GameState
{
    public int Value1;
    public long Value2;
    public bool Value3;
    public Vector2 Value4;
    public Vector3 Value5;
    public readonly byte[] MoreValues = new byte[3];

    public static GameState CreateRandom()
    {
        GameState result = new()
        {
            Value1 = Gen.Random.Int(),
            Value2 = Gen.Random.Long(),
            Value3 = Gen.Random.Bool(),
            Value4 = Gen.Vector2(),
            Value5 = Gen.Vector3(),
        };

        for (int i = 0; i < result.MoreValues.Length; i++)
            result.MoreValues[i] = Gen.Random.Byte();

        return result;
    }
}

[BinarySerializer<GameState>]
public partial class GameStateSerializer;
