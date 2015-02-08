using System.Linq;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Display;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.Helpers;
using SampSharp.GameMode.SAMP;
using SampSharp.GameMode.World;

namespace Barron.World
{
    public class Player : GtaPlayer
    {
        private static readonly TextDraw helperTextdraw;
        public GtaVehicle CreatedVehicle { get; private set; }
        public Player PlayerObserving { get; private set; }

        static Player()
        {
            helperTextdraw = new TextDraw(20.0f, 400.0f, "Press ~b~~k~~PED_SPRINT~ ~w~to spawn~n~Press ~b~~k~~PED_FIREWEAPON~ ~w~to switch players")
            {
                UseBox = false,
                Font = TextDrawFont.Slim,
                Shadow = 0,
                Outline = 1,
                BackColor = Color.AliceBlue,
                ForeColor = Color.White
            };
        }


        public Player(int id) : base(id)
        {
        }

        public override void OnDisconnected(PlayerDisconnectedEventArgs e)
        {
            DisposeVehicle();

            base.OnDisconnected(e);
        }

        public override void OnRequestClass(PlayerRequestClassEventArgs e)
        {
            ObserveNextVehicle();
            helperTextdraw.Show(this);

            var position = SpawnPositionsHelper.Positions[Id];
            SetSpawnInfo(0, 0, position.Position, position.Angle);

            base.OnRequestClass(e);
        }

        public override void OnSpawned(PlayerEventArgs e)
        {
            helperTextdraw.Hide(this);

            var position = SpawnPositionsHelper.Positions[Id];
            CreatedVehicle = GtaVehicle.Create(464, position.Position, position.Angle, -1, -1);
            PutInVehicle(CreatedVehicle);

            SetWorldBounds(200.0f, -300.0f, 200.0f, -200.0f);

            base.OnSpawned(e);
        }

        public override void OnDeath(PlayerDeathEventArgs e)
        {
            RemoveFromVehicle();
            DisposeVehicle();
            SendDeathMessageToAll(e.Killer, this, e.DeathReason);

            base.OnDeath(e);
        }

        public override void OnKeyStateChanged(PlayerKeyStateChangedEventArgs e)
        {
            base.OnKeyStateChanged(e);

            if (PlayerObserving != null && (e.NewKeys.HasFlag(Keys.Sprint) && !e.OldKeys.HasFlag(Keys.Sprint)))
            {
                LeaveSpec();
                return;
            }

            if (PlayerObserving != null && (e.NewKeys.HasFlag(Keys.Fire) && !e.OldKeys.HasFlag(Keys.Fire)))
            {
                ObserveNextVehicle();
                return;
            }

        }

        private void LeaveSpec()
        {
            ToggleSpectating(false);
            PlayerObserving = null;
            SendClientMessage(Color.White, "Leaving spectate");
        }

        private void DisposeVehicle()
        {
            if (CreatedVehicle == null)
            {
                return;
            }

            CreatedVehicle.Dispose();
            CreatedVehicle = null;
        }

        private void ObserveNextVehicle()
        {
            // if the player was already in spec mode we will select the first one which comes after
            // the current spec player (and should be different from himself)
            var skipUntil = PlayerObserving != null ?
                All.FindIndex(player => player == PlayerObserving && player != this) : 0;

            var firstPlayer = All
                .Skip(skipUntil)
                .FirstOrDefault(player => player != this);

            if (firstPlayer != null)
            {
                // a compatible player has been found, spec him
                ObserveVehicleOf((Player)firstPlayer);
            }
            else
            {
                // we can't find someone which comes after the current spec player
                // so start from 0 again we will select the first one which is not himself

                var otherPlayerStartingFromTheStart = All.FirstOrDefault(player => player != this);

                if (otherPlayerStartingFromTheStart == null)
                {
                    // idk how to handle this
                    // didn't find any vehicles to observe. we'll have to default to last <- samp comment
                    return;
                }

                ObserveVehicleOf((Player)otherPlayerStartingFromTheStart);
            }
        }

        private void ObserveVehicleOf(Player player)
        {
            PlayerObserving = player;

            ToggleSpectating(true);
            SpectateVehicle(player.CreatedVehicle);
        }
    }
}