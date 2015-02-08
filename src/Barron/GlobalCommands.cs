using Barron.World;
using SampSharp.GameMode.SAMP.Commands;

namespace Barron
{
    public static class GlobalCommands
    {
        [Command("help")]
        public static void HelpCommand(Player player)
        {
            player.SendClientMessage("You've typed /help. This command can be modified in GlobalCommands.cs");
        }
    }
}