#if ASSET
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Asset
{
    /// <summary>
    /// Addressable assets utilities.
    /// </summary>
    public static class Asset
    {
        /// <summary>
        /// Load addressable assets of type <typeparamref name="T"/> and Name or Label <paramref name="key"/>.
        /// </summary>
        public static async Task<IList<T>> LoadAssets<T>(this object key)
            => await Addressables.LoadAssetsAsync<T>(key, null).Task;

        /// <summary>
        /// Load addressable asset of type <typeparamref name="T"/> and Name or Label <paramref name="key"/>.
        /// </summary>
        public static async Task<T> LoadAsset<T>(this object key)
            => await Addressables.LoadAssetAsync<T>(key).Task;

        /// <summary>
        /// Instantiate <see cref="GameObject"/> from addressables with Name or Label <paramref name="key"/>.
        /// </summary>
        public static async Task<GameObject> InstantiateAsset(
            this object key,
            Transform parent = null,
            bool instantiateInWorldSpace = false,
            bool trackHandle = true)

            => await Addressables.InstantiateAsync(
                key,
                parent,
                instantiateInWorldSpace,
                trackHandle).Task;
    }
}
#endif