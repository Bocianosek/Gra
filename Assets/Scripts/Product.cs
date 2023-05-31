using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Product", menuName = "Product")]
public class Product : ScriptableObject
{
    public new string name;

    public Sprite artwork;

    public int price;
}
