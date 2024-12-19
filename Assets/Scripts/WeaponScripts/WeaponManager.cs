using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons; // Array of weapon GameObjects
    [SerializeField] private int defaultWeaponIndex = 0; // The default weapon to equip at start

    private void Start()
    {
        InitializeWeapons();
    }

    private void InitializeWeapons()
    {
        // Loop through all weapons and deactivate them
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        // Activate the default weapon
        if (defaultWeaponIndex >= 0 && defaultWeaponIndex < weapons.Length)
        {
            weapons[defaultWeaponIndex].SetActive(true);
        }
        else
        {
            Debug.LogError("Default weapon index is out of range!");
        }
    }

    public void SwitchWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length)
        {
            Debug.LogWarning("Invalid weapon index: " + index);
            return;
        }

        // Deactivate all weapons
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        // Activate the selected weapon
        weapons[index].SetActive(true);
    }
}
