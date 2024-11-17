using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StellarPlay.Common.Manager
{
    public class Context : MonoBehaviour
    {
        protected ServiceManager serviceManager = ServiceManager.Instance;
        // Start is called before the first frame update
        void Start()
        {
            RegisterServices();
            CreateControllers();
            StartCoroutine(CallPostRegistration());
        }

        IEnumerator CallPostRegistration()
        {
            yield return new WaitForEndOfFrame();
            PostRegistration();
        }

        private void OnDestroy()
        {
            UnRegisterServices();
        }

        public virtual void RegisterServices()
        {

        }

        public virtual void PostRegistration()
        {

        }

        public virtual void CreateControllers()
        {

        }

        public virtual void UnRegisterServices()
        {

        }

      
    }
}
