using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBest;
    [SerializeField] private TextMeshProUGUI timer;
    private float time = 0;
    private float bestTime = 0;

    private void Start(){
        if (PlayerPrefs.HasKey("bestTime")) PlayerPrefs.SetFloat("bestTime", 0f);

        bestTime = PlayerPrefs.GetFloat("bestTime", 0);

        int minutes = (int)(bestTime / 60); // Вычисляем минуты
        int seconds = (int)(bestTime % 60); // Вычисляем секунды
        textBest.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    public void StartTimer(){
        StartCoroutine(Timers());
    }

    private IEnumerator Timers(){
        while(true){
            time++;

            int minutes = (int)(time / 60); // Вычисляем минуты
            int seconds = (int)(time % 60); // Вычисляем секунды
            timer.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);

            yield return new WaitForSeconds(1f);
        }
    }

    public void StopTime(){
        StopAllCoroutines();

        if(time > bestTime){
            bestTime = time;
        
            int minutes = (int)(bestTime / 60); // Вычисляем минуты
            int seconds = (int)(bestTime % 60); // Вычисляем секунды
            textBest.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }

        time = 0;

        PlayerPrefs.SetFloat("bestTime", bestTime);
        PlayerPrefs.Save(); // Сохраняем изменения
    }
}
