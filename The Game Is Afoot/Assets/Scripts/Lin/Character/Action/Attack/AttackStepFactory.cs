//-----------------------------------------
// 作成日：2018.07.01
// 作成者：林 佳叡
// 内容：攻撃段階を作成するファクトリー
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackState
{
	public class AttackStepFactory
	{
		/// <summary>
		/// 攻撃段階を作成するファクトリー
		/// </summary>
		/// <param name="step">攻撃段階</param>
		/// <returns></returns>
		public static IAttackStep CreateStep(EAttackStep step)
		{
			switch(step)
			{
				case EAttackStep.Find:
					return new AttackStepFind();
				case EAttackStep.CloseTo:
					return new AttackStepClose();
				case EAttackStep.Attack:
					return new AttackStepAttack();
				default:
					return new AttackStepFind();
			}
		}
	}
}
