using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar1 : MonoBehaviour
{
	Vector3 localScale;
	public MissileBatteries battery;
	// Use this for initialization
	void Start()
	{
		localScale = transform.localScale;
	}

	// Update is called once per frame
	void Update()
	{
		this.localScale.x = battery.health;
		this.transform.localScale = this.localScale;
	}
}
