using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{

    public int playerPoint = 0;
    public TMP_Text text;

    public void Start()
    {
        ItemCollider.staticDieVegetable += AddPointToScore;
        text.text = playerPoint.ToString();
    }

    private void AddPointToScore(int point)
    {
        playerPoint += point;
        text.text = playerPoint.ToString(); 
    }

}
