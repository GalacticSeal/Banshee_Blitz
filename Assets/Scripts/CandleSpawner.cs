using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSpawner : MonoBehaviour
{
    public GameObject CandleObj;
    private List<GameObject> candleList = new List<GameObject>();
    public List<Vector2> spawnPosList = new List<Vector2>();

    private void Start() {
        SpawnCandles();
    }

    public void SpawnCandles() {
        for (int i = candleList.Count-1; i >= 0; i--) {
            Destroy(candleList[i]);
            candleList.RemoveAt(i);
        }
        for(int i = spawnPosList.Count-1; i >= 0; i--) {
            GameObject newCandle = Instantiate(CandleObj, new Vector3(spawnPosList[i][0], 1f, spawnPosList[i][1]), Quaternion.identity);
            candleList.Add(newCandle);
        }
    }
}
