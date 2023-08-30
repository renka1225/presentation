using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float swingAngle = 30.0f; // �h���p�x
    public float swingSpeed = 1.0f;  // �h��鑬�x

    private float initialRotation;   // �����̉�]�p�x


    void Start()
    {
        initialRotation = transform.eulerAngles.z;   // ���݂�z���̊p�x���擾 
    }


    void Update()
    {
       float rotationZ = initialRotation + Mathf.Sin(Time.time * swingSpeed) * swingAngle;
       transform.eulerAngles = new Vector3(0, 0, rotationZ);
    }
   
}
