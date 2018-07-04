//-----------------------------------------
// 作成日：2018.07.01
// 作成者：林 佳叡
// 内容：攻撃コンポーネント
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour 
{
	[SerializeField]
	private DetectRange detectRange;						//探知範囲
	[SerializeField]
	private float attackRadius;								//攻撃できる範囲
	[SerializeField]
	private bool isRangeAttack;								//範囲攻撃できるか
	
	private void Attack()
	{
		//ターゲットに対する攻撃や攻撃CD計算などをここに
		Debug.Log("攻撃");
	}

	/// <summary>
	/// 攻撃範囲変更(CharacterAssetから読み込む)
	/// </summary>
	/// <param name="radius">半径</param>
	public void ChangeAttackRange(float radius)
	{
		attackRadius = radius;
	}

	/// <summary>
	/// 探知範囲変更(CharacterAssetから読み込む)
	/// </summary>
	/// <param name="radius">半径</param>
	public void ChangeDetectRange(float radius)
	{
		detectRange.ChangeDetectRadius(radius);
	}

	/// <summary>
	/// 探知範囲内に攻撃できるターゲットがいるか
	/// </summary>
	/// <returns></returns>
	public EAttackStep FindUnit()
	{
		Debug.Log("ターゲット見つからない");
		if(detectRange.IsOppsiteUnitIn())			//ターゲットがいれば接近
			return EAttackStep.CloseTo;
		//Todo: back to team
		return EAttackStep.Find;					//なければ探す
	}

	/// <summary>
	/// 攻撃対象に接近
	/// </summary>
	/// <returns></returns>
	public EAttackStep CloseToTarget()
	{
		Debug.Log("ターゲット接近中");
		if(!detectRange.IsOppsiteUnitIn())			//ターゲットがいない場合
			return EAttackStep.Find;				//探す

		GameObject target = detectRange.FindNearest();				//一番近い目標
		if(IsInAttackRange(target))					//攻撃範囲内
		{
			return EAttackStep.Attack;				//攻撃する
		}

		//Todo：移動処理を別クラス
		int dir = (target.transform.position.x - transform.position.x) > 0 ? 1 : -1;
		transform.Translate(dir * Time.deltaTime, 0, 0);
		return EAttackStep.CloseTo;
	}

	public EAttackStep AttackTarget()
	{
		if(!detectRange.IsOppsiteUnitIn())			//ターゲットがいない場合
			return EAttackStep.Find;				//探す
		
		GameObject target = detectRange.FindNearest();				//一番近い目標
		if(!IsInAttackRange(target))				//攻撃範囲外
			return EAttackStep.CloseTo;
		
		Attack();									//攻撃
		return EAttackStep.Attack;
	}
	
	/// <summary>
	/// 攻撃範囲内か
	/// </summary>
	/// <returns></returns>
	private bool IsInAttackRange(GameObject target)
	{
		float distance = CalcDistance(target.transform.position);	//距離計算
		return distance < attackRadius * attackRadius;				//範囲内
	}

	/// <summary>
	/// 他のユニットと自身との距離二乗
	/// </summary>
	/// <param name="other">他のユニットの位置情報</param>
	/// <returns></returns>
	private float CalcDistance(Vector3 other)
	{
		return (other - transform.position).sqrMagnitude;
	}
}
