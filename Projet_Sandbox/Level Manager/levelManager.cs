using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class levelManager : MonoBehavior 
{
	
	public static sceneManager Instance;
	
	[SerializedField] private GameObject _loaderCanvas;
	[SerializedField] private Image _progressBar;
	private float _target;

	void Awake ()
	{
		if (Instance == nul)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		]
	}
	
	public async void LoadScene(string sceneName)
	{
		_target = 0;
		_progressBar.fillAmount = 0;
		
		var scene = SceneManager.LoadSceneAsync(sceneName);
		scene.allowSceneActivation = false;
		
		_loaderCanvas.SetActive(true);
		
		do
		{
			await Task.Delay(100)
			
			_progressBar.fillAmount = scene.progress;
		}
		
		while (scene.progress < 0.9f);
		
		scene.allowSceneActivation = true;
		_loaderCanvas.SetActive(false);
		
	}
	
	void Update()
	{
		_progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target, 3 * Time.deltaTime);
	}
}