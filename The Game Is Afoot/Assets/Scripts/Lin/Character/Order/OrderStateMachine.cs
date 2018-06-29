//-----------------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクター指令のステートマシン（System側）
//-----------------------------------------------
using System.Collections;
using System.Collections.Generic;
using CharacterOrder;

public class OrderStateMachine
{
	private IOrderState[] orderStates;		//各種の指令
	private EOrder currentOrder;			//現在の指令
	private EOrder nextOrder;				//次の指令

	public OrderStateMachine()
	{
		InitOrders();

		currentOrder = EOrder.Idle;			//初期状態をIdleにする
		nextOrder = EOrder.Null;			//Nullに指定
	}

	/// <summary>
	/// 指令を初期化
	/// </summary>
	private void InitOrders()
	{
		orderStates = new IOrderState[(int)EOrder.Null];						//配列初期化
		for(int i = 0; i < (int)EOrder.Null; ++i)								//中身作成
		{
			orderStates[i] = OrderStateFactory.CreateOrderState((EOrder)i);		//ファクトリーから取る
		}
	}

	/// <summary>
	/// 指令を更新
	/// </summary>
	private void UpdateOrder()
	{
		if(nextOrder == EOrder.Null)		//指令がない場合は現在のステートBaseで決定
		{
			ExcuteNextOrder();				//現在ステートの次の指令
			return;
		}
		ExcuteReceivedOrder(true);			//受けた指令を実行
	}

	/// <summary>
	/// 受けた指令を実行
	/// </summary>
	private void ExcuteReceivedOrder(bool orderbyPlayer)
	{
		orderStates[(int)currentOrder].EndProcess();					//現在の指令を終了
		orderStates[(int)nextOrder].StartProcess(currentOrder);			//受けた指令を初期化
		orderStates[(int)nextOrder].Excute(orderbyPlayer);				//受けた指令を実行
		currentOrder = nextOrder;			//現在状態更新
		nextOrder = EOrder.Null;			//次の指令をNULLにする
	}

	/// <summary>
	/// 次の指令がない場合の処理
	/// </summary>
	private void ExcuteNextOrder()
	{
		nextOrder = orderStates[(int)currentOrder].NextOrder();			//次の指令を設定
		ExcuteReceivedOrder(false);										//実行
	}

	/// <summary>
	/// 命令を受ける
	/// </summary>
	/// <param name="order">指令</param>
	public void ReceiveOrder(EOrder order)
	{
		nextOrder = order;					//次の指令を記録
		UpdateOrder();						//更新
	}
}
