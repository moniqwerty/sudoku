Судоку
======

##Oпис на играта##

**Судоку** (оригинално 数独) е јапонска сложувалка со бројки. Се состои од мрежа од 9 региони (квадрати) и секој од нив има по 9 квадратчиња. Целта на играта е да се пополнат сите квадратчиња со броеви од еден до девет на тој начин што во ниеден ред, колона и регион еден ист број нема да се повторува 2 пати. Играта се започува со мрежа со неколку веќе внесени броеви (во зависност од тежината на играта) и се игра додека не се наполни целата.

![ScreenShot](https://a248.e.akamai.net/camo.github.com/4eab443e1230ad01a43eaf4cb9ac61899d2c3c0a/687474703a2f2f692e696d6775722e636f6d2f39387a37325a362e706e67)

##Имплементација на решение##

Фукнционалностите кои ги содржи нашата апликација вклучваат: генерирање на Судоку ниво, почнување на нова игра со избрано ниво на тежина, играње, продолжување на претходно започната игра, зачување на моментална игра, помош (hint), high scoring систем.

Нашето решение го почнавме со развивање на класата *Sudoku.cs* која ја генерира играта. Првиот пристап ни беше генерирање на ниво преку brute force, но тоа трае премногу долго па се одлучивме на поинаков пристап. Прво, од внесени 3 нивоа на игра (во вид на 9x9 матрици) по рандом се зема едно. Потоа матрицата се меша, со тоа што од една можат да се добијат над 1000 различни комбинации. Потоа од генерираното ниво се земаат соодветен број на елементи во однос на избраната тежина(36 за easy, 25 за medium и 20 за hard). Класата е Serializable.

Следно ја развивме класата *Grid.cs* којa ги чува вредностите од играта, бројот на преостанати hint-ови, позициите на грешно внесените броеви, времето. Класата Grid генерира објект од класата Sudoku, со избраното ниво на тежина (кое се бира од формата Settings која се прикажува при плик на New Game од главниот екран). Класата е исто така Serializable.

Класата (формата) *Game.cs* е всушност целата игра. Таа чува објект од класата Grid, листа од 81 лабела (полињата во мрежата за играње) кои се додаваат динамично, еден Text Box кој се појавува при клик на секоја од лабелите за да може соодветно да се внесе бројот во лабелата (освен на генереираните полиња), и тајмер за да го брои времето. Класата има поголем број на функции меѓу кои и да се зачува моменталната игра, да се отвори претходно започната, да се провери дали внесениот елемент е валиден и тн. Ако во textBox-от се внесе елемент кој не е број од 1-9 едноставно не се прикажува.

Играта е завршена кога во сите полиња има внесено елемент, и сите полиња се валидни. Тогаш се отвара формата за High Scores во која ги прикажува 10те најдобри резултати во опаѓачки редослед. Вреднувањето на резултатот е по следната формула: (тежина на играта + 1) * ((1000-време)+1) * (број на преостанати хинтови + 1). Резултатот е класа која чува поени и име. Зачувување и прикажување на резултатите, го решивме со едноставно читање и запишување во текстуална датотека што се креира каде и да биде ставен извршниот фајл. Откако ќе се прочитаат запамтените резултати од .txt датотеката, се полни листа со резулати со која се пополнува listBox.

Еден од најинтересните кодови ни е акцијата при промена на текстот во textBox-от преку кој ги внесуваме податоците.

<code> void textBox1_TextChanged(object sender, EventArgs ee) </code>
 			
 			
 				{
     		  int i = Convert.ToInt32(textBox1.Name.Substring(textBox1.Name.Length - 2)); // земи ја позицијата каде е кликнато
      			if (textBox1.TextLength != 0) // ако не е празно
      		  {
            //play sound
            SoundPlayer player = new SoundPlayer(Properties.Resources.zvukNaj);
            player.Play();
            	
            int n;
            bool isNumeric = int.TryParse(textBox1.Text, out n);
            if (isNumeric) // ако е број
            {
                if (Convert.ToInt32(textBox1.Text) < 10 && Convert.ToInt32(textBox1.Text) > 0) //ако е 1-9 број
                {
                    if (labels[i - 1].Text != textBox1.Text) // ако е извршена промена на вредноста
                    {
                            labels[i - 1].Text = textBox1.Text.Substring(0, 1); //запиши на екран
                            game.values[i - 1] = Convert.ToInt32(textBox1.Text.Substring(0, 1)); // запиши во грид објектот
                            if (!isValid(i, labels[i - 1].Text)) // ако внесениот број е невалиден за позицијата каде е внесен
                            {
                                if (!game.errorList.Contains(i)) // ако го нема, додади го во листата невалидни броеви
                                {
                                    game.errorList.Add(i);
                                }
                                labels[i - 1].ForeColor = System.Drawing.Color.Red; // означи го со црвена боја
                            }
                            else // ако внесениот број е валиден
                            {
                                if (game.errorList.Contains(i)) // ако го има отстрани го од листата невалидни броеви и обој го црно
                                {
                                    game.errorList.Remove(i);
                                }
                                labels[i - 1].ForeColor = System.Drawing.Color.Black;
                            }
                            if (GameFinished()) //ако завршила играта израчунај резулатат, и побарај име и прикажи High Scores
                            {
                                int points = (game.gameDiff + 1) * (1000 - time) * game.numberOfHints;
                                string name = inputName();
                                Score score = new Score(name, points);
                                HighScore highScore = new HighScore();
                                FileStream fileStream = new FileStream("HighScore.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                                highScore.ReadScores(fileStream);
                                highScore.sortHighScore(score);
                                highScore.Show();
                                fileStream.Close();
                                highScore.WriteScores("HighScore.txt");
                                fileStream.Close();
                            }
                            labels[i - 1].Visible = true; // прикажи ја лабелата
                            textBox1.Visible = false; // скриј го textBox-от
                            try //провери ги дали се невалидни сите елементи во листата грешни елементи 
                            {
                                foreach (int q in game.errorList)
                                {
                                    if (isValid(q, labels[q - 1].Text)) // ако е валиден означи го како таков
                                    {
                                        game.errorList.Remove(q);
                                        labels[q - 1].ForeColor = System.Drawing.Color.Black;
                                    }
                                }
                            }
                            catch (Exception e) // ако настане некаква грешка, провери ги сите елементи
                            {
                                CheckAll();
                            }
                    }
                }
            }
        }
        else // ако внесеното не е број
        {
            labels[i - 1].Text = "";
            game.values[i - 1] = 0;
            try
            {
                foreach (int q in game.errorList) // провери ги сите невалидни
                {
                    int n;
                    bool isNumeric = int.TryParse(labels[q - 1].Text, out n);
                    if (!isNumeric)
                    {
                        game.errorList.Remove(q);
                        labels[q - 1].ForeColor = System.Drawing.Color.Black;
                    }
                    else if (isValid(q, labels[q - 1].Text))
                    {
                        game.errorList.Remove(q);
                        labels[q - 1].ForeColor = System.Drawing.Color.Black;
                    }

                }
            }
            catch (Exception e)
            {
                CheckAll();
            }
        }
    }


Исто така важен дел од кодот за сржта на играта, е функцијата isValid, која проверува дали внесен елемент може да стои на внесената позиција.



			bool isValid(int wat, string el) //прима позицијата каде е внесен во листата лабели, и самиот внесен елемент
    			{
        		int i = ((wat - 1) / 9); //бројот на редица доколку место во листа се наоѓа во матрица
        		int j = ((wat - 1) % 9); //бројот на колона доколку место во листа се наоѓа во матрица

        //dali e validno vo redica
        for (int k = 0; k < 9; k++)
        {
            if (k == j) continue;
            if(labels[i*9+k].Text==el) // ако во редот има ист елемент, значи не е валидно
            {
                return false;
            }
        }
        //dali e validno vo kolona
        for (int k = 0; k < 9; k++)
        {
            if (k == i) continue;
            if (labels[k * 9 + j].Text==el) // ако во колоната има ист елемент, значи не е валидно

            {
                return false;
            }
        }
        int xi = 0, yi = 0, xj = 0, yj = 0; // најди во кој од 9те квадрати се наоѓа елементот
        if ((i >= 0) && (i <= 2))
        {
            xi = 0;
            yi = 2;
        }
        else if ((i >= 3) && (i <= 5))
        {
            xi = 3;
            yi = 5;
        }
        else if ((i >= 6) && (i <= 8))
        {
            xi = 6;
            yi = 8;
        }
        if ((j >= 0) && (j <= 2))
        {
            xj = 0;
            yj = 2;
        }
        else if ((j >= 3) && (j <= 5))
        {
            xj = 3;
            yj = 5;
        }
        else if ((j >= 6) && (j <= 8))
        {
            xj = 6;
            yj = 8;
        }
        //провери во квадрант
        for (int k = xi; k <= yi; k++)
        {
            for (int m = xj; m <= yj; m++)
            {
                if (k == i) continue;
                if (m == j) continue;
                if (labels[k * 9 + m].Text==el) //ако има во квадрант ист елемент, значи не е валидно

                {
                    return false;
                }
            }

        }
        return true;
    }
    
    
*High Scores* може да се пристапат од главното мени, и автоматски се појавуваат на крајот на играта. Save game може да се направи во било кој момент додека се игра. Load game може да се направи од главното мени, и додека се игра некоја тековна игра. Hints функционираат на тој начин што рандом се вади елемент од првогенираната матрица, и се проверува дали тој би бил валиден на истата позиција во моменталната игра. Ако да, го поставува (и соодветно е означен со жолта боја неколку моменти), ако не, бара следен елемент. За секоја игра следуваат 3 hint-ови.

Во *About* се наоѓаат инструкции како да се игра.


##Дизајн##

За дизајнот се одлучивме за тема со змејови. Фонтот кој е користен е [Papyrus](http://ufonts.com/fonts/papyrus.html), но играта изгледа добро дури и да не е инсталиран соодветниот фонт на таа машина.

##Screen Shots##

Изгледот на главниот екран



![ScreenShot](https://a248.e.akamai.net/camo.github.com/050b947000a989f3745ed9cd2c258ade382b07e5/687474703a2f2f692e696d6775722e636f6d2f6a646b62384e592e706e67)



Изгледот на екранот за игра



![ScreenShot](https://a248.e.akamai.net/camo.github.com/d905eff7e14f84a2f332968e85eeb67fd3b4988d/687474703a2f2f696d673830352e696d616765736861636b2e75732f696d673830352f363039362f6c6774393232612e706e67)



Изгледот на High Scores



![ScreenShot](http://i.imgur.com/wTVO6W5.png)

