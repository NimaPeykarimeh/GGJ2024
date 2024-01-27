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
        // Burada tutorial ekranýnýzýn açýlmasýný saðlayacak kodlarý ekleyin
    }
}