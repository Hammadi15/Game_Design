using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons; // Array of weapon GameObjects

    public void SwitchWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length)
        {
            Debug.LogWarning("Invalid weapon index: " + index);
            return;
        }

        for (int i = 0; i < weapons.Length; i++)
        {
            // Deactivate all weapons
            weapons[i].SetActive(false);

            // Inform weapon scripts about deactivation
            var weaponScript = weapons[i].GetComponent<PlayerAimAndShoot>();
            if (weaponScript != null)
            {
                weaponScript.SetActive(false);
            }
        }

        // Activate the selected weapon
        weapons[index].SetActive(true);

        // Inform weapon script about activation
        var activeWeaponScript = weapons[index].GetComponent<PlayerAimAndShoot>();
        if (activeWeaponScript != null)
        {
            activeWeaponScript.SetActive(true);
        }
    }
}
