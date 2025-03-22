using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinishOne : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Structs.Tags.PLAYERONE)
        {
            Structs.LevelManager.isPlayerOneFinish = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Structs.Tags.PLAYERONE)
        {
            Structs.LevelManager.isPlayerOneFinish = false;
        }
    }
}
