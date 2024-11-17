using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StellarPlay.Common.Manager
{
    public interface IService { }

    public class ServiceManager
    {
        static ServiceManager _instance;
        public static ServiceManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceManager();
                }
                return _instance;
            }
        }

        private static readonly Dictionary<Type, IService> services = new Dictionary<Type, IService>();

        // Registers a service implementation with the Service Locator
        public void RegisterService<T>(T service) where T : IService
        {
            var type = typeof(T);
            if (!services.ContainsKey(type))
            {
                services[type] = service;
            }
        }

        // Retrieves a service from the Service Locator
        public T GetService<T>() where T : IService
        {
            var type = typeof(T);
            if (services.TryGetValue(type, out var service))
            {
                return (T)service;
            }
            throw new Exception($"Service of type {type} is not registered.");
        }

        // Optional: Remove a service from the Service Locator
        public void UnregisterService<T>() where T : IService
        {
            var type = typeof(T);
            if (services.ContainsKey(type))
            {
                services.Remove(type);
            }
        }

        // Optional: Clear all registered services
        public void ClearServices()
        {
            services.Clear();
        }
    }
}
