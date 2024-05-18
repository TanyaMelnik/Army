using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Magic
{
    class LogGetAttack(IUnit unit, (int percentAttack, double percentDodge) percentAttackAndDodge) : IUnit(percentAttackAndDodge)
    {
        public IUnit unit = unit;
        const string logFilePath = "logHitUnit.txt";
        public override int Health()
        {
            return unit.Health();
        }
        public override int Attack()
        {
            return unit.Attack();
        }
        public override string ToString()
        {
            return unit.ToString();
        }
        public override void GetHit(int strengthAttack)
        {
            string text = $"[{DateTime.Now}] Удар по {unit.GetType()} уроном {strengthAttack} ";
            Data.WriteInFile(logFilePath, text);
            unit.GetHit(strengthAttack);
        }

        public override string Name()
        {
            return unit.Name();
        }

        public override double Dodge()
        {
            return unit.Dodge();
        }

        public override int Defense()
        {
            return unit.Defense();
        }
        public override int Cost()
        {
            return unit.Cost();
        }

        public override IUnit MakeClone()
        {
            return unit.MakeClone();
        }
    }    
}
