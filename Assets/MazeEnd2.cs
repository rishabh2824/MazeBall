using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Finish")
        {
            //Debug.Log("Game Over");
            LevelComplete2.isGameOver = true;
        }
    }
}
