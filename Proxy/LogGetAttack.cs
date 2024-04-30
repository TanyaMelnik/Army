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
        IUnit unit = unit;
        // Абстрактный класс записи
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
            using (StreamWriter log = File.AppendText(logFilePath))
            {
                log.WriteLine($"[{DateTime.Now}] Удар по {unit.GetType()} уроном {strengthAttack} ");
            }
            unit.GetHit(strengthAttack);
        }
    }    
}
