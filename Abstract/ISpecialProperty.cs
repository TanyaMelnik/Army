using Magic;

/// <summary>
/// ���������, ����������� ������ DoSpecialProperty�olumn, 
/// DoSpecialPropertyBattalion, DoSpecialPropertyWallToWall.
/// </summary>
interface ISpecialProperty
{
    IUnit? DoSpecialProperty�olumn(List<IUnit> ownArmy, 
        List<IUnit> enemyArmy, int number);
    IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy, 
        List<IUnit> enemyArmy, int number);
    IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy, 
        List<IUnit> enemyArmy, int number);
}