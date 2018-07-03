using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill : MonoBehaviour
{
    [SerializeField]
    private EOrder[] skillList;
    private int counter = 0;
    private bool skillOn = false;

    public void ReceiveOrder(EOrder order)
    {
        if (skillOn) return;
        CheckSkill(order);
    }

    private void CheckSkill(EOrder order)
    {
        if (order != skillList[counter])
        {
            counter = 0;
            return;
        }
		
        ++counter;
        if (counter == skillList.Length)
        {
            skillOn = true;
            //state = skill state
        }

    }
}
