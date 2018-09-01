using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tower), true)]
public class TowerEditor : Editor {

	public override void OnInspectorGUI(){
		base.OnInspectorGUI();

		Tower tower = (Tower)target;
		Orbiter[] orbiters = tower.GetComponentsInChildren<Orbiter>();
		Turret[] turrets = tower.GetComponentsInChildren<Turret>();

		UpdateOrbiters(orbiters);
		UpdateTurrets(turrets);
	}

	private void UpdateOrbiters(Orbiter[] orbiters){
		if(orbiters.Length<=0){ return; }

		float orbitSpeed = EditorGUILayout.Slider("Orbiter Speed", orbiters[0].OrbitDegreesPerSec, 0, 360);
		for(int i=0; i<orbiters.Length; ++i){
			orbiters[i].OrbitDegreesPerSec = orbitSpeed;
			EditorUtility.SetDirty(orbiters[i]);
		}
	}

	private void UpdateTurrets(Turret[] turrets){
		if(turrets.Length<=0){ return; }

		float bulletSpeed = EditorGUILayout.Slider("Turret Bullet Speed", turrets[0].BulletSpeed, 0.1f, 10f);
		float fireDelay = EditorGUILayout.Slider("Turret Fire Delay", turrets[0].FireDelay, 0.1f, 1f);
		for(int i=0; i<turrets.Length; ++i){
			turrets[i].BulletSpeed = bulletSpeed;
			turrets[i].FireDelay = fireDelay;
			EditorUtility.SetDirty(turrets[i]);
		}

	}

}
