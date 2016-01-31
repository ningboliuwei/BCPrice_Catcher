using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			var task1 = Task.Run(() => { throw new OutOfMemoryException("内存不足"); });

			try
			{
				task1.Wait();
			}
			catch (AggregateException ex)
			{
				Console.Write(ex.ToString());
				Console.ReadKey();
			}

		}
	}
}
