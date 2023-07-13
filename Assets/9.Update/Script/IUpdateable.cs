using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatePart
{
    public interface IUpdateable
    {
        void OnUpdate(float dt);

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


