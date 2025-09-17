using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerArkanoid : MonoBehaviour
{

    public static int Score = 0;
    public static int Lives = 3;

    public GUISkin layout;

    private void Awake()
    {
        // garante que resete ao carregar Level1 do zero
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            Score = 0;
            Lives = 3;
        }
    }

    public static void AddScore(int amount)
    {
        Score += amount;
    }

    public static void LoseLife()
    {
        Lives--;
        if(Lives <= 0)
        {
            // sem vidas: vai para tela de Game Over
            SceneManager.LoadScene("Level1");
        }
    }

    void OnGUI()
    {
        if(layout) GUI.skin = layout;

        GUI.Label(new Rect(20, 20, 200, 40), "Score: " + Score);
        GUI.Label(new Rect(Screen.width - 140, 20, 120, 40), "Lives: " + Lives);

        // botão de reiniciar nível
        if(GUI.Button(new Rect(Screen.width / 2 - 60, 20, 120, 40), "Restart"))
        {
            Score = 0; Lives = 3;
            SceneManager.LoadScene("Level1");
        }
    }

}
