using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    /*room 1 Xmin = -18.5 Ymin = -14 , Xmax = 18.5 Ymax = 12
     Para Room2 fazer Ymax=38, y min = 26 e Xmin = -18.5 e Xmax= -1.3*/
    public Vector2 cameraNextRoomMax;
    public Vector2 cameraNextRoomMin;
    public Vector3 playerChange;
        
    private CameraMovement cam;

    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition = cameraNextRoomMin;
            cam.maxPosition = cameraNextRoomMax;
            other.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }
    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4);
        text.SetActive(false);
    }
}
