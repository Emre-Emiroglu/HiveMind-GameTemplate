using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Lofelt.NiceVibrations;

namespace HiveMindGameTemplate.Runtime.Controllers.CrossScene
{
    public class PlayHapticCommand : Command<PlayHapticSignal>
    {
        #region ReadonlyFields
        private HapticModel _hapticModel;
        #endregion

        #region Constructor
        public PlayHapticCommand(HapticModel hapticModel)
        {
            _hapticModel = hapticModel;
        }
        #endregion

        #region Executes
        public override void Execute(PlayHapticSignal signal)
        {
            if (_hapticModel.IsHapticMuted)
                return;

            HapticPatterns.PlayPreset(signal.HapticType);
        }
        #endregion
    }
}
