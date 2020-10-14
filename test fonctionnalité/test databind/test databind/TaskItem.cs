using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace test_databind
{
	class TaskItem
	{
		public string Title { get; set; }
		public int Completion { get; set; }

		public TaskItem(string title = null, int completion = -1)
		{
			RngBuilder rng = new RngBuilder();

			if (title != null)
			{
				Title = title;
			}
			else
			{
				Title = rng.RandomString(8);
			}

			if (completion > -1)
			{
				Completion = completion;
			}
			else
			{
				Completion = rng.RandomNumber(0, 100);
			}
		}
	}
}
