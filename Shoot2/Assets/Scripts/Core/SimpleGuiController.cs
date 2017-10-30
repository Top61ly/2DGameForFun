using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SimpleGuiController : MonoBehaviour
{
	public GameObject EndPanel;

	public PlayerManager playerManager;

	public Text Score;

	public float time;

	private void Start()
	{
		time = 0;
		EndPanel.SetActive(false);
		playerManager.OnPlayerDestroyed += OnPlayerDestroyed;
	}

	private void Update()
	{
		time += Time.deltaTime;
	}

	private void OnPlayerDestroyed(object sender, EventArgs e)
	{
		time = Round(time,2);
		Score.text = "时间：" + time + "s";
		EndPanel.SetActive(true);
	}

	float Round(float f, int acc)
	{
		float temp = f * Mathf.Pow(10, acc);
		return Mathf.Round(temp) / Mathf.Pow(10, acc);
	}
}
