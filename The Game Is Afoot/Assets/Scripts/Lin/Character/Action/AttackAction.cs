//-----------------------------------------
// 作成日：2018.07.01
// 作成者：林 佳叡
// 内容：攻撃の行動
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttackState;

public class AttackAction : ICharaAction
{
  private IAttackStep currentStep;    //現在の攻撃状態

  public void EndProcess()
  {
  }

  public bool IsEnd()
  {
		return false;
  }

  public EAction NextAction()
  {
		return EAction.Attack;
  }

  public void StartProcess(EAction lastAction)
  {
    currentStep = AttackStepFactory.CreateStep(EAttackStep.Find);   //ターゲットを探す
  }

  public void Update(GameObject unit)
  {
    currentStep.Update(unit.GetComponent<AttackComponent>());       //更新
    if(currentStep.IsEnd())                                         //終了の場合
      currentStep = currentStep.NextStep();                         //次のステップ
  }
}
