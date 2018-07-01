//-----------------------------------------
// 作成日：2018.07.01
// 作成者：林 佳叡
// 内容：攻撃段階
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackState
{
	public interface IAttackStep
	{
		void Update(AttackComponent attackComponent);
		bool IsEnd();
		IAttackStep NextStep();
	}
}
