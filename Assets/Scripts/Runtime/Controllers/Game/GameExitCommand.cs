using HiveMind.Core.MVC.Controllers;
using HiveMind.Core.ProDebug.Colorize;
using HiveMind.Core.ProDebug.TextFormat;
using HiveMindGameTemplate.Runtime.Models.Game.Player;
using HiveMindGameTemplate.Runtime.Models.Game.Wave;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Game
{
    public sealed class GameExitCommand : Command
    {
        #region Injects
        [Inject] private readonly PlayerModel playerModel;
        [Inject] private readonly WaveModel waveModel;
        #endregion

        #region Constructor
        public GameExitCommand() { }
        #endregion

        #region Executes
        public override void Execute()
        {
            Debug.Log("Game Exit Command Execute!" % Colorize.DarkRed % TextFormat.Bold);

            waveModel.Save();

            Application.Quit();
        }
        #endregion
    }
}
