using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Completed " + SceneManager.GetActiveScene().name);
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "LevelOne")
            {
                GameManager.gm.LevelComplete();
            }
            else
            {
                GameManager.gm.GameComplete();
            }
        }
    }
}
