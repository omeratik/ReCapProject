namespace Core.Helpers.GuideHelper;

public class GuidHelper
{
	public static string CreateGuid()
	{
		return Guid.NewGuid().ToString();
	}
}