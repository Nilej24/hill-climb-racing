using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CarList")]
public class CarList : ScriptableObject
{
	public Car[] cars;
}
