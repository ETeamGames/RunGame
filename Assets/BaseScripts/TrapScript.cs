using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {
	/// <summary>
	/// 罠の名前
	/// </summary>
	[SerializeField]
	private string trapName;
	/// <summary>
	/// 一意に決まる罠の識別子
	/// </summary>
	[SerializeField]
	private int trapNumber;
	/// <summary>
	/// 罠が発動してから消えるまでの時間
	/// </summary>
	[SerializeField]
	private float activeTime;
	/// <summary>
	/// 罠に掛かった時に拘束される時間
	/// </summary>
	[SerializeField]
	private float effectiveTime;
	/// <summary>
	/// 時間のバッファ
	/// </summary>
	protected float timeBuffer = -1;
	
	/*************プロパティ****************/
	public float EffectiveTime
	{
		get { return effectiveTime; }
		protected set { effectiveTime = value; }
	}
	public float ActiveTime
	{
		get { return activeTime; }
		protected set { activeTime = value; }
	}
	public int TrapNumber
	{
		get { return trapNumber; }
		protected set { trapNumber = value; }
	}
	public string TrapName
	{
		get { return trapName; }
		protected set { trapName = value; }
	}
	/****************************************/
	
	void OnTriggerEnter2D(Collider2D col)
	{
		IsTrapScript s = col.gameObject.GetComponent<IsTrapScript>();
		if(s != null)
		{
			// send this script information to the player
			s.callAnimation(this);
			timeBuffer = 0;
		}
	}
	
	/// <summary>
	/// 最初の衝突から有効であるかの判定
	/// </summary>
	/// <returns>まだ有効ならtrue　無効ならばfalse</returns>
	protected virtual bool activation()
	{
		if (timeBuffer < 0)
			return true;
		timeBuffer += Time.deltaTime;
		return timeBuffer < activeTime;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (!activation())
		{
			//GetComponent<Animator>().SetBool("activation", false);
			//デバッグ
			GetComponent<SpriteRenderer>().color = Color.black;
			timeBuffer = -1;
			// delete a trap object or some components
			Destroy(this.GetComponent<BoxCollider2D>());
		}
	}
}
