using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    //the type of item
    [SerializeField] private E_Items _item;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //need something to differenciate cat and mouse
        Destroy(gameObject);
    }
}
