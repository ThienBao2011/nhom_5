using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCotroller : MonoBehaviour
{
    [SerializeField] int core = 0;
    [SerializeField] int live = 4;
    [SerializeField] TextMeshProUGUI coreText;
    [SerializeField] TextMeshProUGUI liveText;
    // Start is called before the first frame update
    void Start()
    {
        liveText.text = live.ToString();
        coreText.text = core.ToString();
    }
    public void AddCore(int coreToAdd)
    {
        core += coreToAdd;
        coreText.text = core.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
