//-----------------------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：キャラクター行動パターンを管理するクラス（Chara側）
//-----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStateMachine
{
    private CharacterDataModel charaModel;          //キャラの設定ファイル
    private Queue<EOrder> inputOrder;               //入力された指令を保存
    private ICharaAction currentState;              //現在状態
    
	public ActionStateMachine(CharacterDataModel statusFile)
    {
        charaModel = statusFile;
        InitOrderQueue();                           //Queueを初期化
    }

    /// <summary>
    /// Queueの長さと中身を初期化
    /// </summary>
    private void InitOrderQueue()
    {
        int queueSize = 0;                                          //Queueのサイズを宣言
        for(int i = 0; i < charaModel.SkillCount(); ++i)            //キャラ全部のスキルを一周
        {
            int count = charaModel.GetSkill(i).SkillOrderCount();   //スキルの指令数を取得
            queueSize = Mathf.Max(queueSize, count);                //大きい方を取る
        }

        inputOrder = new Queue<EOrder>(queueSize);                  //Queueを作成
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public void Update()
    {
        currentState.Update();
    }

    /// <summary>
    /// 指令を実行
    /// </summary>
    /// <param name="order">指令</param>
    /// <param name="orderByPlayer">プレイヤーから入力されたか</param>
    public void ExcuteOrder(EOrder order, bool orderByPlayer)
    {
        if(orderByPlayer)
        {
            UpdateSkillOrder(order);
            return;
        }
        
        //Todo　指定のActionに切り替わる
    }
    
    /// <summary>
    /// 指令を更新
    /// </summary>
    private void UpdateSkillOrder(EOrder order)
    {
        inputOrder.Enqueue(order);                                  //Queueに追加
        for(int i = 0; i < charaModel.SkillCount(); ++i)            //キャラ全部のスキルを一周
        {
            bool launch = CheckSkill(charaModel.GetSkill(i).SkillOrder());              //SkillOrderをチェック
            if(launch)                                              //Trueの場合スキル発動
            {
                //Todo Skill i　を発動
                return;
            }
        }
        //Todo　指定のActionに切り替わる                              //Skill発動しない場合
    }

    /// <summary>
    /// スキル発動するかをチェック
    /// </summary>
    /// <param name="skill">スキル指令の配列</param>
    /// <returns></returns>
    private bool CheckSkill(EOrder[] skill)
    {
        int launchCount = skill.Length;                                                 //発動の数
        int currentCount = 0;                                                           //現在合致している数
        EOrder[] currentOrder = inputOrder.ToArray();
        for(int i = 0; i < currentOrder.Length; ++i)                                    //入力された指令を一周
        {
            if(currentOrder[i] != skill[currentCount])                                  //一致していない場合は計算リセット
            {
                currentCount = 0;
                continue;
            }

            currentCount++;                                                             //一致している場合は増やす
            if(currentCount >= launchCount) return true;                                //発動の数とあっていればTrue
            if(launchCount - currentCount < currentOrder.Length - i) return false;      //残りが不可能の場合
        }
        return false;
    }
}
