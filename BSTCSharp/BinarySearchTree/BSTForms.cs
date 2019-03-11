using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Golovinov Timur
//26/02/2019
//This programm illustrates different manipulations with a binary tree using windows forms.
namespace BinarySearchTree
{
    public partial class BSTForms : Form
    {
        public BSTForms()
        {
            InitializeComponent();
        }
        //create int tree when form is called
        BinarySearchTree<int> intTree = new BinarySearchTree<int>();
        Random r = new Random(DateTime.Now.Millisecond);
        string trace = "";
        //Fill Array Button
        private void btnFillArray_Click(object sender, EventArgs e)
        {
            try
            {
                // Insert 10 random integers into the tree             
                for (int i = 0; i < 10; i++)
                {
                    int randomInt = r.Next(1, 500);
                    intTree.Insert(randomInt);
                    trace += randomInt + " ";
                }
                // The order in which the elements were added to the tree   
                listOutput.Items.Add("The Order in which the elements were added to the tree: ");
                listOutput.Items.Add(trace + " ");
                listOutput.Items.Add("A textual representation of the tree: ");
                listOutput.Items.Add(intTree.ToString());
            }
            catch
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Cannot insert new tree");
            }

        }
        //Button Insert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                intTree.Insert(int.Parse(txtInsert.Text));
                Display();
            }
            catch
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Cannot Insert into the tree");
            }

        }
        //Button Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                intTree.Remove(int.Parse(txtRemove.Text));
                Display();
            }
            catch
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Cannot Remove this item");
            }

        }
        //Button Find
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int f = intTree.Find(int.Parse(txtFind.Text));
                if (f != 0)
                {
                    txtFound.Text = "Found";
                }
                else
                {
                    txtFound.Text = "Not Found";
                }
            }
            catch
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Cannot find Anything");
            }
        }
        //Button Find Min
        private void btnFindMin_Click(object sender, EventArgs e)
        {
            try
            {
                txtFindMin.Text = intTree.FindMin().ToString();
            }
            catch
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Cannot Find Min");
            }

        }
        //Button Find Max
        private void btnFindMax_Click(object sender, EventArgs e)
        {
            try
            {
                txtFindMax.Text = intTree.FindMax().ToString();
            }
            catch
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Cannot Find Max");
            }
        }
        //Button Root
        private void btnRoot_Click(object sender, EventArgs e)
        {
            try
            {
                txtRoot.Text = intTree.Root.Element.ToString();
            }
            catch
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Cannot Find a Root");
                txtRoot.Text = "0";
            }
        }
        //Button Is empty
        private void btnIsEmpty_Click(object sender, EventArgs e)
        {
            bool a = intTree.IsEmpty();

            if (a == true)
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Binary Tree is empty");
            }
            else
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Binary Tree is not empty");
            }
        }
        //Button Make Empty
        private void btnMakeEmpty_Click(object sender, EventArgs e)
        {
            try
            {
                intTree.MakeEmpty();
                statusBar.Items.Clear();
                statusBar.Items.Add("Binary Tree is empty now");
            }
            catch
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Cannot make Empty");
            }

        }
        //Button Remove Min
        private void btnRemoveMin_Click(object sender, EventArgs e)
        {
            try
            {
                intTree.RemoveMin();
                statusBar.Items.Clear();
                statusBar.Items.Add("Smallest int has been removed");
                txtFindMin.Text = intTree.FindMin().ToString();
                Display();
            }
            catch
            {
                statusBar.Items.Clear();
                statusBar.Items.Add("Cannot Remove Min");
            }

        }
        //Display method
        public void Display()
        {
            listOutput.Items.Add(intTree.ToString());
        }
        //Button Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            listOutput.Items.Clear();
            statusBar.Items.Clear();
        }
    }
}
