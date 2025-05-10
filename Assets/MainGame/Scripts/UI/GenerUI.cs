using TMPro;
using UnityEngine;

public class GenerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void FixedUpdate()
    {
        text.text = GetComponent<energyInventory>().energy.ToString();
    }
}
