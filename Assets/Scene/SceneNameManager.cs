/// <summary>
/// シーン名を定数で管理するクラス
/// </summary>
public class SceneNameManager
{
	public const string Battle = "Battle";
	public const string CharacterSelect = "CharacterSelect";
	public const string MapSelect = "MapSelect";
	public const string Title = "Title";
	public const string WeaponSelect = "WeaponSelect";

    public enum Scene
    {
	    Battle,
	    CharacterSelect,
	    MapSelect,
	    Title,
	    WeaponSelect,
    }
}
