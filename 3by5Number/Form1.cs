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


/// <summary>
/// 3by5
/// @2017 Knowblesse
/// </summary>

namespace _3by5Number
{
    public partial class Form1 : Form
    {
        // training tab
        int radioDigit = 0;
        int[][] trainingSet = new int[10][];
        int[] Current_Set = new int[15] { 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1 };

        // testing tab
        int[] Node_input = new int[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // input node
        int[] Node_output = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // output node

        double[,] weight = new double[10, 15 + 1];

        public Form1()
        {
            InitializeComponent();

            // show version
            version.Text = Application.ProductVersion;
            System.Version ver = new System.Version();

            //default trainingset List
            trainingSet[0] = new int[] { 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1 };
            trainingSet[1] = new int[] { 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 1, 1 };
            trainingSet[2] = new int[] { 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1 };
            trainingSet[3] = new int[] { 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1 };
            trainingSet[4] = new int[] { 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1 };
            trainingSet[5] = new int[] { 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1 };
            trainingSet[6] = new int[] { 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
            trainingSet[7] = new int[] { 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 };
            trainingSet[8] = new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1 };
            trainingSet[9] = new int[] { 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1 };

            reloadTraining(0);
        }

        private void b_Recognize_Click(object sender, EventArgs e)
        {
            // recog button clicked
            double[] Node_output = new double[10];

            // calc output node
            for (int nOut = 0; nOut < 10; nOut++)
            {
                double nodeSum = weight[nOut, 0]; // add the vias term 
                for (int nInp = 0; nInp < 15; nInp++)
                {
                    nodeSum += weight[nOut, nInp + 1] * Node_input[nInp];
                }
                Node_output[nOut] = 1.0 / (1.0 + Math.Pow(Math.E, -nodeSum));
            }

            // change the output value to relative percents
            double sumOutputNode = 0;
            foreach (double item in Node_output)
            {
                sumOutputNode += item;
            }

            for (int nOut = 0; nOut < 10; nOut++)
            {
                Node_output[nOut] *= 100 / sumOutputNode;
            }

            // UI Progress Bar
            progressBar1.Value = (int)Node_output[0];
            label12.Text = String.Concat(((int)Node_output[0]).ToString(), "%");
            progressBar2.Value = (int)Node_output[1];
            label13.Text = String.Concat(((int)Node_output[1]).ToString(), "%");
            progressBar3.Value = (int)Node_output[2];
            label14.Text = String.Concat(((int)Node_output[2]).ToString(), "%");
            progressBar4.Value = (int)Node_output[3];
            label15.Text = String.Concat(((int)Node_output[3]).ToString(), "%");
            progressBar5.Value = (int)Node_output[4];
            label16.Text = String.Concat(((int)Node_output[4]).ToString(), "%");
            progressBar6.Value = (int)Node_output[5];
            label17.Text = String.Concat(((int)Node_output[5]).ToString(), "%");
            progressBar7.Value = (int)Node_output[6];
            label18.Text = String.Concat(((int)Node_output[6]).ToString(), "%");
            progressBar8.Value = (int)Node_output[7];
            label19.Text = String.Concat(((int)Node_output[7]).ToString(), "%");
            progressBar9.Value = (int)Node_output[8];
            label20.Text = String.Concat(((int)Node_output[8]).ToString(), "%");
            progressBar10.Value = (int)Node_output[9];
            label21.Text = String.Concat(((int)Node_output[9]).ToString(), "%");

            // show recog. ouput
            double maxValue = Node_output.Max();
            int maxIndex = Node_output.ToList().IndexOf(maxValue);
            textBox1.Text = maxIndex.ToString();
        }

        private void reloadTraining(int digit)
        {
            // 귀찮아.. 버튼 색 바꿔줌.
            t1.BackColor = changeNum2Color(trainingSet[digit][0]);
            t2.BackColor = changeNum2Color(trainingSet[digit][1]);
            t3.BackColor = changeNum2Color(trainingSet[digit][2]);
            t4.BackColor = changeNum2Color(trainingSet[digit][3]);
            t5.BackColor = changeNum2Color(trainingSet[digit][4]);
            t6.BackColor = changeNum2Color(trainingSet[digit][5]);
            t7.BackColor = changeNum2Color(trainingSet[digit][6]);
            t8.BackColor = changeNum2Color(trainingSet[digit][7]);
            t9.BackColor = changeNum2Color(trainingSet[digit][8]);
            t10.BackColor = changeNum2Color(trainingSet[digit][9]);
            t11.BackColor = changeNum2Color(trainingSet[digit][10]);
            t12.BackColor = changeNum2Color(trainingSet[digit][11]);
            t13.BackColor = changeNum2Color(trainingSet[digit][12]);
            t14.BackColor = changeNum2Color(trainingSet[digit][13]);
            t15.BackColor = changeNum2Color(trainingSet[digit][14]);
        }

        private static Color changeNum2Color(int num)
        {
            if (num == 0)
            {
                return Color.White;
            }
            else
                return Color.Black;
        }

        private void trainingSetButtonClicked(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            String senderName = senderButton.Name.Remove(0, 1);
            int senderIndex = Int16.Parse(senderName); //starts from 1 and ends at 15
            
            // Change the color
            if (senderButton.BackColor == Color.White)
            {
                senderButton.BackColor = Color.Black;
            }
            else
            {
                senderButton.BackColor = Color.White;
            }

            // change the data
            trainingSet[radioDigit][senderIndex - 1] = -(trainingSet[radioDigit][senderIndex - 1]) + 1;
        }

        private void b_train_Click(object sender, EventArgs e)
        {
            int[] InputNode = new int[16];
            double[] OutputNode = new double[10];

            //start training
            for(int ep = 0; ep < (int)n_epoch.Value; ep++)
            {
                for(int num = 0; num<=9; num++)
                {
                    int[] DesiredOutput = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    double[] Error = new double[10];
                    DesiredOutput[num] = 1;
                    // load traning set
                    InputNode[0] = 1;
                    Array.Copy(trainingSet[num], 0, InputNode, 1, 15);

                    // array calc
                    for(int i = 0; i < 10; i++)
                    {
                        double temp = 0;
                        for(int j=0; j < 16; j++)
                        {
                            temp += weight[i, j] * InputNode[j];
                        }
                        OutputNode[i] = 1 / (1 + Math.Pow(Math.E, -temp));
                    }

                    // error calc
                    for (int i = 0; i < 10; i++)
                    {
                        Error[i] = DesiredOutput[i] - OutputNode[i];
                    }

                    // backprop
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            weight[i, j] = weight[i, j] + (double)n_alpha.Value * Error[i] * InputNode[j];
                        }
                    }
                    progressBar11.Value = (int)((10 * ep + num) / (n_epoch.Value * 10) * 100);
                }
            }
            MessageBox.Show("Complete!");
            
        }
    }
}
