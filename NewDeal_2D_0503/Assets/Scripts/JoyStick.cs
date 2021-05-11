using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler
{
    [SerializeField] GameObject joystickActiveRangeObj;
    [SerializeField] GameObject joystickObj;

    private RectTransform joystickActiveRange;
    private RectTransform joystick;

    public PlayerMove player;

    public Vector2 m_VecJoystickValue { get; private set; }
    public Vector3 m_VecJoyRotValue { get; private set; }

    public float moveSpeed = 10.0f;
    public float rotSpeed = 80.0f;

    private Vector3 StickFirstPos;
    private float m_fRadius;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        
    }


    private void Init()
    {
        joystickActiveRange = joystickActiveRangeObj.GetComponent<RectTransform>();
        joystick = joystickObj.GetComponent<RectTransform>();
        m_fRadius = joystickActiveRange.rect.width * 0.5f;
        joystickActiveRangeObj.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        print("5");
        joystickActiveRangeObj.transform.position = eventData.position;
        joystickObj.transform.position = eventData.position;
        joystickActiveRangeObj.SetActive(true);
        StickFirstPos = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("4");
        Vector3 Pos = eventData.position;
        Vector3 JoyVec = (Pos - StickFirstPos).normalized;
        player.transform.position += JoyVec * Time.deltaTime * 5;
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("3");
        Vector3 Pos = eventData.position;
        Vector3 JoyVec = (Pos - StickFirstPos).normalized;
        player.transform.position += JoyVec * Time.deltaTime * 5;
        JoyStickMove(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        print("2");
        joystickActiveRangeObj.SetActive(false);
        //player.playerStatus = PlayerManager.CharacterStatus.IDLE;
    }

    void JoyStickMove(PointerEventData eventData)
    {
        print("1");
        m_VecJoystickValue = eventData.position - (Vector2)joystickActiveRange.position;
        m_VecJoystickValue = Vector2.ClampMagnitude(m_VecJoystickValue, m_fRadius);
        joystick.localPosition = m_VecJoystickValue;
        m_VecJoyRotValue = new Vector3(joystick.localPosition.x, 0f, joystick.localPosition.y);
    }

    public void JoystickIsActive(bool isOn)
    {
        gameObject.SetActive(isOn);
    }
}