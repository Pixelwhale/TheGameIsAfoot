using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct CharacterStatus
{

    public CharacterStatus(string[] data)
    {
        hp_max = short.Parse(data[2]);

        atk = new short[5] { short.Parse(data[3]), short.Parse(data[4]), short.Parse(data[5]), short.Parse(data[6]), 0 };
        armour = new short[4] { short.Parse(data[7]), short.Parse(data[8]), short.Parse(data[9]), short.Parse(data[10]) };
        penetration = new short[4] { short.Parse(data[11]), short.Parse(data[12]), short.Parse(data[13]), short.Parse(data[14]) };

        atkRange = short.Parse(data[15]);
        atkSpeed = float.Parse(data[16]);

        criticalChance = float.Parse(data[17]);
        criticalMultiplier = float.Parse(data[18]);
    }

    short hp_max;

    //攻撃
    //参照EDamgeType
    short[] atk;                //攻撃力
    short[] armour;             //防御力
    short[] penetration;        //防御貫通

    short atkRange;             //攻撃範囲
    float atkSpeed;             //攻撃の間

    //クリティカル
    float criticalChance;       //0~1
    float criticalMultiplier;	//クリティカル時の倍率
}
