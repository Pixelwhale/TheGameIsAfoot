//----------------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクター攻撃Skillを作成できるスクリプト
//----------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObject/Character/AttackSkill")]
public class CharacterAttackSkillModel : CharacterSkillModel
 {
	 [SerializeField]
	 private int baseDamage;			//基礎ダメージ
	 [SerializeField]
	 private int hitCount;				//Hit数
}
