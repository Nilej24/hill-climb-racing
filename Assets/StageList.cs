using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/StageList")]
public class StageList : ScriptableObject
{
	public Stage[] stages;
}
