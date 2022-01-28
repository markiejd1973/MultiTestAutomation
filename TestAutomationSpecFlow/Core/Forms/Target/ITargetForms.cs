using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	public interface ITargetForms
	{
		/// <summary>
		///     Gets an instance of a form from its name
		///     Will attempt to match on the name first, then if that fails, it will attempt to match on name + 'page'
		/// </summary>
		/// <param name="name">Name of the form, case insensitive and ignoring spaces</param>
		/// <returns>An instance of the form</returns>
		FormBase this[string name] { get; }
	}
}
