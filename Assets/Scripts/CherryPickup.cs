using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class CherryPickup : MonoBehaviour {

    public AudioClip ding;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.am.sfxSource.PlayOneShot(ding);
            GameManager.gm.playerScore += GameManager.gm.cherryWorth;
            Destroy(this.gameObject);
        }
    }
}
