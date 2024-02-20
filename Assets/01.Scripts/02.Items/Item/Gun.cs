using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.PackageManager;
using Unity.VisualScripting;
using System.IO.Pipes;

public class Gun : MonoBehaviour
{
    public GunClass gunClass;
    private int bulletsLeft, bulletsShot;
    public bool shooting;
    private bool readyToShoot, reloading ,stopShooting;

    public Camera fpsCam;
    //public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    private TextMeshProUGUI text;
    public GameObject bulletHoleGraphic;
    public ParticleSystem muzzleFlash;
    private AudioSource audioSource;
    public AudioClip fire_Sound;
    public AudioClip reload_Sound;
    private GameObject ammoText;
    private GameObject Aim;
    private GameObject gunUI;


    // Start is called before the first frame update
    void Start()
    {
        fpsCam = Camera.main;
        audioSource = gameObject.GetComponent<AudioSource>();
        bulletsLeft = gunClass.magazineSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = gunClass.BulletPerTaps;
            RealShoot();
        }

        text.SetText(bulletsLeft/gunClass.BulletPerTaps + "/" + gunClass.magazineSize/gunClass.BulletPerTaps);
    }

    private void OnEnable()
    {
        gunUI = GameObject.Find("GunUI");
        Aim = gunUI.transform.GetChild(0).gameObject;
        ammoText = gunUI.transform.GetChild(2).gameObject;
        text = ammoText.GetComponent<TextMeshProUGUI>();

        ammoText.SetActive(true);
        Aim.SetActive(true);
    }
    private void OnDisable()
    {
        if(ammoText != null)
        {
            ammoText.SetActive(false);
        }
        if(Aim != null)
        {
            Aim.SetActive(false);
        }
    }

    public void Shoot()
    {
        readyToShoot = false;

        float x = Random.Range(-gunClass.spread, gunClass.spread);
        float y = Random.Range(-gunClass.spread, gunClass.spread);
        float z = Random.Range(-gunClass.spread, gunClass.spread);


        Vector3 dir = fpsCam.transform.forward + new Vector3(x, y, z);


        if (Physics.Raycast(fpsCam.transform.position, dir, out rayHit, gunClass.range, whatIsEnemy))
        {
            var clone = Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal));
            Destroy(clone, 4f);

            if (rayHit.collider.CompareTag("Enemy")) 
            {
                rayHit.collider.TryGetComponent(out CharacterHealth characterHealth);
                characterHealth.TakeDamage(gunClass.damage);
            }
        }

        muzzleFlash.Play();
        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShoot", gunClass.timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            stopShooting = false;
            Invoke("Shoot", gunClass.timeBetweenShots);
        }
        else
        {
            stopShooting = true;
            Invoke("ResetStopShooting", gunClass.timeBetweenShooting);
        }


        PlaySE(fire_Sound);
    }

    private void RealShoot()
    {
        if (!stopShooting)
        {
            Shoot();
        }
    }

    public void ResetShoot()
    {
        readyToShoot = true;
    }

    private void ResetStopShooting()
    {
        stopShooting = false;
    }

    public void Reload()
    {
        if (!reloading && bulletsLeft < gunClass.magazineSize) 
        {
                    reloading = true;
        Invoke("ReloadFinished", gunClass.reloadtime);

        PlaySE(reload_Sound);
        }

    }

    private void ReloadFinished()
    {
        bulletsLeft = gunClass.magazineSize;
        reloading = false;
    }
    private void PlaySE(AudioClip _clip)
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
