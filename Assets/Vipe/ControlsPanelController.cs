using UnityEngine;

public class ControlsPanelController : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject mainMenuPanel;
    public void ShowControlsPanel()
    {
        controlsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void HideControlsPanel()
    {
        controlsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
