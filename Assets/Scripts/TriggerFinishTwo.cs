using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinishTwo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Structs.Tags.PLAYERTWO)
        {
            Structs.LevelManager.isPlayerTwoFinish = true;
            if (Structs.LevelManager.isPlayerOneFinish == true)
            {
                Structs.LevelManager.levelIndex++;
                SceneManager.LoadScene(Structs.LevelManager.levelIndex);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Structs.Tags.PLAYERTWO)
        {
            Structs.LevelManager.isPlayerTwoFinish = false;
        }
    }
}
