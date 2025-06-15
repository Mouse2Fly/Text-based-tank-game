using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Classes;
using static Controler.Player;
using Phrases;

namespace Phrases
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        Vehicle Player1;
        Vehicle Player2;
        RoundCounter playing = new RoundCounter();
        string direction = string.Empty;
        decimal shoot_height = 0;
        decimal shoot_strenght = 0;
        bool skip = false;

        ActiceFunc function = new ActiceFunc();
        //=============================================
        // 1: Movement_part2
        // 2: Shooting_part1
        // 3: Shooting_part2
        //=============================================

        public void Start()
        {
            ClassList list11 = new ClassList();
            ClassList list22 = new ClassList();
            p1_ClassSelectorBox.DataSource = list11.selectableClasses;
            p2_ClassSelectorBox.DataSource = list22.selectableClasses;
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            game_textbox.SelectionStart = game_textbox.Text.Length;
            // scroll it automatically
            game_textbox.ScrollToCaret();
        }

        private void ClassSelectorBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (p1_ClassSelectorBox.SelectedItem.ToString())
            {
                case "MBT":
                    p1_Health_text.Text = "200";
                    p1_Speed_text.Text = "60%";
                    p1_AP_text.Text = "INF";
                    p1_HE_text.Text = "10";
                    p1_MG_text.Text = "200";
                    p1_Auto_text.Text = "0";
                    p1_Rocket_text.Text = "0";
                    pictureBox1.Image = Image.FromFile("../img/tank.jpg");
                    break;
                case "IFV":
                    p1_Health_text.Text = "145";
                    p1_Speed_text.Text = "100%";
                    p1_AP_text.Text = "0";
                    p1_HE_text.Text = "0";
                    p1_MG_text.Text = "200";
                    p1_Auto_text.Text = "INF";
                    p1_Rocket_text.Text = "4";
                    pictureBox1.Image = Image.FromFile("../img/ifv.jpg");
                    break;
                case "Truck":
                    p1_Health_text.Text = "50";
                    p1_Speed_text.Text = "160%";
                    p1_AP_text.Text = "0";
                    p1_HE_text.Text = "0";
                    p1_MG_text.Text = "INF";
                    p1_Auto_text.Text = "0";
                    p1_Rocket_text.Text = "8";
                    pictureBox1.Image = Image.FromFile("../img/truck.png");
                    break;
            }
        }

        private void ClassSelectorBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (p2_ClassSelectorBox.SelectedItem.ToString())
            {
                case "MBT":
                    p2_Health_text.Text = "200";
                    p2_Speed_text.Text = "60%";
                    p2_AP_text.Text = "INF";
                    p2_HE_text.Text = "10";
                    p2_MG_text.Text = "200";
                    p2_Auto_text.Text = "0";
                    p2_Rocket_text.Text = "0";
                    pictureBox2.Image = Image.FromFile("../img/tank.jpg");
                    break;
                case "IFV":
                    p2_Health_text.Text = "145";
                    p2_Speed_text.Text = "100%";
                    p2_AP_text.Text = "0";
                    p2_HE_text.Text = "0";
                    p2_MG_text.Text = "200";
                    p2_Auto_text.Text = "INF";
                    p2_Rocket_text.Text = "4";
                    pictureBox2.Image = Image.FromFile("../img/ifv.jpg");
                    break;
                case "Truck":
                    p2_Health_text.Text = "50";
                    p2_Speed_text.Text = "160%";
                    p2_AP_text.Text = "0";
                    p2_HE_text.Text = "0";
                    p2_MG_text.Text = "INF";
                    p2_Auto_text.Text = "0";
                    p2_Rocket_text.Text = "8";
                    pictureBox2.Image = Image.FromFile("../img/truck.png");
                    break;
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if(p1_ClassSelectorBox.SelectedItem.ToString() == "" || p2_ClassSelectorBox.SelectedItem.ToString() == "")
            {
                return;
            }

            Random rnd = new Random();

            int coin = rnd.Next(1, 3);

            decimal location1 = 0, location2 = 0;

            decimal rnd1 = rnd.Next(1, 95);
            decimal rnd2 = rnd.Next(105, 200);

            if (coin == 2)
            {
                location2 = rnd1;
                location1 = rnd2;
            }
            else
            {
                location1 = rnd1;
                location2 = rnd2;
            }

            switch (p1_ClassSelectorBox.SelectedItem.ToString())
            {
                case "MBT":
                    Player1 = new MBT(location1);
                    p1_picture2.Image = Image.FromFile("../img/tank.jpg");
                    break;
                case "IFV":
                    Player1 = new IFV(location1);
                    p1_picture2.Image = Image.FromFile("../img/ifv.jpg");
                    break;
                case "Truck":
                    Player1 = new Truck(location1);
                    p1_picture2.Image = Image.FromFile("../img/truck.png");
                    break;
            }

            switch (p2_ClassSelectorBox.SelectedItem.ToString())
            {
                case "MBT":
                    Player2 = new MBT(location2);
                    p2_picture2.Image = Image.FromFile("../img/tank.jpg");
                    break;
                case "IFV":
                    Player2 = new IFV(location2);
                    p2_picture2.Image = Image.FromFile("../img/ifv.jpg");
                    break;
                case "Truck":
                    Player2 = new Truck(location2);
                    p2_picture2.Image = Image.FromFile("../img/truck.png");
                    break;
            }

            ClassSelector.Visible = false;
            gameplay();

        }

        public void ending()
        {
            game_textbox.Text += "\n";
            game_textbox.Text += "\n";
            game_textbox.Text += "\n";
            game_textbox.Text += "==============================\n";

            Celebtarions[] phrases = { new Phrase1(), new Phrase2(), new Phrase3() };
            Random rnd3 = new Random();
            int choosen = rnd3.Next(0, 2);

            if (Player1.Health <= 0)
            {
                game_textbox.Text += "PLAYER 2 ";
            }
            else if (Player2.Health <= 0)
            {
                game_textbox.Text += "PLAYER 1 ";
            }
            game_textbox.Text += phrases[choosen].Cheering();


        }

        public void gameplay()
        {
            choice1.Enabled = true;
            choice2.Enabled = true;
            choice3.Enabled = true;

            if (!skip)
            {
                playing.counter++;
            }
            else
            {
                choice1.Enabled = false;
                skip = false;
            }

            roundLabel.Text = playing.counter.ToString();

            int count1 = 0;
            int count2 = 0;
            string ammoname = string.Empty;

            p1_health_game.Text = Player1.Health.ToString();
            p1_location_game.Text = Player1.Location.ToString();
            WeaponList Wnames = new WeaponList();
            for (int i = 0; i < Player1.Ammo.Count(); i++)
            {
                switch (i)
                {
                    case 0:
                        ammoname = Wnames.weaponNames[0] + ":";
                        break;
                    case 1:
                        ammoname = Wnames.weaponNames[1] + ":";
                        break;
                    case 2:
                        ammoname = Wnames.weaponNames[2] + ":";
                        break;
                    case 3:
                        ammoname = Wnames.weaponNames[3] + ":";
                        break;
                    case 4:
                        ammoname = Wnames.weaponNames[4] + ":";
                        break;
                }

                if (Player1.Ammo[i] > 0)
                {
                    switch (count1)
                    {
                        case 0:
                            p1_ammo1.Text = ammoname;
                            p1_ammo1_text.Text = Player1.Ammo[i].ToString();
                            break;
                        case 1:
                            p1_ammo2.Text = ammoname;
                            p1_ammo2_text.Text = Player1.Ammo[i].ToString();
                            break;
                        case 2:
                            p1_ammo3.Text = ammoname;
                            p1_ammo3_text.Text = Player1.Ammo[i].ToString();
                            break;
                    }
                    count1++;
                }
                else if (Player1.Ammo[i] < 0)
                {
                    switch (count1)
                    {
                        case 0:
                            p1_ammo1.Text = ammoname;
                            p1_ammo1_text.Text = "INF";
                            break;
                        case 1:
                            p1_ammo2.Text = ammoname;
                            p1_ammo2_text.Text = "INF";
                            break;
                        case 2:
                            p1_ammo3.Text = ammoname;
                            p1_ammo3_text.Text = "INF";
                            break;
                    }
                    count1++;
                }
                else
                {
                    continue;
                }
            }

            p2_health_game.Text = Player2.Health.ToString();
            p2_location_game.Text = Player2.Location.ToString();
            for (int i = 0; i < Player2.Ammo.Count(); i++)
            {
                switch (i)
                {
                    case 0:
                        ammoname = Wnames.weaponNames[0] + ":";
                        break;
                    case 1:
                        ammoname = Wnames.weaponNames[1] + ":";
                        break;
                    case 2:
                        ammoname = Wnames.weaponNames[2] + ":";
                        break;
                    case 3:
                        ammoname = Wnames.weaponNames[3] + ":";
                        break;
                    case 4:
                        ammoname = Wnames.weaponNames[4] + ":";
                        break;
                }

                if (Player2.Ammo[i] > 0)
                {
                    switch (count2)
                    {
                        case 0:
                            p2_ammo1.Text = ammoname;
                            p2_ammo1_text.Text = Player2.Ammo[i].ToString();
                            break;
                        case 1:
                            p2_ammo2.Text = ammoname;
                            p2_ammo2_text.Text = Player2.Ammo[i].ToString();
                            break;
                        case 2:
                            p2_ammo3.Text = ammoname;
                            p2_ammo3_text.Text = Player2.Ammo[i].ToString();
                            break;
                    }
                    count2++;
                }
                else if (Player2.Ammo[i] < 0)
                {
                    switch (count2)
                    {
                        case 0:
                            p2_ammo1.Text = ammoname;
                            p2_ammo1_text.Text = "INF";
                            break;
                        case 1:
                            p2_ammo2.Text = ammoname;
                            p2_ammo2_text.Text = "INF";
                            break;
                        case 2:
                            p2_ammo3.Text = ammoname;
                            p2_ammo3_text.Text = "INF";
                            break;
                    }
                    count2++;
                }
                else
                {
                    continue;
                }
            }

            string check;

            if (playing.counter % 2 != 0)
            {
                check = "1";
            }
            else if (playing.counter % 2 == 0)
            {
                check = "2";
            }
            else
            {
                check = "broken";
            }

            if (Player1.Health <= 0 || Player2.Health <= 0)
            {
                choice1.Enabled = false;
                choice2.Enabled = false;
                choice3.Enabled = false;
                roundLabel.Text = (playing.counter-1).ToString();
                ending();
            }
            else
            {
                game_textbox.Text += "Player " + check + " turn: \n";
                game_textbox.Text += "Shoot, Move, Skip? \n";

                game_input.Text = "";

                choice1.Text = "Shoot";
                choice3.Text = "Skip";
                choice2.Text = "Move";

                choice1.Tag = "Shoot";
                choice3.Tag = "Skip";
                choice2.Tag = "Move";
            }
        }

        //======================================================================================================
        private void Shooting_part1(decimal height)
        {
            if (1 <= height && height <= 89)
            {
                shoot_height = height;
                function.choosenFunc = 3;
                game_textbox.Text += "Choose strenght (1-100) \n";
                game_input.Text = "";
            }
            else
            {
                game_textbox.Text += "1-89 \n";
            }
        }

        private void Shooting_part2(decimal strenght)
        {
            if (1 <= strenght && strenght <= 100)
            {
                shoot_strenght = strenght;
                game_input.Text = "";
                if (playing.counter % 2 != 0) // player 1
                {
                    Shooting_part3(Player1);
                }
                else if (playing.counter % 2 == 0) // player 2
                {
                    Shooting_part3(Player2);
                }
            }
            else
            {
                game_textbox.Text += "1-100 \n";
            }
        }

        private void Shooting_part3(Vehicle shooter)
        {
            btnInput.Visible = true;
            textInput.Visible = false;

            string ammoname = string.Empty;
            int count = 0;

            choice1.Tag = "None";
            choice2.Tag = "None";
            choice3.Tag = "None";

            for (int i = 0; i < shooter.Ammo.Count(); i++)
            {
                switch (i)
                {
                    case 0:
                        ammoname = "AP"; // 1
                        break;
                    case 1:
                        ammoname = "HE"; // 1
                        break;
                    case 2:
                        ammoname = "MG"; // 1 2 3
                        break;
                    case 3:
                        ammoname = "Auto";// 2
                        break;
                    case 4:
                        ammoname = "Rocket";// 2 3
                        break;
                }

                if (shooter.Ammo[i] > 0)
                {
                    switch (count)
                    {
                        case 0:
                            choice1.Text = ammoname + $": {shooter.Ammo[i]}";
                            choice1.Tag = ammoname;
                            break;
                        case 1:
                            choice2.Text = ammoname + $": {shooter.Ammo[i]}";
                            choice2.Tag = ammoname;
                            break;
                        case 2:
                            choice3.Text = ammoname + $": {shooter.Ammo[i]}";
                            choice3.Tag = ammoname;
                            break;
                    }
                    count++;
                }
                else if (shooter.Ammo[i] == -1)
                {
                    switch (count)
                    {
                        case 0:
                            choice1.Text = ammoname + ": INF";
                            choice1.Tag = ammoname;
                            break;
                        case 1:
                            choice2.Text = ammoname + ": INF";
                            choice2.Tag = ammoname;
                            break;
                        case 2:
                            choice3.Text = ammoname + ": INF";
                            choice3.Tag = ammoname;
                            break;
                    }
                    count++;
                }
                else
                {
                    continue;
                }
            }
            if (choice1.Tag.ToString() == "None") { choice1.Enabled = false; choice1.Text = "None"; }
            if (choice2.Tag.ToString() == "None") { choice2.Enabled = false; choice2.Text = "None"; }
            if (choice3.Tag.ToString() == "None") { choice3.Enabled = false; choice3.Text = "None"; }

            switch (choice1.Tag.ToString())
            {
                case "AP":
                    if (shooter.Ammo[0] == 0) { choice1.Enabled = false; }
                    break;

                case "MG":
                    if (shooter.Ammo[2] == 0) { choice1.Enabled = false; }
                    break;
            }

            switch (choice2.Tag.ToString())
            {
                case "HE":
                    if (shooter.Ammo[1] == 0) { choice2.Enabled = false; }
                    break;

                case "MG":
                    if (shooter.Ammo[2] == 0) { choice2.Enabled = false; }
                    break;

                case "Auto":
                    if (shooter.Ammo[3] == 0) { choice2.Enabled = false; }
                    break;
            }

            switch (choice3.Tag.ToString())
            {
                case "MG":
                    if (shooter.Ammo[2] == 0) { choice3.Enabled = false; }
                    break;

                case "Rocket":
                    if (shooter.Ammo[4] == 0) { choice3.Enabled = false; }
                    break;
            }

            game_textbox.Text += "What weapon? \n";
        }

        private void Shooting_part4(Vehicle shooter, Vehicle target, string weapon)
        {
            decimal location = Math.Ceiling((shoot_height * shoot_strenght) / shooter.Location);
            decimal damage;

            Random rng = new Random();

            switch (weapon)
            {
                case "AP":
                    if (location == target.Location)
                    {
                        game_textbox.Text += "Damage dealt: 75 \n";
                        target.Health -= 75;
                        if (shooter.Ammo[0] == -1)
                        {
                            return;
                        }
                        else
                        {
                            shooter.Ammo[0]--;
                        }
                    }
                    else
                    {
                        game_textbox.Text += "Missed \n";
                        game_textbox.Text += $"Shoot landed at {location} \n";
                    }
                    break;

                case "HE":
                    if (target.Location - location <= 2 && target.Location - location > 0)
                    {
                        damage = 54 / (Math.Ceiling(target.Location - location));
                        game_textbox.Text += $"Damage dealt: {damage} \n";
                        target.Health -= damage;
                        if (shooter.Ammo[1] == -1)
                        {
                            return;
                        }
                        else
                        {
                            shooter.Ammo[1] -= 1;
                        }
                    }
                    else if (location - target.Location <= 2 && location - target.Location > 0)
                    {
                        damage = 54 / Math.Ceiling((location - target.Location));
                        game_textbox.Text += $"Damage dealt: {damage} \n";
                        target.Health -= damage;
                        target.Health -= damage;
                        shooter.Ammo[1] -= 1;
                    }
                    else
                    {
                        game_textbox.Text += "Missed \n";
                        game_textbox.Text += $"Shoot landed at {location} \n";
                    }
                    break;

                case "MG":
                    for (int i = 0; i <= 9; i++)
                    {
                        decimal shoot = rng.Next(-7, 7);
                        decimal mem = location;
                        mem += Math.Ceiling(shoot / 2);

                        if (shooter.Ammo[2] != -1)
                        {
                            shooter.Ammo[2]--;
                        }

                        if (mem == target.Location)
                        {
                            target.Health -= 4;
                            game_textbox.Text += "Hit, damage dealt: 4 \n";
                        }
                        else
                        {
                            game_textbox.Text += "Missed \n";
                            game_textbox.Text += $"Shoot landed at {mem} \n";
                        }
                    }
                    break;

                case "Rocket":
                    //guidance
                    decimal locationR = location;
                    if (location < target.Location)
                    {
                        if (target.Location - locationR <= 8) { locationR += target.Location - locationR; }
                        else { locationR += 8; }
                    }
                    else if (locationR > target.Location)
                    {
                        if (locationR - target.Location <= 8) { locationR -= locationR - target.Location; }
                        else { locationR += 8; }
                    }

                    if (locationR == target.Location)
                    {
                        game_textbox.Text += "Damage dealt: 100 \n";
                        target.Health -= 100;
                        if (shooter.Ammo[0] == -1)
                        {
                            return;
                        }
                        else
                        {
                            shooter.Ammo[4] -= 1;
                        }
                    }
                    else
                    {
                        game_textbox.Text += "Missed \n";
                        game_textbox.Text += $"Shoot landed at {locationR} \n";
                    }
                    break;

                case "Auto":
                    for (int i = 0; i <= 5; i++)
                    {
                        decimal shoot = rng.Next(-5, 5);
                        decimal mem = location;
                        mem += Math.Ceiling(shoot / 2);

                        if (shooter.Ammo[3] != -1)
                        {
                            shooter.Ammo[3]--;
                        }

                        if (mem == target.Location)
                        {
                            target.Health -= 10;
                            game_textbox.Text += "Hit, damage dealt: 10 \n";
                        }
                        else
                        {
                            game_textbox.Text += "Missed \n";
                            game_textbox.Text += $"Shoot landed at {mem} \n";
                        }
                    }
                    break;
            }

            skip = true;
            gameplay();
        }
        //======================================================================================================

        //======================================================================================================
        private void Movement_part1()
        {
            game_textbox.Text += "Left or Right \n";
            choice3.Visible = false;
            choice1.Text = "Left";
            choice2.Text = "Right";

            choice1.Tag = "Left";
            choice2.Tag = "Right";
        }

        private void Movement_part2(Vehicle player)
        {
            decimal maxDistance = 25 * (player.Speed / 100);
            game_textbox.Text += $"How much? (max: {maxDistance})\n";
            btnInput.Visible = false;
            textInput.Visible = true;
        }

        private void Movement_part3(Vehicle player, Vehicle enemy, string direction, int distance)
        {
            decimal maxDistance = 25 * (player.Speed / 100);

            if (direction == "Left")
            {
                if (distance > maxDistance && distance <= 0)
                {
                    game_textbox.Text += $"max: {maxDistance} \n";
                    return;
                }
                if (player.Location - distance < enemy.Location || player.Location - distance > enemy.Location)
                {
                    player.Location -= distance;
                    game_textbox.Text += $"you moved {distance} squares\n";
                    choice3.Visible = true;
                    btnInput.Visible = true;
                    textInput.Visible = false;
                    gameplay();
                }
                else
                {
                    game_textbox.Text += "Enemy in the way \n";
                    return;
                }
            }
            else if (direction == "Right")
            {
                if (distance > maxDistance && distance <= 0)
                {
                    game_textbox.Text += $"max: {maxDistance} \n";
                    return;
                }
                if (player.Location + distance < enemy.Location || player.Location + distance > enemy.Location)
                {
                    player.Location += distance;
                    game_textbox.Text += $"you moved {distance} squares\n";
                    choice3.Visible = true;
                    btnInput.Visible = true;
                    textInput.Visible = false;
                    gameplay();
                }
                else
                {
                    game_textbox.Text += "Enemy in the way \n";
                    return;
                }
            }
        }
        //======================================================================================================

        private void choice1_Click(object sender, EventArgs e)// left
        {
            switch (choice1.Tag.ToString())
            {
                case "Shoot":
                    btnInput.Visible = false;
                    textInput.Visible = true;
                    function.choosenFunc = 2;
                    game_textbox.Text += "Choose height: (1-89) \n";
                    break;

                case "Left":
                    direction = "Left";
                    function.choosenFunc = 1;
                    if (playing.counter % 2 != 0) // player 1
                    {
                        Movement_part2(Player1);
                    }
                    else if (playing.counter % 2 == 0) // player 2
                    {
                        Movement_part2(Player2);
                    }
                    break;

                case "AP":
                    if (playing.counter % 2 != 0) // player 1
                    {
                        Shooting_part4(Player1, Player2, "AP");
                    }
                    else if (playing.counter % 2 == 0) // player 2
                    {
                        Shooting_part4(Player2, Player1, "AP");
                    }
                    break;

                case "MG":
                    if (playing.counter % 2 != 0) // player 1
                    {
                        Shooting_part4(Player1, Player2, "MG");
                    }
                    else if (playing.counter % 2 == 0) // player 2
                    {
                        Shooting_part4(Player2, Player1, "MG");
                    }
                    break;
            }
        }

        private void choice3_Click(object sender, EventArgs e)// mid
        {
            switch (choice3.Tag.ToString())
            {
                case "Skip":
                    game_textbox.Text += "Skipping turn\n";
                    Player1.Health -= 300;
                    gameplay();
                    break;

                case "MG":
                    if (playing.counter % 2 != 0) // player 1
                    {
                        Shooting_part4(Player1, Player2, "MG");
                    }
                    else if (playing.counter % 2 == 0) // player 2
                    {
                        Shooting_part4(Player2, Player1, "MG");
                    }
                    break;

                case "Rocket":
                    if (playing.counter % 2 != 0) // player 1
                    {
                        Shooting_part4(Player1, Player2, "Rocket");
                    }
                    else if (playing.counter % 2 == 0) // player 2
                    {
                        Shooting_part4(Player2, Player1, "Rocket");
                    }
                    break;

            }
        }

        private void choice2_Click(object sender, EventArgs e)// right
        {
            switch (choice2.Tag.ToString())
            {
                case "Move":
                    Movement_part1();
                    break;

                case "Right":
                    function.choosenFunc = 1;
                    direction = "Right";
                    if (playing.counter % 2 != 0) // player 1
                    {
                        Movement_part2(Player1);
                    }
                    else if (playing.counter % 2 == 0) // player 2
                    {
                        Movement_part2(Player2);
                    }
                    break;

                case "HE":
                    if (playing.counter % 2 != 0) // player 1
                    {
                        Shooting_part4(Player1, Player2, "HE");
                    }
                    else if (playing.counter % 2 == 0) // player 2
                    {
                        Shooting_part4(Player2, Player1, "HE");
                    }
                    break;

                case "Auto":
                    if (playing.counter % 2 != 0) // player 1
                    {
                        Shooting_part4(Player1, Player2, "Auto");
                    }
                    else if (playing.counter % 2 == 0) // player 2
                    {
                        Shooting_part4(Player2, Player1, "Auto");
                    }
                    break;

                case "Rocket":
                    if (playing.counter % 2 != 0) // player 1
                    {
                        Shooting_part4(Player1, Player2, "Rocket");
                    }
                    else if (playing.counter % 2 == 0) // player 2
                    {
                        Shooting_part4(Player2, Player1, "Rocket");
                    }
                    break;

            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            switch (function.choosenFunc)
            {
                case 1:
                    if (playing.counter % 2 != 0) // player 1
                    {
                        Movement_part3(Player1, Player2, direction, Int32.Parse(game_input.Text));
                    }
                    else if (playing.counter % 2 == 0) // player 2
                    {
                        Movement_part3(Player2, Player1, direction, Int32.Parse(game_input.Text));
                    }
                    break;
                case 2:
                    Shooting_part1(Int32.Parse(game_input.Text));
                    game_input.Text = "";
                    break;
                case 3:
                    Shooting_part2(Int32.Parse(game_input.Text));
                    game_input.Text = "";
                    break;
            }
        }
    }
}
