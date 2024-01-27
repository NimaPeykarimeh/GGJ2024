using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject controlsPanel;
    void Start()
    {
        // Baþlangýçta sadece ana menü panelini göster
        mainMenuPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }
        public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
