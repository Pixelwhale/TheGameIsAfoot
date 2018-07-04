//-----------------------------------------
// 作成日：2018.07.01
// 作成者：林 佳叡
// 内容：キャラクター管理者
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour 
{
	[SerializeField]
	private List<GameObject> playerUnits;		//Todo:自動作成に変更

	void Start()
	{

	}

	void Update()
	{

	}

	/// <summary>
	/// PlayerUnitに指令を送る
	/// </summary>
	/// <param name="order">指令</param>
	public void PushOrder(EOrder order)
	{
		for(int i = 0; i < playerUnits.Count; ++i)
		{
			playerUnits[i].GetComponent<ActionStateMachine>().ExecuteOrder(order);
		}
	}
}
