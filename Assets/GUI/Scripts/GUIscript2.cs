using UnityEngine;
using System.Collections;

public class GUIscript2 : MonoBehaviour {
	
	bool show = false;
	bool expand = false;
	int menuHeight = 50, counter = 0;
	string[] size = new string[20];
	string[] label = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T"};// = new string[26];
	int[] btn = new int[20];
	float lastWidth, lastHeight, newPosY = 44.0f, newPosX, leftX = -101.9f;
	float[] boxX = new float[20];
	float[] boxY = new float[20];
	public Transform item;
	private string state = "Off";
	
	void Start () {	
		//Labels
		size[0] = "A - 27.5x10"; size[1] = "B - 8x19"; size[2] = "C - 8x8.75"; size[3] = "D - 7.5x12"; size[4] = "E - 13.25x6"; size[5] = "F - 7x5.5";
		size[6] = "G - 11x7.5"; size[7] = "H - 11.75x4.5"; size[8] = "I - 8x5.75"; size[9] = "J - 4x5.5"; size[10] = "K - 7.5x10.75"; size[11] = "L - 10.25x7.25"; size[12] = "M - 9.5x9.25";
		size[13] = "N - 9.75x6"; size[14] = "O - 11x10.25"; size[15] = "P - 9.75x6.75"; size[16] = "Q - 8.5x9.25"; size[17] = "R - 7.5x9"; size[18] = "S - 8.5x8.5"; size[19] = "T - 31.5x9.5"; 
		
		//label[0] = "A"; label[1] = "B"; label[2] = "C"; label[3] = "D"; label[4] = "E"; label[5] = "F"; label[6] = "G"; label[7] = "H"; label[8] = "I"; label[9] = "J";
		
		boxX[0] = 27.5f; boxX[1] = 8.0f; boxX[2] = 8.0f; boxX[3] = 7.5f; boxX[4] = 13.25f; boxX[5] = 7.0f; boxX[6] = 11.0f; boxX[7] = 11.75f; boxX[8] = 8.0f; boxX[9] = 4.0f; 
		boxX[10] = 7.5f; boxX[11] = 10.25f; boxX[12] = 9.5f; boxX[13] = 9.75f; boxX[14] = 11.0f; boxX[15] = 9.75f; boxX[16] = 8.5f; boxX[17] = 7.5f; boxX[18] = 8.5f; boxX[19] = 31.5f; 
		
		boxY[0] = 10.0f; boxY[1] = 19.0f; boxY[2] = 8.75f; boxY[3] = 12.0f; boxY[4] = 6.0f; boxY[5] = 5.5f; boxY[6] = 7.5f; boxY[7] = 4.5f; boxY[8] = 5.75f; boxY[9] = 5.5f; 
		boxY[10] = 10.75f; boxY[11] = 7.25f; boxY[12] = 9.25f; boxY[13] = 6.0f; boxY[14] = 10.25f; boxY[15] = 6.75f; boxY[16] = 9.25f; boxY[17] = 9.0f; boxY[18] = 8.5f; boxY[19] = 9.5f; 
	}
	
	void Update() {	
		/*float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		Vector3 mouseLoc = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 79));
		print(mouseLoc);*/
	}
	void CreateBox(float width, float height, int button) {
		newPosX = leftX + (width / 2) + 1;
		newPosY = newPosY - (lastHeight / 2 + height / 2) - 1;
		if(newPosY - height < -50) {
			newPosY = 44.0f - (height / 2) - 1;
			newPosX = newPosX + lastWidth + 1;
			leftX = leftX + lastWidth + 1;
			lastWidth = width;
		}
		Transform box = (Transform)Instantiate(item, new Vector3(newPosX, newPosY, 69.0f), Quaternion.identity);
		TextMesh mesh = box.FindChild("New Text").GetComponent(typeof(TextMesh)) as TextMesh;
		mesh.text = label[button];
		
		box.transform.localScale = new Vector3(width, height, 2.0f);
		lastHeight = height;
		if(width > lastWidth) {
			lastWidth = width;
		}
	}
	
	void OnGUI() {
		
		int btnHeight = 25, btnWidth = 100, menuWidth = 240;
		float scrnHeight = Screen.height, scrnWidth = Screen.width;
		
		if(GUI.Button(new Rect(0, 0, btnWidth, btnHeight), "Box")) {
			show = !show;
			expand = false;
		}
		if(show) {
			int count = 0;
			
			GUI.BeginGroup(new Rect((scrnWidth - menuWidth) / 2, (scrnHeight - menuHeight) / 2, menuWidth, menuHeight));
			GUI.Box (new Rect(0, 0, menuWidth, menuHeight), "Menu");
			if(GUI.Button (new Rect(10, 20, 220, 20), "Box")) {
				expand = !expand;
			}
			if(expand) {
				menuHeight = (btnHeight + 10) * 12 + 30;
				for(int j = 50; j < menuHeight; j += 40) {
					for(int i = 10; i < menuWidth; i += 120) {
						btn[count] = count;
						if(GUI.Button (new Rect(i, j, btnWidth, btnHeight), size[count])) {
							CreateBox(boxX[count], boxY[count], count);
						}
						count++;
					}
				}
				menuHeight = menuHeight + 10;
			}
			else {
				menuHeight = 50;
			}
			GUI.EndGroup();
		}
	}
}
