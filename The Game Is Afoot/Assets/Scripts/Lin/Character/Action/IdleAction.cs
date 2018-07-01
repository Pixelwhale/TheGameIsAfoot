//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：待機、集合の行動
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : ICharaAction
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
        return EAction.Idle;
    }

    public void StartProcess(EAction lastAction)
    {
    }

    public void Update(GameObject unit)
    {
    }
}
