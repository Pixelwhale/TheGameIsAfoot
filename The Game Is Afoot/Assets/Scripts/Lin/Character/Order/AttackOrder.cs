//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：攻撃指令
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;

public class AttackOrder : IOrderState
{
    private CharacterManager characterManager;                  //キャラクター管理者
    public AttackOrder(CharacterManager characterManager)
    {
        this.characterManager = characterManager;
    }
    public void EndProcess()
    {
    }

    public void Excute()
    {
        characterManager.PushOrder(EOrder.Attack);
    }

    public EOrder NextOrder()
    {
        return EOrder.Attack;
    }

    public void StartProcess(EOrder previousOrder)
    {
    }
}
