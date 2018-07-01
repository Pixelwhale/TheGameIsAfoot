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
		/// <summary>
		/// 指定の指令状態を作成するファクトリーデザインパターン
		/// </summary>
		/// <param name="order">オーダータイプ</param>
		/// <returns></returns>
		public static IOrderState CreateOrderState(EOrder order, CharacterManager characterManager)
		{
			switch(order)
			{
				case EOrder.Attack:
					return new AttackOrder(characterManager);
				default:
					return new IdleOrder(characterManager);
			}
		}
	}
}
