namespace PokemonRPG.Models;

// The abstract modifier indicates that the thing being modified has a missing or incomplete implementation
//Use the abstract modifier in a class declaration to indicate that a class is intended only to be a base class of other classes, not instantiated on its own
public abstract class BaseMonster
{
    /// <summary>
    /// Pokemon Number
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Pokemon Type
    /// </summary>
    public MonsterType Type { get; set; }
    
    /// <summary>
    /// Monster's Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Health
    /// </summary>
    public int HP { get; set; }
    
    /// <summary>
    /// Base Attack Stat (Physical and Special)
    /// </summary>
    public int Attack { get; set; }

    /// <summary>
    /// Base Defencee stat (Physical and Special)
    /// </summary>
    public int Defence { get; set; }

    /// <summary>
    /// Base speed stat (used to determine round order)
    /// </summary>
    public int Speed { get; set; }
    
    /// <summary>
    /// up to 4 moves that the monster knows
    /// </summary>
    /// -- TODO: Add controls/restirctions for learning new moves.
    /// -- Note: When Learning a 5th move it actuall needs to replace one of the existing 4 moves.
    public virtual IList<BattleMove> MoveList { get; set; }
    
    
}