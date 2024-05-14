using HiveMind.Core.MVC.Runtime.Controllers;
using HiveMind.Core.ProDebug.Runtime.Colorize;
using HiveMind.Core.ProDebug.Runtime.TextFormat;
using HiveMindGameTemplate.Runtime.Enums.UI;
using HiveMindGameTemplate.Runtime.Signals.Game;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Game
{
    public sealed class StartGameCommand : Command
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        #endregion

        #region Constructor
        public StartGameCommand() { }
        #endregion

        #region Executes
        public override void Execute()
        {
            Debug.Log("Start Game Command Execute!" % Colorize.DarkOrange % TextFormat.Bold);

            signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.HudPanel));
        }
        #endregion
    }
}
