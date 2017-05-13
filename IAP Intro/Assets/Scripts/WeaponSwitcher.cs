using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    public int defaultWeaponNumber = 0;
    public GameObject[] weaponPrefabs;

    public Done_PlayerController playerController;

    void Awake()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<Done_PlayerController>();
    }

    // Use this for initialization
    void Start()
    {
        SwitchWeapon(defaultWeaponNumber);
    }

    public void SwitchWeapon(int weaponIndex)
    {
        if (playerController == null)
        {
            Debug.LogWarning("WEAPONSWITCHER SwitchWeapn Failed: PlayerController not found!");
            return;
        }

        if (weaponPrefabs == null || weaponPrefabs.Length == 0)
        {
            Debug.LogWarning("WEAPONSWITCHER SwitchWeapn Failed: weaponPrefabds not found!");
            return;
        }

        if (weaponPrefabs[weaponIndex] != null)
        {
            playerController.shot = weaponPrefabs[weaponIndex];
        }
    }
}
