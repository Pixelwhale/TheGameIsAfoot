//-----------------------------------------
// 作成日：2018.07.01
// 作成者：林 佳叡
// 内容：探知範囲内の段階
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttackState;

public class AttackStepFind : IAttackStep
{
	private EAttackStep nextStep = EAttackStep.Find;

    public bool IsEnd()
    {
        return nextStep != EAttackStep.Find;					//状態変わる時
    }

    public IAttackStep NextStep()
    {
        return AttackStepFactory.CreateStep(nextStep);
    }

    void IAttackStep.Update(AttackComponent attackComponent)
    {
        nextStep = attackComponent.FindUnit();					//ターゲットを探す
    }
}
