using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class EnergyPlayer : MonoBehaviour
{
#region  param
    private int energy = 10;
    private int maxEnergy = 10;

    [Inject] private GameController gameC;
    private bool isAddEnergy;
    [SerializeField] private TextMeshProUGUI energyView;
#endregion

    private void Start(){
        StartCoroutine(EnergyLose());
    }
    
    public void AddEnergy(){
        isAddEnergy = true;
    }
    public void RemoveEnergy(){
        isAddEnergy = false;
    }

    private IEnumerator EnergyLose(){
        while(true){
            if(isAddEnergy)
                if(energy < maxEnergy)
                    energy++;
            else
                energy--;

            if(energy <= 0){
                gameC.LouseGame();
            }
            
            energyView.text = energy.ToString();

            yield return new WaitForSeconds(1);
        }
    }
}
