using System.Collections;
using UnityEngine;
using Zenject;

public class Item:MonoBehaviour
{
    [SerializeField] private float checkRadius = 1.0f; // Радиус проверки
    [SerializeField] private string targetTag = "Item";
    
    [SerializeField] private GameObject InteractPanelUI;

    [SerializeField] private GameObject TargetItem;
    [Inject] private InputPlayer input;

    private bool isItem;
    private Transform col;

    private void Start(){
        input.Player.Attack.started += i => StartCor();
        InteractPanelUI.SetActive(false);
    }

    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag(targetTag))
            {
                col = collider.transform;
                InteractPanelUI.SetActive(true);
                return;
            }
        }    
        InteractPanelUI.SetActive(false);
    }
    private void StartCor(){
        if(col == null) return;

        if(!isItem)
            StartCoroutine(ItemMove(col.gameObject.transform));
        else{
            StopAllCoroutines();
            col.parent = null;
            col.GetComponent<Rigidbody>().isKinematic = false;
            col.GetComponent<Collider>().isTrigger = false;
            isItem = false;
        }
    }
    private IEnumerator ItemMove(Transform item){
        Vector3 startPosition = item.position;
        float elapsedTime = 0f;

        isItem = true;

        while (elapsedTime < 1)
        {
            item.position = Vector3.Lerp(startPosition, TargetItem.transform.position, (elapsedTime / 1));
            elapsedTime += Time.deltaTime;
            yield return null; // Ждет до следующего кадра
        }

        item.position = TargetItem.transform.position;
        item.parent = TargetItem.transform;
        item.GetComponent<Rigidbody>().isKinematic = true;
        col.GetComponent<Collider>().isTrigger = true;
    }
}