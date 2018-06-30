//----------------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクターBaseDateを作成できるスクリプト
//----------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObject/Character/Status")]
public class CharacterDataModel : ScriptableObject
 {
	 [SerializeField]
	 private string charaName;		//キャラ名
	 [SerializeField]
	 private Sprite thumbnail;		//小さい画像
	 [SerializeField]
	 private Sprite characterImage;	//立ち絵
	 [SerializeField]
	 private int baseHp;			//基礎HP
	 [SerializeField]
	 private int baseAtk;			//基礎ATK
	 [SerializeField]
	 private int baseDefence;		//基礎DEF
	 [SerializeField]
	 private CharacterSkillModel[] skills;	//スキル


	/// <summary>
	/// 持っているスキル数
	/// </summary>
	/// <returns></returns>
	 public int SkillCount()
	 {
		 return skills.Length;
	 }

	/// <summary>
	/// 指定のスキル番を取得
	/// </summary>
	/// <param name="skillNo">キャラのスキルNo</param>
	/// <returns></returns>
	 public CharacterSkillModel GetSkill(int skillNo)
	 {
		 return skills[skillNo];
	 }

	/// <summary>
	/// skillを一括取得
	/// </summary>
	/// <returns></returns>
	 public CharacterSkillModel[] GetSkills()
	 {
		 return skills;
	 }
}
