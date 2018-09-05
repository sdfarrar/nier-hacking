using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour {

	public IntegerReference PlayerHealth;

	public UnityEvent BossInvulnerableEvent;
	public UnityEvent BossVulnerableEvent;

	private Boss[] bosses;
	private EnemyShip[] enemyShips;

	void Awake() {
		bosses = FindObjectsOfType<Boss>();
		enemyShips = FindObjectsOfType<EnemyShip>();

        //SetBossesInvulnerability(enemyShips.Length>0);
		if(enemyShips.Length>0){ BossInvulnerableEvent.Invoke(); }else{ BossVulnerableEvent.Invoke(); }
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
