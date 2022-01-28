using Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	public class TargetForms : ITargetForms
	{
		private static TargetForms instance;
		private readonly Dictionary<string, FormBase> forms;

		static TargetForms()
		{
			instance = new TargetForms();
		}

		private TargetForms()
		{
			forms = new Dictionary<string, FormBase>(StringComparer.OrdinalIgnoreCase);
		}

		public static TargetForms Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new TargetForms();
				}

				return instance;
			}
		}

		public FormBase this[string name] => GetForm(name);

		private FormBase GetForm(string name)
		{
			DebugOutput.Log($"Proc - GetForm {name}");
			var key = name.Replace(" ", string.Empty);
			DebugOutput.Log($"Looking for {key}");

			if (forms.ContainsKey(key))
			{
				return forms[key];
			}

			// Try adding page to the end of the key if that didn't work
			key = $"{key}page";
			DebugOutput.Log($"Looking for with page added {key}");

			if (forms.ContainsKey(key))
			{
				DebugOutput.Log($"Well found page using {key}");
				return forms[key];
			}

			DebugOutput.Log($"No form matching {name} found using {key}");
			throw new ArgumentOutOfRangeException($"No form matching {name} found");
		}

		public void PopulateList(Assembly assembly)
		{
			forms.Clear();

			var q = assembly.GetTypes()
				.Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(FormBase)))
				.ToList();

			foreach (var type in q)
			{
				var f = Activator.CreateInstance(type) as FormBase;

				if (f == null)
				{
					throw new InvalidOperationException($"Could not create an instance of {type.Name}");
				}

				var key = f.Name.Replace(" ", string.Empty);
				forms.Add(key, f);
			}
		}
	}
}
