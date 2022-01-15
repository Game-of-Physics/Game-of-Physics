using UnityEngine;
using UnityEngine.SceneManagement;
 
public class InitializeOnLoad : MonoBehaviour {
 
	[RuntimeInitializeOnLoadMethod]
	public void Initialize()
	{
		if (SceneManager.GetActiveScene().name == "StartMenu")
		{
			return;
		}
        SceneManager.LoadScene("StartMenu");
	}
	    void Update()
    {
		
    }
}