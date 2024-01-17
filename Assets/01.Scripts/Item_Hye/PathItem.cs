using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathItem : MonoBehaviour
{
    public string itemName = "SpecialItem";  // �������� �̸�

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PathController pathController = other.GetComponent<PathController>();
            if (pathController != null)
            {
                // �������� �̸��� �����Ͽ� ȹ�� ���θ� ó��
                pathController.AcquireItem(itemName);
            }

            // ������ ��Ȱ��ȭ �Ǵ� ���� ���� �߰� ���� ����
            gameObject.SetActive(false);
        }
    }
}
