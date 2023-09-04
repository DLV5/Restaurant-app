using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public static Order Instance;

    private class OrderElement
    {
        public string name;
        public decimal price;
        public int count = 1;

        public OrderElement(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

    }

    private bool _hasMatch = false;

    private List<OrderElement> order = new List<OrderElement>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddDishInOrder(string name, decimal price)
    {
        foreach (var element in order)
        {
            if (element.name == name)
            {
                element.count++;
                _hasMatch = true;
                break;
            }
        }

        if(!_hasMatch)
        {
            order.Add(new OrderElement(name, price));
        }
    }

    public void GetTotalPrice()
    {
        decimal totalSum = 0;
        foreach (var element in order)
        {
            totalSum += element.price * element.count;
        }
    }
}
