using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField]
    private List<RoundsConfiguration> roundsConfigurations;

    private WaitForSecondsRealtime waitSeconds = new WaitForSecondsRealtime(0);
    // Start is called before the first frame update
    void Start()
    {
        StartRoundButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    private void StartRoundButton()
    {
        StartCoroutine(StartRound(roundsConfigurations));
    }

    public IEnumerator StartRound(List<RoundsConfiguration> rounds)
    {

        for(int i = 0; i < rounds.Count; i++)
        {
            waitSeconds.waitTime = rounds[i].TimeToWaitToStartThisRound;
            yield return waitSeconds;
            for (int j = 0; j< rounds[i].round.Count; j++)
            {
                rounds[i].round[j].spawner.ThrowObject(rounds[i].round[j].numberItemThrow, rounds[i].round[j].timeToStartThisConfiguration);
            }

        }

    }
}

[System.Serializable]
public struct RoundsConfiguration
{
    public List<RoundConfiguration> round;
    public float TimeToWaitToStartThisRound;
}

[System.Serializable]
public struct RoundConfiguration
{
    public SpawnerBehavior spawner;
    public int numberItemThrow;
    public float timeToStartThisConfiguration;
}

