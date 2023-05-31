using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private TextMeshProUGUI interactionTextField;

    [Header("Held Product")]
    [SerializeField] private Image heldProductSlot;
    [SerializeField] private TextMeshProUGUI heldProductCountTextField;

    #region Interaction
    public void DisplayInteractionText(string interactionText)
    {
        interactionTextField.text = interactionText;
    }

    public void ResetInteractionText()
    {
        interactionTextField.text = "";
    }
    #endregion

    #region Held Product
    public void DisplayHeldProduct(ProductWrapper productWrapper)
    {
        heldProductSlot.sprite = productWrapper.Product.artwork;
        heldProductCountTextField.text = productWrapper.Count.ToString();
    }

    public void RestHeldProduct()
    {
        heldProductSlot.sprite = null;
        heldProductCountTextField.text = "";
    }
    #endregion
}