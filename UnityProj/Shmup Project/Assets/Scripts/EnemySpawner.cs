using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ITrigger {
    public GameObject[] enemies;
    TimerManager timer;
    public int enemyAmount;
    
    
	// Use this for initialization
	void Awake () {
        timer = GameObject.Find("TimerManager").GetComponent<TimerManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    void SpawnEnemies() {
        GameObject go = Instantiate(enemies[0]);
        go.GetComponent<Anchor>().lPos = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }
    public void Trigger() {
        for (int i = 0; i <= enemyAmount; i++) {
            timer.Once(SpawnEnemies, i * 5);
        }
    }
}
