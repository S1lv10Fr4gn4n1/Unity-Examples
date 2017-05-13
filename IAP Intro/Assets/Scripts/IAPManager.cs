using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener
{

    public static IAPManager Instance;
    static IStoreController mStoreController;
    static IExtensionProvider mStoreExtensionProvider;

    int mCredits;

    public int Credits
    {
        get
        { 
            return mCredits;
        }
    }

    static string packageName = "iap_space_shooter_test";
    public static string productId100Credits = packageName + ".100_credits";
    public static string productIdDoubleShot = packageName + ".double_shot";
    public static string productIdTripleShot = packageName + ".triple_shot";


    static IDs storeId100Credits = new IDs()
    {
        { productId100Credits + "_google", GooglePlay.Name },
        { productId100Credits + "_mac", MacAppStore.Name },
        { productId100Credits + "_ios", AppleAppStore.Name },
        { productId100Credits + "_win", WindowsStore.Name }
    };


    public Text creditText;
    public Text messageText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        if (!IsInitialized())
        {
            InitializePurchasing();
        }
        UpdateCreditsText();
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        StandardPurchasingModule module = StandardPurchasingModule.Instance();
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);
        builder.AddProduct(productId100Credits, ProductType.Consumable, storeId100Credits);
        builder.AddProduct(productIdDoubleShot, ProductType.NonConsumable);
        builder.AddProduct(productIdTripleShot, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        mStoreController = controller;
        mStoreExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogWarning("IAPManager error " + error);
        ShowMessage("OnInitializeFailed " + error);
    }

    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
        Debug.LogWarning("IAPManager OnPurchaseFailed for product " + i.definition.id + " PurchaseFailureReason " + p);
        ShowMessage("OnPurchaseFailed " + p);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        string productId = e.purchasedProduct.definition.id;
        HandlePurchase(productId);
        return PurchaseProcessingResult.Complete;
    }

    void HandlePurchase(string productId)
    {
        if (productId == productId100Credits)
        {
            AddCredits(100);
        }
        else if (productId == productIdDoubleShot)
        {
            EnableDoubleShot();
        }
        else if (productId == productIdTripleShot)
        {
            EnableTripleShot();
        }
    }

    bool IsInitialized()
    {
        return (mStoreController != null && mStoreExtensionProvider != null);
    }

    public void BuyProductID(string productId)
    {
        if (!IsInitialized())
        {
            Debug.LogWarning("IAPMANAGER BuyProductID Error: " + productId + ". Store not initialized");
            ShowMessage("Store not initialized");
            return;
        }

        Product product = mStoreController.products.WithID(productId);

        if (product != null)
        {
            if (product.hasReceipt && product.definition.type == ProductType.NonConsumable)
            {
                HandlePurchase(productId);
                Debug.Log("IAPMANAGER " + product.definition.id + " already purchased!");
                ShowMessage("Enabling " + product.definition.id);
            }
            else if (product.availableToPurchase)
            {
                mStoreController.InitiatePurchase(product);
                Debug.Log("IAPMANAGER Purchasing product " + product.definition.id);
                ShowMessage("Purchasing " + product.definition.id);
            }
        }
        else
        {
            Debug.Log("IAPMANAGER BuyProductId Error: " + product.definition.id + " not found");
            ShowMessage("Product " + product.definition.id + " not found");
        }
    }

    public void AddCredits(int creditsToAdd)
    {
        mCredits += creditsToAdd;
        UpdateCreditsText();
    }

    public void Buy100Credits()
    {
        BuyProductID(productId100Credits);
    }

    public void BuyDoubleShot()
    {
        BuyProductID(productIdDoubleShot);
    }

    public void BuyTripleShot()
    {
        BuyProductID(productIdTripleShot);
    }

    void EnableDoubleShot()
    {
        WeaponSwitcher weaponSwitcher = GameObject.FindWithTag("WeaponSwitcher").GetComponent<WeaponSwitcher>();
        if (weaponSwitcher != null)
        {
            weaponSwitcher.SwitchWeapon(1);
        }
    }

    void EnableTripleShot()
    {
        WeaponSwitcher weaponSwitcher = GameObject.FindWithTag("WeaponSwitcher").GetComponent<WeaponSwitcher>();
        if (weaponSwitcher != null)
        {
            weaponSwitcher.SwitchWeapon(2);
        }
    }

    void UpdateCreditsText()
    {
        if (creditText == null)
        {
            return;
        }

        creditText.text = "Credits " + mCredits.ToString();
    }

    void ShowMessage(string message, float delay = 2f)
    {
        StartCoroutine(ShowMessageRoutine(message, delay)); 
    }

    IEnumerator ShowMessageRoutine(string message, float delay)
    {
        if (messageText != null)
        {
            messageText.text = message;
            yield return new WaitForSecondsRealtime(delay);
            messageText.text = "";
        }
    }
}
