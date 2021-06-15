using BotanicaStoreBack.Runner.Runs;
using System;

namespace BotanicaStoreBack.Runner
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine(Test.DtFormats());

			Console.Write(DtConversion.FromShoppingListAdmin());

			Console.WriteLine("Done.");
			Console.ReadKey();
		}
	}
}
