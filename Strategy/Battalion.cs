using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class Battalion : ITypeConstruction, Dead
    {
        public void DeleteUnit(List<IUnit> army, int numberUnit)
        {
            for (int i = numberUnit; i < army.Count()-3; i+=3)
            {
                army[i] = army[i+3];
            }
        }

        public void DoSpecialProperties(List<IUnit> army1, List<IUnit> army2)
        {
            throw new NotImplementedException();
        }

        public void MakeMeleeFight(List<IUnit> army1, List<IUnit> army2)
        {
            ProxyDie proxy = new(new Battalion());
            for (int i = 0; i < 3; i++) 
            {
                if (army1[i] != null && army2[i] != null)
                {
                    army2[i].GetHit(army1[i].Attack());
                    if (army2[i].Health() < 0) proxy.DeleteUnit(army2, i);
                }
                if (army1[i] != null && army2[i] != null)
                {
                    army1[i].GetHit(army2[i].Attack());
                    if (army1[i].Health() < 0) proxy.DeleteUnit(army1, i);
                }
            }
        }

        public void Show(List<IUnit> army1, List<IUnit> army2)
        {
            throw new NotImplementedException();
        }
    }
}
