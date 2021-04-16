using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomController : MonoBehaviour
{
    //디바이스 모델들
    [SerializeField] private List<GameObject> controllerModels;
    private Animator handAnimator;
    private GameObject controllerInstance; //디바이스 오브젝트
    private GameObject handInstance;       //hand 오브젝트
    public InputDevice availableDevice;   //연결된 컨트롤러가 무엇인지 알려줌

    public GameObject HandGun;
    public bool triggerButton;
    //디바이스 속성들의 정의 => 연결시 여러 디바이스가 들어오기 때문에 나눠줌
    //사람들이 임의로 정의해준 디바이스 열거 넘버
    public InputDeviceCharacteristics characteristics;

    public GameObject handModel;          //hand모델
    public bool renderController = false; //hand인지 컨트롤러인지 확인하는 변수

    private void Start()
    {
        TryInitialize();
    }

    //바이브인지 오큘러스 리프트인지 확인하고 연결해주는 함수
    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        //컨트롤러를 입력받기 위해 사용하는 것
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        foreach (var device in devices)
        {
            //연결가능한 디바이스 속성이 무엇인지
            Debug.Log($"Available Device Name: {device.name}, Characteristic: {device.characteristics}");
        }
        //접속 가능한 디바이스가 1개 이상일경우
        if (devices.Count > 0)
        {
            availableDevice = devices[0];

            //Oculus Quest Controller를 구버전으로 인식해서 구버전이름을 인식시 신버전으로 이름을 바꾼다.
            string name = "";
            if ("Oculus Touch Controller - Left" == availableDevice.name)
            {
                name = "Oculus Quest Controller - Left";
            }
            else if ("Oculus Touch Controller - Right" == availableDevice.name)
            {
                name = "Oculus Quest Controller - Right";
            }
            GameObject currentControllerModel = controllerModels.Find(controller => controller.name == name);

            //GameObject currentControllerModel = controllerModels.Find(controller => controller.name == availableDevice.name);
            //9개 모델을 찾아서 3D모델을 찾아주자
            if (currentControllerModel)
            {
                controllerInstance = Instantiate(currentControllerModel, transform);
            }
            //설정해둔게 없을경우 기본 모델로 만들어줌
            else
            {
                Debug.Log("Didn't get suitable controller model");
                controllerInstance = Instantiate(controllerModels[0], transform);
            }

            handInstance = Instantiate(handModel, transform);
            handAnimator = handInstance.GetComponent<Animator>();
        }
    }

    private void Update()
    {
        //사용가능한 디바이스가 없으면 다시 호출
        //예를 들어 사용도중 배터리가 방전시
        if (!availableDevice.isValid)
        {
            TryInitialize();
            return;
        }
        if (renderController)
        {
            handInstance.SetActive(false);
            controllerInstance.SetActive(true);
        }
        else
        {
            handInstance.SetActive(true);
            controllerInstance.SetActive(false);
            UpdateHandAnimation();
        }
        if (HandGun != null)
        {
            bool menuButtonValue;
            if (availableDevice.TryGetFeatureValue(CommonUsages.triggerButton, out menuButtonValue) && menuButtonValue)
            {
                if (triggerButton == false)
                {
                    HandGun.GetComponent<SimpleShoot>().Shoot();
                    triggerButton = true;
                }
            }
            else
            {
                triggerButton = false;
            }
        }
        //if (FindObjectOfType<GameManager>().isGameOver)
        //{
        //    bool menuButtonvalue;
        //    if (availableDevice.TryGetFeatureValue(CommonUsages.menuButton, out menuButtonvalue) && menuButtonvalue)
        //    {
        //        FindObjectOfType<GameManager>().RestartGame();
        //    }
        //}

        void UpdateHandAnimation()
        {
            // 현재 값에 액세스하려고 시도하며 다음을 반환
            //특정 기능 값을 검색해서 가져오면 true를 반환합니다.
            //현재 기기가 특정 기능을 지원하지 않거나, 기기가 유효하지 않은 경우(예: 컨트롤러 비활성) false를 반환합니다.
            if (availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            {
                handAnimator.SetFloat("Trigger", triggerValue);
            }
            else
            {
                handAnimator.SetFloat("Trigger", 0);
            }

            if (availableDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            {
                handAnimator.SetFloat("Grip", gripValue);
            }
            else
            {
                handAnimator.SetFloat("Grip", 0);
            }
        }
    }
}
