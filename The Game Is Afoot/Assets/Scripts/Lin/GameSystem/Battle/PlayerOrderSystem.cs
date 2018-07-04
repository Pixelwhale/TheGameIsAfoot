//-----------------------------------------------
// 作成日：2018.06.30
// 作成者：林 佳叡
// 内容：Playerの入力とキャラクターのやり取りをする
//		仲介クラス
//-----------------------------------------------
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerOrderSystem : MonoBehaviour 
{
	[SerializeField]
	private CharacterManager characterManager;		//キャラクター管理者

	[SerializeField]
	private float loadOrderSecond = 2.0f;			//何秒ごとに指示を出す
	private Timer orderTimer;						//時間を計算するタイマー
	[SerializeField]
	private int orderStackCount = 3;				//Orderが溜まれる数
	[SerializeField]
	private EOrder[] orders;						//実行を待っている指令
	private int orderCount;							//指令数

	void Start () 
	{
		orderTimer = new Timer(loadOrderSecond);
		orderTimer.Initialize();
		orders = Enumerable.Repeat<EOrder>(EOrder.Null, orderStackCount).ToArray();			//Null指令で初期化
		orderCount = 0;
	}	
	
	void Update () 
	{
		UpdateTimer();								//タイマー更新	
		UpdateOrder();								//指令更新
	}

	/// <summary>
	/// タイマーを更新
	/// </summary>
	private void UpdateTimer()
	{
		if(!orderTimer.IsTime())					//時間になっていなければ
			orderTimer.Update();					//タイマー更新
	}

	/// <summary>
	/// 指令をキャラクター達へ
	/// </summary>
	private void UpdateOrder()
	{
		if(!orderTimer.IsTime())					//時間になっていなければ実行しない
			return;
		if(orders[0] == EOrder.Null)				//指令がなければ実行しない
			return;

		characterManager.PushOrder(orders[0]);		//先端指令を送る
		orderTimer.Initialize();					//CoolDownTime reset
		ShiftOrder(0);								//先端から指令をずらす
	}

	/// <summary>
	/// Stackされた指令を一個ずらす
	/// </summary>
	private void ShiftOrder(int startIndex)
	{
		for(int i = startIndex; i < orders.Length; ++i)
		{
			if(i == orders.Length - 1)				//末尾はNULLにする
			{
				orders[i] = EOrder.Null;
				--orderCount;						//一個指令削除
				break;
			}
			orders[i] = orders[i + 1];				//一個ずらす
		}
	}

	/// <summary>
	/// 指令を取り消す
	/// </summary>
	public void CancelOrder(int index)
	{
		index = Mathf.Clamp(index, 0, orders.Length);		//Bug対策
		ShiftOrder(index);							//Index番から後ろを一個前にずらす
	}
	
	/// <summary>
	/// 指令を追加
	/// </summary>
	public void AddOrder(EOrder newOrder)
	{
		if(orderCount >= orderStackCount)			//最大数以上なら追加できない
			return;
		orders[orderCount] = newOrder;				//末尾指定
		++orderCount;
	}
}
