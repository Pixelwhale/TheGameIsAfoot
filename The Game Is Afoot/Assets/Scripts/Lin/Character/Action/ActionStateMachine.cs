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
    private ICharaAction currentAction;             //現在の行動
    private EAction currentState;                   //現在の状態

    void Start()
    {
        skillManager = new SkillManager(charaModel.GetSkills());
        currentAction = ActionStateFactory.CreateActionState(EAction.Idle);
        currentAction.StartProcess(EAction.Idle);
        currentState = EAction.Idle;
    }

    void Update()
    {
        currentAction.Update();                                                     //状態更新
        if(currentAction.IsEnd())                                                   //終了の場合
            ChangeActionState(currentAction.NextAction());                          //次の行動をとる
    }

    /// <summary>
    /// 指令を実行
    /// </summary>
    /// <param name="order">指令</param>
    public void ExcuteOrder(EOrder order)
    {
        bool launch = skillManager.AddOrder(order);                                 //Player入力ならスキル発動チェック
        if(launch)
        {
            //Todo Skill状態（アニメションなど必要な処理）
            return;
        }
        ChangeActionState((EAction)order);                                          //発動しなかった場合は指令を実行
    }

    /// <summary>
    /// 状態を切り替え
    /// </summary>
    private void ChangeActionState(EAction actionType)
    {
        EAction previous = currentState;                                            //現在の状態を記録
        currentState = actionType;                                                  //新状態を指定
        currentAction.EndProcess();                                                 //現在の行動を終了処理
        currentAction = ActionStateFactory.CreateActionState(currentState);         //新行動を指定
        currentAction.StartProcess(previous);                                       //行動を初期化処理
    }
}
