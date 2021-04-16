using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private float destroyTimer = 2f;
    [SerializeField] private float shotPower = 500f;
    [SerializeField] private float ejectPower = 100f;

    private Animator gunAnimator;
    private Transform barrelLocation;       //총알 위치
    private Transform casingExitLocation;   //탄피 방향

    public GameObject bulletPrefab; //총알
    public GameObject casingPrefab; //탄피
    public MeshRenderer muzzleFlash;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

     public void Shoot()
    {
        gunAnimator.SetTrigger("Fire");
        StartCoroutine(ShowMuzzleFlash());

        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
    }

    IEnumerator ShowMuzzleFlash()
    {
        //MuzzleFlash 활성화
        muzzleFlash.enabled = true;
        //불규칙한 회전 각도를 계산
        Quaternion rot = Quaternion.Euler(Vector3.forward * Random.Range(0, 360));
        //MuzzleFlash를 Z축 방향으로 회전
        muzzleFlash.transform.localRotation = rot;
        //MuzzleFlash의 스케일을 불규칙하게 조정
        muzzleFlash.transform.localScale = Vector3.one * Random.Range(1.0f, 2.0f);
        //텍스처의 Offset 속성에 적용할 불규칙한 값을 생성
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        //MuzzleFlash의 머티리얼의 Offset 값을 적용
        muzzleFlash.material.SetTextureOffset("_MainTex", offset);
        //MuzzleFlash가 보일 동안 잠시 대기
        yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
        //MuzzleFlash를 다시 비활성화
        muzzleFlash.enabled = false;
    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}
