//-----------------------------------------------------
// 作成日：2018.06.30
// 作成者：林 佳叡
// 内容：キャラクタースキルを管理するクラス
//-----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterAction;

public class SkillManager
{
	private CharacterSkillModel[] skillModels;						//スキル設定のモデル
	private Queue<EOrder> inputOrder;               				//入力された指令を保存する容器
	private int queueSize;											//OrderQueueのサイズ

	public SkillManager(CharacterSkillModel[] skillModels)
	{
		this.skillModels = skillModels;
		InitOrderQueue();
	}

	/// <summary>
    /// Queueの長さと中身を初期化
    /// </summary>
    private void InitOrderQueue()
    {
        queueSize = 0;                                          	//Queueのサイズを宣言
        for(int i = 0; i < skillModels.Length; ++i)            		//キャラ全部のスキルを一周
        {
            int count = skillModels[i].SkillOrderCount();   		//スキルの指令数を取得
            queueSize = Mathf.Max(queueSize, count);                //大きい方を取る
        }

        inputOrder = new Queue<EOrder>(queueSize);                  //Queueを作成
    }


	public bool AddOrder(EOrder order)
	{
		inputOrder.Enqueue(order);                                  //Queueに追加
        for(int i = 0; i < skillModels.Length; ++i)            		//キャラ全部のスキルを一周
        {
            bool launch = CheckSkill(skillModels[i].SkillOrder());  //SkillOrderをチェック
            if(launch)                                              //Trueの場合スキル発動
            {
                //Todo Skill i　を発動
                return true;
            }
        }
        return false;                                                //Skill発動しない場合
	}

	//Todo Skillクラスに任せる
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
