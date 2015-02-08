using System;
using System.Data.OleDb;
using Barron.Controllers;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.World;

namespace Barron
{
    public class GameMode : BaseMode
    {
        protected override void OnInitialized(EventArgs e)
        {
            SetGameModeText("RC Barnstorm");
            ShowNameTags(true);
            ShowPlayerMarkers(PlayerMarkersMode.Off);
            SetWorldTime(7);
            SetWeather(5);

            AddPlayerClass(0, new Vector(0.0, 0.0, 0.0), 4.0f);

            base.OnInitialized(e);
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);

            controllers.Remove<GtaPlayerController>();
            controllers.Add(new PlayerController());
        }
    }
}