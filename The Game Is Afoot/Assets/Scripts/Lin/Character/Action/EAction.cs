//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクターアクションの列挙型
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;

public enum EAction
{
    Move = 0,           //移動
    Attack = 1,         //攻撃
    Defence = 2,        //防御
    Charge = 3,         //チャージ
    BackStep = 4,       //後退回避
    JumpEvasion = 5,    //ジャンプ回避
    Idle = 6,           //待機、集合
	Skill = 7,

    Null,               //Enumの最後に置く
}
