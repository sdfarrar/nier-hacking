using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public IntegerReference PlayerHealth;

	private Boss[] bosses;
	private EnemyShip[] enemyShips;

	void Awake() {
		bosses = FindObjectsOfType<Boss>();
		enemyShips = FindObjectsOfType<EnemyShip>();

        SetBossesInvulnerability(enemyShips.Length>0);
	}
	
    public void CheckLevelComplete() {
        StartCoroutine(Check());
    }

    public void GameOver() {
        Debug.Log("Game over");
    }

    private void SetBossesInvulnerability(bool invulnerable) {
		foreach (var boss in bosses){ 
            boss.GetComponent<UnitHealth>().Invulnerable = invulnerable;
		}
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
