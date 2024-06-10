using UnityEngine;
using UnityEngine.UI;

public class SaveAnimationController : MonoBehaviour
{
    [SerializeField] Image confirm;

    private bool save;
    float count = 0.00000f;
    // Start is called before the first frame update
    void Start()
    {
        save = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (save)
        {
            count+=0.01f;
            if (count == 1f)
            {
                save = false;
                count = 0.00000f;
                gameObject.GetComponent<Image>().fillAmount = count;
                confirm.fillAmount = count;
            }
            gameObject.GetComponent<Image>().fillAmount = count;
            confirm.fillAmount = count;
        }
    }
    public void ActivateAnimation(){
        save = true;
    }
}
