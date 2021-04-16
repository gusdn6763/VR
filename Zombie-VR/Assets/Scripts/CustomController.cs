using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomController : MonoBehaviour
{
    //����̽� �𵨵�
    [SerializeField] private List<GameObject> controllerModels;
    private Animator handAnimator;
    private GameObject controllerInstance; //����̽� ������Ʈ
    private GameObject handInstance;       //hand ������Ʈ
    public InputDevice availableDevice;   //����� ��Ʈ�ѷ��� �������� �˷���

    public GameObject HandGun;
    public bool triggerButton;
    //����̽� �Ӽ����� ���� => ����� ���� ����̽��� ������ ������ ������
    //������� ���Ƿ� �������� ����̽� ���� �ѹ�
    public InputDeviceCharacteristics characteristics;

    public GameObject handModel;          //hand��
    public bool renderController = false; //hand���� ��Ʈ�ѷ����� Ȯ���ϴ� ����

    private void Start()
    {
        TryInitialize();
    }

    //���̺����� ��ŧ���� ����Ʈ���� Ȯ���ϰ� �������ִ� �Լ�
    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        //��Ʈ�ѷ��� �Է¹ޱ� ���� ����ϴ� ��
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        foreach (var device in devices)
        {
            //���ᰡ���� ����̽� �Ӽ��� ��������
            Debug.Log($"Available Device Name: {device.name}, Characteristic: {device.characteristics}");
        }
        //���� ������ ����̽��� 1�� �̻��ϰ��
        if (devices.Count > 0)
        {
            availableDevice = devices[0];

            //Oculus Quest Controller�� ���������� �ν��ؼ� �������̸��� �νĽ� �Ź������� �̸��� �ٲ۴�.
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
            //9�� ���� ã�Ƽ� 3D���� ã������
            if (currentControllerModel)
            {
                controllerInstance = Instantiate(currentControllerModel, transform);
            }
            //�����صа� ������� �⺻ �𵨷� �������
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
        //��밡���� ����̽��� ������ �ٽ� ȣ��
        //���� ��� ��뵵�� ���͸��� ������
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
            // ���� ���� �׼����Ϸ��� �õ��ϸ� ������ ��ȯ
            //Ư�� ��� ���� �˻��ؼ� �������� true�� ��ȯ�մϴ�.
            //���� ��Ⱑ Ư�� ����� �������� �ʰų�, ��Ⱑ ��ȿ���� ���� ���(��: ��Ʈ�ѷ� ��Ȱ��) false�� ��ȯ�մϴ�.
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
