using HiveMind.Core.MVC.Runtime.Model;
using HiveMindGameTemplate.Runtime.Data.ScriptableObjects.Game;

namespace HiveMindGameTemplate.Runtime.Models.Game
{
    public class TutorialModel : Model<TutorialSettings>
    {
        #region Constants
        private const string ResourcePath = "Data/Game/TutorialSettings";
        private const string TUTORIAL_PATH = "TUTORIAL_PATH";
        #endregion

        #region Fields
        private bool _isTutorialShowed;
        #endregion

        #region Getters
        public bool IsTutorialShowed => _isTutorialShowed;
        #endregion

        #region Constructor
        public TutorialModel() : base(ResourcePath)
        {
            _isTutorialShowed = ES3.Load(nameof(_isTutorialShowed), TUTORIAL_PATH, false);
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Executes
        public void SetTutorial(bool isActive)
        {
            _isTutorialShowed = isActive;
            ES3.Save(nameof(_isTutorialShowed), _isTutorialShowed, TUTORIAL_PATH);
        }
        #endregion
    }
}