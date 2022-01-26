using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace TSim2.Menu
{
    internal class UI : MonoBehaviour
    {

        private static Rect mainWindow = new Rect(30f, 10f, 250f, 150f);
        private static Rect spawnWindow = new Rect(30f, 10f, 250f, 350f);

        public static void OnGUI()
        {

            mainWindow = GUILayout.Window(0, mainWindow, new GUI.WindowFunction(DrawHome), "Asgard", new GUILayoutOption[0]);
            if(spawnItemWindow)
                spawnWindow = GUILayout.Window(1, spawnWindow, new GUI.WindowFunction(DrawSpawn), "Asgard [Spawn Items]", new GUILayoutOption[0]);
        }

        public static bool aiESP;
        public static bool pedestrianESP;
        public static bool policeESP;
        public static bool carESP;
        public static bool guardESP;
        public static bool heliESP;
        public static bool dogESP;

        public static bool playWalkSpeed;
        public static bool playCrouchSpeed;
        public static bool playerCarryWeight;

        public static bool spawnItemWindow;

        public static bool t;
        public static float slideValue = 12;
        private static void DrawHome(int id) 
        {
            PlayerScript player = UnityEngine.Object.FindObjectOfType(typeof(PlayerScript)) as PlayerScript;


            GUILayout.Label("ESP Settings");
            aiESP = GUILayout.Toggle(aiESP, "AI", new GUILayoutOption[0]);
            carESP = GUILayout.Toggle(carESP, "Car", new GUILayoutOption[0]);
            heliESP = GUILayout.Toggle(heliESP, "Helicopter", new GUILayoutOption[0]);
            pedestrianESP = GUILayout.Toggle(pedestrianESP, "Pedestrain", new GUILayoutOption[0]);
            policeESP = GUILayout.Toggle(policeESP, "Police", new GUILayoutOption[0]);
            guardESP = GUILayout.Toggle(guardESP, "Guard", new GUILayoutOption[0]);
            dogESP = GUILayout.Toggle(dogESP, "Dog", new GUILayoutOption[0]);

            

            GUILayout.Space(15);
            GUILayout.Label("Add Money");
            if (GUILayout.Button("Give $500"))
                player.PickUpMoney(500);
            if (GUILayout.Button("Give $1000"))
                player.PickUpMoney(1000);
            if (GUILayout.Button("Give $10000"))
                player.PickUpMoney(10000);

            GUILayout.Space(10);
            GUILayout.Label("Misc Stuff");
            playWalkSpeed = GUILayout.Toggle(playWalkSpeed, "2x Walk Speed", new GUILayoutOption[0]);
            playCrouchSpeed = GUILayout.Toggle(playCrouchSpeed, "2x Crouch Speed", new GUILayoutOption[0]);

            player.PMB.moveSpeed = playWalkSpeed ? 10f : 5f;
            player.PMB.runSpeed = playWalkSpeed ? 20f : 10f;
            player.PMB.crouchSpeed = playCrouchSpeed ? 5f : 2.5f;

            GUILayout.Label("Gravity Scale");
            player.PMB.gravityScale = GUILayout.HorizontalSlider(player.PMB.gravityScale, -1, 2, new GUILayoutOption[0]);

            playerCarryWeight = GUILayout.Toggle(playerCarryWeight, "Max Carry Weight", new GUILayoutOption[0]);

            player.maxWeight = playerCarryWeight ? float.MaxValue : 45f; //Cba to check skill tree so just do 45 for now

            if (GUILayout.Button("Spawn Items"))
                spawnItemWindow = true;

            GUI.DragWindow();
        }

        public static Vector2 scrollPosition = Vector2.zero;
        private static void DrawSpawn(int id)
        {
            PlayerScript player = UnityEngine.Object.FindObjectOfType(typeof(PlayerScript)) as PlayerScript;


            if (GUILayout.Button("Close View"))
                spawnItemWindow = false;


            scrollPosition = GUILayout.BeginScrollView(scrollPosition, new GUILayoutOption[0]);

            if (GUILayout.Button("crowbar")) player.AddItem(0);
            if (GUILayout.Button("blt")) player.AddItem(1);
            if (GUILayout.Button("lockpick")) player.AddItem(2);
            if (GUILayout.Button("flashlight")) player.AddItem(3);
            if (GUILayout.Button("binoculars")) player.AddItem(4);
            if (GUILayout.Button("glasscutter")) player.AddItem(5);
            if (GUILayout.Button("stethoscope")) player.AddItem(6);
            if (GUILayout.Button("hackpda")) player.AddItem(7);
            if (GUILayout.Button("baton")) player.AddItem(8);
            if (GUILayout.Button("climbing_gloves")) player.AddItem(9);
            if (GUILayout.Button("automatic_lockpick")) player.AddItem(10);
            if (GUILayout.Button("hacking_laptop")) player.AddItem(11);
            if (GUILayout.Button("frying_pan")) player.AddItem(12);
            if (GUILayout.Button("teapot")) player.AddItem(13);
            if (GUILayout.Button("coffee_machine")) player.AddItem(14);
            if (GUILayout.Button("night_goggles")) player.AddItem(15);
            if (GUILayout.Button("jewellery_tools")) player.AddItem(16);
            if (GUILayout.Button("bracelet")) player.AddItem(17);
            if (GUILayout.Button("bracelet_parts")) player.AddItem(18);
            if (GUILayout.Button("automatic_lockpick")) player.AddItem(19);
            if (GUILayout.Button("regular_wallet")) player.AddItem(20);
            if (GUILayout.Button("atm_hacking_tool")) player.AddItem(21);
            if (GUILayout.Button("pixar_phone")) player.AddItem(22);
            if (GUILayout.Button("car_lock_pickgun")) player.AddItem(23);
            if (GUILayout.Button("blowtorch")) player.AddItem(24);
            if (GUILayout.Button("cardboard_box")) player.AddItem(25);
            if (GUILayout.Button("sleeping_gas")) player.AddItem(26);
            if (GUILayout.Button("respirator")) player.AddItem(27);
            if (GUILayout.Button("old_TV")) player.AddItem(28);
            if (GUILayout.Button("keyfob")) player.AddItem(29);
            if (GUILayout.Button("pot")) player.AddItem(30);
            if (GUILayout.Button("candelabra")) player.AddItem(31);
            if (GUILayout.Button("wine_creek")) player.AddItem(32);
            if (GUILayout.Button("ripple_tablet_broken")) player.AddItem(33);
            if (GUILayout.Button("vase")) player.AddItem(34);
            if (GUILayout.Button("vase")) player.AddItem(35);
            if (GUILayout.Button("super_TV")) player.AddItem(36);
            if (GUILayout.Button("hard_drive")) player.AddItem(37);
            if (GUILayout.Button("alarm_clock")) player.AddItem(38);
            if (GUILayout.Button("radio")) player.AddItem(39);
            if (GUILayout.Button("router")) player.AddItem(40);
            if (GUILayout.Button("toaster")) player.AddItem(41);
            if (GUILayout.Button("knifeholder")) player.AddItem(42);
            if (GUILayout.Button("antique_clock")) player.AddItem(43);
            if (GUILayout.Button("old_clock")) player.AddItem(44);
            if (GUILayout.Button("teapot")) player.AddItem(45);
            if (GUILayout.Button("wall_clock")) player.AddItem(46);
            if (GUILayout.Button("key_102")) player.AddItem(47);
            if (GUILayout.Button("painting_triangles")) player.AddItem(48);
            if (GUILayout.Button("remote_camera")) player.AddItem(49);
            if (GUILayout.Button("dog_meat")) player.AddItem(50);
            if (GUILayout.Button("micro_camera")) player.AddItem(51);
            if (GUILayout.Button("landline_phone")) player.AddItem(52);
            if (GUILayout.Button("abacus")) player.AddItem(53);
            if (GUILayout.Button("head_statue")) player.AddItem(54);
            if (GUILayout.Button("uphone_damaged")) player.AddItem(55);
            if (GUILayout.Button("blender")) player.AddItem(56);
            if (GUILayout.Button("painting_bond")) player.AddItem(57);
            if (GUILayout.Button("electric_kettle")) player.AddItem(58);
            if (GUILayout.Button("coffee_machine")) player.AddItem(59);
            if (GUILayout.Button("calculator")) player.AddItem(60);
            if (GUILayout.Button("wine_robert")) player.AddItem(61);
            if (GUILayout.Button("key_102_gate")) player.AddItem(62);
            if (GUILayout.Button("landline_phone")) player.AddItem(63);
            if (GUILayout.Button("projector")) player.AddItem(64);
            if (GUILayout.Button("headset")) player.AddItem(65);
            if (GUILayout.Button("low_end_laptop")) player.AddItem(66);
            if (GUILayout.Button("microphone")) player.AddItem(67);
            if (GUILayout.Button("radio_set")) player.AddItem(68);
            if (GUILayout.Button("wooden_decor")) player.AddItem(69);
            if (GUILayout.Button("headphones_noname")) player.AddItem(70);
            if (GUILayout.Button("key_103")) player.AddItem(71);
            if (GUILayout.Button("wifi_adapter")) player.AddItem(72);
            if (GUILayout.Button("pendrive")) player.AddItem(73);
            if (GUILayout.Button("subwoofer")) player.AddItem(74);
            if (GUILayout.Button("imak")) player.AddItem(75);
            if (GUILayout.Button("imak_keyboard")) player.AddItem(76);
            if (GUILayout.Button("imak_mouse")) player.AddItem(77);
            if (GUILayout.Button("watch_smithford")) player.AddItem(78);
            if (GUILayout.Button("tvremote")) player.AddItem(79);
            if (GUILayout.Button("acoustic_guitar")) player.AddItem(80);
            if (GUILayout.Button("vase")) player.AddItem(81);
            if (GUILayout.Button("vase")) player.AddItem(82);
            if (GUILayout.Button("vase")) player.AddItem(83);
            if (GUILayout.Button("printer")) player.AddItem(84);
            if (GUILayout.Button("sanny_phone")) player.AddItem(85);
            if (GUILayout.Button("flyp_smartphone")) player.AddItem(86);
            if (GUILayout.Button("motoloco_phone")) player.AddItem(87);
            if (GUILayout.Button("key_101")) player.AddItem(88);
            if (GUILayout.Button("flyby_drone")) player.AddItem(89);
            if (GUILayout.Button("cardboard_box")) player.AddItem(90);
            if (GUILayout.Button("black_package")) player.AddItem(91);
            if (GUILayout.Button("microwave")) player.AddItem(92);
            if (GUILayout.Button("nexon_camera")) player.AddItem(93);
            if (GUILayout.Button("flyp_smartphone")) player.AddItem(94);


            GUILayout.EndScrollView();


            GUI.DragWindow();
        }
    }
}
