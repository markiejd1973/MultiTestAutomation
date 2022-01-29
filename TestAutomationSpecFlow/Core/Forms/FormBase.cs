using Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	public abstract class FormBase : Form
	{
		protected FormBase(By locator, string name) : base(locator, name)
		{
			Element = new Dictionary<string, By>(StringComparer.OrdinalIgnoreCase);
			ElementString = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		}

		protected IDictionary<string, By> Element { get; }

		public IDictionary<string, string> ElementString { get; protected set; }

	}
}
