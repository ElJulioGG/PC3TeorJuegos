using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private bool isFollowing = false;

    void Update()
    {
        if (isFollowing && target != null && target.activeInHierarchy)
        {
            transform.position = target.transform.position;
        }
    }

    public void StartFollowing()
    {
        isFollowing = true;
    }

    public void StopFollowing()
    {
        isFollowing = false;
    }
}
