using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I also want this to only trigger if player is looking in direction of the door?

public class MapTransition : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private Transform cameraTargetPos; // make sure z is always -10
    [SerializeField] private Transform playerTargetPos; // make sure z is always 0

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
            Debug.Log("Player entered the trigger");
            FadeTransition(other.gameObject);
        }
    }

    async void FadeTransition(GameObject player) // take targetcamposition as parameter
    {
        PauseController.SetPause(true);
        await ScreenFader.Instance.FadeOut();

        // UpdateCameraPosition(targetPosition);
        if (cameraTargetPos != null)
        {
            mainCam.transform.position = cameraTargetPos.position;
            Debug.Log("Camera position changed: " + mainCam.transform.position);
        }

        // UpdatePlayerPosition(player);
        if (playerTargetPos != null)
        {
            player.transform.position = playerTargetPos.position;
            Debug.Log("Player position changed: " + player.transform.position);
        }

        await ScreenFader.Instance.FadeIn();
        PauseController.SetPause(false);
    }
}
