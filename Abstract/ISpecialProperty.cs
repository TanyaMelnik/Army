using Magic;

interface ISpecialProperty
{
    IUnit? DoSpecialProperty—olumn(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number);
    IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number);
    IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number);
}