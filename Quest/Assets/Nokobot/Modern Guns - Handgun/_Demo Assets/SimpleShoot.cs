using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [SerializeField] private float shotPower = 500f;
    public bool isGrab = false;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public HandState currentGrab;
     


    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
        audioSource = GetComponent<AudioSource>();

    }



    public void Shoot()
    {
        if (isGrab == true)
        {
            GetComponent<Animator>().SetTrigger("Fire");
            GameObject tempFlash;
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void grabGun()
    {
        isGrab = true;
    }

    public void dropGun()
    {
        isGrab = false;
    }

    public void SetGraspState(HandState state)
    {
        currentGrab = state;
    }

    public void SetGraspNONE()
    {
            currentGrab = HandState.NONE;
    }

    public void SetGraspLEFT()
    {
        currentGrab = HandState.LEFT;
    }

    public void SetGraspRIGHT()
    {
        currentGrab = HandState.RIGHT;
    }

}
