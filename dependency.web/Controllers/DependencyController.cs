using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dependency.lib;
using Microsoft.AspNetCore.Mvc;

namespace dependency.web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DependencyController : ControllerBase
	{
		// valid: https://localhost:5001/api/dependency/["KittenService: ", "Leetmeme: Cyberportal", "Cyberportal: Ice", "CamelCaser: KittenService", "Fraudstream: Leetmeme", "Ice: " ]
		// valid: https://localhost:5001/api/dependency/["zero: one","one: two","two: three","three: ","four: five","five: six","six: "]
		// invalid: https://localhost:5001/api/dependency/["KittenService: ", "Leetmeme: Cyberportal", "Cyberportal: Ice", "CamelCaser: KittenService", "Fraudstream: ", "Ice: Leetmeme" ]
		// invalid: https://localhost:5001/api/dependency/["zero: one","one: two","two: three","three: zero","four: five","five: six","six: "]

		// GET api/dependency/["zero: one","one: two","two: three","three: ","four: five","five: six","six: "]
		[HttpGet("{dependencyText}")]
		public ActionResult<string> Get(string dependencyText)
		{
			var result = string.Empty;
			try
			{
				var parser = new DependencyParser(new InputParser());
				result = parser.ParseDependencies(dependencyText);
			}
			catch (System.Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}
	}
}
