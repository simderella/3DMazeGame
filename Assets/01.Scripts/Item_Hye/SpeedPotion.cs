using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPotion : Item
{

    public float speedBoostAmount; //속도 증가량
    public float duration;  //아이템 지속 시간

    //속도 포션 사용
    public void UseSpeedPotion()
    {
        //속도 포션 사용 로직 필요.
        Debug.Log("Using speed potion: " + itemName + ", Speed Boost: " + speedBoostAmount);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
