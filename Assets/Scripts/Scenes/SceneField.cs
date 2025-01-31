﻿// Taken from https://gist.github.com/phosphoer/c9c8cd3e19576c001d589cdf514a2ef1
// Which was in turn taken from http://wiki.unity3d.com/index.php/SceneField (dead link)

using UnityEngine;

namespace Scenes
{
    [System.Serializable]
    public class SceneField : ISerializationCallbackReceiver
    {

#if UNITY_EDITOR
        public UnityEditor.SceneAsset sceneAsset;
#endif

#pragma warning disable 414
        [SerializeField, HideInInspector]
        private string sceneName = "";
#pragma warning restore 414


        // Makes it work with the existing Unity methods (LoadLevel/LoadScene)
        public static implicit operator string(SceneField sceneField)
        {
#if UNITY_EDITOR
            return System.IO.Path.GetFileNameWithoutExtension(UnityEditor.AssetDatabase.GetAssetPath(sceneField.sceneAsset));
#else
    return sceneField.sceneName;
#endif
        }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            sceneName = this;
#endif
        }
        public void OnAfterDeserialize() { }
    } 
}