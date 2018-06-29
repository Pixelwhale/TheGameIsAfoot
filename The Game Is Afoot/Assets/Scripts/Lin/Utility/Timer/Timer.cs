//-----------------------------------------
// 作成日：2018.06.29
// 作成者：林 佳叡
// 内容：Unity用のTimerクラス
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
	private ETimerType timerType;
	private float currentTime;
	private float limitTime;			//上限

	public Timer(float second, ETimerType type = ETimerType.ScaledTime)
	{
		timerType = type;
		limitTime = second;
		Initialize();
	}

	/// <summary>
	/// 初期化処理
	/// </summary>
	public void Initialize()
	{
		currentTime = limitTime;
	}

	/// <summary>
	/// 最大秒数を変える
	/// </summary>
	/// <param name="second">秒</param>
	public void ChangeLimitTime(float second) { limitTime = second; }

	/// <summary>
	/// 更新処理
	/// </summary>
	public void Update()
	{
		if(currentTime <= 0)						//0以下は更新しない
			return;

		if(timerType == ETimerType.ScaledTime)		//ScaledTime
		{
			currentTime -= Time.deltaTime;			//経過時間を減らす
			return;
		}
		currentTime -= Time.unscaledDeltaTime;		//実際の経過時間を減らす
	}
	
	/// <summary>
	/// Time比率
	/// </summary>
	/// <param name="isFromZero">0から1に変化するか</param>
	/// <returns></returns>
	public float Rate(bool isFromZero = false)
	{
		if(isFromZero)								//0から増える場合
			return 1 - (currentTime / limitTime);	//1-rate

		return currentTime / limitTime;				//比率そのまま
	}

	/// <summary>
	/// 時間になったか
	/// </summary>
	/// <returns></returns>
	public bool IsTime() { return currentTime <= 0; }
}
