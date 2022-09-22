using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour, IThrowable
{

    //Reférence

    [Header("Référence")]
    [SerializeField]
    private GameObject objectRenderer;
    [SerializeField]
    private Rigidbody rbd;

    public float waitTimeBeforeStart; 

    public void EnableItem()
    {
        objectRenderer.SetActive(true);
        rbd.useGravity = true;
    }

    public void ThrowItem(Vector3 direction, float force)
    {
        rbd.AddForce(direction * force);
    }

    public void Awake()
    {
        objectRenderer.SetActive(false);
    }

    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
