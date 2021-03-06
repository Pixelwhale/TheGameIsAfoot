﻿//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクター行動インターフェース
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharaAction
{
    void StartProcess(EAction lastAction);
	void Update(GameObject unit);
    void EndProcess();

    EAction NextAction();
    bool IsEnd();
}
