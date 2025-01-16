using Pi.Subsystems;
using UnityEngine;

namespace Character
{
    public class PlayerControllerSystem : SubsystemLocator
    {
        private static PlayerControllerSystem instance;

        public static SurvivorPlayerController CurrentPlayerController => instance?.PlayerController;
        public SurvivorPlayerController PlayerController { get; private set; }

        // PlayerController System Interface
        public static T FindOrRegister<T>() where T : PlayerControllerSubsystem
        {
            var subsystem = Find<T>();
            return subsystem? subsystem : instance?.gameObject.AddComponent<T>();
        }
        public static T Find<T>() where T : PlayerControllerSubsystem
        {
            if (!instance)
            {
                Debug.LogError("[Character.PlayerControllerSystem] PlayerController System has no instance");
            }
            return instance?.GetComponent<T>();
        }
 
        public static void RegisterPlayerController(SurvivorPlayerController newController)
        {
            var system = GetOrCreateInstance();
            if (!system) { return; }

            system.PlayerController = newController;
            system.RegisterSubsystems();
        }

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
        private static PlayerControllerSystem GetOrCreateInstance()
        {
            if (instance) { return instance; }
            var instanceObject = new GameObject("PlayerControllerSystem", typeof(PlayerControllerSystem));
            instance = instanceObject.GetComponent<PlayerControllerSystem>();
            return instance;
        }
 
        private void RegisterSubsystems()
        {
            foreach (var subsystemType in SubsystemLocators.GetAllSubsystemTypes<PlayerControllerSubsystem>())
            {
                if (!GetComponent(subsystemType)) { gameObject.AddComponent(subsystemType); }
            }
        }
    }       
}