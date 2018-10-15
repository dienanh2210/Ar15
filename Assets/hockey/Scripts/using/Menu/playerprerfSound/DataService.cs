using UnityEngine;

namespace EX1
{
	
	public class DataService : MonoBehaviour
	{
		private static DataService _instance = null;
		public static DataService Instance
		{
			get
			{
				
				if (_instance == null)
				{
					
					_instance = FindObjectOfType<DataService>();
				
					if (_instance == null)
					{
						GameObject go = new GameObject(typeof(DataService).ToString());
						_instance = go.AddComponent<DataService>();
					}
				}

				return _instance;
			}
		}

		public PlayerPrefsHandler prefs { get; private set; }

		private void Awake()
		{
			if (Instance != this)
			{
				Destroy(this);
			}
			else
			{
				DontDestroyOnLoad(gameObject);

				prefs = new PlayerPrefsHandler();
				prefs.RestorePreferences();
				
#if UNITY_5_4_OR_NEWER
				//SceneManager.sceneLoaded += OnLevelWasLoaded;
#endif
			}
		}

		void OnLevelWasLoaded()
		{
			prefs.RestorePreferences();
		}
	}
}