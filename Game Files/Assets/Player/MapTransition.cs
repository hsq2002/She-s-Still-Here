using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I also want this to only trigger if player is looking in direction of the door?

public class MapTransition : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private Transform cameraTargetPos; // make sure z is always -10
    [SerializeField] private float cameraTargetSize;
    [SerializeField] private Transform playerTargetPos; // make sure z is always 0
    // [SerializeField] private Transform playerTargetDirection; // how to make this left, right, up, down
    [SerializeField] private bool isLocked = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        //Debug.Log("Camera position: " + mainCam.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isLocked)
            {
                Debug.Log("Player is trying to enter a LOCKED door");
                // check if player has key in inventory. if so, unlock door
                return;
            }
            Debug.Log("Player entered the trigger");
            FadeTransition(other.gameObject);
        }
    }

    async void FadeTransition(GameObject player)
    {
        PauseController.SetPause(true);
        await ScreenFader.Instance.FadeOut();

        // UpdateCameraPosition(targetPosition);
        if (cameraTargetPos != null)
        {
            mainCam.transform.position = cameraTargetPos.position;
            Debug.Log("Camera position changed: " + mainCam.transform.position);
            if (cameraTargetSize != 0)
            {
                mainCam.orthographicSize = cameraTargetSize;
                Debug.Log("Camera size changed: " + mainCam.orthographicSize);
            }
        }

        // UpdatePlayerPosition(player);
        if (playerTargetPos != null)
        {
            player.transform.position = playerTargetPos.position;
            Debug.Log("Player position changed: " + player.transform.position);
        }

        await ScreenFader.Instance.FadeIn();
        PauseController.SetPause(false);
        Debug.Log("Player position fr" + player.transform.position);
    }
}
