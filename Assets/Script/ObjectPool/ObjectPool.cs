namespace DF.ObjectPool
{
    using System.Collections.Generic;
    using DF.Extension;
    using UnityEngine;
    using UnityEngineTimers;

    public class ObjectPool<T> where T : Component
    {
        private Transform _objectsParent = default;

        private List<T> ObjectsPool = new List<T>();
        private TimersPool _timersPool = TimersPool.GetInstance();

        public ObjectPool(Transform objectsParent)
        {
            _objectsParent = objectsParent;
        }

        public ObjectPool(Transform objectsParent, T prefab, int preGenCount)
        {
            _objectsParent = objectsParent;

            for (int i = 0; i < preGenCount; i++)
            {
                T item = CreateObject(prefab);
                item.Deactivate();
            }
        }

        public void Clear() => ObjectsPool.Clear();

        /// <summary>
        /// Получить объект из пула
        /// </summary>
        /// <returns></returns>
        public T GetObjectFromPool(T prefab)
        {
            if (ObjectsPool.Count > 0)
            {
                T currentObj = ObjectsPool[0];
                currentObj.gameObject.SetActive(true);
                ObjectsPool.RemoveAt(0);
                return currentObj;
            }
            return CreateObject(prefab);
        }

        /// <summary>
        /// Получить объект из пула на время
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public T GetObjectFromPool(T prefab, float time)
        {
            T currentObj;
            if (ObjectsPool.Count > 0)
            {
                currentObj = ObjectsPool[0];
                currentObj.gameObject.SetActive(true);
                ObjectsPool.RemoveAt(0);
            }
            else
            {
                currentObj = CreateObject(prefab);
            }
            _timersPool.StartTimer(() => AddToPool(currentObj), time);
            return currentObj;
        }

        /// <summary>
        /// Добавить объект в пул
        /// </summary>
        /// <param name="obj"></param>
        public void AddToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            ObjectsPool.Add(obj);
        }

        private T CreateObject(T prefab)
        {
            GameObject createdObj = GameObject.Instantiate(prefab.gameObject, _objectsParent);
            T objT = createdObj.GetComponent<T>();
            return objT;
        }
    }
}
