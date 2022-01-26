using Unity;
using UnityEngine;

namespace TSim2
{
    public class Loader
    {
        private static GameObject _GO;

        public static void Load()
        {
            _GO = new GameObject();
            _GO.AddComponent<Main>();
            Object.DontDestroyOnLoad(_GO);
        }

        public static void Unload()
        {
            Object.Destroy(_GO);
            _GO = null;
        }
    }
}
