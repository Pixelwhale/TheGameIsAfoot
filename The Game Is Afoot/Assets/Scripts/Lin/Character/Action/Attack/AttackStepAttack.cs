//-----------------------------------------
// 作成日：2018.07.01
// 作成者：林 佳叡
// 内容：攻撃段階
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttackState;

public class AttackStepAttack : IAttackStep
{
	private EAttackStep nextStep = EAttackStep.Attack;

    public bool IsEnd()
    {
        return nextStep != EAttackStep.Attack;					//状態変わる時
    }

    public IAttackStep NextStep()
    {
        return AttackStepFactory.CreateStep(nextStep);
    }

    public void Update(AttackComponent attackComponent)
    {
        nextStep = attackComponent.AttackTarget();				//Targetを攻撃
    }
}
