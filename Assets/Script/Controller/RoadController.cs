using System;
using System.Collections.Generic;
using DF.Data;
using DF.Input;
using DF.Interface;
using UnityEngine;

namespace DF.Controller
{
    internal sealed class RoadController : IExecuteLater, IDisposable
    {

        #region Fields

        private const int PRE_GENERATE_CHUNK = 3;

        private Vector2 _motionVector = Vector2.down;

        private readonly List<Chunk> _backMap;
        private readonly MapConfig _setting;


        #endregion


        #region ClassLife

        public RoadController(Chunk prefab, Transform chunkParent, MapConfig setting)
        {
            _setting = setting;
            _backMap = new List<Chunk>(PRE_GENERATE_CHUNK);

            for (int i = 0; i < PRE_GENERATE_CHUNK; i++)
            {
                var chunk = GameObject.Instantiate(prefab, chunkParent);
                if (_backMap.Count > 0)
                {
                    chunk.transform.position = _backMap[^1].End.position - chunk.Begin.localPosition;
                }

                chunk.TrigerEnter.AddListener(ObjectInvisible);
                _backMap.Add(chunk);
            }
        }

        public void Dispose()
        {
            _backMap.Clear();
            foreach (var item in _backMap)
            {
                item.TrigerEnter.RemoveListener(ObjectInvisible);
            }
        }

        #endregion


        #region Methods

        public void ExecuteLater()
        {
            foreach (var item in _backMap)
            {
                item.transform.Translate(_setting.Speed * Time.deltaTime * _motionVector);
            }
        }

        private void ObjectInvisible(Collider2D _)
        {
            var chunk = _backMap[0];
            _backMap.RemoveAt(0);
            chunk.transform.position = _backMap[^1].End.position - chunk.Begin.localPosition;
            _backMap.Add(chunk);
        }

        #endregion

    }
}
