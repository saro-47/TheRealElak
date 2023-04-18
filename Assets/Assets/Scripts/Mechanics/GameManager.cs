using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
		[Header("Global Data: "), Space]
		[Tooltip("Showed when the scene is loading."), SerializeField] private GameObject loadScreen;

		public GameManager instance;
		
		public bool gameIsPaused;
		
		
		private void Awake()
		{
			instance = this;
			SceneManager.LoadSceneAsync((int)SceneIndexes.MainMenu, LoadSceneMode.Additive);
		}

		private readonly List <AsyncOperation> scenesLoading = new List <AsyncOperation>();

		public void LoadGame()
		{
			loadScreen.SetActive(true);
			
			scenesLoading.Add(SceneManager.UnloadSceneAsync((int) SceneIndexes.MainMenu));
			scenesLoading.Add(SceneManager.LoadSceneAsync((int) SceneIndexes.MainScene, LoadSceneMode.Additive));

			StartCoroutine(GetSceneLoadProgress());
		}
    
		public void LoadMainMenu()
		{
			loadScreen.SetActive(true);
			
			scenesLoading.Add(SceneManager.UnloadSceneAsync((int) SceneIndexes.MainScene));
			scenesLoading.Add(SceneManager.LoadSceneAsync((int) SceneIndexes.MainMenu, LoadSceneMode.Additive));
		}
		
		private IEnumerator GetSceneLoadProgress()
		{
			for (int i = 0; i < scenesLoading.Count; i++)
			{
				while(!scenesLoading[i].isDone)
				{
					yield return null;
				}
			}
			loadScreen.SetActive(false);
		}

		public void ExitApplication()
		{
			Application.Quit();
		}
		
		public void Pause()
		{
			gameIsPaused = true;
		}
		public void Resume()
		{
			gameIsPaused = false;
		}
}
