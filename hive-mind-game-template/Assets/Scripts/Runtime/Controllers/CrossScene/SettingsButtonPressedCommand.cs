using HiveMind.Core.MVC.Runtime.Controller;
using HiveMindGameTemplate.Runtime.Enums.CrossScene;
using HiveMindGameTemplate.Runtime.Models.CrossScene;
using HiveMindGameTemplate.Runtime.Signals.CrossScene;
using Zenject;

namespace HiveMindGameTemplate.Runtime.Controllers.CrossScene
{
    public class SettingsButtonPressedCommand : Command<SettingsButtonPressedSignal>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly AudioModel _audioModel;
        private readonly HapticModel _hapticModel;
        #endregion

        #region Constructor
        public SettingsButtonPressedCommand(SignalBus signalBus, AudioModel audioModel, HapticModel hapticModel)
        {
            _signalBus = signalBus;
            _audioModel = audioModel;
            _hapticModel = hapticModel;
        }
        #endregion

        #region Executes
        public override void Execute(SettingsButtonPressedSignal signal)
        {
            switch (signal.SettingsType)
            {
                case SettingsTypes.Music:
                    _audioModel.SetMusic(!_audioModel.IsMusicMuted);
                    break;
                case SettingsTypes.Sound:
                    _audioModel.SetSound(!_audioModel.IsSoundMuted);
                    break;
                case SettingsTypes.Haptic:
                    _hapticModel.SetHaptic(!_hapticModel.IsHapticMuted);
                    break;
            }

            _signalBus.Fire<SettingsButtonRefreshSignal>(new(signal.SettingsType));
        }
        #endregion
    }
}
