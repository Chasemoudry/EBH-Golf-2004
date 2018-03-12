using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "KillPlane")
        {
            GameManager.gm.PlayerDeath();
        }
    }
}
