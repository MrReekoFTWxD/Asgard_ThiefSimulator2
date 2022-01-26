using UnityEngine;

namespace TSim2
{
    internal class Main : MonoBehaviour
    {

        public static Texture2D lineTex;
        public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
        {
            Matrix4x4 matrix = GUI.matrix;
            if (!lineTex)
            {
                lineTex = new Texture2D(1, 1);
            }
            Color color2 = GUI.color;
            GUI.color = color;
            float num = Vector3.Angle(pointB - pointA, Vector2.right);
            if (pointA.y > pointB.y)
            {
                num = -num;
            }
            GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
            GUIUtility.RotateAroundPivot(num, pointA);
            GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), lineTex);
            GUI.matrix = matrix;
            GUI.color = color2;
        }

        public bool menuOpen;

        public void Start()
        {
            if (Menu.AsgardLogo.AsgardImage == null)
            {
                Menu.AsgardLogo.AsgardImage = new Texture2D(1, 1);
                Menu.AsgardLogo.AsgardImage.LoadImage(Menu.AsgardLogo.rawData);
            }

           
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
                menuOpen = !menuOpen;
        }

        public void OnGUI()
        {
            Graphics.DrawTexture(new Rect(5, UnityEngine.Screen.height - 45, 45, 45), Menu.AsgardLogo.AsgardImage);

            if (menuOpen)
                Menu.UI.OnGUI();

            if (Menu.UI.aiESP)
            {
                foreach (AI ai in Object.FindObjectsOfType(typeof(AI)) as AI[])
                {
                    if (ai.enabled)
                    {
                        Vector3 Position = Camera.main.WorldToScreenPoint(ai.transform.position);
                        DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height - 1)), new Vector2(Position.x, (float)Screen.height - Position.y), Color.green, 2f);//SnapLine
                    }
                }
            }

            if (Menu.UI.pedestrianESP)
            {
                foreach (SidewalkAI ai in Object.FindObjectsOfType(typeof(SidewalkAI)) as SidewalkAI[])
                {
                    if (ai.enabled)
                    {
                        Vector3 Position = Camera.main.WorldToScreenPoint(ai.transform.position);
                        DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height - 1)), new Vector2(Position.x, (float)Screen.height - Position.y), Color.green, 2f);//SnapLine
                    }
                }
            }

            if (Menu.UI.carESP)
            {
                foreach (AICar ai in Object.FindObjectsOfType(typeof(AICar)) as AICar[])
                {
                    if (ai.enabled)
                    {
                        Vector3 Position = Camera.main.WorldToScreenPoint(ai.transform.position);
                        DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height - 1)), new Vector2(Position.x, (float)Screen.height - Position.y), Color.green, 2f);//SnapLine
                    }
                }
            }

            if (Menu.UI.heliESP)
            {
                foreach (HelicopterAI ai in Object.FindObjectsOfType(typeof(HelicopterAI)) as HelicopterAI[])
                {
                    if (ai.enabled)
                    {
                        Vector3 Position = Camera.main.WorldToScreenPoint(ai.transform.position);
                        DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height - 1)), new Vector2(Position.x, (float)Screen.height - Position.y), Color.blue, 2f);//SnapLine
                    }
                }
            }

            if (Menu.UI.policeESP)
            {
                foreach (PolicemanAI ai in Object.FindObjectsOfType(typeof(PolicemanAI)) as PolicemanAI[])
                {
                    if (ai.enabled)
                    {
                        Vector3 Position = Camera.main.WorldToScreenPoint(ai.transform.position);
                        DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height - 1)), new Vector2(Position.x, (float)Screen.height - Position.y), Color.blue, 2f);//SnapLine
                    }
                }
            }

            if (Menu.UI.guardESP)
            {
                foreach (GuardAI ai in Object.FindObjectsOfType(typeof(GuardAI)) as GuardAI[])
                {
                    if (ai.enabled)
                    {
                        Vector3 Position = Camera.main.WorldToScreenPoint(ai.transform.position);
                        DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height - 1)), new Vector2(Position.x, (float)Screen.height - Position.y), Color.red, 2f);//SnapLine
                    }
                }
            }

            if (Menu.UI.dogESP)
            {
                foreach (DogAI ai in Object.FindObjectsOfType(typeof(DogAI)) as DogAI[])
                {
                    if (ai.enabled)
                    {
                        Vector3 Position = Camera.main.WorldToScreenPoint(ai.transform.position);
                        DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height - 1)), new Vector2(Position.x, (float)Screen.height - Position.y), Color.yellow, 2f);//SnapLine
                    }
                }
            }
        }
    }
}
