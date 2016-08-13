using UnityEngine;
using System.Collections;

public class GUI_D14 : MonoBehaviour
{

    bool show = false;
    bool expand = false;
    int menuHeight = 50, counter = 0;
    string[] label = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X" };
    string[] size = new string[24];
    int[] btn = new int[24];
    float[] boxX = new float[24];
    float[] boxY = new float[24];
    float lastWidth, lastHeight, newPosY = 44.0f, newPosX, leftX = -101.9f;
    public Transform item;

    void Start()
    {
        //Labels
        size[0] = "A - 8.5x6"; size[1] = "B - 4x5.5"; size[2] = "C - 15.5x4.5"; size[3] = "D - 7.5x11"; size[4] = "E - 24x5"; size[5] = "F - 8.5x9";
        size[6] = "G - 10.5x7.5"; size[7] = "H - 12x6"; size[8] = "I - 12x8"; size[9] = "J - 22.5x7"; size[10] = "K - 8.5x7"; size[11] = "L - 12x4.5";
        size[12] = "M - 8x5.5"; size[13] = "N - 8.5x8"; size[14] = "O - 13.5x5"; size[15] = "P - 6x17"; size[16] = "Q - 6.5x23.5"; size[17] = "R - 7.5x12";
        size[18] = "S - 7.5x7"; size[19] = "T - 10.5x8.5"; size[20] = "U - 12x12"; size[21] = "V - 10.5x9.5"; size[22] = "W - 5.5x5.5"; size[23] = "X - 6.5x8.5";

        boxX[0] = 8.5f; boxX[1] = 4.0f; boxX[2] = 15.5f; boxX[3] = 7.5f; boxX[4] = 24.0f; boxX[5] = 8.5f; boxX[6] = 10.5f; boxX[7] = 12.0f; boxX[8] = 12.0f; boxX[9] = 22.5f;
        boxX[10] = 8.5f; boxX[11] = 12.0f; boxX[12] = 8.0f; boxX[13] = 8.5f; boxX[14] = 13.5f; boxX[15] = 6.0f; boxX[16] = 6.5f; boxX[17] = 7.5f; boxX[18] = 7.5f; boxX[19] = 10.5f;
        boxX[20] = 12.0f; boxX[21] = 10.5f; boxX[22] = 5.5f; boxX[23] = 6.5f;

        boxY[0] = 6.0f; boxY[1] = 5.5f; boxY[2] = 4.5f; boxY[3] = 11.0f; boxY[4] = 5.0f; boxY[5] = 9.0f; boxY[6] = 7.5f; boxY[7] = 6.0f; boxY[8] = 8.0f; boxY[9] = 7.0f;
        boxY[10] = 7.0f; boxY[11] = 4.5f; boxY[12] = 5.5f; boxY[13] = 8.0f; boxY[14] = 5.0f; boxY[15] = 17.0f; boxY[16] = 23.5f; boxY[17] = 12.0f; boxY[18] = 7.0f; boxY[19] = 8.5f;
        boxY[20] = 12.0f; boxY[21] = 9.5f; boxY[22] = 5.5f; boxY[23] = 8.5f;
    }

    void CreateBox(float width, float height, int button)
    {
        newPosX = leftX + (width / 2) + 1;
        newPosY = newPosY - (lastHeight / 2 + height / 2) - 1;
        if (newPosY - height < -50)
        {
            newPosY = 44.0f - (height / 2) - 1;
            newPosX = newPosX + lastWidth + 1;
            leftX = leftX + lastWidth + 1;
            lastWidth = width;
        }
        Transform box = (Transform)Instantiate(item, new Vector3(newPosX, newPosY, 99.0f), Quaternion.Euler(new Vector3(0, 180, 0)));
        TextMesh mesh = box.FindChild("New Text").GetComponent(typeof(TextMesh)) as TextMesh;
        Vector2 colDim = GetColliderSize(width, height);
        box.GetComponent<BoxCollider>().size = new Vector3(colDim.x, colDim.y, 1);
        mesh.text = label[button];

        box.transform.localScale = new Vector3(width, height, 2.0f);
        lastHeight = height;
        if (width > lastWidth)
        {
            lastWidth = width;
        }
    }

    void OnGUI()
    {

        int btnHeight = 25, btnWidth = 100, menuWidth = 240;
        float scrnHeight = Screen.height, scrnWidth = Screen.width;

        if (GUI.Button(new Rect(0, 0, btnWidth, btnHeight), "Box"))
        {
            show = !show;
            expand = false;
        }
        if (show)
        {
            int count = 0;

            GUI.BeginGroup(new Rect((scrnWidth - menuWidth) / 2, (scrnHeight - menuHeight) / 2, menuWidth, menuHeight));
            GUI.Box(new Rect(0, 0, menuWidth, menuHeight), "Menu");
            if (GUI.Button(new Rect(10, 20, 220, 20), "Box"))
            {
                expand = !expand;
            }
            if (expand)
            {
                menuHeight = (btnHeight + 10) * 14 + 30;
                for (int j = 50; j < menuHeight; j += 40)
                {
                    for (int i = 10; i < menuWidth; i += 120)
                    {
                        btn[count] = count;
                        if (GUI.Button(new Rect(i, j, btnWidth, btnHeight), size[count]))
                        {
                            CreateBox(boxX[count], boxY[count], count);
                        }
                        count++;
                    }
                }
                menuHeight = menuHeight + 10;
            }
            else
            {
                menuHeight = 50;
            }
            GUI.EndGroup();
        }
    }

    Vector2 GetColliderSize(float width, float height)
    {
        Vector2 boxDim = new Vector2(width, height);
        Vector2 dim = new Vector2(1, 1);
        boxDim.x = width + 1;
        dim.x = (boxDim.x - width) / width + 1;

        if(height <= 5)
        {
            boxDim.y = 2.0f;
        }
        else if(height > 5 && height <= 8)
        {
            boxDim.y = 3.0f;
        }
        else if (height > 8 && height <= 11)
        {
            boxDim.y = 4.0f;
        }
        else if (height > 11 && height <= 14)
        {
            boxDim.y = 5.0f;
        }
        else if (height > 14 && height <= 17)
        {
            boxDim.y = 6.0f;
        }
        else if (height > 17 && height <= 20)
        {
            boxDim.y = 7.0f;
        }
        else if (height > 20 && height <= 23)
        {
            boxDim.y = 8.0f;
        }
        else if (height > 23 && height <= 26)
        {
            boxDim.y = 9.0f;
        }
        boxDim.y = boxDim.y * 3;
        dim.y = (boxDim.y - height) / height + 1;

        return dim;
    }
}
