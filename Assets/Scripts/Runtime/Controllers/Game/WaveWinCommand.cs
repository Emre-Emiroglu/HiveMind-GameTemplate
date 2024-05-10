using HiveMind.Core.MVC.Controllers;
using HiveMind.Core.ProDebug.Colorize;
using HiveMind.Core.ProDebug.TextFormat;
using HiveMindGameTemplate.Runtime.Enums.UI;
using HiveMindGameTemplate.Runtime.Models.Game.Wave;
using HiveMindGameTemplate.Runtime.Signals.Game;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Game
{
    public sealed class WaveWinCommand : Command
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        [Inject] private readonly WaveModel waveModel;
        #endregion

        #region Constructor
        public WaveWinCommand() { }
        #endregion

        #region Executes
        public override void Execute()
        {
            Debug.Log("Wave Win Command Execute!" % Colorize.DarkGreen % TextFormat.Bold);

            waveModel.UpdateCurrentWaveIndex(false, 1);

            signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.WaveWinPanel));
        }
        #endregion
    }
}
