using UnityEngine;

public class EnergyZone : MonoBehaviour
{
    public float checkRadius = 1.0f; // Радиус проверки
    public string targetTag = "Energy";
    private EnergyPlayer playerE;

    private void Start(){
        playerE = GetComponent<EnergyPlayer>();
    }

    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag(targetTag))
            {
                playerE.col = collider;
                playerE.AddEnergy();

                return;
            }
        }    
        playerE.col = null;
        playerE.RemoveEnergy();
    }
}
