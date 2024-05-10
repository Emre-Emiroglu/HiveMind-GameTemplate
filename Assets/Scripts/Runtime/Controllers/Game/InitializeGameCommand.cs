using HiveMind.Core.MVC.Controllers;
using HiveMind.Core.ProDebug.Colorize;
using HiveMind.Core.ProDebug.TextFormat;
using HiveMindGameTemplate.Runtime.Enums.UI;
using HiveMindGameTemplate.Runtime.Signals.Game;
using UnityEngine;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.Game
{
    public sealed class InitializeGameCommand : Command
    {
        #region Injects
        [Inject] private readonly SignalBus signalBus;
        #endregion

        #region Constructor
        public InitializeGameCommand() { }
        #endregion

        #region Executes
        public override void Execute()
        {
            Debug.Log("Initialize Game Command Execute!" % Colorize.DarkGreen % TextFormat.Bold);

            signalBus.Fire<ChangeUIPanelSignal>(new(UIPanelTypes.MainMenuPanel));
        }
        #endregion
    }
}
