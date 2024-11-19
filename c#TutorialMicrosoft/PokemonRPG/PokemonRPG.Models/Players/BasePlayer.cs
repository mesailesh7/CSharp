namespace PokemonRPG.Models.Players;

public abstract class BasePlayer
{
    public string Name { get; set; }
    
    /// <summary>
    /// Currenty Party of pokemon. Max of ^ and needs controls/restrictions
    /// for swapping new pokemon with existing
    /// </summary>
    public virtual IList<BaseMonster> Party { get; set; }
    
}