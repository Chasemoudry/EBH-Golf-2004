using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

    private Text textDisplayer;
	
    void Update()
    {
        if (gameObject.name == "ScoreText")
        textDisplayer.text = "Score: " + GameManager.gm.playerScore; 
    }

	void OnEnable() 
    {
        if (!textDisplayer)
        {
            textDisplayer = this.gameObject.GetComponent<Text>();
        }

        if (gameObject.name == "LevelVictoryText")
        {
            textDisplayer.text = "Level Complete!\n\nScore: " + GameManager.gm.playerScore; 
        }
        else if (gameObject.name == "GameVictoryText")
        {
            textDisplayer.text = "Congratulations!\n\nFinal Score: " + GameManager.gm.playerScore; 
        }
        else if (gameObject.name == "DeathText")
        {
            textDisplayer.text = "You Died.\n\nScore: " + GameManager.gm.playerScore; 
        }
	}
}
