using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveMentProvider : MonoBehaviour
{
    private CharacterController characterController = null;     //VR Rig의 캐릭터 컨트롤러
    private GameObject head = null;                             //카메라 머리 위치

    public List<XRController> controllers = null;               //컨트롤러 리스트 (여러개가 설정될 수 도있음)
    public float speed = 1.0f;
    public float gravityMultiplier = 1f;                        //중력영향
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

    //현재 위치 설정
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
        //설정된 컨트롤러중에서 입력이 있으면 이동처리
        foreach(XRController controller in controllers)
        {
            CheckForMovement(controller.inputDevice);
        }
    }

    void CheckForMovement(InputDevice device)
    {
        //값을 입력받으면 position값을 배출, 조이스틱은 2차원값이다.
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            StartMove(position);
        }
    }

    //입력받은 조이스틱값으로 이동
    void StartMove(Vector2 position)
    {
        Vector3 direction = new Vector3(position.x, 0, position.y);
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

        direction = Quaternion.Euler(headRotation) * direction;

        Vector3 movement = direction * speed;
        characterController.Move(movement * Time.deltaTime);
    }

    //중력 적용
    void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        gravity.y *= Time.deltaTime;
        characterController.Move(gravity * Time.deltaTime);
    }


}
