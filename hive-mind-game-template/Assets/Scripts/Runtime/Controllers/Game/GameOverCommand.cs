using HiveMind.Core.MVC.Runtime.Controllers;
using HiveMind.Core.ProDebug.Runtime.Colorize;
using HiveMind.Core.ProDebug.Runtime.TextFormat;
using HiveMindGameTemplate.Runtime.Enums.UI;
using HiveMindGameTemplate.Runtime.Models.Game.Player;
using HiveMindGameTemplate.Runtime.Models.Game.Wave;
using HiveMindGameTemplate.Runtime.Signals.Game;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Game
{
    public sealed class GameOverCommand : Command
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        [Inject] private readonly PlayerModel playerModel;
        [Inject] private readonly WaveModel waveModel;
        #endregion

        #region Constructor
        public GameOverCommand() { }
        #endregion

        #region Executes
        public override void Execute()
        {
            Debug.Log("Game Over Command Execute!" % Colorize.DarkRed % TextFormat.Bold);

            waveModel.ResetWavePersisentData();

            signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.GameOverPanel));
        }
        #endregion
    }
}
