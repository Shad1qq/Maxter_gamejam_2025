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
    public Collider col;
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
            if(col == null)
                energy--;
            else{
                if(col.TryGetComponent(out energyInventory inv)){
                    if(inv.CheckEnergy()) 
                        energy--;
                    else{
                        if(energy < maxEnergy){
                            energy++;
                            
                            inv.UpdateEnergy();
                        }
                        else
                            inv.UpdateEnergy();
                    }
                }
            }

            if(energy <= 0){
                gameC.LouseGame();
            }
            
            energyView.text = energy.ToString();

            yield return new WaitForSeconds(1);
        }
    }
}
