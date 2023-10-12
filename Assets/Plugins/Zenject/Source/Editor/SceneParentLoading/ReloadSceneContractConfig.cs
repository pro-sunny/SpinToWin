using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Zenject.Internal
{
    public class ReloadSceneContractConfig : ScriptableObject
    {
        public const string ResourcePath = "ZenjectReloadSceneContractConfig";

        public List<ContractInfo> DefaultContracts;

        [Serializable]
        public class ContractInfo
        {
            public string ContractName;
            public SceneAsset Scene;
        }
    }
}
