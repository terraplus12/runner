using UnityEngine;
using DG.Tweening;
public class Coin_Move : Moving_Staff
{
    [SerializeField] private float MoveDist_y;
    [SerializeField] private float duration;
    [SerializeField] private float rotation;
    protected override void Move()
    {
        transform.position += vector * speed * Time.deltaTime * GameSettings.speed;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Stop_Object"))
        {
            IsFree = true;
        }
    }
    void Start()
    {
        transform.DOMoveY(transform.position.y + MoveDist_y, duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        transform.DORotate(new Vector3(360, 0, 0), rotation, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
}
