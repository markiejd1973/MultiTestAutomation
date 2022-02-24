

namespace Generic.Steps.Helpers.Interfaces
{
    public interface IButtonStepHelper : IStepHelper
    {
        bool ClickButton(string buttonName);
        bool DoubleClick(string buttonName);
        bool IsDisplayed(string buttonName);
        bool MouseOver(string buttonName);
        bool RightClick(string buttonName);

    }
}
