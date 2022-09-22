using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    public int PointsEarn;

    // Start is called before the first frame update
    private int layerMask;

    //Observer pattern
    public delegate void StaticDieItemDelegate(int point);
    public static event StaticDieItemDelegate staticDieVegetable;

    void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up,out hit, 1, layerMask))
        {
            Destroy(transform.parent.gameObject);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Destroy(transform.parent.gameObject);
        }

        if(other.gameObject.tag == "Laser")
        {
            Destroy(transform.parent.gameObject); // To Change
            staticDieVegetable?.Invoke(PointsEarn);
        }
    }
}
