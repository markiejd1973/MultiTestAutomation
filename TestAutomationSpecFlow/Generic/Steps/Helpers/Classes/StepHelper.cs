using Generic.Steps.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Generic.Steps.Helpers.Classes
{
    public class StepHelper : IStepHelpers
	{
		protected StepHelper(FeatureContext featureContext)
		{
			CurrentFeatureContext = featureContext;
		}

		private FeatureContext CurrentFeatureContext { get; }

		public String CurrentPage
		{
			get => CurrentFeatureContext.Get<String>();
			set => CurrentFeatureContext.Set(value);
		}
	}
}
