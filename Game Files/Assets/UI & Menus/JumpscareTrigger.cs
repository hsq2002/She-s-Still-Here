using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    // public static 
    public GameObject jumpscareUI;
    public AudioSource jumpscareSound; // figure out how to do audiosources lol
    public float displayTime = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // do player health check here later.
            // I guess this would be connected to monster attack/contact
            StartCoroutine(JumpscareCoroutine());
        }
    }

    private System.Collections.IEnumerator JumpscareCoroutine()
    {
        PauseController.SetPause(true);

        jumpscareUI.SetActive(true);
        jumpscareSound.Play();

        yield return new WaitForSeconds(displayTime);
        // could fade out before setting jumpscare to false
        // this could be through fadeoutpanel or would there be a visual 
        // difference of fading out the jumpscare itself with a canvasgroup
        jumpscareUI.SetActive(false);
        // maybe destroy instead
    }
}
