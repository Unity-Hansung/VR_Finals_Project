using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateController : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 3f;
    Quaternion defaultRotation;      // y : 35
    Quaternion targetRotation;              // y :-38

    void Start()
    {
        defaultRotation = transform.rotation;
        targetRotation = defaultRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

    public void SetTargetRotation(Vector3 eulerAngles)
    {
        targetRotation = Quaternion.Euler(eulerAngles);
    }

    public void SetDefaultRotation()
    {
        targetRotation = defaultRotation;
    }
}
