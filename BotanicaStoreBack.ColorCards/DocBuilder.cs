using BotanicaStoreBack.Repo.Models;
using SautinSoft.Document;

namespace BotanicaStoreBack.ColorCards
{
	public class DocBuilder
	{
		private List<Plant> plants;
		private string docPath;

		public DocBuilder(List<Plant> plants, string docPath)
		{
			this.plants = plants;
			this.docPath = docPath;
		}

		public void Create()
		{
			// Create a new document and DocumentBuilder.
			DocumentCore dc = new DocumentCore();


			// Add new section
			Section s = new Section(dc);

			s.PageSetup.PaperType = PaperType.Letter;
			s.PageSetup.Orientation = Orientation.Landscape;
			s.PageSetup.PageMargins = new PageMargins()
			{
				Top = LengthUnitConverter.Convert(0.5, LengthUnit.Inch, LengthUnit.Point),
				Right = LengthUnitConverter.Convert(0.25, LengthUnit.Inch, LengthUnit.Point),
				Bottom = LengthUnitConverter.Convert(0.3, LengthUnit.Inch, LengthUnit.Point),
				Left = LengthUnitConverter.Convert(0.25, LengthUnit.Inch, LengthUnit.Point)
			};

			s.PageSetup.TextColumns = new TextColumnCollection(2);
			s.PageSetup.TextColumns.EvenlySpaced = true;
			s.PageSetup.TextColumns.SpaceBetween = LengthUnitConverter.Convert(0.25, LengthUnit.Inch, LengthUnit.Point);

			dc.Sections.Add(s);

			MakeFooter(dc);

			foreach (var p in plants)
			{
				var cb1 = new CardBuilder(p, false);
				cb1.AddToDoc(dc);
				var cb2 = new CardBuilder(p, true);
				cb2.AddToDoc(dc);
			}


			// Save the document to the file in DOCX format.
			dc.Save(docPath, new DocxSaveOptions { EmbeddedJpegQuality = 90 });

			// Open the result for demonstration purposes.
			System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(docPath) { UseShellExecute = true });
		}


		private void MakeFooter(DocumentCore dc)
		{
			string txt = $"© {DateTime.Now.Year} Pamela Harlow";

			var pf = new ParagraphFormat
			{
				LeftIndentation = 0,
				RightIndentation = 0,
				SpecialIndentation = 0,
				LineSpacing = 12,
				LineSpacingRule = LineSpacingRule.AtLeast,
				SpaceBefore = 0,
				SpaceAfter = 12,
				Alignment = HorizontalAlignment.Left
			};

			pf.Tabs.Clear();
			pf.Tabs.Add(new TabStop(LengthUnitConverter.Convert(10.5, LengthUnit.Inch, LengthUnit.Point), TabStopAlignment.Right));


			var footer = new HeaderFooter(dc, HeaderFooterType.FooterDefault);

			// Create a paragraph to insert it into the footer.
			Paragraph par = new Paragraph(dc);
			par.ParagraphFormat = pf;

			var rTx1 = new Run(dc);
			rTx1.Text = txt;
			rTx1.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 10.0, Bold = false };
			par.Inlines.Add(rTx1);

			par.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.Tab));

			var rTx2 = new Run(dc);
			rTx2.Text = txt;
			rTx2.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 10.0, Bold = false };
			par.Inlines.Add(rTx2);

			footer.Blocks.Add(par);
			dc.Sections[0].HeadersFooters.Add(footer);

		}
	}
}