using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class ClothShop : Shop
    {
        protected override void Awake()
        {
            base.Awake();
            ShopName = "CLOTHS";
        }
    }
}