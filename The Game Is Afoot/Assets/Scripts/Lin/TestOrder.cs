//Test用　後で削除
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOrder : MonoBehaviour 
{
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Q))
			GetComponent<PlayerOrderSystem>().AddOrder(EOrder.Idle);
		if(Input.GetKeyDown(KeyCode.W))
			GetComponent<PlayerOrderSystem>().AddOrder(EOrder.Attack);
	}
}
