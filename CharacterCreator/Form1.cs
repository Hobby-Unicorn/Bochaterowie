using Bochaterowie;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;
using CharacterCreator.Properties;
using System.Media;
using NAudio.Wave;

namespace CharacterCreator
{
    public partial class Form1 : Form
    {
        int warriorCount = Warrior.GetWarriorCount();
        int archerCount = Archer.GetArcherCount();
        int wizardCount = Wizard.GetWizardCount();
        int zabojcaCount = Zabojca.GetZabojcaCount();
        int jednorozecCount = Jednorozec.GetJednorozecCount();

        private int availableTokens = 5;
        private int Coin = 0;
        private List<Monster> monstersList = new List<Monster>();
        private List<Quest> questsList = new List<Quest>();
        private List<Buff> buffsList = new List<Buff>();
        private SoundPlayer backgroundMusicPlayer;
        private WaveOutEvent waveOut;
        private Random random = new Random();
        public Form1()
        {
            waveOut = new WaveOutEvent();
            InitializeBuffs();
            InitializeComponent();
            InitializeMonsters();
            InitializeQuests(); // Inicjalizacja questów
            cmbClass.Items.Add("Wojownik");
            cmbClass.Items.Add("Łucznik");
            cmbClass.Items.Add("Czarodziej");
            cmbClass.Items.Add("Zabojca");
            cmbClass.Items.Add("Jednorozec");
            DisplayQuests();
            DisplayBuffs();
           /* backgroundMusicPlayer = new SoundPlayer(Resources.Stereo_Sayan_3D1); // Podaj nazwę zasobu dźwiękowego
            backgroundMusicPlayer.PlayLooping();*/


        }
            private void AddTextWithColor(string text, Color color)
            {
                richTextBox.SelectionColor = color;
                richTextBox.AppendText(text + "\n");
            }

        private void InitializeMonsters()
        {
            // Inicjalizacja potworów
            monstersList.Add(new Monster("Smoczy Wąż", 80, 15)); // Nazwa, zdrowie, siła
            monstersList.Add(new Monster("Zmutowany Szkielet", 60, 12));
            monstersList.Add(new Monster("Demoniczny Cień", 50, 10));
            monstersList.Add(new Monster("Ognisty Żywiołak", 70, 18));
            monstersList.Add(new Monster("Lodowy Olbrzym", 90, 20));
            monstersList.Add(new Monster("Krwawa Latająca Żaba", 40, 8));
            monstersList.Add(new Monster("Zardzewiały Golem", 100, 25));
            monstersList.Add(new Monster("Ukryty Upiór", 55, 13));
            monstersList.Add(new Monster("Oświecony Ork", 75, 17));
            monstersList.Add(new Monster("Mroczny Elf", 65, 14));
            monstersList.Add(new Monster("Lśniący Jednorożec", 85, 19));
            monstersList.Add(new Monster("Gnijący Zombiak", 45, 9));
            monstersList.Add(new Monster("Rozpłakany Duch", 55, 11));
            monstersList.Add(new Monster("Krwiożerczy Ghul", 60, 16));
            monstersList.Add(new Monster("Trujący Skorpion", 70, 15));
            monstersList.Add(new Monster("Szarżujący Minotaur", 85, 22));
            monstersList.Add(new Monster("Ostreptany Wilk", 65, 14));
            monstersList.Add(new Monster("Wściekły Tygrys", 90, 21));
            monstersList.Add(new Monster("Mroźny Yeti", 95, 23));
            monstersList.Add(new Monster("Czarny Gryf", 80, 20));
            monstersList.Add(new Monster("Błyszczący Bazyliszek", 75, 18));
            monstersList.Add(new Monster("Ryjący Troll", 100, 26));
            monstersList.Add(new Monster("Zaklęty Lich", 110, 28));
            monstersList.Add(new Monster("Gnijący Nagar", 55, 12));
            monstersList.Add(new Monster("Wielki Skorpion", 75, 16));
            monstersList.Add(new Monster("Rdzawy Cyklop", 105, 24));
            monstersList.Add(new Monster("Mroczny Rycerz", 80, 19));
            monstersList.Add(new Monster("Złowrogi Grymasz", 90, 21));
            monstersList.Add(new Monster("Krwawy Kraken", 120, 30));


        }
        private void InitializeBuffs()
        {
            buffsList.Add(new Buff("Super Siła", 5, 0, 0, 0, 0, 0));
            buffsList.Add(new Buff("Super Zręczność", 0, 5, 0, 0, 0, 0));
            buffsList.Add(new Buff("Super Inteligencja", 0, 0, 5, 0, 0, 0));
            buffsList.Add(new Buff("Zwiększone Zdrowie", 0, 0, 0, 20, 0, 0));
            buffsList.Add(new Buff("Dodatkowy Damage", 0, 0, 0, 0, 10, 0 ));
            buffsList.Add(new Buff("Zwiększona Odporność", 0, 0, 0, 0, 0, 5));
        }
      
