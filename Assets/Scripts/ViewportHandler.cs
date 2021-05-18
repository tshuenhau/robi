using Cinemachine;
using UnityEngine;

public class ViewportHandler : MonoBehaviour
{
    public int fullWidthUnits = 6;

	void Start () {
		// Force fixed width
		float ratio = (float)Screen.height / (float)Screen.width;
		GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = (float)fullWidthUnits * ratio / 2.0f;
	}
	public int  GetFullWidthUnits(){
		return fullWidthUnits;
	}
}
