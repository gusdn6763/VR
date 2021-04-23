using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveMentProvider : MonoBehaviour
{
    private CharacterController characterController = null;     //VR Rig�� ĳ���� ��Ʈ�ѷ�
    private GameObject head = null;                             //ī�޶� �Ӹ� ��ġ

    public List<XRController> controllers = null;               //��Ʈ�ѷ� ����Ʈ (�������� ������ �� ������)
    public float speed = 1.0f;
    public float gravityMultiplier = 1f;                        //�߷¿���
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
    }

    private void Start()
    {
        PositionController();
    }
    private void Update()
    {
        PositionController(); 
        CheckForInput();
        ApplyGravity();
    }

    public void Move()
    {
        Vector3 dir = new Vector3(0, 0, 1.0f);
        Vector3 movement = dir * speed;
        characterController.Move(movement * Time.deltaTime);
    }

    //���� ��ġ ����
    void PositionController()
    {
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        characterController.height = headHeight;

        Vector3 newCenter = Vector3.zero;
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;

        characterController.center = newCenter;
    }

    void CheckForInput()
    {
        //������ ��Ʈ�ѷ��߿��� �Է��� ������ �̵�ó��
        foreach(XRController controller in controllers)
        {
            CheckForMovement(controller.inputDevice);
        }
    }

    void CheckForMovement(InputDevice device)
    {
        //���� �Է¹����� position���� ����, ���̽�ƽ�� 2�������̴�.
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            StartMove(position);
        }
    }

    //�Է¹��� ���̽�ƽ������ �̵�
    void StartMove(Vector2 position)
    {
        Vector3 direction = new Vector3(position.x, 0, position.y);
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

        direction = Quaternion.Euler(headRotation) * direction;

        Vector3 movement = direction * speed;
        characterController.Move(movement * Time.deltaTime);
    }

    //�߷� ����
    void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        gravity.y *= Time.deltaTime;
        characterController.Move(gravity * Time.deltaTime);
    }


}
