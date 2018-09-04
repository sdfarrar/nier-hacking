using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public IntegerReference PlayerHealth;

	private Boss[] bosses;
	private EnemyShip[] enemyShips;

	void Start() {
		bosses = FindObjectsOfType<Boss>();
	}
	
    public void CheckLevelComplete() {
        StartCoroutine(Check());
    }

    public void GameOver() {
        Debug.Log("Game over");
    }

    private IEnumerator Check(){
        yield return new WaitForEndOfFrame();
		if(AreBossesDead()){ EndLevel(); }
    }

	private bool AreBossesDead(){
		bool allDead = true;
		foreach (var boss in bosses){ 
			allDead = allDead && boss==null;
			if(!allDead){ return false; }
		}
		return true;
	}

	private void EndLevel() {
		Debug.Log("Level complete");
	}

}
