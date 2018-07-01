//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクター行動のファクトリー
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;

namespace CharacterAction
{
	public class ActionStateFactory
	{
		/// <summary>
		/// 指定の行動状態を作成するファクトリーデザインパターン
		/// </summary>
		/// <param name="actionType">アクションタイプ</param>
		/// <returns></returns>
		public static ICharaAction CreateActionState(EAction actionType)
		{
			switch(actionType)
			{
				case EAction.Attack:
					return new AttackAction();
				default:
					return new IdleAction();
			}
		}
	}
}
