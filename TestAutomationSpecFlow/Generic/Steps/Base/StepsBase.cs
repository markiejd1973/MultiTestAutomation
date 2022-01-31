using Generic.Steps.Helpers.Interfaces;

namespace Generic.Steps
{
	/// <summary>
	///     Base for steps classes
	/// </summary>
	public class StepsBase
	{
		protected StepsBase(IStepHelper helpers)
		{
			Helpers = helpers;
		}

		protected IStepHelper Helpers { get; }
	}
}
