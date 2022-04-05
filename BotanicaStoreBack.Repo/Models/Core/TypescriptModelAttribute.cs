namespace BotanicaStoreBack.Repo.Models;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class TypeScriptModelAttribute : Attribute
{
	public string ExcludeMembersByName { get; set; }
	public string OptionalMembersByName { get; set; }
}
