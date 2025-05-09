using UnityEngine;

public class energyInventory : MonoBehaviour
{
    public int energy = 5;

    // Update is called once per frame
    public void UpdateEnergy()
    {
        energy--;
    }
    public bool CheckEnergy(){
        return energy <= 0;
    }
}