        private bool CanStartFight()
        {
            // Sprawdź, czy przynajmniej jedna postać żyje
            foreach (var character in charactersList)
            {
                if (character.CurrentHealth > 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void UpdateCharacterCountLabels()
        {
            lblWarriorCount.Text = $"Wojownicy: {warriorCount}";
            lblArcherCount.Text = $"Łucznicy: {archerCount}";
            lblWizardCount.Text = $"Czarodzieje: {wizardCount}";
            lblZabojcaCount.Text = $"Zabojcy: {zabojcaCount}";
            lblJednorozecCount.Text = $"Unicorny: {jednorozecCount}";

        }
        private void btnCreateCharacter_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string characterType = cmbClass.SelectedItem.ToString();
           
            int tokensNeeded = 0;

            switch (characterType)
            {
                case "Wojownik":
                    tokensNeeded = 1;
                    break;
                case "Łucznik":
                    tokensNeeded = 2;
                    break;
                case "Czarodziej":
                    tokensNeeded = 2;
                    break;
                case "Zabojca":
                    tokensNeeded = 3;
                    break;
                case "Jednorozec":
                    tokensNeeded = 20;
                    break;
                default:
                    MessageBox.Show("Please select a character class.");
                    return;
            }
            if (availableTokens < tokensNeeded)
            {
                MessageBox.Show("Brak wystarczającej liczby tokenów.");
                return;
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a character name.");
                return;
            }

            // Sprawdzenie czy nazwa postaci nie została już użyta
        /*    if (charactersList.Any(character => character.Name == name))
            {
                MessageBox.Show("Character name must be unique.");
                return;
            }*/

            Character newCharacter = null;

            switch (characterType)
            {
                case "Wojownik":
                    newCharacter = new Warrior(name);
                    availableTokens -= 1;
                    IncreaseCharacterCount(characterType);
                    break;
                case "Łucznik":
                    newCharacter = new Archer(name);
                    availableTokens -= 2;
                    IncreaseCharacterCount(characterType);
                    break;
                case "Czarodziej":
                    newCharacter = new Wizard(name);
                    availableTokens -= 2;
                    IncreaseCharacterCount(characterType);
                    break;
                case "Zabojca":
                    newCharacter = new Zabojca(name);
                    availableTokens -= 3;
                    IncreaseCharacterCount(characterType);
                    break;
                case "Jednorozec":
                    newCharacter = new Jednorozec(name);
                    availableTokens -= 20;
                    IncreaseCharacterCount(characterType);
                    break;
                default:
                    MessageBox.Show("Please select a character class.");
                    break;
            }
            UpdateAvailableTokensLabel();
            UpdateAvailableCoinsLabel();
            UpdateCharacterCountLabels();
            if (newCharacter != null)
            {
                charactersList.Add(newCharacter);
                string message = $"{newCharacter.Name} - {characterType}";
                AddTextWithColor(message, Color.Olive); // Dodanie wiadomości w kolorze czarnym
            }

            Stream win = Properties.Resources.create;
            MemoryStream memory = new MemoryStream();
            win.CopyTo(memory);
            memory.Position = 0;
            WaveStream wave = new WaveFileReader(memory);

            WaveOut out2 = new WaveOut();
            out2.Init(wave);
            out2.Play();

            out2.PlaybackStopped += (s, args) =>
            {
                wave.Dispose();
            };
            CheckGameOver();
        }
        private void UpdateAvailableTokensLabel()
        {
            lblAvailableTokens.Text = $"Pozostałe tokeny: {availableTokens}";
        }
        private void UpdateAvailableCoinsLabel()
        {
            lblAvailableCoins.Text = $"Pozostałe Coiny: {Coin}";
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }
        private void btnFight_Click(object sender, EventArgs e)
        {
            if (!CanStartFight())
            {
              
                MessageBox.Show("Nie masz żyjących postaci. Nie można rozpocząć walki.");
                return;
            }

            if (lstQuests.SelectedItem != null)
            {
                // Pobierz indeks wybranego questu
                int selectedIndex = lstQuests.SelectedIndex;

                // Sprawdź, czy indeks jest prawidłowy
                if (selectedIndex >= 0 && selectedIndex < questsList.Count)
                {
                    // Pobierz wybrany quest
                    Quest selectedQuest = questsList[selectedIndex];

                    // Rozpocznij walkę z potworami z wybranego questu
                    StartFight(selectedQuest);
                }
            }

        }

        private void StartFight(Quest quest)
        {
            Stream win = Properties.Resources.start_quset;
            MemoryStream memory = new MemoryStream();
            win.CopyTo(memory);
            memory.Position = 0;
            WaveStream wave = new WaveFileReader(memory);

            WaveOut out2 = new WaveOut();
            out2.Init(wave);
            out2.Play();

            out2.PlaybackStopped += (s, args) =>
            {
                wave.Dispose();
            };
            MessageBox.Show($"Rozpoczynasz walkę z potworami z questu: {quest.Name}", "Rozpoczęcie walki", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Symulacja walki z potworami z questu
            foreach (var character in charactersList)
            {
                foreach (var monster in quest.Monsters)
                {
                    Fight(character, monster);
                }
            }
          

            // Usuń zakończony quest z listy questów
            bool allMonstersDefeated = quest.Monsters.All(monster => monster.Health <= 0);

            if (allMonstersDefeated)
            {
                {
                    if (quest.IsEasy)
                    {
                        Coin += 5;
                        availableTokens += 5;
                    }
                    else
                    {
                        Coin += 10;
                        availableTokens += 10;
                    }

                    UpdateAvailableTokensLabel(); // Aktualizacja wyświetlania dostępnych tokenów
                    UpdateAvailableCoinsLabel();

                    // Usuń zakończony quest z listy questów
                    questsList.Remove(quest);
                    win = Properties.Resources.win_quest;
                    memory = new MemoryStream();
                    win.CopyTo(memory);
                    memory.Position = 0;
                    wave = new WaveFileReader(memory);

                    out2 = new WaveOut();
                    out2.Init(wave);
                    out2.Play();

                    out2.PlaybackStopped += (s, args) =>
                    {
                        wave.Dispose();
                    };
                    // Wyświetl komunikat kończący walkę
                    MessageBox.Show("Walka z potworami zakończona!", "Koniec walki", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Odśwież listę questów
                    DisplayQuests();
                }
               
            }
            else
            {
                win = Properties.Resources.fail_quest;
                memory = new MemoryStream();
                win.CopyTo(memory);
                memory.Position = 0;
                wave = new WaveFileReader(memory);

                out2 = new WaveOut();
                out2.Init(wave);
                out2.Play();

                out2.PlaybackStopped += (s, args) =>
                {
                    wave.Dispose();
                };
                MessageBox.Show("Nie wszystkie potwory zostały pokonane!", "Koniec walki", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (questsList.Count == 0)
            {
                win = Properties.Resources.win_game;
                memory = new MemoryStream();
                win.CopyTo(memory);
                memory.Position = 0;
                wave = new WaveFileReader(memory);

                out2 = new WaveOut();
                out2.Init(wave);
                out2.Play();

                out2.PlaybackStopped += (s, args) =>
                {
                    wave.Dispose();
                };
                MessageBox.Show("Gratulacje! Wykonałeś wszystkie zadania i wygrałeś grę!", "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                ResetGame(); // Zresetuj grę
            }
            else
            {
                // Sprawdź, czy gra się zakończyła z innych powodów
                CheckGameOver();
            }
        }



       private void Fight(Character character, Monster monster)
{
    Random random = new Random(); // Nowy generator liczb losowych
            
            // Deklaracja zmiennej śledzącej uniknięcie ataku przez łucznika i wykonanie ataku
            bool archerDodged = false;

    while (character.CurrentHealth > 0 && monster.Health > 0)
    {
        double randomValue = random.NextDouble(); // Losowa wartość od 0.0 do 1.0
        int damageToMonster = character.GetTotalDamage();

        // Sprawdzenie czy postać jest łucznikiem (Archer) i czy przeciwnik to potwór
        if (character is Archer && randomValue < ((Archer)character).DodgeChance && !archerDodged)
        {
                    string message = ($"{character.Name} unika ataku {monster.Name}!");
                    AddTextWithColor(message, Color.Yellow);
                    archerDodged = true;
        }
        else
        {
            // Atak postaci na potwora
            monster.Health -= damageToMonster;
            
                    string message = ($"{character.Name} ({character.GetType().Name}) zadaje {damageToMonster} obrażeń {monster.Name}! (Zdrowie potwora: {monster.Health})");
                    AddTextWithColor(message, Color.Green);
                }

        if (monster.Health <= 0)
        {
            string message =($"{character.Name} pokonuje {monster.Name}!");
                    AddTextWithColor(message, Color.LimeGreen);
                    // Sprawdzenie, czy nadal istnieje przynajmniej jedna żyjąca postać w drużynie
                    if (charactersList.Any(c => c.CurrentHealth > 0))
            {
                // Jeśli tak, kontynuuj walkę z następnym potworem
                return;
            }
            else
            {
                // Jeśli nie, zakończ walkę
                CheckGameOver();
                return;
            }
        }

        // Atak potwora na postać
        int damageToCharacter = monster.Strength;

        // Sprawdzenie, czy postać jest łucznikiem i czy potwór nie uniknął ataku
        if (!(character is Archer) || randomValue >= ((Archer)character).DodgeChance)
        {

            character.CurrentHealth -= damageToCharacter;
                    string message = $"{monster.Name} zadaje {damageToCharacter} obrażeń {character.Name}! (Zdrowie postaci: {character.CurrentHealth})";
                    AddTextWithColor(message, Color.Red);


                    if (character.CurrentHealth <= 0)
            {
                        message = $"{monster.Name} pokonuje {character.Name} ({character.GetType().Name})!";
                        AddTextWithColor(message, Color.IndianRed);

                        // Zmniejszenie licznika dla danej klasy postaci
                        if (character is Warrior)
                {
                    warriorCount--;
                    UpdateCharacterCountLabels();
                }
                else if (character is Archer)
                {
                    archerCount--;
                    UpdateCharacterCountLabels();
                }
                else if (character is Wizard)
                {
                    wizardCount--;
                    UpdateCharacterCountLabels();
                }
                else if (character is Zabojca)
                {
                    zabojcaCount--;
                    UpdateCharacterCountLabels();
                }
                else if (character is Jednorozec)
                {
                    jednorozecCount--;
                    UpdateCharacterCountLabels();
                }

                // Sprawdzenie, czy nadal istnieje przynajmniej jedna żyjąca postać w drużynie
                if (charactersList.Any(c => c.CurrentHealth > 0))
                {
                    // Jeśli tak, kontynuuj walkę z następnym potworem
                    return;
                }
                else
                {
                    // Jeśli nie, zakończ walkę
                    CheckGameOver();
                    return;
                }
            }
        }
    }
}





        private void IncreaseCharacterCount(string characterType)
        {
            switch (characterType)
            {
                case "Wojownik":
                    warriorCount++;
                    break;
                case "Łucznik":
                    archerCount++;
                    break;
                case "Czarodziej":
                    wizardCount++;
                    break;
                case "Zabojca":
                    zabojcaCount++;
                    break;
                case "Jednorozec":
                    jednorozecCount++;
                    break;
                default:
                    break;
            }
            // Aktualizacja wyświetlania liczby postaci dla każdej klasy
            UpdateCharacterCountLabels();
        }



        private void InitializeQuests()
        {
            Random random = new Random();

            // Stworzenie listy potworów, które mogą być przypisane do questów
            List<Monster> availableMonsters = new List<Monster>(monstersList);

            for (int i = 1; i <= 10; i++)
            {
                Quest quest = new Quest($"Quest {i}");

                // Losowanie dwóch potworów dla każdego questu
                int totalDamage = 0;
                for (int j = 0; j < 2; j++)
                {
                    // Sprawdzenie, czy dostępna lista potworów nie jest pusta
                    if (availableMonsters.Count > 0)
                    {
                        // Losowanie indeksu potwora z listy dostępnych potworów
                        int index = random.Next(0, availableMonsters.Count);
                        Monster selectedMonster = availableMonsters[index];

                        // Dodanie wylosowanego potwora do questu i usunięcie go z listy dostępnych potworów
                        quest.AddMonster(selectedMonster);
                        availableMonsters.RemoveAt(index);

                        // Dodanie obrażeń potwora do sumy
                        totalDamage += selectedMonster.Strength;
                    }
                    else
                    {
                        // Jeśli lista potworów jest pusta, przerwij pętlę
                        break;
                    }
                }

                // Określenie poziomu trudności questu na podstawie sumy obrażeń potworów
                if (totalDamage <= 35)
                {
                    quest.Name += " (Łatwy)";
                    quest.IsEasy = true; // Ustaw quest jako łatwy
                   

                }
                else
                {
                    quest.Name += " (Trudny)";
                   
                }

                // Dodanie questu do listy questów
                questsList.Add(quest);
            }

            // Dodanie tokenów za questy
            
            UpdateAvailableTokensLabel();
            UpdateAvailableCoinsLabel();
        }


        private void DisplayQuests()
        {
            lstQuests.Items.Clear();
            foreach (var quest in questsList)
            {
                lstQuests.Items.Add(quest.Name);
            }
        }
        private void lstQuests_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obsługa zdarzenia po zmianie wybranego questu
            if (lstQuests.SelectedItem != null)
            {
                // Pobierz indeks wybranego questu
                int selectedIndex = lstQuests.SelectedIndex;

                // Sprawdź, czy indeks jest prawidłowy
                if (selectedIndex >= 0 && selectedIndex < questsList.Count)
                {
                    // Pobierz wybrany quest
                    Quest selectedQuest = questsList[selectedIndex];
                    string message = $"Monsters in {selectedQuest.Name} quest:";
                    foreach (var monster in selectedQuest.Monsters)
                    {
                        message += $"\n- {monster.Name} (Health: {monster.Health}, Strength: {monster.Strength})";
                    }
                    MessageBox.Show(message, "Monsters in Quest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Aktywuj przycisk "Rozpocznij walkę"
                    btnFight.Enabled = true;
                }
            }

        
    }
        private void SaveListBoxContentsToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string line in richTextBox.Lines)
                    {
                        writer.WriteLine(line);
                    }
                }
                    MessageBox.Show("Zawartość ListBoxa została zapisana do pliku.", "Zapisano", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisywania do pliku: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Przykładowe użycie funkcji do zapisu ListBoxa do pliku
        private void btnExportToFile_Click(object sender, EventArgs e)
        {
            // Otwórz dialog zapisu pliku
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.Title = "Zapisz zawartość ListBoxa do pliku";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                SaveListBoxContentsToFile(filePath);
            }
        }
        private bool IsGameOver()
        {
            return availableTokens <= 0 && charactersList.All(character => character.CurrentHealth <= 0);
        }

        private void CheckGameOver()
        {
            if (IsGameOver())
            {
                Stream win = Properties.Resources.Mission_Failed;
                MemoryStream memory = new MemoryStream();
                win.CopyTo(memory);
                memory.Position = 0;
                WaveStream wave = new WaveFileReader(memory);

                WaveOut out2 = new WaveOut();
                out2.Init(wave);
                out2.Play();

                out2.PlaybackStopped += (s, args) =>
                {
                    wave.Dispose();
                };
                MessageBox.Show("Nie masz już dostępnych tokenów, a wszyscy bohaterowie nie żyją. Przegrałeś!", "Koniec gry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetGame();
            }
        }

        private void ResetGame()
        {
            // Usuwamy wpisy z list
            richTextBox.Clear();
           
            wizardCount = 0;
            archerCount = 0;
            warriorCount = 0;
            zabojcaCount = 0;
            jednorozecCount = 0;
            UpdateCharacterCountLabels();
            lstQuests.Items.Clear();
            questsList.Clear();

            // Przywracamy domyślne wartości
            txtName.Clear();
            cmbClass.SelectedIndex = -1;
   

            // Przywracamy dostępne tokeny
            availableTokens = 5;
            UpdateAvailableTokensLabel();
            Coin = 0;
            UpdateAvailableCoinsLabel();
            
            InitializeQuests();
            DisplayQuests();
            DisplayBuffs();
            
            // Przywracamy stan przycisków
            btnFight.Enabled = false;
        }

        private void DisplayBuffs()
        {
            lstBuffs.Items.Clear();
            foreach (var buff in buffsList)
            {
                lstBuffs.Items.Add(buff.Name);
            }
        }
     
        private void btnBuyBuffForGroup_Click(object sender, EventArgs e)
        {
            if (lstBuffs.SelectedItem != null)
            {
                // Sprawdź, czy gracz ma wystarczającą ilość Coinów
                if (Coin >= 20) // Przykładowa cena buffa dla grupy
                {
                    // Pobierz wybrany buff
                    string selectedBuffName = lstBuffs.SelectedItem.ToString();
                    Buff selectedBuff = buffsList.FirstOrDefault(buff => buff.Name == selectedBuffName);
                    Stream win = Properties.Resources.buff;
                    MemoryStream memory = new MemoryStream();
                    win.CopyTo(memory);
                    memory.Position = 0;
                    WaveStream wave = new WaveFileReader(memory);

                    WaveOut out2 = new WaveOut();
                    out2.Init(wave);
                    out2.Play();

                    out2.PlaybackStopped += (s, args) =>
                    {
                        wave.Dispose();
                    };
                    if (selectedBuff != null)
                    {
                        // Zakupienie buffa dla całej grupy postaci
                        foreach (var character in charactersList)
                        {
                            character.ApplyBuff(selectedBuff);
                        }

                        // Odjęcie odpowiedniej ilości Coinów
                        Coin -= 20; // Przykładowa cena buffa dla grupy

                        // Aktualizacja wyświetlania dostępnych Coinów
                        UpdateAvailableCoinsLabel();

                        MessageBox.Show($"Zakupiono buffa \"{selectedBuff.Name}\" dla całej grupy postaci!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Nie masz wystarczającej ilości Coinów, aby zakupić buffa dla całej grupy.", "Brak wystarczających funduszy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Wybierz buffa przed zakupem dla całej grupy.", "Brak wybranego buffa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Zapis stanu gry
        private void SaveGameState(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Zapisz informacje o postaciach
                    foreach (var character in charactersList)
                    {
                        writer.WriteLine($"{character.Name},{character.GetType().Name},{character.CurrentHealth}");
                    }

                    // Zapisz pozostałe informacje, takie jak ilość tokenów, monet, listę zadań, itp.
                    writer.WriteLine($"Tokens:{availableTokens}");
                    writer.WriteLine($"Coins:{Coin}");
                    foreach (var quest in questsList)
                    {
                        writer.WriteLine($"Quest:{quest.Name}");
                        foreach (var monster in quest.Monsters)
                        {
                            writer.WriteLine($"Monster:{monster.Name},{monster.Health},{monster.Strength}");
                        }
                        writer.WriteLine("EndQuest");
                    }

                    // Zapisz informacje o liczbie jednostek stworzonych dla każdej klasy postaci
                    writer.WriteLine($"WarriorCount:{warriorCount}");
                    writer.WriteLine($"ArcherCount:{archerCount}");
                    writer.WriteLine($"WizardCount:{wizardCount}");
                    writer.WriteLine($"ZabojcaCount:{zabojcaCount}");
                    writer.WriteLine($"JednorozecCount:{jednorozecCount}");

                    // Zapisz zawartość kontrolki RichTextBox
                    writer.WriteLine("RichTextBoxContents:");
                    foreach (RichTextBoxLine line in GetRichTextBoxContentsWithColors())
                    {
                        writer.WriteLine($"{line.Text};{line.Color.Name}");
                    }
                }
                MessageBox.Show("Stan gry został zapisany.", "Zapisano", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisywania stanu gry: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IEnumerable<RichTextBoxLine> GetRichTextBoxContentsWithColors()
        {
            List<RichTextBoxLine> lines = new List<RichTextBoxLine>();
            int startPos = 0;
            foreach (var line in richTextBox.Lines)
            {
                Color lineColor = richTextBox.SelectionColor;
                lines.Add(new RichTextBoxLine(line, lineColor));
                startPos += line.Length + 1;
            }
            return lines;
        }

        public class RichTextBoxLine
        {
            public string Text { get; set; }
            public Color Color { get; set; }

            public RichTextBoxLine(string text, Color color)
            {
                Text = text;
                Color = color;
            }
        }


        // Wczytywanie stanu gry
        private void LoadGameState(string filePath)
        {

            try
            {
                bool readingRichTextBoxContents = false;
                int questCount = CountQuestsInFile(filePath);
                using (StreamReader reader = new StreamReader(filePath))
                {

                    string line;
                    Quest currentQuest = null;
                    
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Tokens:"))
                        {
                            availableTokens = int.Parse(line.Split(':')[1]);
                            UpdateAvailableTokensLabel();
                        }
                        else if (line.StartsWith("Coins:"))
                        {
                            Coin = int.Parse(line.Split(':')[1]);
                            UpdateAvailableCoinsLabel();
                        }
                    
                        else if (line.StartsWith("WarriorCount:"))
                        {
                            warriorCount = int.Parse(line.Split(':')[1]);
                            UpdateCharacterCountLabels();
                        }
                        else if (line.StartsWith("ArcherCount:"))
                        {
                            archerCount = int.Parse(line.Split(':')[1]);
                            UpdateCharacterCountLabels();
                        }
                        else if (line.StartsWith("WizardCount:"))
                        {
                            wizardCount = int.Parse(line.Split(':')[1]);
                            UpdateCharacterCountLabels();
                        }
                        else if (line.StartsWith("ZabojcaCount:"))
                        {
                            zabojcaCount = int.Parse(line.Split(':')[1]);
                            UpdateCharacterCountLabels();
                        }
                        else if (line.StartsWith("JednorozecCount:"))
                        {
                            jednorozecCount = int.Parse(line.Split(':')[1]);
                            UpdateCharacterCountLabels();
                        }
                        else if (line.StartsWith("RichTextBoxContents:"))
                        {
                            // Start reading RichTextBox contents
                            readingRichTextBoxContents = true;
                            // Clear RichTextBox before loading contents
                            richTextBox.Clear();
                        }
                        else if (readingRichTextBoxContents)
                        {
                            // If reading RichTextBox contents, split the line into text and color
                            string[] parts = line.Split(';');
                            if (parts.Length == 2)
                            {
                                string text = parts[0];
                                Color color = Color.FromName(parts[1]);
                                AddTextWithColor(text, color);
                            }
                        }
                        /*  else if (line.StartsWith("Quest:"))
                          {


                              string questName = line.Split(':')[1];
                              currentQuest = new Quest(questName);
                              questsList.Add(currentQuest);



                          }*/
                        /*       else if (line.StartsWith("Monster:") && currentQuest != null)
                               {
                                   string[] parts = line.Split(',');
                                   if (parts.Length == 4)
                                   {
                                       string monsterName = parts[1];
                                       int health = int.Parse(parts[2]);
                                       int strength = int.Parse(parts[3]);
                                       Monster newMonster = new Monster(monsterName, health, strength);
                                       currentQuest.Monsters.Add(newMonster);
                                   }

                               }*/


                        /* else if (line.Equals("EndQuest") && currentQuest != null)
                         {
                             questsList.Add(currentQuest);
                             currentQuest = null; // Zakończono wczytywanie aktualnego zadania

                         }*/

                        else
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 3)
                            {
                                string name = parts[0];
                                string type = parts[1];
                                int health = int.Parse(parts[2]);

                                // Odtwórz postać na podstawie wczytanych informacji
                                Character newCharacter = null;
                                switch (type)
                                {
                                    case "Warrior":
                                        newCharacter = new Warrior(name);
                                        break;
                                    case "Archer":
                                        newCharacter = new Archer(name);
                                        break;
                                    case "Wizard":
                                        newCharacter = new Wizard(name);
                                        break;
                                    case "Zabojca":
                                        newCharacter = new Zabojca(name);
                                        break;
                                    case "Jednorozec":
                                        newCharacter = new Jednorozec(name);
                                        break;
                                    default:
                                        break;
                                }
                                if (newCharacter != null)
                                {
                                    newCharacter.CurrentHealth = health;
                                    charactersList.Add(newCharacter);
                                    
                                }
                            }
                        }

                    }

                    GenerateMonstersForQuests(questCount);
                }
                MessageBox.Show("Stan gry został wczytany.", "Wczytano", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas wczytywania stanu gry: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CountQuestsInFile(string filePath)
        {
            int questCount = 0;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Quest:"))
                        {
                            questCount++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zliczania questów: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return questCount;
        }

        // Przykładowe użycie funkcji do zapisu i wczytywania stanu gry
        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            // Otwórz dialog zapisu pliku
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.Title = "Zapisz stan gry";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                SaveGameState(filePath);
            }
            Stream win = Properties.Resources.save;
            MemoryStream memory = new MemoryStream();
            win.CopyTo(memory);
            memory.Position = 0;
            WaveStream wave = new WaveFileReader(memory);

            WaveOut out2 = new WaveOut();
            out2.Init(wave);
            out2.Play();

            out2.PlaybackStopped += (s, args) =>
            {
                wave.Dispose();
            };
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {

            lstQuests.Items.Clear();
            questsList.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            openFileDialog.Title = "Wczytaj stan gry";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                LoadGameState(filePath);

            }
            Stream win = Properties.Resources.load;
            MemoryStream memory = new MemoryStream();
            win.CopyTo(memory);
            memory.Position = 0;
            WaveStream wave = new WaveFileReader(memory);

            WaveOut out2 = new WaveOut();
            out2.Init(wave);
            out2.Play();

            out2.PlaybackStopped += (s, args) =>
            {
                wave.Dispose();
            };
        }
        private void GenerateMonstersForQuests(int numberOfQuests)
        {
            Random random = new Random();
            List<Monster> availableMonsters = new List<Monster>(monstersList);
            for (int i = 0; i < numberOfQuests; i++)
            {
                Quest quest = new Quest($"Quest {i + 1}");

                int totalDamage = 0;

                for (int j = 0; j < 2; j++)
                {
                    if (availableMonsters.Count > 0)
                    {
                        // Losowanie indeksu potwora z listy dostępnych potworów
                        int index = random.Next(0, availableMonsters.Count);
                        Monster selectedMonster = availableMonsters[index];

                        // Dodanie wylosowanego potwora do questu i usunięcie go z listy dostępnych potworów
                        quest.AddMonster(selectedMonster);
                        availableMonsters.RemoveAt(index);

                        // Dodanie obrażeń potwora do sumy
                        totalDamage += selectedMonster.Strength;

                    }
                    else
                    {
                        // Jeśli lista potworów jest pusta, przerwij pętlę
                        break;
                    }
                    
                }

                // Określenie poziomu trudności questu na podstawie sumy obrażeń potworów
                if (totalDamage <= 35)
                {
                    quest.Name += " (Łatwy)";
                }
                else
                {
                    quest.Name += " (Trudny)";
                }

                // Dodanie questu do listy questów
                questsList.Add(quest);
                DisplayQuests();
            }

            // Dodanie tokenów za questy

            UpdateAvailableTokensLabel();
            UpdateAvailableCoinsLabel();
        }


    }
}
