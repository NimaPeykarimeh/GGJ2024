using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OpenTutorial()
    {
        // Burada tutorial ekran�n�z�n a��lmas�n� sa�layacak kodlar� ekleyin
    }
}