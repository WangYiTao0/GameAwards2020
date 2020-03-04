using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Graphic
{
    public enum Em2DType
    {
        Bar,
        Fade,
    }
    public enum Em3DType
    {
    }

    public class CsGraphicManager : MonoBehaviour
    {

        [SerializeField] private GameObject OBJ_Bar;
        [SerializeField] private GameObject OBJ_Fade;


        public void Create(Em2DType type)
        {
            switch (type)
            {
                case Em2DType.Bar:
                    Instantiate(OBJ_Bar);
                    break;
                case Em2DType.Fade:
                    Instantiate(OBJ_Fade);
                    break;
            }
        }
        public void Create(Em3DType type)
        {
            switch(type)
            {

            }
        }

    }
}
