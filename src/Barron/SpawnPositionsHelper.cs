using SampSharp.GameMode.World;

namespace Barron
{
    public class SpawnPositionsHelper
    {
        public static readonly WorldPosition[] Positions = {
            new WorldPosition(-205.7703,-119.6655,2.4094,342.0546f),
            new WorldPosition(-202.1386,-54.1213,2.4111,95.6799f),
            new WorldPosition(-197.2334,7.5293,2.4034,16.0852f),
            new WorldPosition(-135.7348,61.7265,2.4112,354.3534f),
            new WorldPosition(-73.7883,73.4238,2.4082,260.5399f),
            new WorldPosition(-6.9850,27.9988,2.4112,201.7691f),
            new WorldPosition(0.6782,-16.0898,2.4076,161.7720f),
            new WorldPosition(-46.3365,-88.3937,2.4092,180.7382f),
            new WorldPosition(-72.4389,-127.2939,2.4107,113.5616f),
            new WorldPosition(-128.1940,-144.1725,2.4094,78.9676f),
            new WorldPosition(-266.0189,-50.6718,2.4125,223.8079f),
            new WorldPosition(-244.2617,-1.0468,2.1038,257.3333f),
            new WorldPosition(-93.3146,-32.4889,2.4085,186.0631f),
            new WorldPosition(-130.7054,-93.4983,2.4124,73.8375f),
            new WorldPosition(-117.4049,4.2989,2.4112,337.1284f),
            new WorldPosition(-26.1622,135.8739,2.4094,248.1580f),
            new WorldPosition(45.5705,86.7586,2.0753,147.3342f),
            new WorldPosition(54.9881,2.2997,1.1132,95.7173f),
            new WorldPosition(-248.9905,-119.3982,2.4083,303.7859f),
            new WorldPosition(-60.1321,55.5239,2.4038,325.2209f),
            new WorldPosition(-60.9184,47.9302,5.7706,342.8299f),
            new WorldPosition(-70.0303,-22.0071,2.4113,165.2789f),
            new WorldPosition(-138.3093,-83.2640,2.4152,4.0455f),
            new WorldPosition(-25.5989,94.6100,2.4041,150.8322f),
            new WorldPosition(-161.0327,-70.5945,2.4042,142.9221f),
            new WorldPosition(-54.8308,-139.6148,2.4119,258.7639f)
        };

        public class WorldPosition
        {
            public Vector Position;
            public float Angle;

            public WorldPosition(Vector position, float angle)
            {
                Position = position;
                Angle = angle;
            }

            public WorldPosition(float x, float y, float z, float angle) : this(new Vector(x, y, z), angle)
            {
            }

            public WorldPosition(double x, double y, double z, float angle) : this((float)x, (float)y, (float)z, angle)
            {
            }
        };

    }
}