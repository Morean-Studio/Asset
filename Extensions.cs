#if MOREAN_ASSETS
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Morean.Assets
{
    /// <summary>
    /// Addressable assets utilities.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Load addressable asset of type <typeparamref name="T"/> and Name or Label <paramref name="key"/>.
        /// </summary>
        public static async UniTask<bool> ResourceExists<T>(this object key)
            => (await Addressables.LoadResourceLocationsAsync(key, typeof(T)).ToUniTask()).Count > 0;

        /// <summary>
        /// Load addressable assets of type <typeparamref name="T"/> and Name or Label <paramref name="key"/>.
        /// </summary>
        public static async UniTask<IList<T>> LoadAssets<T>(this object key)
            => await Addressables.LoadAssetsAsync<T>(key, null).ToUniTask();

        /// <summary>
        /// Load addressable asset of type <typeparamref name="T"/> and Name or Label <paramref name="key"/>.
        /// </summary>
        public static async UniTask<T> LoadAsset<T>(this object key)
            => await Addressables.LoadAssetAsync<T>(key).ToUniTask();

        /// <summary>
        /// InstantiateAsync <see cref="GameObject"/> from addressables with Name or Label <paramref name="key"/>.
        /// </summary>
        public static async UniTask<GameObject> InstantiateAsync(
            this object key,
            Transform parent = null,
            bool instantiateInWorldSpace = false,
            bool trackHandle = true)

            => await Addressables.InstantiateAsync(
                key,
                parent,
                instantiateInWorldSpace,
                trackHandle).ToUniTask();

        public static async UniTask<GameObject[]> LoadAndInstantiateAssets(this object key)
        {
            var assets = await key.LoadAssets<GameObject>();
            var objects = new GameObject[assets.Count];
            for (int i = 0; i < assets.Count; i++)
            {
                var instance = GameObject.Instantiate(assets[i]);
                instance.name = assets[i].name;
                objects[i] = instance;
            }
            return objects;
        }

        public static void Unload(this object obj)
            => Addressables.Release(obj);

        public static void UnloadInstance(this GameObject obj)
            => Addressables.ReleaseInstance(obj);
    }
}
#endif