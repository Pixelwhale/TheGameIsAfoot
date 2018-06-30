//-----------------------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクター行動パターンを管理するクラス（Chara側）
//-----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterAction;

public class ActionStateMachine : MonoBehaviour
{
    [SerializeField]
    private CharacterDataModel charaModel;          //キャラの設定ファイル
    private SkillManager skillManager;              //SkillManager
    private ICharaAction currentState;              //現在状態

    void Start()
    {
        skillManager = new SkillManager(charaModel.GetSkills());
        currentState = ActionStateFactory.CreateActionState(EOrder.Idle);
    }

    void Update()
    {
        currentState.Update();                      //状態更新
    }

    /// <summary>
    /// 指令を実行
    /// </summary>
    /// <param name="order">指令</param>
    /// <param name="orderByPlayer">プレイヤーから入力されたか</param>
    public void ExcuteOrder(EOrder order, bool orderByPlayer)
    {
        if(!orderByPlayer)
        {
            ChangeActionState(ActionStateFactory.CreateActionState(order));
            return;
        }
        
        skillManager.AddOrder(order);           //Player入力ならスキルチェック
    }

    /// <summary>
    /// 状態を切り替え
    /// </summary>
    /// <param name="newState">新しい状態</param>
    private void ChangeActionState(ICharaAction newState)
    {
        currentState.EndProcess();              //現在の状態を終了処理
        currentState = newState;                //新状態を指定
        newState.StartProcess();                //状態を初期化処理
    }
}
