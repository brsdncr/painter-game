using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bucket : MonoBehaviour
{

    string bucketColor;
    bool isQuitting = false; //A variable to ensure not getting errors when inst, onDestroy
    [SerializeField] GameObject splashPrefab;
    float fallingSpeed;
    float minFallingSpeed = 1f;
    float maxFallingSpeed = 2f;

    [SerializeField] Camera dropCam;

    private void Awake()
    {
        fallingSpeed = Random.Range(minFallingSpeed, maxFallingSpeed);
    }

    private void Start()
    {
        bucketColor = StaticColors.GetRandomColor();
        SetOwnColor(bucketColor);
    }

    private void Update()
    {
        Fall();
    }

    private void Fall()
    {
        transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
    }

    

    private void SetOwnColor(string ownColor)
    {
        Color unityColor;
        ownColor = "#" + ownColor;

        if (ColorUtility.TryParseHtmlString(ownColor, out unityColor))
        {
            var m_renderer = gameObject.GetComponent<Renderer>();
            m_renderer.material.SetColor("_Color", unityColor);
        }
    }

    public string GetBucketColor()
    {
        return bucketColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            GameObject splash = Instantiate(splashPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);

            Color unityColor;
            bucketColor = "#" + bucketColor;
            if (ColorUtility.TryParseHtmlString(bucketColor, out unityColor))
            {
                splash.GetComponent<ParticleSystem>().startColor = unityColor;
            }
        }
    }

}
