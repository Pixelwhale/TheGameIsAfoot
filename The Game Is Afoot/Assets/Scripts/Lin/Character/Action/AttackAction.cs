//-----------------------------------------
// 作成日：2018.07.01
// 作成者：林 佳叡
// 内容：攻撃の行動
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : ICharaAction
{
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
		Debug.Log("攻撃だ！");
    }

    public void Update()
    {
    }
}
