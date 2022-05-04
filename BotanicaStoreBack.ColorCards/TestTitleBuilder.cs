using BotanicaStoreBack.Repo.Models;
using SautinSoft.Document;

namespace BotanicaStoreBack.ColorCards;

public class TestTitleBuilder
{
	private List<Plant> plants;

	public TestTitleBuilder(List<Plant> plants)
	{
		this.plants = plants;
	}

	public byte[] Create()
	{
		// Create a new document and DocumentBuilder.
		DocumentCore dc = new DocumentCore();


		// Add new section
		Section s = new Section(dc);

		s.PageSetup.PaperType = PaperType.Letter;
		s.PageSetup.Orientation = Orientation.Portrait;
		s.PageSetup.PageMargins = new PageMargins()
		{
			Top = LengthUnitConverter.Convert(0.5, LengthUnit.Inch, LengthUnit.Point),
			Right = LengthUnitConverter.Convert(1.688, LengthUnit.Inch, LengthUnit.Point),
			Bottom = LengthUnitConverter.Convert(0.5, LengthUnit.Inch, LengthUnit.Point),
			Left = LengthUnitConverter.Convert(1.688, LengthUnit.Inch, LengthUnit.Point)
		};

		dc.Sections.Add(s);

		foreach (var p in plants)
		{
			MakeTitle(dc, p.Genus, p.Species);
		}

		using var ms = new MemoryStream();
		dc.Save(ms, new DocxSaveOptions());
		return ms.ToArray();
	}




	private void MakeTitle(DocumentCore dc, string genus, string species)
	{
		// Paragraph Formats

		var pfTop = new ParagraphFormat()
		{
			LeftIndentation = 0,
			RightIndentation = 0,
			SpecialIndentation = 0,
			LineSpacing = 15,
			LineSpacingRule = LineSpacingRule.AtLeast,
			SpaceBefore = 12,
			SpaceAfter = 0,
			Alignment = HorizontalAlignment.Center,
			KeepLinesTogether = true,
			KeepWithNext = true
		};

		var  pfLine1 = new ParagraphFormat()
		{
			LeftIndentation = 0,
			RightIndentation = 0,
			SpecialIndentation = 0,
			LineSpacing = 28,
			LineSpacingRule = LineSpacingRule.AtLeast,
			SpaceBefore = 0,
			SpaceAfter = 0,
			Alignment = HorizontalAlignment.Center
		};

		var pfLine2 = new ParagraphFormat()
		{
			LeftIndentation = 0,
			RightIndentation = 0,
			SpecialIndentation = 0,
			LineSpacing = 24,
			LineSpacingRule = LineSpacingRule.AtLeast,
			SpaceBefore = 0,
			SpaceAfter = 0,
			Alignment = HorizontalAlignment.Center
		};

		var (line1, line2, rule) = Utils.LineSplit(genus, species);


		// Top
		var pTop = new Paragraph(dc);
		pTop.ParagraphFormat = pfTop;
		var rTop = new Run(dc);
		rTop.Text = $"Rule: {rule}";
		rTop.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 15.0, Bold = false };
		pTop.Inlines.Add(rTop);
		dc.Sections[0].Blocks.Add(pTop);

		// Title Line 1
		var pLine1 = new Paragraph(dc);
		pLine1.ParagraphFormat = pfLine1;
		var rLine1 = new Run(dc);
		rLine1.Text = line1;
		rLine1.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 28.0, Bold = true };
		pLine1.Inlines.Add(rLine1);
		dc.Sections[0].Blocks.Add(pLine1);

		// Title Line 2
		if (!String.IsNullOrWhiteSpace(line2))
		{
			var pLine2 = new Paragraph(dc);
			pLine2.ParagraphFormat = pfLine2;
			var rLine2 = new Run(dc);
			rLine2.Text = line2;
			rLine2.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 24.0, Bold = true };
			pLine2.Inlines.Add(rLine2);
			dc.Sections[0].Blocks.Add(pLine2);
		}

	}
}
