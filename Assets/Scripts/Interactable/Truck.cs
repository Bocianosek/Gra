using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : InteractableObject
{
    [SerializeField] private GameObject model;
    [SerializeField] private BoxCollider collider;

    [Header("Delivery Time")]
    [SerializeField] private float minDeliveryTime;
    [SerializeField] private float maxDeliveryTime;

    [Header("Products")]
    [SerializeField] private List<Product> products = new List<Product>();

    private bool deliver;

    private float deliveryTime;
    private float timer;

    protected override void Start()
    {
        base.Start();

        PlanDelivery();
    }

    protected override void Update()
    {
        base.Update();

        if (deliver)
        {
            timer += Time.deltaTime;

            if (timer >= deliveryTime)
            {
                DeliveryArrived();
                timer = 0;
            }
        }

    }

    protected override void InteractWithObject()
    {
        if (playerHands.IsProductInHands == false)
        {
            base.InteractWithObject();

            ProductWrapper deliveryProduct = GetProduct();
            playerHands.HeldProduct(deliveryProduct);

            StopInteractWithObject();
            PlanDelivery();
        }
        else
        {
            Debug.Log("Ju¿ masz coœ w rêce!");
        }
    }

    private ProductWrapper GetProduct()
    {
        Product randomProduct = products[Random.Range(0, products.Count)];
        int randomCount = Random.Range(1, 5);

        ProductWrapper productWrapper = new ProductWrapper(randomProduct, randomCount);

        return productWrapper;
    }

    private void PlanDelivery()
    {
        model.SetActive(false);
        collider.enabled = false;
        playerInTrigger = false;
         
        deliveryTime = Random.Range(minDeliveryTime, maxDeliveryTime);
        deliver = true;
    }

    private void DeliveryArrived()
    {
        model.SetActive(true);
        collider.enabled = true;

        deliver = false;
    }
}