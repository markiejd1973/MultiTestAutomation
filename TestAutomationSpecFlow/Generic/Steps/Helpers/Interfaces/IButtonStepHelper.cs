
namespace Generic.Steps.Helpers.Interfaces
{
    public interface IButtonStepHelper : IStepHelper
    {
        bool Disabled(string button, int timeOut = 2);

    }
}
