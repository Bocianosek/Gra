using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    private ProductWrapper productInHands;
    private UIManager uiManager;

    private bool isProductInHands = false;

    [SerializeField] private GameObject carton;

    public bool IsProductInHands { get { return isProductInHands; } }
    public ProductWrapper ProductInHands { get { return productInHands; } }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void HeldProduct(ProductWrapper product)
    {
        productInHands = product;
        uiManager.DisplayHeldProduct(product);

        carton.SetActive(true);
        isProductInHands = true;
    }

    public void ResetHeldProduct()
    {
        productInHands = null;
        uiManager.RestHeldProduct();

        carton.SetActive(false);
        isProductInHands = false;
    }
}