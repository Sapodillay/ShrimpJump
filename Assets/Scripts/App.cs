using UnityEngine;

public class App : MonoBehaviour
{


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootstrap()
    {
        var app = Instantiate(Resources.Load("App")) as GameObject;
        if (app == null)
            throw new System.ApplicationException();

        DontDestroyOnLoad(app);

    }


}
