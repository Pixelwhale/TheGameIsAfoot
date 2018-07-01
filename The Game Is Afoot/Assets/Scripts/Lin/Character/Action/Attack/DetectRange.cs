//-----------------------------------------
// 作成日：2018.07.01
// 作成者：林 佳叡
// 内容：探知範囲
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DetectRange : MonoBehaviour 
{
	private CircleCollider2D detect;					//探知コライダー
	private List<GameObject> oppsiteUnits;				//反対陣営のユニット

	void Start()
	{
		detect = GetComponent<CircleCollider2D>();
		oppsiteUnits = new List<GameObject>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		oppsiteUnits.Add(other.gameObject);				//範囲内Listに追加
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		oppsiteUnits.Remove(other.gameObject);			//Listから削除
	}

	/// <summary>
	/// 探知範囲変更
	/// </summary>
	/// <param name="radius">半径</param>
	public void ChangeDetectRadius(float radius)
	{
		detect.radius = radius;
	}

	/// <summary>
	/// 範囲内に攻撃目標いるか
	/// </summary>
	/// <returns></returns>
	public bool IsOppsiteUnitIn()
	{
		oppsiteUnits.RemoveAll(g => !g);				//死んだObｊを削除
		return oppsiteUnits.Count > 0;					//生きているObjがあればTrue
	}

	/// <summary>
	/// 一番近いユニットを取得
	/// </summary>
	/// <returns></returns>
	public GameObject FindNearest()
	{
		int index = 0;									//0番から
		float distance = CalcDistance(oppsiteUnits[index].transform.position);		//距離を取る
		for(int i = 1; i < oppsiteUnits.Count; ++i)		//残りと比較する
		{
			float dist = CalcDistance(oppsiteUnits[i].transform.position);			//距離を計算
			if(dist < distance)							//近いなら
			{
				index = i;								//番号を記録
				distance = dist;						//距離を更新
			}
		}
		return oppsiteUnits[index];
	}

	/// <summary>
	/// 範囲内のユニットを取得
	/// </summary>
	/// <returns></returns>
	public List<GameObject> GetAllInRange()
	{
		return oppsiteUnits;
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
