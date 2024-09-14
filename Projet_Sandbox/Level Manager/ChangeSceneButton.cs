using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeSceneButton : MonoBehavior
{
	
	public void ChangeScene(string sceneName)
	{
		LevelManager.Instance.LoadScene(sceneName);	
	}





















}