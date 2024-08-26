using HiveMind.Core.MVC.Runtime.View;
using HiveMindGameTemplate.Runtime.Models.Bootstrap;
using HiveMindGameTemplate.Runtime.Utilities.Extensions;

namespace HiveMindGameTemplate.Runtime.Views.Bootstrap
{
    public class LogoHolderPanelMediator : Mediator<LogoHolderPanelView>
    {
        #region ReadonlyFields
        private readonly BootstrapModel _bootstrapModel;
        #endregion

        #region Constructor
        public LogoHolderPanelMediator(LogoHolderPanelView view, BootstrapModel bootstrapModel) : base(view)
        {
            _bootstrapModel = bootstrapModel;
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Core
        public override void Initialize()
        {
            _view.LogoImage.sprite = _bootstrapModel.Settings.LogoSprite;
            _view.LogoImage.preserveAspect = true;

            _view.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(true);
            _view.UIPanelVo.PlayableDirector.ChangeUIPanelTimelineActivation(true);
        }
        public override void Dispose() { }
        #endregion
    }
}
