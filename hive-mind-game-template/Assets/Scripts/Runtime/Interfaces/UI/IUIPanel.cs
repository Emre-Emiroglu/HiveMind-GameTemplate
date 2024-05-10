using HiveMindGameTemplate.Runtime.Datas.ValueObjects.UI;

namespace HiveMindGameTemplate.Runtime.Interfaces.UI
{
    public interface IUIPanel
    {
        public UIPanel_VO UIPanel_VO { get; }
        public void Show();
        public void Hide();
    }
}
