using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject controlsPanel;
    void Start()
    {
        // Ba�lang��ta sadece ana men� panelini g�ster
        mainMenuPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }
        public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
