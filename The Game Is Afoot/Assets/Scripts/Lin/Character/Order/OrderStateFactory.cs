//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクター指令のファクトリー
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;

namespace CharacterOrder
{
	public class OrderStateFactory
	{
		public static IOrderState CreateOrderState(EOrder order)
		{
			switch(order)
			{
				case EOrder.Attack:
					return new AttackOrder();
			}
			return new AttackOrder();
		}
	}
}
