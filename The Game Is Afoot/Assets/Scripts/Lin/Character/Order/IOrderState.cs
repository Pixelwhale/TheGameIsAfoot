//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクター指令インターフェース
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;

public interface IOrderState
{
    void StartProcess(EOrder previousOrder);        //回避後状態を戻るやUI表示など
    void Excute();                                  //各キャラクターに知らせる
    void EndProcess();                              //主にUI表示
	EOrder NextOrder();                             //回避など必要に応じて取る
}
