using Pi.Subsystems;
using UnityEngine;

namespace MapSystems
{
    public class MapSystem : SubsystemLocator
    {
        private static MapSystem instance;

        // Map System Interface
        public static T FindOrRegister<T>() where T : MapSubsystem
        {
            var subsystem = Find<T>();
            return subsystem? subsystem : instance?.gameObject.AddComponent<T>();
        }
        public static T Find<T>() where T : MapSubsystem
        {
            if (!instance) { Debug.LogError("[Survivor.MapSystem] Map System has no instance"); }
            return instance?.GetComponent<T>();
        }

        public static void RegisterMap(Transform newProjection)
        {
            var system = GetOrCreateInstance();
            if (!system) { return; }
            system.IsometricProjection = newProjection;
            system.RegisterSubsystems();
        }

        public static Transform CurrentIsometricProjection => instance?.IsometricProjection;
        public Transform IsometricProjection { get; private set; }
        
        // Unity Events
        private void Awake()
        {
            if (instance && instance != this) { Destroy(this); }
        }
        private void OnDestroy()
        {
            if (instance == this) { instance = null; }
        }

        // Internal Interface
        private static MapSystem GetOrCreateInstance()
        {
            if (instance) { return instance; }
            var instanceObject = new GameObject("MapSystem", typeof(MapSystem));
            instance = instanceObject.GetComponent<MapSystem>();
            return instance;
        }

        private void RegisterSubsystems()
        {
            foreach (var subsystemType in SubsystemLocators.GetAllSubsystemTypes<MapSubsystem>())
            {
                if (!GetComponent(subsystemType)) { gameObject.AddComponent(subsystemType); }
            }
        }
    }
}