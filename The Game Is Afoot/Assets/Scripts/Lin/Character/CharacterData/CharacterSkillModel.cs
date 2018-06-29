//----------------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクターSkillを作成できるスクリプト
//----------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkillModel : ScriptableObject
 {
	[SerializeField]
	private string skillName;				//スキル名
	[SerializeField]
	private string skillInfo;				//スキルの説明文
	[SerializeField]
	private EOrder[] skillOrder;			//発動できるOrder順番
	[SerializeField]
	private int coolDown;					//CD

	/// <summary>
	/// 発動条件の数
	/// </summary>
	/// <returns></returns>
	public int SkillOrderCount() { return skillOrder.Length; }
	/// <summary>
	/// 発動条件を取得
	/// </summary>
	/// <returns></returns>
	public EOrder[] SkillOrder() { return skillOrder; }

	/// <summary>
	/// CoolDownターンを取得
	/// </summary>
	/// <returns></returns>
	public int CoolDown() { return coolDown; }
}
