using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DamageCalculator
{

    //ダメージ減免の比率
    //armourが100増加すると、受けるダメージ半減
    static float DamageReduction(int armour)
    {
        return 1 - 1.0f * armour / (100 + armour);
    }

    //攻撃方の攻撃力と防御方の減免率
    static int DirectDamage(int attackPower, float damageReduction)
    {
        return (int)(attackPower * damageReduction);
    }

}
