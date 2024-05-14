using HiveMind.Core.MVC.Runtime.Attributes;
using HiveMind.Core.MVC.Runtime.Controllers;
using UnityEngine;

namespace HiveMindGameTemplate.Runtime.Controllers.Game.Audio
{
    public sealed class PlayAudioCommand : Command
    {
        #region Injects
        [CommandInject("Game")] private AudioClip audioClip;
        #endregion

        #region ReadonlyFields
        #endregion

        #region Constructor
        public PlayAudioCommand() { }
        #endregion

        #region Executes
        public override void Execute()
        {
            Debug.Log($"Audio {audioClip.name} used!");
        }
        #endregion
    }
}
