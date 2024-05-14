using HiveMind.Core.MVC.Runtime.Controllers;
using HiveMind.Core.ProDebug.Runtime.Colorize;
using HiveMind.Core.ProDebug.Runtime.TextFormat;
using HiveMindGameTemplate.Runtime.Signals.Game;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Game
{
    public sealed class NextWaveCommand : Command
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        #endregion

        #region Constructor
        public NextWaveCommand() { }
        #endregion

        #region Executes
        public override void Execute()
        {
            Debug.Log("Next Wave Command Execute!" % Colorize.Magenta % TextFormat.Bold);

            signalBus.Fire<StartGameSignal>(new());
        }
        #endregion
    }
}
