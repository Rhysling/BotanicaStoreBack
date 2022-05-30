using BotanicaStoreBack.Repo.Models;
using System.Collections.Generic;

namespace BotanicaStoreBack.Models.Core;

[TypeScriptModel]
public class PicAuditResult
{
	public int OldOrphanCount { get; set; }

	public List<string> OrphanPicNames { get; set; } = new();

	public List<string> MissingPicNames { get; set; } = new();

	public List<int> PlantIdsMissingPics { get; set; } = new();
}
