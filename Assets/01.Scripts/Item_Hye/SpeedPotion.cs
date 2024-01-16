using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPotion : MonoBehaviour
{

    public float speedBoostAmount = 2f; //속도 증가량
    public float duration = 5f;  //아이템 지속 시간

    //속도 아이템 사용
    public void UseSpeedPotion(PlayerController player)
    {
        player.ApplySpeedPotion(speedBoostAmount);
        StartCoroutine(ResetSpeedAfterDelay(player, duration));
    }

    //일정 시간이 지나면, 원래의 속도로 돌아옴.
    private IEnumerator ResetSpeedAfterDelay(PlayerController player, float delay)
    {
        yield return new WaitForSeconds(delay);
        player.ResetSpeed();
    }
}
