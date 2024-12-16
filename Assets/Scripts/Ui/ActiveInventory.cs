using System;
using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
    private int activeSlotIndexNum = 0; // Tracks active slot index
    private Pointer pointer;           // Input system for slot switching

    // Reference to WeaponManager
    [SerializeField] private WeaponManager weaponManager;

    private void Awake()
    {
        pointer = new Pointer(); // Initializes input system
    }

    private void Start()
    {
        // Assigns keyboard input to toggle slots
        pointer.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
    }

    private void OnEnable()
    {
        pointer.Enable(); // Enables input system
    }

    public void ToggleActiveSlot(int numValue)
    {
        // Convert input to 0-based index
        int indexNum = numValue - 1;

        if (indexNum < 0 || indexNum >= this.transform.childCount)
        {
            Debug.LogWarning("Invalid slot index: " + indexNum);
            return;
        }

        // Highlight selected slot
        ToggleActiveHighLight(indexNum);

        // Switch weapon through WeaponManager
        weaponManager.SwitchWeapon(indexNum);
    }

    private void ToggleActiveHighLight(int indexNum)
    {
        activeSlotIndexNum = indexNum;

        // Deactivate highlights on all slots
        foreach (Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        // Activate highlight on selected slot
        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);
    }
}
