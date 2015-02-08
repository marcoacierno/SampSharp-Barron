using Barron.World;
using SampSharp.GameMode.Controllers;

namespace Barron.Controllers
{
    public class PlayerController : GtaPlayerController
    {
        public override void RegisterTypes()
        {
            Player.Register<Player>();
        }
    }
}