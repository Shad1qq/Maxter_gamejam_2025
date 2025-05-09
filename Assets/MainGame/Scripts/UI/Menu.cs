using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Метод для выхода из игры
    public void QuitGame()
    {
        #if UNITY_EDITOR
            // Если игра запущена в редакторе
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBGL
            // Для веб-игры
            Debug.Log("Выход из игры (веб-версия).");
            // Здесь можно добавить логику для возврата на главную страницу
            Application.OpenURL("https://blaksou1.itch.io/wayoutstudio"); // Замените на URL вашей главной страницы
        #else
            // Для настольной версии
            Application.Quit();
        #endif
    }}
