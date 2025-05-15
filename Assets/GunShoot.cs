using UnityEngine;
using TMPro;
using System.Collections;

public class GunShoot : MonoBehaviour
{
    [Header("Gun Settings")]
    public AudioSource gunAudio;
    public AudioSource reloadAudio;
    public Camera playerCamera;
    public float shootRange = 100f;
    public int maxAmmo = 30;
    public float reloadTime = 1.5f;
    private int currentAmmo;
    private bool isReloading = false;

    [Header("UI Settings")]
    public TextMeshProUGUI ammoText;

    private void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }

    private void Update()
    {
        if (isReloading)
            return;

        // Press R to reload manually
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentAmmo < maxAmmo) 
                StartCoroutine(Reload());
            return;
        }

        // Left click to shoot
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentAmmo > 0)
                Shoot();
            else
                Debug.Log("Out of ammo! Press R to reload!");
        }
    }

    void Shoot()
    {
        gunAudio.Play();

        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, shootRange))
        {
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(20);
            }
        }

        currentAmmo--;
        UpdateAmmoUI();
    }

    IEnumerator Reload()
    {
        isReloading = true;

        if (reloadAudio != null)
            reloadAudio.Play();

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        UpdateAmmoUI();
        isReloading = false;
    }

    void UpdateAmmoUI()
    {
        if (ammoText != null)
            ammoText.text = currentAmmo + " / " + maxAmmo;
    }
}
