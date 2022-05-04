using BotanicaStoreBack.Repo.Models;
using SautinSoft.Document;

namespace BotanicaStoreBack.ColorCards;

public class CardBuilder
{
	private Plant plant;
	private string line1;
	private string line2;
	private bool isLast;

	// Paragraph Formats
	private ParagraphFormat pfTitle = new()
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

	private ParagraphFormat pfLine2 = new()
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

	private ParagraphFormat pfNormal = new()
	{
		LeftIndentation = 0,
		RightIndentation = 0,
		SpecialIndentation = 0,
		LineSpacing = 15,
		LineSpacingRule = LineSpacingRule.AtLeast,
		SpaceBefore = 0,
		SpaceAfter = 0,
		Alignment = HorizontalAlignment.Center
	};

	private ParagraphFormat pfTopMargin = new()
	{
		LeftIndentation = 0,
		RightIndentation = 0,
		SpecialIndentation = 0,
		LineSpacing = 15,
		LineSpacingRule = LineSpacingRule.AtLeast,
		SpaceBefore = 6,
		SpaceAfter = 0,
		Alignment = HorizontalAlignment.Center
	};

	public CardBuilder(Plant plant, bool isLast)
	{
		this.plant = plant;
		(line1, line2, _) = Utils.LineSplit(plant.Genus, plant.Species);
		this.isLast = isLast;
	}

	public void AddToDoc(DocumentCore dc)
	{
		// Picture plaeholder
		var pPic = new Paragraph(dc);
		pPic.ParagraphFormat = pfNormal.Clone();
		pPic.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));

		if (!isLast)
			pPic.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));

		pPic.Inlines.Add(new Run(dc, "PicPlaceholder"));
		pPic.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
		pPic.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.LineBreak));
		dc.Sections[0].Blocks.Add(pPic);

		// Title - Line 1
		var pTitle = new Paragraph(dc);
		pTitle.ParagraphFormat = pfTitle.Clone();
		var rTitle = new Run(dc);
		rTitle.Text = line1;
		rTitle.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 28.0, Bold = true };
		pTitle.Inlines.Add(rTitle);
		dc.Sections[0].Blocks.Add(pTitle);

		// Title - Line 2
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

		// Family
		if (!String.IsNullOrWhiteSpace(plant.Family))
		{
			var pFamily = new Paragraph(dc);
			pFamily.ParagraphFormat = pfNormal.Clone();
			var rFamily = new Run(dc);
			rFamily.Text = plant.Family;
			rFamily.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 15.0, Bold = true };
			pFamily.Inlines.Add(rFamily);
			dc.Sections[0].Blocks.Add(pFamily);
		}

		// Glyph
		var pGlyph = new Paragraph(dc);
		pGlyph.ParagraphFormat = pfNormal.Clone();
		var rGlyph = new Run(dc);
		rGlyph.Text = "";
		rGlyph.CharacterFormat = new CharacterFormat() { FontName = "Wingdings", Size = 36.0, Bold = false };
		pGlyph.Inlines.Add(rGlyph);
		dc.Sections[0].Blocks.Add(pGlyph);

		// Description
		if (!String.IsNullOrWhiteSpace(plant.Description))
		{
			var pDesc = new Paragraph(dc);
			pDesc.ParagraphFormat = pfNormal.Clone();
			var rDesc = new Run(dc);
			rDesc.Text = plant.Description;
			rDesc.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 15.0, Bold = true };
			pDesc.Inlines.Add(rDesc);
			dc.Sections[0].Blocks.Add(pDesc);
		}			

		// Size
		var pSize = new Paragraph(dc);
		pSize.ParagraphFormat = pfTopMargin.Clone();
		var rSize = new Run(dc);
		rSize.Text = plant.PlantSize ?? "";
		rSize.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 15.0, Bold = true };
		pSize.Inlines.Add(rSize);
		dc.Sections[0].Blocks.Add(pSize);

		// Type
		var pType = new Paragraph(dc);
		pType.ParagraphFormat = pfNormal.Clone();
		var rType = new Run(dc);
		rType.Text = plant.PlantType ?? "";
		rType.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 15.0, Bold = true };
		pType.Inlines.Add(rType);
		dc.Sections[0].Blocks.Add(pType);

		// Zone
		var pZone = new Paragraph(dc);
		pZone.ParagraphFormat = pfNormal.Clone();
		var rZone = new Run(dc);
		rZone.Text = plant.PlantZone ?? "";
		rZone.CharacterFormat = new CharacterFormat() { FontName = "Times New Roman", Size = 15.0, Bold = true };
		pZone.Inlines.Add(rZone);
		
		if (isLast)
		{
			pZone.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.PageBreak));
		}
		else
		{
			pZone.Inlines.Add(new SpecialCharacter(dc, SpecialCharacterType.ColumnBreak));
		}

		dc.Sections[0].Blocks.Add(pZone);

	}

}
