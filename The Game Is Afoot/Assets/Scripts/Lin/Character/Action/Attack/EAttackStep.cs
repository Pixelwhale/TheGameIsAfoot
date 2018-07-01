//-----------------------------------------
// 作成日：2018.07.01
// 作成者：林 佳叡
// 内容：攻撃段階の列挙型
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;

public enum EAttackStep
{
	Find = 0,
	CloseTo = 1,
	Attack = 2,
	Null,
}
