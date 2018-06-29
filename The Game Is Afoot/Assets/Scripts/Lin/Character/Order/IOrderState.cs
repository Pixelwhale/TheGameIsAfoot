//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクター指令インターフェース
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;

public interface IOrderState
{
    void StartProcess(EOrder previousOrder);
    void Excute(bool orderByPlayer);                //各キャラクターに知らせる
    void EndProcess();
	EOrder NextOrder();
}
