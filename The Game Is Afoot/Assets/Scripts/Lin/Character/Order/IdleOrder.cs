//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：待機、集合の指令
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;

public class IdleOrder : IOrderState
{
    private CharacterManager characterManager;                  //キャラクター管理者
    public IdleOrder(CharacterManager characterManager)
    {
        this.characterManager = characterManager;
    }

    public void EndProcess()
    {
    }

    public void Excute()
    {
        characterManager.PushOrder(EOrder.Idle);
    }

    public EOrder NextOrder()
    {
        return EOrder.Idle;
    }

    public void StartProcess(EOrder previousOrder)
    {
    }
}
