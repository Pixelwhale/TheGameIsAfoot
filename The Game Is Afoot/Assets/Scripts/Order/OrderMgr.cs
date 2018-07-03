using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMgr : MonoBehaviour
{
    private EOrder currentOrder;
    private EOrder previousOrder;
    private List<EOrder> nextOrders;
    private byte orderCapacity;

    public GameObject charaMgr;			//charaMgrに指示を発送する
    private Timer timer;
    private float interval;				//秒数ことに指示を発送する

    void Start()
    {
        currentOrder = EOrder.Idle;
        orderCapacity = 2;
        nextOrders = new List<EOrder>(orderCapacity);

        interval = 2.0f;
        timer = new Timer(interval);
    }

    void Update()
    {
        timer.Update();
        if (timer.IsTime())
        {
            timer.Initialize();
			CheckNextOrder();
            AnnounceOrder();
        }
    }

	/// <summary>
	/// 指示をqueueの最後に追加する。
	/// queueの容量超えるとき追加しない。
	/// </summary>
    public void PushOrder(EOrder order)
    {
        if (nextOrders.Count == orderCapacity) return;
        nextOrders.Add(order);
    }

    private void PopOrder()
    {
        nextOrders.RemoveAt(0);
    }

	/// <summary>
	/// 指定インデックスの指示を消す。
	/// </summary>
    public void CancelOrder(int index)
    {
        nextOrders.RemoveAt(index);
    }

    private void CheckNextOrder()
    {
        //次の指示がある場合
        if (nextOrders.Count != 0)
        {
            previousOrder = currentOrder;
            currentOrder = nextOrders[0];
            PopOrder();
            return;
        }

        //次の指示がない場合
        //後退回避かジャンプ回避後は前の指示をプッシュする。
        //他の指示なら同じ指示をプッシュする。
        if (currentOrder == EOrder.BackStep || currentOrder == EOrder.JumpEvasion)
        {
            currentOrder = previousOrder;
        }
    }

    private void AnnounceOrder()
    {
        charaMgr.GetComponent<CharacterManager>().PushOrder(currentOrder);
    }
}
