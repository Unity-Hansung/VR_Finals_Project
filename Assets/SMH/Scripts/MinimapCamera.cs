using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform target;    // 플레이어 Transform
    public Vector3 offset = new Vector3(0f, 20f, 0f);
    public bool rotateWithTarget = false;

    void LateUpdate()
    {
        if (target == null) return;

        // 위치는 항상 캐릭터 위에 고정
        transform.position = target.position + offset;

        // 회전 고정 (북쪽이 항상 위) or 플레이어 방향에 맞춰 회전
        if (rotateWithTarget)
        {
            // Y축 회전만 따라가게
            Vector3 euler = transform.eulerAngles;
            euler.y = target.eulerAngles.y;
            transform.eulerAngles = euler;
        }
        else
        {
            // 항상 위에서 내려다보는 각도로 고정 (예: (90, 0, 0))
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}
