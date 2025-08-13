using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using Unity.VisualScripting;

public abstract class Button_Anim : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected Vector3 Original_Scale;
    [SerializeField] protected float Scale_Factor = 0.6f;
    [SerializeField] protected float Anim_Time = 0.5f;
    private Tween Anim;

    public delegate void Click_Event();
    public event Click_Event click;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Anim != null && Anim.IsActive() && Anim.IsPlaying())
        {
            return;
        }
        Anim = transform.DOScale(Original_Scale * Scale_Factor, Anim_Time);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (Anim != null && Anim.IsActive() && Anim.IsPlaying())
        {
            Anim.Kill();
        }

        Anim = transform.DOScale(Original_Scale, Anim_Time).OnComplete(()=>OnButtonClicked());
    }
    
    void Start()
    {
        Original_Scale = transform.localScale;
    }
    protected abstract void OnButtonClicked();
    void Update()
    {

    }
}
    
   
