﻿using Core.Logging;
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
			Elements = new Dictionary<string, string>();
			ElementXPath = new Dictionary<string, string>();
		}

		protected IDictionary<string, string> Elements { get; }

		public IDictionary<string, string> ElementXPath { get; protected set; }

	}
}
