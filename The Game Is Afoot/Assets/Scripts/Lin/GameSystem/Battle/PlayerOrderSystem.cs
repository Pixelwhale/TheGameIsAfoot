﻿//-----------------------------------------------
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
	private OrderStateMachine orderStateMachine;	//指令状態を管理するクラス

	[SerializeField]
	private float loadOrderSecond = 2.0f;			//何秒ごとに指示を出す
	private Timer orderTimer;						//時間を計算するタイマー
	private bool loadOrder;							//指令を読み込むフラグ
	[SerializeField]
	private int orderStackCount = 3;				//Orderが溜まれる数
	private EOrder[] orders;						//実行を待っている指令
	private int orderCount;							//指令数

	void Start () 
	{
		orderStateMachine = new OrderStateMachine();
		orderTimer = new Timer(loadOrderSecond);
		orderTimer.Initialize();
		loadOrder = false;
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
		loadOrder = false;							//指令を読み込むフラグ
		orderTimer.Update();						//タイマー更新
		if(orderTimer.IsTime())						//時間に来たら
		{
			orderTimer.Initialize();				//タイマー初期化
			loadOrder = true;						//指令を読み込むフラグをTrue
		}
	}

	/// <summary>
	/// 指令をキャラクター達へ
	/// </summary>
	private void UpdateOrder()
	{
		if(!loadOrder)								//Loadできなければ戻る
			return;

		orderStateMachine.ReceiveOrder(orders[0]);	//先端指令を送る
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
