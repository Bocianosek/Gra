using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Shelf : InteractableObject
{
    private Product product;
    private int productCount;

    [SerializeField] private Transform productsPointsParent;

    private List<Transform> productsPoints = new List<Transform>();

    protected override void Start()
    {
        base.Start();

        foreach (Transform point in productsPointsParent)
        {
            productsPoints.Add(point);
        }
    }

    protected override void InteractWithObject()
    {
        base.InteractWithObject();

        if (playerHands.IsProductInHands == true && (product == null || playerHands.ProductInHands.Product == product))
        {
            product = playerHands.ProductInHands.Product;
            productCount += playerHands.ProductInHands.Count;

            for (int i = 0; i < productsPoints.Count; i++)
            {
                if (i < productCount)
                {
                    if (productsPoints[i].childCount == 0)
                    {
                        GameObject productModel = Instantiate(product.model, productsPoints[i]);
                        productModel.transform.localPosition = new Vector3(0, 0, 0);
                        productModel.transform.localRotation = Quaternion.identity;
                    }
                }
            }

            playerHands.ResetHeldProduct();
        }
    }
}