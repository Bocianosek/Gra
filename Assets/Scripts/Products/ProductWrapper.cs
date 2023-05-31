using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductWrapper
{
    private Product product;
    private int count;

    public Product Product => product;
    public int Count => count; // to jest to samo co: "public int Count { get { return count; } }", tylko w skrócie

    public ProductWrapper(Product product, int count)
    {
        this.product = product;
        this.count = count;
    }
}