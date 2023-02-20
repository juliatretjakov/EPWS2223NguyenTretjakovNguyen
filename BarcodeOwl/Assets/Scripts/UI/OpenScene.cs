
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene: MonoBehaviour
{   
    public int SceneNumber;
    // Start is called before the first frame update
    public void sceneOpener()
    {
        SceneManager.LoadScene(SceneNumber);
    }

    // Update is called once per frame

}
