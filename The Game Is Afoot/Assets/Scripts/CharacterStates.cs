using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct CharacterStates {

	short hp_max;

	//攻撃
	//参照EDamgeType
	short[] atk;				//攻撃力
	short[] armour;				//防御力
	short[] penetration;		//防御貫通

	short atkRange;				//攻撃範囲
	float atkSpeed;				//攻撃の間
	float atkRatio;				//攻撃の倍率
	
	//クリティカル
	float criticalChance;		//0~1
	float criticalMultiplier;	//クリティカル時の倍率
}
