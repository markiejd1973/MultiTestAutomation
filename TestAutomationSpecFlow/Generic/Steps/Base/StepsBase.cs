using Generic.Steps.Helpers.Interfaces;

namespace Generic.Steps
{
	/// <summary>
	///     Base for steps classes
	/// </summary>
	public class StepsBase
	{
		protected StepsBase(IStepHelpers helpers)
		{
			Helpers = helpers;
		}

		protected IStepHelpers Helpers { get; }
	}
}
