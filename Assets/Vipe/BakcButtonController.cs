using UnityEngine;

public class BackButtonController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject controlsPanel;

    public void GoBackToMainMenu()
    {
        controlsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
