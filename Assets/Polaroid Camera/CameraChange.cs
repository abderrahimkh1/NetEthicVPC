using StarterAssets;
using System.Collections;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;
    [SerializeField]
    private ThirdPersonController controller;
    public GameObject InventoryTab1, InventoryTab2, CursorCam;
    public GameObject CtoExit;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // if (InventoryManager.Instance.HasItem("Camera"))
        // {
        if (Input.GetButtonDown("Camera"))
        {
            ToggleCameraMode();
        }
        //}

        if (Input.GetButtonDown("Inventory"))
        {
            ToggleInventory();
        }
    }

    public void ToggleCameraMode()
    {
        CamMode = (CamMode == 0) ? 1 : 0; // Toggle between 0 and 1

        if (CamMode == 0)
        {
            CursorCam.SetActive(false);

        }
        else
        {
            CursorCam.SetActive(true);

        }

        StartCoroutine(CamChange());
    }

    void ToggleInventory()
    {
        InventoryTab1.SetActive(!InventoryTab1.activeSelf);
        InventoryTab2.SetActive(!InventoryTab2.activeSelf);
        InventoryManager.Instance.ListItems();
        ToggleCursorVisibilityAndLockState();
    }

    void ToggleCursorVisibilityAndLockState()
    {
        Cursor.visible = !Cursor.visible;

        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public GameObject phone;
    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
            controller.enabled = true;
            CtoExit.SetActive(false);
            phone.SetActive(true);
        }
        else
        {
            ThirdCam.SetActive(false);
            FirstCam.SetActive(true);
            controller.enabled = false;

        }
    }
}
