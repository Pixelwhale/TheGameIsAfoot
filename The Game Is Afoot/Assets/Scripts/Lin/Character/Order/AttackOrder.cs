﻿//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：攻撃指令
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;

public class AttackOrder : IOrderState
{
    public void EndProcess()
    {
    }

    public void Excute(bool orderByPlayer)
    {
        
    }

    public EOrder NextOrder()
    {
        return EOrder.Attack;
    }

    public void StartProcess(EOrder previousOrder)
    {
    }
}