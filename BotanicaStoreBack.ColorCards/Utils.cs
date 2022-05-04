namespace BotanicaStoreBack.ColorCards;

public static class Utils
{
	public static (string line1, string line2, string rule) LineSplit(string genus, string species)
	{
		genus = genus.Trim();
		species = species.Trim();

		int genusLength = genus.Length;
		int speciesLength = species.Length;

		// Rule 1
		if (genusLength > 23)
			return (genus, species, "1");

		// Rule 2
		if (genusLength + speciesLength < 23)
			return ($"{genus} {species}", "", "2");

		// Rule 3
		if (species.StartsWith('\''))
			return (genus, species, "3");

		int ix = species.IndexOf(' ');
		if (ix > -1)
		{
			string firstWord = species[..ix];
			int firstWordLen = firstWord.Length;

			if (firstWordLen < 4)
			{
				// Try expand to incl second word
				int ix2 = species.IndexOf(' ', ix + 1);

				if (ix2 > -1 && !species[..ix2].Contains('\''))
				{
					ix = ix2;
					firstWord = species[..ix];
					firstWordLen = firstWord.Length;
				}
			}

			// Rule 5a
			if (speciesLength > 25 && genusLength + firstWordLen < 28)
				return ($"{genus} {firstWord}", species[ix..].Trim(), "5a");

			// Rule 5b
			if (genusLength + firstWordLen < 23)
				return ($"{genus} {firstWord}", species[ix..].Trim(), "5b");

		}

		return (genus, species, "99");
	}
}
