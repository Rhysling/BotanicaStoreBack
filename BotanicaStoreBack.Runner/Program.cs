using BotanicaStoreBack.Runner.Runs;
using System;

namespace BotanicaStoreBack.Runner
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine(Test.DtFormats());
			//Console.Write(DtConversion.FromShoppingListAdmin());

			//ColorCardMaker.Create();
			SlugMaker.Create();
			//PicFileNames.ConvertNames();
			//ColorCardMaker.TestTitlesTxt();
			//ColorCardMaker.TestTitles();
			//PicAudit.RunAuditClass();

			Console.WriteLine("Done.");
			Console.ReadKey();
		}
	}
}
