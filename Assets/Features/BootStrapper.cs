using UnityEngine;

namespace II
{
    public static class BootStrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void CreateNeededObjectsBeforeSceneLoad()
        {
            var singletonPrefab = Resources.Load<GameObject>("Manager");
            var singletonObj = GameObject.Instantiate(singletonPrefab);
            GameObject.DontDestroyOnLoad(singletonObj);
        }
    }
}
