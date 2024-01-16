using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPotion : MonoBehaviour
{

    public float speedBoostAmount = 2f; //�ӵ� ������
    public float duration = 5f;  //������ ���� �ð�

    //�ӵ� ������ ���
    public void UseSpeedPotion(PlayerController player)
    {
        player.ApplySpeedPotion(speedBoostAmount);
        StartCoroutine(ResetSpeedAfterDelay(player, duration));
    }

    //���� �ð��� ������, ������ �ӵ��� ���ƿ�.
    private IEnumerator ResetSpeedAfterDelay(PlayerController player, float delay)
    {
        yield return new WaitForSeconds(delay);
        player.ResetSpeed();
    }
}
