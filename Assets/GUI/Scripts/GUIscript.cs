using UnityEngine;
using System.Collections;

public class GUIscript : MonoBehaviour {
	
	bool show = false;
	bool expand = false;
	int menuHeight = 50, counter = 0;
	string[] size = new string[54];
	string[] label = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
		"A1","B1","C1","D1","E1","F1","G1","H1","I1","J1","K1","L1","M1","N1","O1","P1","Q1","R1","S1","T1","U1","V1","W1","X1","Y1","Z1",
		"A2","B2"};// = new string[26];
	int[] btn = new int[54];
	float lastWidth, lastHeight, newPosY = 44.0f, newPosX, leftX = -101.9f;
	float[] boxX = new float[54];
	float[] boxY = new float[54];
	public Transform item;
	private string state = "Off";
	
	void Start () {	
		//Labels
		size[0] = "A - 4x5.5"; size[1] = "B - 5.5x5.5"; size[2] = "C - 6.5x5.5"; size[3] = "D - 7.5x10.75"; size[4] = "E - 7.5x11.75"; size[5] = "F - 7.5x13.5";
		size[6] = "G - 8x5.5"; size[7] = "H - 8x9"; size[8] = "I - 10.25x7"; size[9] = "J - 13.25x6"; size[10] = "K - 7.25x11"; size[11] = "L - 9.25x6.5"; size[12] = "M - 7x9";
		size[13] = "N - 7.25x9"; size[14] = "O - 9x10.5"; size[15] = "P - 7.25x10"; size[16] = "Q - 5.75x7.5"; size[17] = "R - 6.5x22.5"; size[18] = "S - 6.5x21"; size[19] = "T - 15.5x4.5"; 
		size[20] = "U - 23.75x5"; size[21] = "V - 11.25x5.5"; size[22] = "W - 14x5.5"; size[23] = "X - 14.75x4.5"; size[24] = "Y - 17.5x5.5"; size[25] = "Z - 7.5x8"; 
		size[26] = "A1 - 8.25x7.75"; size[27] = "B1 - 24.25x8"; size[28] = "C1 - 8.5x8"; size[29] = "D1 - 8.5x8.5"; size[30] = "E1 - 11.5x8"; size[31] = "F1 - 6.25x8.25"; 
		size[32] = "G1 - 4.25x10.25"; size[33] = "H1 - 10x11.5"; size[34] = "I1 - 10.5x11.5"; size[35] = "J1 - 12.25x8.75"; size[36] = "K1 - 15.25x6"; size[37] = "L1 - 4.5x4.25"; 
		size[38] = "M1 - 12x12"; size[39] = "N1 - 10x8.5"; size[40] = "O1 - 10.25x8.5"; size[41] = "P1 - 11.25x4.5"; size[42] = "Q1 - 7.5x7"; size[43] = "R1 - 17.5x14.25"; size[44] = "S1 - 31.5x9.5";
		size[45] = "T1 - 25x10.5"; size[46] = "U1 - 9.5x9.25"; size[47] = "V1 - 10.5x9.5"; size[48] = "W1 - 8.5x7"; size[49] = "X1 - 9.75x6"; size[50] = "Y1 - 8.5x9.25"; size[51] = "Z1 - 9.5x7"; 
		size[52] = "A2 - 10.25x10.5"; size[53] = "B2 - 16.5x11";
		
		//label[0] = "A"; label[1] = "B"; label[2] = "C"; label[3] = "D"; label[4] = "E"; label[5] = "F"; label[6] = "G"; label[7] = "H"; label[8] = "I"; label[9] = "J";
		
		boxX[0] = 4.0f; boxX[1] = 5.5f; boxX[2] = 6.5f; boxX[3] = 7.5f; boxX[4] = 7.5f; boxX[5] = 7.5f; boxX[6] = 8.0f; boxX[7] = 8.0f; boxX[8] = 10.25f; boxX[9] = 13.25f; 
		boxX[10] = 11.0f; boxX[11] = 9.5f; boxX[12] = 7.0f; boxX[13] = 7.25f; boxX[14] = 9.0f; boxX[15] = 7.25f; boxX[16] = 5.75f; boxX[17] = 6.5f; boxX[18] = 6.5f; boxX[19] = 15.5f; 
		boxX[20] = 23.75f; boxX[21] = 11.25f; boxX[22] = 14.0f; boxX[23] = 14.75f; boxX[24] = 17.5f; boxX[25] = 7.5f; boxX[26] = 8.25f; boxX[27] = 24.25f; boxX[28] = 8.5f; boxX[29] = 8.5f; 
		boxX[30] = 11.5f; boxX[31] = 6.25f; boxX[32] = 4.25f; boxX[33] = 10.0f; boxX[34] = 10.5f; boxX[35] = 12.25f; boxX[36] = 15.25f; boxX[37] = 4.5f; boxX[38] = 12.0f; boxX[39] = 10.0f; 
		boxX[40] = 10.25f; boxX[41] = 11.25f; boxX[42] = 7.5f; boxX[43] = 7.5f; boxX[44] = 31.5f; boxX[45] = 25.0f; boxX[46] = 9.5f; boxX[47] = 10.5f; boxX[48] = 8.5f; boxX[49] = 9.75f; boxX[50] = 8.5f;
		boxX[51] = 9.5f; boxX[52] = 10.25f; boxX[53] = 16.5f;

		boxY[0] = 5.5f; boxY[1] = 5.5f; boxY[2] = 5.5f; boxY[3] = 10.75f; boxY[4] = 11.75f; boxY[5] = 13.5f; boxY[6] = 5.5f; boxY[7] = 9.0f; boxY[8] = 7.0f; boxY[9] = 6.0f; 
		boxY[10] = 7.25f; boxY[11] = 6.5f; boxY[12] = 9.0f; boxY[13] = 9.0f; boxY[14] = 10.5f; boxY[15] = 10.0f; boxY[16] = 7.5f; boxY[17] = 22.5f; boxY[18] = 21.0f; boxY[19] = 4.5f; 
		boxY[20] = 5.0f; boxY[21] = 5.5f; boxY[22] = 5.5f; boxY[23] = 4.5f; boxY[24] = 5.5f; boxY[25] = 8.0f; boxY[26] = 7.75f; boxY[27] = 8.0f; boxY[28] = 8.0f; boxY[29] = 8.5f; 
		boxY[30] = 8.0f; boxY[31] = 8.25f; boxY[32] = 10.25f; boxY[33] = 11.5f; boxY[34] = 11.5f; boxY[35] = 8.75f; boxY[36] = 6.0f; boxY[37] = 4.25f; boxY[38] = 12.0f; boxY[39] = 8.5f; 
		boxY[40] = 8.5f; boxY[41] = 4.5f; boxY[42] = 7.0f; boxY[43] = 14.25f; boxY[44] = 9.5f; boxY[45] = 10.5f; boxY[46] = 9.25f; boxY[47] = 9.5f; boxY[48] = 7.0f; boxY[49] = 6.0f; boxY[50] = 9.25f;
		boxY[51] = 7.0f; boxY[52] = 10.5f; boxY[53] = 11.0f;
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
				menuHeight = (btnHeight + 10) * 25 + 30;
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
