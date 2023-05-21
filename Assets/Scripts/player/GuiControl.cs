using UnityEngine;
using System.Collections;

public class controlEnement {
	public Rect rect;
	public string str;
	public bool istexture;
	public Texture text;
	public Vector4 r;
	
	public  controlEnement(Vector4 r, string s){
		this.rect=new Rect((Screen.width/100)*r.x,(Screen.height/100)* r.y
			,(Screen.width/100)*r.z,(Screen.height/100)*r.w);
		this.str=s;
	}
	public void Button(){
		if(istexture) GUI.Box(rect,text);
		else
		GUI.Box(rect,str);
	}
	public void RepeatButton(){
		if(istexture) GUI.Box(rect,text);
		else GUI.Box(rect,str);
	}
}
public class GuiControl : MonoBehaviour {
	public CharacterMotor motor;
	// Use this for initialization
	public float sensitivityX = 15F;
	public float rot;
	public float horizontal;
	public float vertical;
	public int control=2;
	public controlEnement up=new controlEnement(new Vector4(15,65,10,10),"up");
	public controlEnement down=new controlEnement(new Vector4(15,85,10,10),"down");
	public controlEnement right=new controlEnement(new Vector4(15,65,10,10),"up");
	public controlEnement left=new controlEnement(new Vector4(15,65,10,10),"up");
	public controlEnement button1=new controlEnement(new Vector4(15,65,10,10),"up");
	public controlEnement button2=new controlEnement(new Vector4(15,65,10,10),"up");
	public float width;
	public float height;
	void Awake(){
	motor = GetComponent<CharacterMotor>();
	}
	void Start () {
	width=Screen.width;
		height=Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		// Get the input vector from kayboard or analog stick
	var directionVector = new Vector3(horizontal, 0, vertical);
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector;
	motor.inputJump = Input.GetButton("Jump");
		transform.Rotate(0, rot * sensitivityX, 0);
		rot=0;
		vertical=0;
		horizontal=0;
	}
	void OnGUI(){
		if(GUI.Button(new Rect(width*.1f,height*.1f,width*.1f,height*.1f),"control")){
			control=3-control;
		}
		if(GUI.RepeatButton(new Rect(width*.15f,height*.65f,width*.1f,height*.1f),"up")){
			vertical=1;
		}
		if(GUI.RepeatButton(new Rect(width*.15f,height*.85f,width*.1f,height*.1f),"down")){
			vertical=-1;
		}
		if(GUI.RepeatButton(new Rect(width*.05f,height*.75f,width*.1f,height*.1f),"left")){
			horizontal=-1;
		}
		if(GUI.RepeatButton(new Rect(width*.25f,height*.75f,width*.1f,height*.1f),"right")){
			horizontal=1;
		}
		if(control==1){
		if (GUI.Button(new Rect(width*.65f,height*.75f,width*.1f,height*.1f),"but1")){
			
		}
		if(GUI.Button(new Rect(width*.8f,height*.75f,width*.1f,height*.1f),"but2")){
			
		}
		}else if(control==2){
			if (GUI.Button(new Rect(width*.65f,height*.65f,width*.1f,height*.1f),"but1")){
			
		}
		if(GUI.Button(new Rect(width*.85f,height*.65f,width*.1f,height*.1f),"but2")){
			
		}
		if (GUI.RepeatButton(new Rect(width*.65f,height*.85f,width*.1f,height*.1f),"rot")){
			rot=-1;
		}
		if(GUI.RepeatButton(new Rect(width*.85f,height*.85f,width*.1f,height*.1f),"rot")){
			rot=1;
		}
		
		}
	}
}
