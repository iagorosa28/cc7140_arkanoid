using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgressor : MonoBehaviour
{
    void Update()
    {
        // procura todos com Tag "Brick";
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0)
        {
            var scene = SceneManager.GetActiveScene().name;

            if (scene == "Level1")
                SceneManager.LoadScene("Level2");
            else
                SceneManager.LoadScene("Level1");
            //    SceneManager.LoadScene("Win");
        }
    }
}
