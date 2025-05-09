using UnityEngine;

public class Generator : MonoBehaviour
{
    public string targetTag = "Item";

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(targetTag)){

            GetComponentInChildren<energyInventory>().energy += collision.gameObject.GetComponent<itemRes>().energy;

            Destroy(collision.gameObject);
        }
    }
}
