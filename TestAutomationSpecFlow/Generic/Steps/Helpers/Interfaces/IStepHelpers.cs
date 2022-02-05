

namespace Generic.Steps.Helpers.Interfaces
{
    public interface IStepHelpers
    {
        /// <summary>
        /// Add new ElementStepHelper.cs? needs to populate BELOW
        /// </summary>
        /// 
        IAccordionStepHelper Accordion { get; } 
        IButtonStepHelper Button { get; }   
        IPageStepHelper Page { get; }
        IRadioButtonStepHelper RadioButton { get; } 
        ITextBoxStepHelper TextBox { get; }
        ITreeStepHelper Tree { get; }
    }
}
