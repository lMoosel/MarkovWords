using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MarkovWords
{
    public partial class Form1 : Form
    {
        double[][] probabilities = new double[27][];
        double[][] probabilitiesGerman = new double[32][];
        double[][] probabilitiesHawaiian = new double[28][];
        public Form1()
        {
            InitializeComponent();
            lblOutput.Text = ((int)'a').ToString();
            StreamReader sr;

            for (int i = 0; i < probabilities.Length; i++)
                probabilities[i] = new double[26];

            for (int i = 0; i < probabilitiesGerman.Length; i++)
                probabilitiesGerman[i] = new double[31];

            for (int i = 0; i < probabilitiesHawaiian.Length; i++)
                probabilitiesHawaiian[i] = new double[27];

            //Read From text file

            sr = new StreamReader("EnglishProb.txt");

            for (int i = 0; i < probabilities.Length; i++)
            {
                string[] temp = sr.ReadLine().Split(';');
                for (int j = 0; j < probabilities[i].Length; j++)
                {
                    probabilities[i][j] = Convert.ToDouble(temp[j]);
                }
            }

            sr = new StreamReader("GermanProb.txt");

            for (int i = 0; i < probabilitiesGerman.Length; i++)
            {
                string[] temp = sr.ReadLine().Split(';');
                for (int j = 0; j < probabilitiesGerman[i].Length; j++)
                {
                    probabilitiesGerman[i][j] = Convert.ToDouble(temp[j]);
                }
            }

            sr = new StreamReader("HawaiianProb.txt");

            for (int i = 0; i < probabilitiesHawaiian.Length; i++)
            {
                string[] temp = sr.ReadLine().Split(';');
                for (int j = 0; j < probabilitiesHawaiian[i].Length; j++)
                {
                    probabilitiesHawaiian[i][j] = Convert.ToDouble(temp[j]);
                }
            }


        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            Random gen = new Random();
            string output = "";
            char prevChar = '`';
            bool hasVowel = false;


            while (true)
            {
                double letterKey = gen.NextDouble();
                for (int i = 0; i < probabilities[0].Length; i++)
                {
                    if (letterKey <= probabilities[(int)prevChar - 96][i])
                    {
                        prevChar = (char)(i + 97);
                        if (prevChar == 'a' || prevChar == 'e' || prevChar == 'i' || prevChar == 'o' || prevChar == 'u')
                            hasVowel = true;
                        break;
                    }
                }
                output += prevChar;
                if (gen.NextDouble() <= 0.225 && hasVowel)
                {
                    break;
                }
            }


            lblOutput.Text = output;
        }


        private int convertToInt(char letter, string lang)
        {
            if (lang == "german")
            {
                if (letter == 'ä')
                    return 26;
                else if (letter == 'ö')
                    return 27;
                else if (letter == 'ü')
                    return 28;
                else if (letter == 'ë')
                    return 29;
                else if (letter == 'ß')
                    return 30;
                else
                    return (int)letter - 97;
            }
            else if (lang == "hawaiian")
            {
                if (letter == '\'')
                    return 26;
                else
                    return (int)letter - 97;
            }
            else
            {
                return (int)letter - 97;
            }
        }

        private char convertToChar(int value, string lang)
        {
            if (lang == "german")
            {
                if (value == 123)
                    return 'ä';
                else if (value == 124)
                    return 'ö';
                else if (value == 125)
                    return 'ü';
                else if (value == 127)
                    return 'ë';
                else if (value == 128)
                    return 'ß';
                else
                    return (char)value;
            }
            else
            {
                return (char)value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random gen = new Random();
            string output = "";
            char prevChar = '`';
            bool hasVowel = false;

            while (true)
            {
                double letterKey = gen.NextDouble();
                for (int i = 0; i < probabilitiesGerman[0].Length; i++)
                {
                    if (letterKey <= probabilitiesGerman[convertToInt(prevChar, "german")+1][i])
                    {
                        prevChar = convertToChar(i+97,"german");
                        if (prevChar == 'a' || prevChar == 'e' || prevChar == 'i' || prevChar == 'o' || prevChar == 'u')
                            hasVowel = true;
                        break;
                    }
                }
                output += prevChar;
                if (gen.NextDouble() <= 0.15 && hasVowel)
                {
                    break;
                }
            }


            lblOutput.Text = output;
        }

        private void btnGenerateProb_Click(object sender, EventArgs e)
        {
            int count;
            StreamReader sr = new StreamReader("words.txt");
            string[] words = sr.ReadToEnd().Split('\n');

            //Generate text file
            ///*
            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToLower();
                probabilities[0][((int)currentWord.ElementAt(0)) - 97]++;

                for (int j = 1; j < words[i].Length - 1; j++)
                {
                    probabilities[((int)currentWord.ElementAt(j - 1)) - 96][((int)currentWord.ElementAt(j)) - 97]++;
                }
            }

            for (int i = 0; i < probabilities.Length; i++)
            {
                for (int j = 1; j < probabilities[i].Length; j++)
                {
                    probabilities[i][j] += probabilities[i][j - 1];
                }
                count = (int)probabilities[i][25];

                for (int j = 0; j < probabilities[i].Length; j++)
                {
                    probabilities[i][j] /= count;
                }
            }

            sr.Close();
            StreamWriter sw = new StreamWriter("EnglishProb.txt");

            for (int i = 0; i < probabilities.Length; i++)
            {
                for (int j = 0; j < probabilities[i].Length; j++)
                {
                    sw.Write(probabilities[i][j] + ";");
                }
                sw.WriteLine();

            }
            lblOutput.Text = "English Finished Writing";

            sw.Close();

            //German Words
            sr = new StreamReader("wordsgerman.txt");

            words = sr.ReadToEnd().Split('\n');

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToLower();
                probabilitiesGerman[0][convertToInt(currentWord.ElementAt(0), "german")]++;

                for (int j = 1; j < words[i].Length - 1; j++)
                {
                    probabilitiesGerman[convertToInt(currentWord.ElementAt(j - 1), "german") + 1][convertToInt(currentWord.ElementAt(j), "german")]++;
                }
            }

            for (int i = 0; i < probabilitiesGerman.Length; i++)
            {
                for (int j = 1; j < probabilitiesGerman[i].Length; j++)
                {
                    probabilitiesGerman[i][j] += probabilitiesGerman[i][j - 1];
                }
                count = (int)probabilitiesGerman[i][30];

                for (int j = 0; j < probabilitiesGerman[i].Length; j++)
                {
                    probabilitiesGerman[i][j] /= count;
                }
            }

            sr.Close();
            sw = new StreamWriter("GermanProb.txt");

            for (int i = 0; i < probabilitiesGerman.Length; i++)
            {
                for (int j = 0; j < probabilitiesGerman[i].Length; j++)
                {
                    sw.Write(probabilitiesGerman[i][j] + ";");
                }
                sw.WriteLine();

            }
            //lblOutput.Text = "German Finished Writing";
            //*/
            sw.Close();

            btnGenerateProb.Enabled = false;

            //Hawaiian Words
            sr = new StreamReader("hawaiianwords.txt");

            words = sr.ReadToEnd().Split('\n');

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToLower();
                probabilitiesHawaiian[0][convertToInt(currentWord.ElementAt(0), "hawaiian")]++;

                for (int j = 1; j < words[i].Length - 1; j++)
                {
                    probabilitiesHawaiian[convertToInt(currentWord.ElementAt(j - 1), "hawaiian") + 1][convertToInt(currentWord.ElementAt(j), "hawaiian")]++;
                }
            }

            for (int i = 0; i < probabilitiesHawaiian.Length; i++)
            {
                for (int j = 1; j < probabilitiesHawaiian[i].Length; j++)
                {
                    probabilitiesHawaiian[i][j] += probabilitiesHawaiian[i][j - 1];
                }
                count = (int)probabilitiesHawaiian[i][26];

                for (int j = 0; j < probabilitiesHawaiian[i].Length; j++)
                {
                    probabilitiesHawaiian[i][j] /= count;
                }
            }

            sr.Close();
            sw = new StreamWriter("HawaiianProb.txt");

            for (int i = 0; i < probabilitiesHawaiian.Length; i++)
            {
                for (int j = 0; j < probabilitiesHawaiian[i].Length; j++)
                {
                    sw.Write(probabilitiesHawaiian[i][j] + ";");
                }
                sw.WriteLine();

            }
            //lblOutput.Text = "German Finished Writing";
            //*/
            sw.Close();

            btnGenerateProb.Enabled = false;
        }

        private void btnHawaiian_Click(object sender, EventArgs e)
        {
            Random gen = new Random();
            string output = "";
            char prevChar = '`';
            bool hasVowel = false;

            while (true)
            {
                double letterKey = gen.NextDouble();
                for (int i = 0; i < probabilitiesHawaiian[0].Length; i++)
                {
                    if (letterKey <= probabilitiesHawaiian[convertToInt(prevChar, "hawaiian") + 1][i])
                    {
                        prevChar = convertToChar(i + 97, "hawaiian");
                        if (prevChar == 'a' || prevChar == 'e' || prevChar == 'i' || prevChar == 'o' || prevChar == 'u')
                            hasVowel = true;
                        break;
                    }
                }
                output += prevChar;
                if (gen.NextDouble() <= 0.225 && hasVowel)
                {
                    break;
                }
            }


            lblOutput.Text = output;
        }
    }
}
