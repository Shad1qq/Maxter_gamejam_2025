using UnityEngine;
using Zenject;

public class CanvasManager : MonoBehaviour
{
    [Inject] private InputPlayer input;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject colorPanel;

    private void Start()
    {
        pauseMenu.SetActive(false);
        colorPanel.SetActive(false);

        #region input
        input.Player.Esc.started += i => PauseMenu();
        input.Player.Tab.started += i => ColorPanel();
        #endregion

    }
    private void PauseMenu(){
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
    }
    private void ColorPanel(){
        colorPanel.SetActive(!colorPanel.activeInHierarchy);
    }
}
