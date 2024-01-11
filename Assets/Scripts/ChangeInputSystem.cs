using UnityEngine;
using UnityEngine.UI;

public class ChangeInputSystem : MonoBehaviour
{
    public bool MobileInput = true;
    public bool DesktopInput = false;

    [SerializeField] private Sprite mobileDeviceIcon;
    [SerializeField] private Sprite desktopDeviceIcon;

    [SerializeField] private Image buttonImage;

    public void OnClick()
    {
        MobileInput = !MobileInput;
        DesktopInput = !DesktopInput;
        buttonImage.sprite = ChangeSprite();
    }
    private Sprite ChangeSprite()
    {
        if (MobileInput)
        {
            return mobileDeviceIcon;
        }
        else if (DesktopInput)
        {
            return desktopDeviceIcon;
        }
        return null;
    }
}
