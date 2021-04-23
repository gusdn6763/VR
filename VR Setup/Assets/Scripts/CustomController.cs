using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomController : MonoBehaviour
{
    public bool renderController = false;
    public InputDeviceCharacteristics characteristics;
    public GameObject handModel;

    [SerializeField]
    private List<GameObject> controllerModels;
    private GameObject controllerInstance;
    private GameObject handInstance;
    private InputDevice availableDevice;
    private Animator handModelAnimator;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(!availableDevice.isValid)
        {
            TryInitialize();
            return;
        }
        else
        {
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
        }
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        //오른쪽 컨트롤러를 입력받기 위해 사용하는 것
        //InputDeviceCharacteristics rightControllerCharacteristics = 
        //    InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);

        foreach (var device in devices)
        {
            Debug.Log($"Available Device Name: {device.name}, Characteristic: {device.characteristics}");

            Debug.Log("Avaialable Device Name: " + device.name + ", Characteristic: " + device.characteristics);
        }

        if (devices.Count > 0)
        {
            availableDevice = devices[0];
            GameObject currentControllerModel = controllerModels.Find(controller => controller.name == availableDevice.name);
            if (currentControllerModel)
            {
                controllerInstance = Instantiate(currentControllerModel, transform);
            }
            else
            {
                Debug.LogError("Didn't get suitable controller model");
                controllerInstance = Instantiate(controllerModels[0], transform);
            }

            handInstance = Instantiate(handModel, transform);
            handModelAnimator = handInstance.GetComponent<Animator>();
        }
    }

    void UpdateHandAnimation()
    {
        if(availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handModelAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handModelAnimator.SetFloat("Trigger", 0);
        }

        if(availableDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handModelAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handModelAnimator.SetFloat("Grip", 0);
        }
    }
}
