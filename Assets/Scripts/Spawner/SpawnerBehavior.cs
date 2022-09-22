using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class SpawnerBehavior : MonoBehaviour
{
    //Data Of Spawner
    [SerializeField]
    private Transform positionSpawner;
    [SerializeField]
    public float timeBeforeSpawn;
    [SerializeField] VisualEffect VisualEffect;

    private WaitForSecondsRealtime waitSeconds = new WaitForSecondsRealtime(0);

    //List of item to throw
    public List<ItemThrower> itemThrowers;
    private Dictionary<string, GameObject> dictItemThrower = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i< itemThrowers.Count; i++)
        {
            dictItemThrower.Add(itemThrowers[i].name, itemThrowers[i].item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] SpawnItemThrow(int numberItem)
    {
        GameObject[] spawnItems = new GameObject[numberItem];
        for(int i = 0; i< numberItem; i++)
        {
            int randomItemToPick = Random.Range(0, itemThrowers.Count);
            spawnItems[i] = Instantiate(itemThrowers[randomItemToPick].item, positionSpawner.position, Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))));
        }
        return spawnItems;
    }

    [Button]
    public void ButtonThrow() 
    {
        ThrowObject(5,0);
    }
    
    public void ThrowObject(int numberItem,float timeBeforeStart)
    {
        GameObject[] spawnItems = SpawnItemThrow(numberItem);
        StartCoroutine(ThrowItemManager(spawnItems, timeBeforeSpawn, timeBeforeStart, Vector3.up,350));
    }

    public IEnumerator ThrowItemManager(GameObject[] items, float timeSequencer, float timeBeforeStart,Vector3 direction, float force)
    {
        yield return new WaitForSecondsRealtime(timeBeforeStart);
        waitSeconds.waitTime = timeSequencer;
        for (int i = 0; i< items.Length; i++)
        {
            IThrowable itemToThrow = items[i].GetComponent<IThrowable>();
            if (itemToThrow != null)
            {
                itemToThrow.EnableItem();
                Vector3 directionRandom = new Vector3(Random.Range(-0.2f, 0.2f), 1, Random.Range(-0.2f, 0.2f));
                itemToThrow.ThrowItem(directionRandom, force);
                PlayParticles();
                yield return waitSeconds;
            }

        }
        yield return null;
    }

    void PlayParticles()
    {
        VisualEffect.Play();
    }
}
[System.Serializable]
public struct ItemThrower {
    public string name;
    public GameObject item;
}
