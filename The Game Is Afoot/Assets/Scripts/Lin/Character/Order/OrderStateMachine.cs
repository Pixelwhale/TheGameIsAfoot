//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクター指令のステートマシン
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using CharacterOrder;

public class OrderStateMachine
{
	private IOrderState[] orderStates;

	public OrderStateMachine()
	{
		orderStates = new IOrderState[(int)EOrder.Null];
		for(int i = 0; i < (int)EOrder.Null; ++i)
		{
			orderStates[i] = OrderStateFactory.CreateOrderState((EOrder)i);
		}
	}
}
