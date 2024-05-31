using Magic;

/// <summary>
/// Èíòåğôåéñ, îïğåäåëåíèå ìåòîäà DoSpecialPropertyÑolumn, 
/// DoSpecialPropertyBattalion, DoSpecialPropertyWallToWall.
/// </summary>
interface ISpecialProperty
{
    IUnit? DoSpecialPropertyÑolumn(List<IUnit> ownArmy, 
        List<IUnit> enemyArmy, int number);
    IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy, 
        List<IUnit> enemyArmy, int number);
    IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy, 
        List<IUnit> enemyArmy, int number);
}