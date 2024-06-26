using HiveMind.Core.MVC.Runtime.Binders;
using HiveMind.Core.MVC.Runtime.Datas;

namespace HiveMind.Core.MVC.Runtime.Installers
{
    public class MVCInstaller<TSubInstaller>: MVCInstallerBase<BinderData, MVCInstaller<TSubInstaller>, TSubInstaller>
    {
        #region Fields
        protected readonly BinderData binderData;
        protected readonly ModelBinder modelBinder;
        protected readonly MediationBinder mediationBinder;
        protected readonly CommandBinder commandBinder;
        #endregion

        #region Constructor
        public MVCInstaller(BinderData binderData)
        {
            this.binderData = binderData;
            modelBinder = new(binderData);
            mediationBinder = new(binderData);
            commandBinder = new(binderData);
        }
        #endregion

        #region Bindings
        public override void InstallBindings()
        {
            modelBinder.Bind();
            mediationBinder.Bind();
            commandBinder.Bind();
        }
        #endregion
    }
}
